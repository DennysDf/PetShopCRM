-- Serviços
DECLARE @ProcedureGroups_Servicos table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Servicos
VALUES ('Serviços', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Serviços
DECLARE @Procedures_Microchipagem table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Microchipagem
VALUES ('Microchipagem', (SELECT ID FROM @ProcedureGroups_Servicos), GETDATE(), NULL, 1)

DECLARE @Procedures_LocacaoSalaAtendimentoVolante table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LocacaoSalaAtendimentoVolante
VALUES ('Locação de Sala de Atendimento Volante', (SELECT ID FROM @ProcedureGroups_Servicos), GETDATE(), NULL, 1)