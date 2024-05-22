-- Cirurgias Oculares
DECLARE @ProcedureGroups_CirurgiasOculares table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasOculares
VALUES ('Cirurgias Oculares', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Cirurgias Oculares
DECLARE @Procedures_CorrecaoEntropioEctropioUnilateral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CorrecaoEntropioEctropioUnilateral
VALUES ('Correção de entrópio ou ectrópio unilateral', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_EnucleacaoRetiradaGloboOcular table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_EnucleacaoRetiradaGloboOcular
VALUES ('Enucleação (retirada do globo ocular)', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_ReducaoProtrusaoGloboOcular table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ReducaoProtrusaoGloboOcular
VALUES ('Redução Protrusão Globo Ocular', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_ExcisaoGlandulaTerceiraPalpebra table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ExcisaoGlandulaTerceiraPalpebra
VALUES ('Excisão da glândula de terceira pálpebra', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_ReposicaoGlandulaTerceiraPalpebra table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ReposicaoGlandulaTerceiraPalpebra
VALUES ('Reposição da glândula de terceira pálpebra', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_ExcisaoNeoplasiaPalpebralReconstrucao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ExcisaoNeoplasiaPalpebralReconstrucao
VALUES ('Excisão de Neoplasia Palpebral com Reconstrução', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_Tarsorrafia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Tarsorrafia
VALUES ('Tarsorrafia', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_EversaoCartilagemTerceiraPalpebra table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_EversaoCartilagemTerceiraPalpebra
VALUES ('Eversão da Cartilagem da Terceira Pálpebra', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_CorrecaoUlceraCornea table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CorrecaoUlceraCornea
VALUES ('Correção para Úlcera de Córnea', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)

DECLARE @Procedures_CorrecaoTriquiaseDistiquiaseCiliosEctopicos table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CorrecaoTriquiaseDistiquiaseCiliosEctopicos
VALUES ('Correção de Triquíase, Distiquíase e/ou Cílios ectópicos', (SELECT ID FROM @ProcedureGroups_CirurgiasOculares), GETDATE(), NULL, 1)
