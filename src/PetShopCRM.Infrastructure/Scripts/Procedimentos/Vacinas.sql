--Vacinas

DECLARE @ProcedureGroups_Vacinas table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Vacinas
VALUES ('Vacinas', GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaPolivalente table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaPolivalente
VALUES ('Vacina polivalente', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaRaiva table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaRaiva
VALUES ('Vacina raiva', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaTriplice table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaTriplice
VALUES ('Vacina triplice / quadrupla', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaQuintupla table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaQuintupla
VALUES ('Vacina quintupla', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaGripePneumonia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaGripePneumonia
VALUES ('Vacina gripe/pneumonia', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)
