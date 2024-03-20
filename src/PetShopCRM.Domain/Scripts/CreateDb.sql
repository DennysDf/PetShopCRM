CREATE DATABASE PetShopDb;
GO
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    [Type] NVARCHAR(50),
    Login NVARCHAR(50),
    [Password] NVARCHAR(255),
    Email NVARCHAR(255),
    Phone NVARCHAR(20),
    UrlPhoto NVARCHAR(255),
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME,
    Active BIT NOT NULL
);
CREATE TABLE Companies (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone NVARCHAR(20),
    Responsible NVARCHAR(255),
    CNPJ NVARCHAR(20),
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME,
    Active BIT NOT NULL
);

CREATE TABLE Species (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME,
    Active BIT NOT NULL
);
CREATE TABLE Guardians (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    DateBirth DATE,
    CPF NVARCHAR(14),
    Phone NVARCHAR(20),
    Address NVARCHAR(255),
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME,
    Active BIT NOT NULL
);
CREATE TABLE Pets (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    GuardianId INT,
    Identifier NVARCHAR(255),
    EspecieId INT,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME,
    Active BIT NOT NULL,
    FOREIGN KEY (GuardianId) REFERENCES Guardians(Id),
    FOREIGN KEY (EspecieId) REFERENCES Species(Id)
);
CREATE TABLE HealthPlans (
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Value DECIMAL(18, 2) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME,
    Active BIT NOT NULL
);