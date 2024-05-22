--Exames laboratoriais

DECLARE @ProcedureGroups_ExamesLaboratoriais table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_ExamesLaboratoriais
VALUES ('Exames laboratoriais', GETDATE(), NULL, 1)

DECLARE @Procedures_Hemograma table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Hemograma
VALUES ('Hemograma', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_AlaninaAminotransferase table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AlaninaAminotransferase
VALUES ('Alanina aminotransferase (TGP / ALT)', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Creatinina table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Creatinina
VALUES ('Creatinina', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_FosfataseAlcalina table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_FosfataseAlcalina
VALUES ('Fosfatase alcalina (FA)', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Ureia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Ureia
VALUES ('Uréia', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Urinalise table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Urinalise
VALUES ('Urinalise', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_PesquisaEctoparasitasPele table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_PesquisaEctoparasitasPele
VALUES ('Pesquisa de ectoparasitas pele', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_PesquisaEctoparasitasOuvido table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_PesquisaEctoparasitasOuvido
VALUES ('Pesquisa de ectoparasitas ouvido', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Glicose table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Glicose
VALUES ('Glicose', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Triglicerideos table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Triglicerideos
VALUES ('Triglicerideos', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Albumina table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Albumina
VALUES ('Albumina', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Colesterol table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Colesterol
VALUES ('Colesterol', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Potassio table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Potassio
VALUES ('Potassio', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Sodio table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Sodio
VALUES ('Sodio', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Frutosamina table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Frutosamina
VALUES ('Frutosamina', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_PesquisaHematozoarios table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_PesquisaHematozoarios
VALUES ('Pesquisa de hematozoarios', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_GlicemiaFita table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_GlicemiaFita
VALUES ('Glicemia fita', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Cloro table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Cloro
VALUES ('Cloro', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Magnesio table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Magnesio
VALUES ('Magnesio', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Ferro table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Ferro
VALUES ('Ferro', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Amilase table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Amilase
VALUES ('Amilase', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Amonia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Amonia
VALUES ('Amonia', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Hematocrito table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Hematocrito
VALUES ('Hematocrito', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_ProteinasTotaisFracoes table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ProteinasTotaisFracoes
VALUES ('Proteinas totais e fracoes', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_CK table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CK
VALUES ('CK', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_ColetaCistosentese table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ColetaCistosentese
VALUES ('Coleta por cistosentese', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_BabesiaIgg table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BabesiaIgg
VALUES ('Babesia igg', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_BabesiaIgm table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BabesiaIgm
VALUES ('Babesia igm', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Erliquia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Erliquia
VALUES ('Erliquia sp igm', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Fiv table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Fiv
VALUES ('Fiv e felv imunocromatografico', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_Parvovirus table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Parvovirus
VALUES ('Parvovirus igg', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_CinomoseIgg table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CinomoseIgg
VALUES ('Cinomose igg', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)

DECLARE @Procedures_CinomoseIgm table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CinomoseIgm
VALUES ('Cinomose igm ', (SELECT ID FROM @ProcedureGroups_ExamesLaboratoriais), GETDATE(), NULL, 1)
