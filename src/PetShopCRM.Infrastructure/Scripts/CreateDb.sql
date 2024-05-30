CREATE DATABASE PetShopDb;
GO
USE PetShopDb
GO
CREATE TABLE Guardians (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    DateBirth NVARCHAR(20),
    CPF NVARCHAR(14),
    Phone NVARCHAR(20),
    Email NVARCHAR(255),
    Address NVARCHAR(255),
    Country NVARCHAR(5),
    State NVARCHAR(2),
    City NVARCHAR(255),
    CEP NVARCHAR(9),
    Neighborhood NVARCHAR(100),
    Unit NVARCHAR(100),
    Number NVARCHAR(100),
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL
);
GO
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    [Type] INT NOT NULL,
    Login NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255),
    Phone NVARCHAR(20),
    CPF NVARCHAR(14),
    UrlPhoto NVARCHAR(255),
    GuardianId INT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
    CONSTRAINT User_Guardians_GuardianId FOREIGN KEY (GuardianId) REFERENCES Guardians(Id)
);
CREATE TABLE Clinics (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone NVARCHAR(20),
    Responsible NVARCHAR(255),
    CNPJ NVARCHAR(20) NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL
);
GO
SET IDENTITY_INSERT [dbo].[Clinics] ON 
GO
INSERT [dbo].[Clinics] ([Id], [Name], [Address], [Phone], [Responsible], [CNPJ], [CreatedDate], [UpdatedDate], [Active]) VALUES (1, N'Gato.cão - Recanto das Emas', N'Av. Potiguar, Q 203, L 39, Loja 01, Recanto das Emas - DF', N'(61) 9 3543-4603', N'Jhonny', N'11.111.111/1111-11', CAST(N'2024-05-28T00:13:09.7143874' AS DateTime2), CAST(N'2024-05-28T00:13:09.7142563' AS DateTime2), 1)
GO
INSERT [dbo].[Clinics] ([Id], [Name], [Address], [Phone], [Responsible], [CNPJ], [CreatedDate], [UpdatedDate], [Active]) VALUES (2, N'Gato.cão - Luziânia', N'Rua Dr. João Teixeira, Q 71B, LT 04 - Centro Luziânia - GO', N'(61) 9 3601-1062', N'Jhony', N'11.111.111/1111-11', CAST(N'2024-05-28T00:14:45.6244135' AS DateTime2), CAST(N'2024-05-28T00:14:45.6244122' AS DateTime2), 1)
GO
INSERT [dbo].[Clinics] ([Id], [Name], [Address], [Phone], [Responsible], [CNPJ], [CreatedDate], [UpdatedDate], [Active]) VALUES (3, N'HomeVet - Sobradinho', N'Q 08, Cl 29, loja 06, Sobradinho - DF', N'(61) 9 3970-7744', N'Allexis', N'11.111.111/1111-11', CAST(N'2024-05-28T00:16:09.6757184' AS DateTime2), CAST(N'2024-05-28T00:16:09.6757166' AS DateTime2), 1)
GO
INSERT [dbo].[Clinics] ([Id], [Name], [Address], [Phone], [Responsible], [CNPJ], [CreatedDate], [UpdatedDate], [Active]) VALUES (4, N'Home Vet', N'Q 2, Conjunto H, Lote 21, Setor Residencial Leste, Planaltina - DF', N'(61) 9 3308-4981', N'Allexis', N'11.111.111/1111-11', CAST(N'2024-05-28T00:17:24.3958237' AS DateTime2), CAST(N'2024-05-28T00:17:24.3958216' AS DateTime2), 1)
GO
SET IDENTITY_INSERT [dbo].[Clinics] OFF
GO
GO
CREATE TABLE Species (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL
);
GO
INSERT Species VALUES('Cachorro',GETDATE(),null,1);
INSERT Species VALUES('Gato',GETDATE(),null,1);
GO
CREATE TABLE Pets (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    GuardianId INT NOT NULL,
    Identifier NVARCHAR(255) NULL,
    SpecieId INT NOT NULL,
    Sexy NVARCHAR(20),
    Color NVARCHAR(20),
    Weight NVARCHAR(20),
    Age NVARCHAR(20),
    Breed NVARCHAR(70),
    Obs NVARCHAR(2000),
    Spayed BIT NULL,
    UrlPhoto NVARCHAR(2000),
    ShowReportImgUpdate BIT default 0,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    UpdatedDateImg DATETIME2,
    Active BIT NOT NULL,
    CONSTRAINT Pets_Guardians_GuardianId FOREIGN KEY (GuardianId) REFERENCES Guardians(Id),
    CONSTRAINT Pets_Species_SpecieId FOREIGN KEY (SpecieId) REFERENCES Species(Id)
);
CREATE TABLE HealthPlans (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Value DECIMAL(18, 2) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL
);
GO
CREATE TABLE Payments (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ExternalId NVARCHAR(255),
    PetId INT NOT NULL,
    GuardianId INT NOT NULL,
    HealthPlanId INT NOT NULL,
    IsRecurrence BIT NOT NULL,
    Installment INT NOT NULL,
    FirstPayment DATETIME2,
    LastPayment DATETIME2,
    IsSuccess BIT NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
    CONSTRAINT Payments_Pets_PetId FOREIGN KEY (PetId) REFERENCES Pets(Id),
    CONSTRAINT Payments_Guardians_GuardianId FOREIGN KEY (GuardianId) REFERENCES Guardians(Id),
    CONSTRAINT Payments_HealthPlans_HealthPlanId FOREIGN KEY (HealthPlanId) REFERENCES HealthPlans(Id)
);
go
INSERT INTO Users VALUES ('Administrador', 0, 'admin', '123',NULL, NULL, NULL,NULL, NULL, GETDATE(), NULL, 1);
go
CREATE TABLE Configurations (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Key] VARCHAR(200) NOT NULL,
    [Value] VARCHAR(1000) NOT NULL,
    [Type] INT NOT NULL,
    [Group] INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
);
go
INSERT INTO Configurations VALUES ('PagarMeUser', 'sk_747d8ddf31334d94b19617f3e4f24b39', 1, 1, GETDATE(), NULL, 1)
INSERT INTO Configurations VALUES ('PagarMePassword', '', 1, 1, GETDATE(), NULL, 1)
INSERT INTO Configurations VALUES ('SystemName', 'Vet Card', 1, 0, GETDATE(), NULL, 1)
INSERT INTO Configurations VALUES ('PagarMeDashboardUrl', '', 1, 1, GETDATE(), NULL, 1)
INSERT INTO Configurations VALUES ('SmtpUser', 'meuvetcard@gmail.com', 1, 2, GETDATE(), NULL, 1)
INSERT INTO Configurations VALUES ('SmtpPassword', 'yihv dxah xnak tewf', 1, 2, GETDATE(), NULL, 1)
INSERT INTO Configurations VALUES ('SmtpSenderEmail', 'meuvetcard@gmail.com', 1, 2, GETDATE(), NULL, 1)
go
CREATE TABLE PaymentHistories (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    PaymentId INT NOT NULL,
    IsSuccess BIT NOT NULL,
    [Event] VARCHAR(200) NOT NULL,
    [Value] DECIMAL(18, 2) NOT NULL,
    ExternalId VARCHAR(200) NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
    CONSTRAINT PaymentHistories_Payments_PaymentId FOREIGN KEY (PaymentId) REFERENCES Payments(Id),
);
go
CREATE TABLE Logs (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Type] varchar(100) NOT NULL,
    [Message] varchar(2000),
    Exception varchar(2000),
    StackTrace varchar(8000),
    InnerException varchar(2000),
    InnerStackTrace varchar(8000),
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
);
GO
CREATE TABLE ProcedureGroups (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL
);
go
CREATE TABLE [Procedures] (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    ProcedureGroupId INT,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
    CONSTRAINT Procedures_ProcedureGroups_ProcedureGroupId FOREIGN KEY (ProcedureGroupId) REFERENCES ProcedureGroups(Id)
);
go
CREATE TABLE ProcedureHealthPlans (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Coparticipation DECIMAL(18, 2) NOT NULL,
    CoparticipationUnit VARCHAR(200) NOT NULL,
    AnnualLimit INT,
    Lack INT NOT NULL,
    HealthPlanId INT NOT NULL,
    ProcedureId INT NOT NULL,
    Observation VARCHAR(500),
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
    CONSTRAINT ProcedureHealthPlans_HealthPlan_HealthPlanId FOREIGN KEY (HealthPlanId) REFERENCES HealthPlans(Id),
    CONSTRAINT ProcedureHealthPlans_Procedures_ProcedureId FOREIGN KEY (ProcedureId) REFERENCES [Procedures](Id)
);
GO
CREATE TABLE Records (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Date  DATETIME2 NOT NULL,
    ProcedureHealthPlanId INT NOT NULL,
    PetId INT NOT NULL,
    ClinicId INT NOT NULL,
    ReasonConsultation VARCHAR(500) NULL,
    ClinicalHistory VARCHAR(500) NULL,
    PhysicalExam VARCHAR(500) NULL,
    Diagnosis VARCHAR(500) NULL,
    Prescription VARCHAR(500) NULL,
    Observation VARCHAR(500) NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
    CONSTRAINT Record_ProceduresHealthPlans_ProcedureHealthPlanId FOREIGN KEY (ProcedureHealthPlanId) REFERENCES ProcedureHealthPlans(Id),
    CONSTRAINT Record_Pets_PetId FOREIGN KEY (PetId) REFERENCES Pets(Id),
    CONSTRAINT Record_Clinics_ClinicId FOREIGN KEY (ClinicId) REFERENCES Clinics(Id)
);