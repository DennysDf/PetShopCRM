--Exames de Imagem

DECLARE @ProcedureGroups_ExamesDeImagem table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_ExamesDeImagem
VALUES ('Exames de Imagem', GETDATE(), NULL, 1)

DECLARE @Procedures_AcompanhamentoRetornoUltrassonograficoAbdominal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AcompanhamentoRetornoUltrassonograficoAbdominal
VALUES ('Acompanhamento/RETORNO ultrassonográfico abdominal', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)

DECLARE @Procedures_RaioXPorPosicaoProjecao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RaioXPorPosicaoProjecao
VALUES ('Raio-x (por posição / projeção)', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)

DECLARE @Procedures_UltrassonografiaAbdominal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_UltrassonografiaAbdominal
VALUES ('Ultrassonografia abdominal', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)

DECLARE @Procedures_RaioXPlantaoPorPosicaoProjecao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RaioXPlantaoPorPosicaoProjecao
VALUES ('Raio-x Plantão (por posição / projeção)', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)

DECLARE @Procedures_UltrassonografiaOcularBilateral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_UltrassonografiaOcularBilateral
VALUES ('Ultrassonografia ocular bilateral', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)

DECLARE @Procedures_UltrassonografiaEncefalica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_UltrassonografiaEncefalica
VALUES ('Ultrassonografia Encefálica', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)

DECLARE @Procedures_UltrassonografiaArticular table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_UltrassonografiaArticular
VALUES ('Ultrassonografia Articular', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)

DECLARE @Procedures_UltrassonografiaAbdominalPlantao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_UltrassonografiaAbdominalPlantao
VALUES ('Ultrassonografia abdominal Plantão', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)

DECLARE @Procedures_UltrassonografiaCervical table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_UltrassonografiaCervical
VALUES ('Ultrassonografia Cervical', (SELECT ID FROM @ProcedureGroups_ExamesDeImagem), GETDATE(), NULL, 1)
