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
INSERT INTO HealthPlans VALUES ('VetCard - Green', 29.99, 'Plano Básico', GETDATE(), NULL, 1);
INSERT INTO HealthPlans VALUES ('VetCard - Gold', 89.99, 'Plano Básico', GETDATE(), NULL, 1);
INSERT INTO HealthPlans VALUES ('VetCard - Black', 199.90, 'Plano Básico', GETDATE(), NULL, 1);
GO
CREATE TABLE Payments (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ExternalId NVARCHAR(255) NOT NULL,
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