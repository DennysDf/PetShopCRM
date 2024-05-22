--Medicamentos

DECLARE @ProcedureGroups_Medicamentos table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Medicamentos
VALUES ('Medicamentos', GETDATE(), NULL, 1)

DECLARE @Procedures_AplicacaoMedicacoesInjetaveisIMSC table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AplicacaoMedicacoesInjetaveisIMSC
VALUES ('Aplicação de medicações injetáveis IM/SC', (SELECT ID FROM @ProcedureGroups_Medicamentos), GETDATE(), NULL, 1)

DECLARE @Procedures_ColetaMaterialExames table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ColetaMaterialExames
VALUES ('Coleta de material para exames', (SELECT ID FROM @ProcedureGroups_Medicamentos), GETDATE(), NULL, 1)

DECLARE @Procedures_AplicacaoVacina table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AplicacaoVacina
VALUES ('Aplicação de vacina', (SELECT ID FROM @ProcedureGroups_Medicamentos), GETDATE(), NULL, 1)
