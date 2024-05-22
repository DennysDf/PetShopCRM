-- Cirurgias Ortopédicas
DECLARE @ProcedureGroups_CirurgiasOrtopedicas table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasOrtopedicas
VALUES ('Cirurgias Ortopédicas', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Cirurgias Ortopédicas
DECLARE @Procedures_AmputacaoFalange table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AmputacaoFalange
VALUES ('Amputação de falange', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

DECLARE @Procedures_AmputacaoMembros table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AmputacaoMembros
VALUES ('Amputação de membros', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

DECLARE @Procedures_RetiradaImplantesOrtopedicos table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RetiradaImplantesOrtopedicos
VALUES ('Retirada de implantes ortopédicos', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

DECLARE @Procedures_RetiradaFixadorExterno table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RetiradaFixadorExterno
VALUES ('Retirada de fixador externo', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

DECLARE @Procedures_Osteossintese table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Osteossintese
VALUES ('Osteossíntese', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)
