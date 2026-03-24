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
| Email | MailKit — SMTP Gmail (porta 587) |
| Pagamentos | PagarMe (SDK customizado em `PetShopCRM.External`) |
| JSON | Newtonsoft.Json |
| Serialização | System.Text.Json (secundário) |

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

A classe `AppSettings` (em `Infrastructure.Settings`) faz bind de toda a seção de configuração via `builder.Services.Configure<AppSettings>(builder.Configuration)`.

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

**Entidades principais:**

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

**Enums principais (`src/PetShopCRM.Domain/Enums/`):**
- `UserType` — `Admin`, `General`, `Guardian`
- `LogType` — tipos de log
- `NotificationType` — tipos de notificação
- `ConfigurationKey`, `ConfigurationGroup`, `ConfigurationType` — configurações da app

---

## Acesso a Dados

### Padrão Repository + Unit of Work

```csharp
// Repositório genérico — métodos principais
Task<T?> GetByIdAsync(int id);
IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
Task<PaginateDTO<T>> GetPaginateByAsync(int page, int size, ...);
Task<bool> AddOrUpdateAsync(T entity);
Task<bool> DeleteOrRestoreAsync(int id);  // soft delete: altera Active

// Unit of Work — um save para todos os repos
await _unitOfWork.SaveChangesAsync();
```

- **Soft delete**: nunca use DELETE direto. Chame `DeleteOrRestoreAsync()` ou defina `entity.Active = false`.
- **EF Core config**: auto-descoberta de `IEntityTypeConfiguration<T>` pela assembly.
- **Paginação**: use `GetPaginateByAsync()` — não traga todos os registros em memória.

---

## Camada de Serviço (`src/PetShopCRM.Application/Services/`)

Cada conceito de domínio tem interface + implementação:

```
I{Name}Service  →  {Name}Service
```

Exemplos: `IUserService`, `IGuardianService`, `IPetService`, `IPaymentService`, `IEmailService`, etc.

**Padrão de retorno:**
```csharp
// Serviços retornam Response<T> com flag de sucesso
public class Response<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
```

Registro: `builder.Services.AddServices()` (via `Application.Bootstrapper`).

---

## Camada Web (`src/PetShopCRM.Web/`)

### Controllers

- Injeção de dependência via construtor
- Autorização por política: `[Authorize(Policy = nameof(UserType.Admin))]`
- As três políticas são: `Admin`, `General`, `Guardian`
  - `General` aceita também `Admin` (Admin > General)

### ViewModels (`Web/Models/`)

- ViewModels têm método `.ToDTO()` para converter para o DTO da camada Application
- Validações via Data Annotations; mensagens em `ValidationMessages.resx`

### Recursos / Localização (`Web/Resources/`)

| Arquivo | Conteúdo |
|---|---|
| `ValidationMessages.resx` | Mensagens de validação de formulários |
| `Text.resx` | Strings de UI |
| `Message.resx` | Mensagens da aplicação |
| `ConfigurationKeyDescription.resx` | Descrições das chaves de configuração |

### Serviços Web (`Web/Services/`)

| Serviço | Responsabilidade |
|---|---|
| `LoginService` | Autenticação via cookies ASP.NET Core |
| `LoggedUserService` | Extrai claims do usuário logado (Id, Name, Role, Image) |
| `NotificationService` | Gerencia notificações de usuário |
| `Upload` | Upload de arquivos (fotos de pets) |
| `AddressService` | Consulta/gestão de endereços |
| `WebContext` | Contexto web da requisição atual |

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

---

## Notificações em Tempo Real (SignalR)

- Hub: `NotificationHub` na rota `/Notification`
- Métodos server→client: `SendNotificationAll()`, `SendNotificationUser(userId)`, `JoinGroup(group)`
- Middleware de exceções: `LogExceptionMiddleware` — captura erros globais, loga via `ILogService` e redireciona para login

---

## Pagamentos (PagarMe)

Localização: `src/PetShopCRM.External/PagarMe/`

- SDK customizado com suporte a: cartão de crédito, boleto, PIX, transferência bancária, assinaturas recorrentes
- Interface: `IPagarMeService`
- Inclui tratamento de webhooks
- Registro: `builder.Services.AddExternalServices()` (via `External.Bootstrapper`)

---

## Convenções de Código

- **Namespaces**: `PetShopCRM.[Camada].[Feature]` (ex: `PetShopCRM.Application.Services`)
- **Interfaces**: prefixo `I` (ex: `IUserService`)
- **Métodos async**: sufixo `Async` (ex: `GetByIdAsync`)
- **Injeção de dependência**: sempre via construtor
- **Nullable**: `#nullable enable` — tratar possíveis nulos explicitamente
- **Commits**: mensagens em português (convenção do projeto)
- **Soft delete**: sempre usar `Active = false`, nunca remover registros do banco

---

## Arquivos e Diretórios Principais

| Path | Descrição |
|---|---|
| `src/PetShopCRM.Web/Program.cs` | Entry point, DI container, middleware pipeline |
| `src/PetShopCRM.Infrastructure/PetShopDbContext.cs` | EF Core DbContext |
| `src/PetShopCRM.Application/Bootstrapper.cs` | Registro dos serviços da Application |
| `src/PetShopCRM.Infrastructure/Bootstrapper.cs` | Registro dos repositórios |
| `src/PetShopCRM.External/Bootstrapper.cs` | Registro dos serviços externos |
| `src/PetShopCRM.Web/Controllers/` | Controllers MVC |
| `src/PetShopCRM.Web/Views/` | Razor Views (organizadas por controller) |
| `src/PetShopCRM.Web/Models/` | ViewModels |
| `src/PetShopCRM.Web/Services/` | Serviços específicos da camada Web |
| `src/PetShopCRM.Web/SignalHubs/` | Hubs SignalR |
| `src/PetShopCRM.Web/Middlewares/` | Middlewares customizados |
| `src/PetShopCRM.Web/Resources/` | Arquivos .resx de localização |
| `src/PetShopCRM.Domain/Models/` | Entidades de domínio |
| `src/PetShopCRM.Domain/Enums/` | Enumerações |
| `src/PetShopCRM.Application/Services/` | Serviços de negócio |
| `src/PetShopCRM.Application/DTOs/` | Data Transfer Objects |
| `src/PetShopCRM.Infrastructure/Data/Repository/` | Implementações de repositório |
| `src/PetShopCRM.External/PagarMe/` | SDK PagarMe |

---

## Testes

Não existem projetos de teste automatizado na solução. Testes são feitos manualmente via interface web. Ao adicionar testes, considere xUnit com o padrão Arrange/Act/Assert.

---

## Git e Branches

- Sem git hooks ou linting configurados
- Mensagens de commit em português
- Desenvolvimento em feature branches com merge para `main`
- Branch atual de desenvolvimento: verificar configuração do ambiente
