--Procedimentos Clínicos

DECLARE @ProcedureGroups_ProcedimentosClinicos table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_ProcedimentosClinicos
VALUES ('Procedimentos Clínicos', GETDATE(), NULL, 1)

DECLARE @Procedures_ColetaMaterialExames table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ColetaMaterialExames
VALUES ('Coleta de material p/ exames cobertos', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_AplicacaoInjecaoSCIM table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AplicacaoInjecaoSCIM
VALUES ('Aplicação de injeção subcutânea ou intramuscular (sc / im) - com medicação', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_CurativoSimples table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CurativoSimples
VALUES ('Curativo simples', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_SuturaPeleSimples table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_SuturaPeleSimples
VALUES ('Sutura pele simples', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_DrenagemAbscesso table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_DrenagemAbscesso
VALUES ('Drenagem de abscesso', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_SoroterapiaFluidoterapia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_SoroterapiaFluidoterapia
VALUES ('Soroterapia/fluidoterapia', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_DesobstrucaoUretral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_DesobstrucaoUretral
VALUES ('Desobstrução uretral', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_AplicacaoIV table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AplicacaoIV
VALUES ('Aplicação (iv) - com medicação', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_FluidoterapiaColoidal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_FluidoterapiaColoidal
VALUES ('Fluidoterapia (solução coloidal)', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_FluidoterapiaHipertonicaManitol table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_FluidoterapiaHipertonicaManitol
VALUES ('Fluidoterapia (solução hipertonica ou manitol)', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Reanimacao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Reanimacao
VALUES ('Reanimação', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_LimpezaDebridamento table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LimpezaDebridamento
VALUES ('Limpeza e debridamento', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_RetiradaAnzolTopico table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RetiradaAnzolTopico
VALUES ('Retirada de anzol topico', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_AmputacaoUnha table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AmputacaoUnha
VALUES ('Amputação de unha', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_LavagemGastrica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LavagemGastrica
VALUES ('Lavagem gástrica', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_CarvaoAtivadoLavagemGastrica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CarvaoAtivadoLavagemGastrica
VALUES ('Carvão ativado + lavagem gástrica', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_LavagemVesical table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LavagemVesical
VALUES ('Lavagem vesical', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Inalacao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Inalacao
VALUES ('Inalação -15 minutos', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_SedacaoTranquilizacao table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_SedacaoTranquilizacao
VALUES ('Sedação / tranquilização', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_RetiradaMiase table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RetiradaMiase
VALUES ('Retirada de miíase (retirada de bicheiras)', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Oxigenoterapia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Oxigenoterapia
VALUES ('Oxigenoterapia até 30 minutos', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_CurativoComplexo table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_CurativoComplexo
VALUES ('Curativo complexo', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_ResseccaoVerruga table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ResseccaoVerruga
VALUES ('Ressecção de verruga', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_LavagemIntestinal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LavagemIntestinal
VALUES ('Lavagem intestinal', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_ImobilizacaoFraturasSimples table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ImobilizacaoFraturasSimples
VALUES ('Imobilização de fraturas simples', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Abdominocentese table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Abdominocentese
VALUES ('Abdominocentese', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Toracocentese table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Toracocentese
VALUES ('Toracocentese', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_RemocaoEspinhosOuriços table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RemocaoEspinhosOuriços
VALUES ('Remoção espinhos (ouriços)', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Pericardiocentese table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Pericardiocentese
VALUES ('Pericardiocentese', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_TesteFluoresceinaJonesUnilateral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TesteFluoresceinaJonesUnilateral
VALUES ('Teste de fluoresceína + jones unilateral', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_TesteSchirmerBilateral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TesteSchirmerBilateral
VALUES ('Teste de schirmer bilateral', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_TesteRosaBengalaBilateral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TesteRosaBengalaBilateral
VALUES ('Teste rosa bengala bilateral', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_ColirioAnestesicounilateral table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ColirioAnestesicounilateral
VALUES ('Colírio Anestésico unilateral', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_SessaoQuimioterapia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_SessaoQuimioterapia
VALUES ('Sessão de Quimioterapia', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_DebridamentoCorneaSwab table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_DebridamentoCorneaSwab
VALUES ('Debridamento de córnea com swab', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Flushing table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Flushing
VALUES ('Flushing', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)

DECLARE @Procedures_EpilacaoMecanica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_EpilacaoMecanica
VALUES ('Epilação Mecânica', (SELECT ID FROM @ProcedureGroups_ProcedimentosClinicos), GETDATE(), NULL, 1)
