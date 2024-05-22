-- Cirurgias Auriculares
DECLARE @ProcedureGroups_CirurgiasAuriculares table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasAuriculares
VALUES ('Cirurgias Auriculares', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Cirurgias Auriculares
DECLARE @Procedures_LavagemOtologica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LavagemOtologica
VALUES ('Lavagem otológica', (SELECT ID FROM @ProcedureGroups_CirurgiasAuriculares), GETDATE(), NULL, 1)

DECLARE @Procedures_ExcisaoPolipoOtologico table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ExcisaoPolipoOtologico
VALUES ('Excisão de Pólipo Otológico', (SELECT ID FROM @ProcedureGroups_CirurgiasAuriculares), GETDATE(), NULL, 1)

DECLARE @Procedures_ConchectomiaTerapeutica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ConchectomiaTerapeutica
VALUES ('Conchectomia terapêutica', (SELECT ID FROM @ProcedureGroups_CirurgiasAuriculares), GETDATE(), NULL, 1)

DECLARE @Procedures_OtohematomaTratamentoCirurgico table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_OtohematomaTratamentoCirurgico
VALUES ('Otohematoma - tratamento cirúrgico', (SELECT ID FROM @ProcedureGroups_CirurgiasAuriculares), GETDATE(), NULL, 1)
