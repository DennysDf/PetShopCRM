CREATE DATABASE PetShopDb;
GO
USE PetShopDb
GO
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    [Type] INT NOT NULL,
    Login NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255),
    Phone NVARCHAR(20),
    UrlPhoto NVARCHAR(255),
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL
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
CREATE TABLE Guardians (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    DateBirth NVARCHAR(20),
    CPF NVARCHAR(14),
    Phone NVARCHAR(20),
    Address NVARCHAR(255),
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL
);
CREATE TABLE Pets (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    GuardianId INT NOT NULL,
    Identifier NVARCHAR(255),
    SpecieId INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
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
CREATE TABLE Payments (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ExternalId NVARCHAR(255) NOT NULL,
    PetId INT NOT NULL,
    GuardianId INT NOT NULL,
    HealthPlanId INT NOT NULL,
    IsRecurrence BIT NOT NULL,
    Installments INT NOT NULL,
    LastPayment DATETIME2,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2,
    Active BIT NOT NULL,
    CONSTRAINT Payments_Pets_PetId FOREIGN KEY (PetId) REFERENCES Pets(Id),
    CONSTRAINT Payments_Guardians_GuardianId FOREIGN KEY (GuardianId) REFERENCES Guardians(Id),
    CONSTRAINT Payments_HealthPlans_HealthPlanId FOREIGN KEY (HealthPlanId) REFERENCES HealthPlans(Id)
);
INSERT INTO Users VALUES ('Administrador', 0, 'admin', '123', NULL, NULL, NULL, GETDATE(), NULL, 1)