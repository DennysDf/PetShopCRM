--Transfusão

DECLARE @ProcedureGroups_Transfusao table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Transfusao
VALUES ('Transfusão', GETDATE(), NULL, 1)

DECLARE @Procedures_TesteCompatibilidade table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TesteCompatibilidade
VALUES ('Teste de compatibilidade', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_TaxaTransfusaoSanguinea table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TaxaTransfusaoSanguinea
VALUES ('Taxa para transfusão sanguínea', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_BolsaPlasmaFrescoCongelado table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BolsaPlasmaFrescoCongelado
VALUES ('Bolsa plasma fresco congelado', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_BolsaConcentradoPlaquetas table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BolsaConcentradoPlaquetas
VALUES ('Bolsa concentrado de plaquetas', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_BolsaConcentradoHemacias table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BolsaConcentradoHemacias
VALUES ('Bolsa concentrado de hemácias', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_BolsaSangueTotal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BolsaSangueTotal
VALUES ('Bolsa sangue total', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)