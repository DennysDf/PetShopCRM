-- Cirurgias Gerais
DECLARE @ProcedureGroups_CirurgiasGerais table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasGerais
VALUES ('Cirurgias Gerais', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Cirurgias Gerais
DECLARE @Procedures_BlocoCirurgico table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BlocoCirurgico
VALUES ('Bloco Cirúrgico', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_BiopsiaLinfonodoColeta table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BiopsiaLinfonodoColeta
VALUES ('Biópsia linfonodo - coleta', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_ResseccaoPregaCutaneaFacial table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ResseccaoPregaCutaneaFacial
VALUES ('Ressecção de Prega Cutânea Facial', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_BiopsiaTriadeFelinaColeta table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BiopsiaTriadeFelinaColeta
VALUES ('Biópsia tríade felina - coleta', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_NodulectomiaP table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_NodulectomiaP
VALUES ('Nodulectomia P', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_BiopsiaGastricaColeta table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BiopsiaGastricaColeta
VALUES ('Biópsia gástrica - Coleta', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_BiopsiaIntestinalColeta table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BiopsiaIntestinalColeta
VALUES ('Biópsia Intestinal - Coleta', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_BiopsiaOsseaColeta table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BiopsiaOsseaColeta
VALUES ('Biopsia ossea - coleta', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_RejeicaoSuturaMusculaturaPele table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RejeicaoSuturaMusculaturaPele
VALUES ('Rejeição sutura (musculatura e pele)', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_NodulectomiaM table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_NodulectomiaM
VALUES ('Nodulectomia M', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_Linfadenectomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Linfadenectomia
VALUES ('Linfadenectomia', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_LaparotomiaExploratoria table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LaparotomiaExploratoria
VALUES ('Laparotomia exploratória', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_Evisceracao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Evisceracao
VALUES ('Evisceração', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_AbalacaoGlandulaAdanal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AbalacaoGlandulaAdanal
VALUES ('Ablação glândula adanal', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_BiopsiaHepaticaColeta table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BiopsiaHepaticaColeta
VALUES ('Biópsia Hepática - coleta', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_TaxaAnaplastiaRetalho table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TaxaAnaplastiaRetalho
VALUES ('Taxa de Anaplastia (retalho)', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_NodulectomiaG table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_NodulectomiaG
VALUES ('Nodulectomia G', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_Eventracao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Eventracao
VALUES ('Eventração', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_AdicionalAnestesiaPlantao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AdicionalAnestesiaPlantao
VALUES ('Adicional anestesia plantão', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)

DECLARE @Procedures_AdicionalCirurgiaPlantao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AdicionalCirurgiaPlantao
VALUES ('Adicional de cirurgia plantão', (SELECT ID FROM @ProcedureGroups_CirurgiasGerais), GETDATE(), NULL, 1)
