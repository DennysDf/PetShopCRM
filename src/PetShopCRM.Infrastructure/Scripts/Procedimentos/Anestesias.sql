--Anestesias

DECLARE @ProcedureGroups_Anestesias table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Anestesias
VALUES ('Anestesias', GETDATE(), NULL, 1)

DECLARE @Procedures_AnestesiaLocal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AnestesiaLocal
VALUES ('Anestesia local', (SELECT ID FROM @ProcedureGroups_Anestesias), GETDATE(), NULL, 1)

DECLARE @Procedures_AnestesiaGeralAmbulatorialIntravenosa table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AnestesiaGeralAmbulatorialIntravenosa
VALUES ('Anestesia geral ambulatorial (intravenosa)', (SELECT ID FROM @ProcedureGroups_Anestesias), GETDATE(), NULL, 1)

DECLARE @Procedures_BloqueiosRegionais table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BloqueiosRegionais
VALUES ('Bloqueios regionais', (SELECT ID FROM @ProcedureGroups_Anestesias), GETDATE(), NULL, 1)

DECLARE @Procedures_AnestesiaInalatoriaGrupo1 table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AnestesiaInalatoriaGrupo1
VALUES ('Anestesia inalatória - grupo 1(ate 10kg)', (SELECT ID FROM @ProcedureGroups_Anestesias), GETDATE(), NULL, 1)

DECLARE @Procedures_AnestesiaInalatoriaGrupo2 table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AnestesiaInalatoriaGrupo2
VALUES ('Anestesia inalatória - grupo 2(10 a 20kg)', (SELECT ID FROM @ProcedureGroups_Anestesias), GETDATE(), NULL, 1)

DECLARE @Procedures_AnestesiaInalatoriaGrupo3 table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AnestesiaInalatoriaGrupo3
VALUES ('Anestesia inalatória - grupo 3 (20 a 40kg)', (SELECT ID FROM @ProcedureGroups_Anestesias), GETDATE(), NULL, 1)
