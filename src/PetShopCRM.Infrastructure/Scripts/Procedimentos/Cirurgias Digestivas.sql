-- Cirurgias Digestivas
DECLARE @ProcedureGroups_CirurgiasDigestivas table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasDigestivas
VALUES ('Cirurgias Digestivas', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Cirurgias Digestivas
DECLARE @Procedures_Enterectomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Enterectomia
VALUES ('Enterectomia', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_ProlapsoRetoReducao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ProlapsoRetoReducao
VALUES ('Prolapso de Reto - Redução', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_EsofagotomiaRetiradaCorpoEstranho table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_EsofagotomiaRetiradaCorpoEstranho
VALUES ('Esofagotomia para retirada de corpo estranho', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_GastrostomiaGastrotomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_GastrostomiaGastrotomia
VALUES ('Gastrostomia / Gastrotomia', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_Esplenectomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Esplenectomia
VALUES ('Esplenectomia', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_Sialoadenectomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Sialoadenectomia
VALUES ('Sialoadenectomia', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_GastrectomiaParcial table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_GastrectomiaParcial
VALUES ('Gastrectomia Parcial', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_Enterotomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Enterotomia
VALUES ('Enterotomia', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_Enteroanastomose table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Enteroanastomose
VALUES ('Enteroanastomose', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_Colonopexia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Colonopexia
VALUES ('Colonopexia', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_ProlapsoRetoAmputacao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ProlapsoRetoAmputacao
VALUES ('Prolapso de Reto - Amputação', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_TorcaoDilatacaoGastricaReducaoGastropexia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TorcaoDilatacaoGastricaReducaoGastropexia
VALUES ('Torção/Dilatação Gástrica - Redução e Gastropexia', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)

DECLARE @Procedures_TorcaoDilatacaoGastricaReducaoGastropexiaGastrectomiaParcialEsplenectomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TorcaoDilatacaoGastricaReducaoGastropexiaGastrectomiaParcialEsplenectomia
VALUES ('Torção/Dilatação Gástrica – Redução, Gastropexia, Gastrectomia Parcial e Esplenectomia', (SELECT ID FROM @ProcedureGroups_CirurgiasDigestivas), GETDATE(), NULL, 1)
