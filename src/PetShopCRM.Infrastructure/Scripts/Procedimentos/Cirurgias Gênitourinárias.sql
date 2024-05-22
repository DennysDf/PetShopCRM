-- Cirurgias Gênitourinárias
DECLARE @ProcedureGroups_CirurgiasGenitourinarias table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasGenitourinarias
VALUES ('Cirurgias Gênitourinárias', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Cirurgias Gênitourinárias
DECLARE @Procedures_AblacaoBolsaEscrotal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AblacaoBolsaEscrotal
VALUES ('Ablação da Bolsa Escrotal', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_ProlapsoUretra table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ProlapsoUretra
VALUES ('Prolapso de Uretra', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_CastracaoMacho table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CastracaoMacho
VALUES ('Castração macho', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_Cistotomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Cistotomia
VALUES ('Cistotomia (cirurgia de bexiga)', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_PolipoVaginal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_PolipoVaginal
VALUES ('Pólipo vaginal', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_OvarioRemanescente table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_OvarioRemanescente
VALUES ('Ovário Remanescente', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_Cistorrafia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Cistorrafia
VALUES ('Cistorrafia', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_Ureterostomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Ureterostomia
VALUES ('Ureterostomia', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_PiometraCotoUterino table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_PiometraCotoUterino
VALUES ('Piometra de coto uterino', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_CastracaoFemea table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CastracaoFemea
VALUES ('Castração fêmea', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_Uretrostomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Uretrostomia
VALUES ('Uretrostomia (cirurgia de uretra)', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_OvariohisterectomiaTerapêutica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_OvariohisterectomiaTerapêutica
VALUES ('Ovariohisterectomia Terapêutica (piometra)', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_ProlapsoUteroReducaoCirurgica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ProlapsoUteroReducaoCirurgica
VALUES ('Prolapso de Útero - Redução Cirúrgica', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_UreterostomiaBilateral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_UreterostomiaBilateral
VALUES ('Ureterostomia Bilateral', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_Penectomia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Penectomia
VALUES ('Penectomia (retirada do pênis)', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_MastectomiaTotal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_MastectomiaTotal
VALUES ('Mastectomia total (neoplasia mamária - câncer de mama)', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_NeoplasiaMamariaCadeiaBilateral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_NeoplasiaMamariaCadeiaBilateral
VALUES ('Neoplasia mamária cadeia bilateral (câncer de mama)', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)

DECLARE @Procedures_CastracaoCriptorquida table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CastracaoCriptorquida
VALUES ('Castração Criptorquida', (SELECT ID FROM @ProcedureGroups_CirurgiasGenitourinarias), GETDATE(), NULL, 1)
