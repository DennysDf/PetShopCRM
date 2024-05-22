--Internação

DECLARE @ProcedureGroups_Internacao table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Internacao
VALUES ('Internação', GETDATE(), NULL, 1)

DECLARE @Procedures_DayCareAte12h table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_DayCareAte12h
VALUES ('Day Care Até 12h', (SELECT ID FROM @ProcedureGroups_Internacao), GETDATE(), NULL, 1)

DECLARE @Procedures_Internacao24Horas table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Internacao24Horas
VALUES ('Internação 24 Horas', (SELECT ID FROM @ProcedureGroups_Internacao), GETDATE(), NULL, 1)

DECLARE @Procedures_InternacaoSemiIntensiva table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_InternacaoSemiIntensiva
VALUES ('Internação Semi-Intensiva', (SELECT ID FROM @ProcedureGroups_Internacao), GETDATE(), NULL, 1)