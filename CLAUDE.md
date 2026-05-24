# CLAUDE.md — PetShopCRM

Guia de referência rápida para assistentes de IA trabalhando neste repositório.

---

## Visão Geral

**PetShopCRM** é um sistema de gestão para clínicas veterinárias / pet shops, desenvolvido em ASP.NET Core 8 MVC. Gerencia tutores (guardiões), pets, planos de saúde, procedimentos, pagamentos e prontuários médicos. Domínio voltado ao mercado brasileiro (pagamentos via PagarMe, strings em português).

- Licença: MIT (2024, Kevyn Carlos)
- Linguagem principal: C#
- Framework: .NET 8.0

---

## Arquitetura

Clean Architecture em 5 projetos dentro de `src/`, mais um app cliente legado:

```
PetShopCRM/
├── src/
│   ├── PetShopCRM.Domain/          # Entidades, enums, EntityBase
│   ├── PetShopCRM.Application/     # Serviços, DTOs, helpers, email
│   ├── PetShopCRM.Infrastructure/  # EF Core DbContext, repositórios, UoW
│   ├── PetShopCRM.External/        # SDK PagarMe (pagamentos)
│   └── PetShopCRM.Web/             # Controllers MVC, Razor Views, SignalR
├── WebAppCliente/                  # App cliente MVC legado (consome a API Web)
└── PetShopCRM.sln
```

**Direção de dependência:**
`Web` → `Application` → `Domain`
`Infrastructure` → `Domain`
`External` → `Application`

---

## Stack Tecnológica

| Componente | Tecnologia |
|---|---|
| Runtime | .NET 8.0 / C# (nullable enabled, implicit usings) |
| Web | ASP.NET Core MVC + Razor Views |
| ORM | Entity Framework Core 8 (SQL Server, code-first) |
| Banco | Microsoft SQL Server |
| Tempo real | SignalR (`NotificationHub`) |
| Email | MailKit v4.6.0 — SMTP Gmail (porta 587) |
| Pagamentos | PagarMe (SDK customizado em `PetShopCRM.External`) |
| HTTP Client | Microsoft.Extensions.Http v9.0.2 (WebAppCliente) |

---

## Build e Execução

```bash
# Build completo da solução
dotnet build PetShopCRM.sln

# Executar o app web
dotnet run --project src/PetShopCRM.Web

# Restore de pacotes NuGet
dotnet restore PetShopCRM.sln
```

**Requisitos:**
- SQL Server acessível com a connection string `ConnectionStrings:PetShopDb`
- Configurar `src/PetShopCRM.Web/appsettings.Development.json` para desenvolvimento local

Não há Docker, Makefile, scripts npm ou pipelines de CI/CD.

---

## Configuração

| Arquivo | Uso |
|---|---|
| `src/PetShopCRM.Web/appsettings.json` | Produção (SQL Server em site4now.net, Gmail SMTP) |
| `src/PetShopCRM.Web/appsettings.Development.json` | Overrides locais (connection string local) |

A classe `AppSettings` (em `PetShopCRM.Infrastructure.Settings`) faz bind de toda a configuração via `builder.Services.Configure<AppSettings>(builder.Configuration)`.

Não existem arquivos `.env`. Toda configuração vai nos `appsettings` files.

**Chaves obrigatórias:**
```json
{
  "ConnectionStrings": {
    "PetShopDb": "<sql-server-connection-string>"
  },
  "Smtp": {
    "Host": "smtp.gmail.com",
    "Port": 587
  }
}
```

---

## Modelos de Domínio (`src/PetShopCRM.Domain/Models/`)

Todos herdam de `EntityBase`:

```csharp
public class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Active { get; set; }  // soft delete flag
}
```

**Entidades principais (15):**

| Entidade | Descrição |
|---|---|
| `User` | Usuários do sistema (Admin, General, Guardian) |
| `Guardian` | Tutores/donos de pets (com endereço e contato) |
| `Pet` | Pets vinculados a um Guardian |
| `Specie` | Espécies dos pets |
| `HealthPlan` | Planos de saúde/serviço com preços |
| `Procedure` | Procedimentos veterinários |
| `ProcedureGroup` | Agrupamento de procedimentos |
| `ProcedureHealthPlan` | Tabela de junção Procedimento ↔ Plano |
| `Payment` | Registros de pagamento (recorrente/parcelado) |
| `PaymentHistory` | Histórico de transações de pagamento |
| `Record` | Prontuários médicos |
| `Clinic` | Informações da clínica |
| `Configuration` | Configurações da aplicação (chave-valor) |
| `Log` | Log de erros e eventos do sistema |

**Enums (`src/PetShopCRM.Domain/Enums/`):**

| Enum | Valores |
|---|---|
| `UserType` | `Admin`, `General`, `Guardian` |
| `LogType` | tipos de log do sistema |
| `NotificationType` | tipos de notificação |
| `ConfigurationKey` | chaves de configuração da app |
| `ConfigurationGroup` | agrupamentos de configuração |
| `ConfigurationType` | tipos de configuração |
| `ProcedureCoparticipationUnit` | unidades de coparticipação de procedimentos |

---

## Acesso a Dados

### Padrão Repository + Unit of Work

O `UnitOfWork` expõe repositórios com lazy initialization via `??=`. Há 14 repositórios, um por entidade.

```csharp
// IRepositoryBase<T> — métodos disponíveis
Task<T?> GetByIdAsync(int id);
IQueryable<T> GetBy(Expression<Func<T, bool>>? filter = null);
Task<int> GetTotalByAsync(Expression<Func<T, bool>>? filter = null);
Task<IQueryable<T>> GetPaginateByAsync(Expression<Func<T, bool>>? filter = null, int pageIndex = 0, int pageSize = 10);
Task<T> AddOrUpdateAsync(T entity);                   // Id == 0 → insert; Id != 0 → update
Task<List<T>> AddOrUpdateRangeAsync(List<T> entities);
Task<bool> DeleteOrRestoreAsync(int id);              // toggle Active (soft delete)
Task<bool> DeletePermanentAsync(int id);              // remoção física — usar com cautela

// Unit of Work — persiste todas as mudanças pendentes
await _unitOfWork.SaveChangesAsync();
```

**Regras de acesso a dados:**
- **Soft delete**: use `DeleteOrRestoreAsync()` que alterna `Active`. Nunca DELETE direto sem motivo explícito.
- **`DeletePermanentAsync`** existe mas deve ser usado apenas quando a remoção física for requisito de negócio.
- **`GetBy`** retorna `IQueryable` com `AsNoTracking()` — sempre materializar com `.ToList()` / `.FirstOrDefault()` antes de retornar da camada de serviço.
- **Paginação**: use `GetPaginateByAsync(filter, pageIndex, pageSize)` — não traga todos os registros em memória.
- **EF Core config**: auto-descoberta de `IEntityTypeConfiguration<T>` pela assembly via `PetShopDbContext`.
- **`AddOrUpdateAsync`**: seta `UpdatedDate = DateTime.Now` sempre. No insert, seta também `Active = true` e `CreatedDate`.

---

## Camada de Serviço (`src/PetShopCRM.Application/Services/`)

Cada conceito de domínio tem interface + implementação:

```
I{Name}Service  →  {Name}Service
```

**Serviços registrados (15) em `Application.Bootstrapper.AddServices()`:**

| Interface | Responsabilidade |
|---|---|
| `IUserService` | CRUD de usuários, autenticação |
| `IGuardianService` | CRUD de tutores |
| `IClinicService` | Dados da clínica |
| `IPetService` | CRUD de pets |
| `ISpecieService` | CRUD de espécies |
| `IHealthPlanService` | Planos de saúde |
| `IPaymentService` | Pagamentos e assinaturas |
| `IPaymentHistoryService` | Histórico de transações |
| `IConfigurationService` | Configurações da aplicação |
| `ILogService` | Registro de logs e erros |
| `IProcedureService` | Procedimentos veterinários |
| `IProcedureGroupService` | Grupos de procedimentos |
| `IProcedureHealthPlanService` | Relação procedimento ↔ plano |
| `IRecordService` | Prontuários médicos |
| `IEmailService` | Envio de e-mail via MailKit |

**Padrão de retorno:**
```csharp
// ResponseDTO é um record imutável
public record ResponseDTO<T>(bool Success, string Message, T Data);
```

---

## Camada Web (`src/PetShopCRM.Web/`)

### Controllers (14)

| Controller | Responsabilidade |
|---|---|
| `HomeController` | Dashboard principal (índice e visão guardian) |
| `UserController` | Login, logout, perfil, gestão de usuários |
| `GuardianController` | CRUD de tutores |
| `PetController` | CRUD de pets |
| `SpecieController` | CRUD de espécies |
| `HealthPlansController` | Planos de saúde e detalhes |
| `ProcedureController` | Procedimentos, grupos e relação com planos |
| `PaymentController` | Checkout, monitoramento e histórico de pagamentos |
| `RecordController` | Prontuários médicos |
| `ClinicController` | Dados e configuração da clínica |
| `ConfigurationController` | Configurações da aplicação |
| `DetailsController` | Views Ajax de detalhes (guardians, pets, pagamentos, planos, prontuários) |
| `ReportController` | Relatórios e upload de imagem de perfil |
| `ValidationController` | Endpoints de validação client-side |

**Convenções de controllers:**
- Injeção de dependência via construtor
- Autorização por política: `[Authorize(Policy = nameof(UserType.Admin))]`
- Três políticas: `Admin` (somente Admin), `General` (Admin ou General), `Guardian` (somente Guardian)
- Actions Ajax retornam `JsonResult` ou `PartialViewResult`

### ViewModels (`Web/Models/`)

- ViewModels têm método `.ToDTO()` para converter para o DTO da camada Application
- Validações via Data Annotations; mensagens em `ValidationMessages.resx`
- Estrutura de pastas espelha os controllers

**ViewModels existentes:**

| ViewModel | Localização |
|---|---|
| `ClinicVM` | `Models/Clinic/` |
| `ConfigurationVM` | `Models/Configuration/` |
| `DetailsPetVM` | `Models/Details/` |
| `AddressModel` | `Models/Endereco/` |
| `GuardianVM` | `Models/Guardian/` |
| `HealthPlansVM` | `Models/HealthPlans/` |
| `PaymentVM`, `PaymentHistoryVM` | `Models/Payment/` |
| `PetVM` | `Models/Pet/` |
| `ProcedureVM`, `ProcedureGroupVM`, `ProcedureHealthPlanVM` | `Models/Procedure/` |
| `RecordVM` | `Models/Record/` |
| `SpecieVM` | `Models/Specie/` |
| `AddUserVM`, `ProfileVM`, `UserGuardianVM`, `UserLoginVM` | `Models/User/` |
| `ResponseVM` | `Models/` (raiz) |

### Atributos de Validação Customizados (`Web/Util/ValidationAttribute.cs`)

| Atributo | Comportamento |
|---|---|
| `[RequiredIf(propertyName)]` | Campo obrigatório condicionalmente com base em uma propriedade booleana |
| `[RequiredIfInput(propertyName, desiredValue)]` | Campo obrigatório se outra propriedade tiver valor específico |

Ambos implementam `IClientModelValidator` para validação client-side via data-attributes.

### Recursos / Localização (`Web/Resources/`)

| Arquivo | Conteúdo |
|---|---|
| `ValidationMessages.resx` | Mensagens de validação de formulários |
| `Text.resx` | Strings de UI |
| `Message.resx` | Mensagens da aplicação |
| `ConfigurationKeyDescription.resx` | Descrições das chaves de configuração |

### Serviços Web (`Web/Services/`)

| Serviço | Interface | Responsabilidade |
|---|---|---|
| `LoginService` | `ILoginService` | Autenticação via cookies ASP.NET Core |
| `LoggedUserService` | `ILoggedUserService` | Extrai claims do usuário logado |
| `NotificationService` | `INotificationService` | Gerencia notificações de usuário |
| `Upload` | `IUpload` | Upload de arquivos (fotos de pets) |
| `AddressService` | `IAddressService` | Consulta/gestão de endereços |
| `WebContext` | `IWebContext` | Contexto web da requisição atual |

### Utilitários (`Web/Util/`)

| Utilitário | Função |
|---|---|
| `CPFUltil.cs` | Formatação e validação de CPF |
| `DateToBrazil.cs` | Formatação de datas para o padrão brasileiro |
| `EmailMaskerUltil.cs` | Mascaramento de endereços de e-mail |
| `EnumUtil.cs` | Helpers para enumerações |
| `FormFileExtensions.cs` | Extensões para `IFormFile` |
| `NotificationUtil.cs` | Helpers para notificações |
| `ParseDecimal.cs` | Conversão segura para decimal |
| `ParseInt.cs` | Conversão segura para int |
| `ValidationAttribute.cs` | Atributos de validação customizados |
| `ValidationKeysUtil.cs` | Chaves de validação |

### Reports (`Web/Reports/`)

Classes utilitárias que calculam métricas comparativas (mês atual vs. mês anterior) para o dashboard:

| Classe | Métricas |
|---|---|
| `GuardiansReport` | Quantidade de tutores, percentual, seta de tendência |
| `PetsReport` | Quantidade de pets e tendência |
| `RevenueReport` | Receita e variação percentual |
| `SalesReport` | Vendas e variação percentual |

---

## Autenticação e Autorização

- **Tipo**: Cookie-based (`CookieAuthenticationDefaults.AuthenticationScheme`)
- **Expiração**: 60 minutos
- **Rotas**: Login → `/User/Login`, Logout → `/User/Logout`, Acesso negado → `/User/Denied`
- **Claims armazenadas**: Id, Name, Role, Image

```csharp
// Verificar usuário logado
_loggedUserService.Id
_loggedUserService.Name
_loggedUserService.Role  // UserType enum
_loggedUserService.Image
```

**Políticas de autorização:**
```csharp
.AddPolicy("Admin",    x => x.RequireRole("Admin"))
.AddPolicy("General",  x => x.RequireRole("Admin", "General"))  // Admin também acessa
.AddPolicy("Guardian", x => x.RequireRole("Guardian"))
```

---

## Notificações em Tempo Real (SignalR)

- Hub: `NotificationHub` na rota `/Notification`
- `EnableDetailedErrors = true` em todos os ambientes
- Métodos server→client: `SendNotificationAll()`, `SendNotificationUser(userId)`, `JoinGroup(group)`

---

## Middleware

### `LogExceptionMiddleware` (`Web/Middlewares/`)

Registrado via `app.UseLogException()`. Captura exceções globais, registra via `ILogService` e redireciona para a página de login. Deve ser posicionado **após** `UseAuthentication()` e **antes** de `UseRouting()`.

**Ordem do pipeline em `Program.cs`:**
1. `UseAuthentication()`
2. `UseExceptionHandler` (somente produção)
3. `UseHsts` (somente produção)
4. `UseCors` (AllowAnyOrigin)
5. `UseHttpsRedirection()`
6. `UseStaticFiles()`
7. `UseLogException()` (middleware customizado)
8. `UseRouting()`
9. `UseAuthorization()`
10. `MapHub<NotificationHub>("/Notification")`
11. `MapControllerRoute` (default)

---

## Pagamentos (PagarMe)

Localização: `src/PetShopCRM.External/PagarMe/`

- SDK customizado com suporte a: cartão de crédito, boleto, PIX, transferência bancária, assinaturas recorrentes
- Interface principal: `IPagarMeService`
- Modelos de integração: `CustomerDTO`, `CardDTO`, `BillingAddressDTO`, `WebhookDTO`, `CardBrand`
- Controllers SDK: `ChargesController`, `TransactionsController`, `RecipientsController`, `CustomersController`, `TokensController`, `PlansController`, `OrdersController`, `TransfersController`
- Inclui tratamento de webhooks
- Registro: `builder.Services.AddExternalServices()` (via `External.Bootstrapper`)

---

## WebAppCliente (`WebAppCliente/`)

App cliente MVC legado que consome a API do PetShopCRM via HTTP.

| Componente | Descrição |
|---|---|
| `ClienteController` | CRUD de clientes (listar, criar, editar, detalhes, deletar) |
| `HomeController` | Login e home |
| `ClienteService` | Chamadas HTTP para a API de guardians/clientes |
| `Autenticacao` | Serviço de autenticação JWT com a API |
| `ClienteViewModel` | ViewModel de cliente |
| `TokenViewModel` | Token de autenticação |
| `UsuarioViewModel` | Dados do usuário para login |

Dependência: `Microsoft.Extensions.Http v9.0.2`.

---

## Infraestrutura (`src/PetShopCRM.Infrastructure/`)

### DbContext (`PetShopDbContext.cs`)

14 `DbSet<T>` registrados: `Users`, `Guardians`, `Pets`, `Clinics`, `Species`, `HealthPlans`, `Payments`, `Configurations`, `PaymentHistories`, `Logs`, `Procedures`, `ProcedureGroups`, `ProcedureHealthPlans`, `Records`.

### Mappers (`Infrastructure/Mappers/`)

13 mappers de configuração EF Core (um por entidade), descobertos automaticamente pela assembly.

### Scripts de Banco (`Infrastructure/Scripts/`)

- `CreateDb.sql` — script de criação do banco
- `Procedimentos/` — scripts de seed de procedimentos

### Bootstrapper

> **Atenção:** O arquivo tem typo no nome: `Boostrapper.cs` (sem 't') mas o método é `AddRepositories()`. Registra somente `IUnitOfWork → UnitOfWork` como Scoped.

---

## Convenções de Código

- **Namespaces**: `PetShopCRM.[Camada].[Feature]` (ex: `PetShopCRM.Application.Services`)
- **Interfaces**: prefixo `I` (ex: `IUserService`)
- **Métodos async**: sufixo `Async` (ex: `GetByIdAsync`)
- **Injeção de dependência**: sempre via construtor
- **Nullable**: `#nullable enable` — tratar possíveis nulos explicitamente
- **Commits**: mensagens em português (convenção do projeto)
- **Soft delete**: sempre usar `DeleteOrRestoreAsync()` ou `Active = false`, nunca remover registros sem necessidade
- **ResponseDTO**: é um `record` imutável — não tente criar instâncias com setters
- **ViewModels**: sempre implementar `.ToDTO()` para conversão para a camada Application
- **Recursos (.resx)**: usar os arquivos existentes para novas strings; não hardcodar mensagens em português no código

---

## Arquivos e Diretórios Principais

| Path | Descrição |
|---|---|
| `src/PetShopCRM.Web/Program.cs` | Entry point, DI container, middleware pipeline |
| `src/PetShopCRM.Infrastructure/PetShopDbContext.cs` | EF Core DbContext com 14 DbSets |
| `src/PetShopCRM.Application/Bootstrapper.cs` | Registro dos 15 serviços da Application |
| `src/PetShopCRM.Infrastructure/Boostrapper.cs` | Registro do UnitOfWork (typo no nome) |
| `src/PetShopCRM.External/Bootstrapper.cs` | Registro do PagarMeService |
| `src/PetShopCRM.Web/Controllers/` | 14 controllers MVC |
| `src/PetShopCRM.Web/Views/` | Razor Views (46 arquivos .cshtml) |
| `src/PetShopCRM.Web/Models/` | 19 ViewModels |
| `src/PetShopCRM.Web/Services/` | 6 serviços específicos da camada Web |
| `src/PetShopCRM.Web/SignalHubs/NotificationHub.cs` | Hub SignalR |
| `src/PetShopCRM.Web/Middlewares/LogExceptionMiddleware.cs` | Middleware de exceções |
| `src/PetShopCRM.Web/Resources/` | 4 arquivos .resx de localização |
| `src/PetShopCRM.Web/Reports/` | 4 classes de relatório para dashboard |
| `src/PetShopCRM.Web/Util/` | 10 utilitários da camada Web |
| `src/PetShopCRM.Domain/Models/` | 15 entidades de domínio |
| `src/PetShopCRM.Domain/Enums/` | 7 enumerações |
| `src/PetShopCRM.Application/Services/` | 15 serviços de negócio |
| `src/PetShopCRM.Application/DTOs/` | DTOs (ResponseDTO, ClinicDTO, GuardianDTO, etc.) |
| `src/PetShopCRM.Infrastructure/Data/Repository/` | RepositoryBase + 14 repositórios específicos |
| `src/PetShopCRM.Infrastructure/Data/UnitOfWork/` | UnitOfWork com lazy init de repos |
| `src/PetShopCRM.Infrastructure/Mappers/` | 13 mappers de configuração EF Core |
| `src/PetShopCRM.Infrastructure/Settings/AppSettings.cs` | Classe de configuração da aplicação |
| `src/PetShopCRM.External/PagarMe/` | SDK PagarMe customizado |

---

## Testes

Não existem projetos de teste automatizado na solução. Testes são feitos manualmente via interface web. Ao adicionar testes, considere xUnit com o padrão Arrange/Act/Assert.

---

## Git e Branches

- Sem git hooks ou linting configurados
- Mensagens de commit em português
- Desenvolvimento em feature branches com merge para `main`
- Branch atual de desenvolvimento: verificar configuração do ambiente
