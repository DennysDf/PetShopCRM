--Exames Cardiológicos

DECLARE @ProcedureGroups_ExamesCardiologicos table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_ExamesCardiologicos
VALUES ('Exames Cardiológicos', GETDATE(), NULL, 1)

DECLARE @Procedures_AfericaoPressaoArterial table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AfericaoPressaoArterial
VALUES ('Aferição de pressão arterial', (SELECT ID FROM @ProcedureGroups_ExamesCardiologicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Eletrocardiograma table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Eletrocardiograma
VALUES ('Eletrocardiograma', (SELECT ID FROM @ProcedureGroups_ExamesCardiologicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Ecodopplercardiograma table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Ecodopplercardiograma
VALUES ('Ecodopplercardiograma', (SELECT ID FROM @ProcedureGroups_ExamesCardiologicos), GETDATE(), NULL, 1)