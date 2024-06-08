--Consulta clinico geral
DECLARE @ProcedureGroups_ConsultaClinicoGeral table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_ConsultaClinicoGeral
VALUES ('Consulta com clinico geral', GETDATE(), NULL, 1)

DECLARE @Procedures_Consulta8as18 table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Consulta8as18
VALUES ('Consulta das 08:00 às 18:00', (SELECT ID FROM @ProcedureGroups_ConsultaClinicoGeral), GETDATE(), NULL, 1)

DECLARE @Procedures_Consulta18as00 table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Consulta18as00
VALUES ('Consulta clinico geral das 18:00 ás 00:00 horas', (SELECT ID FROM @ProcedureGroups_ConsultaClinicoGeral), GETDATE(), NULL, 1)

DECLARE @Procedures_ConsultaPediatricaDefinicaoProtocoloVacinal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ConsultaPediatricaDefinicaoProtocoloVacinal
VALUES ('Consulta pediatrica para definição de protocolo vacinal', (SELECT ID FROM @ProcedureGroups_ConsultaClinicoGeral), GETDATE(), NULL, 1)

DECLARE @Procedures_Retornos8as18 table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Retornos8as18
VALUES ('Retornos das 8:00 as 18:00 horas', (SELECT ID FROM @ProcedureGroups_ConsultaClinicoGeral), GETDATE(), NULL, 1)

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

-- Cirurgias Auriculares
DECLARE @ProcedureGroups_CirurgiasAuriculares table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasAuriculares
VALUES ('Cirurgias Auriculares', GETDATE(), NULL, 1)

DECLARE @Procedures_LavagemOtologica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LavagemOtologica
VALUES ('Lavagem otológica', (SELECT ID FROM @ProcedureGroups_CirurgiasAuriculares), GETDATE(), NULL, 1)

DECLARE @Procedures_ExcisaoPolipoOtologico table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ExcisaoPolipoOtologico
VALUES ('Excisão de Pólipo Otológico', (SELECT ID FROM @ProcedureGroups_CirurgiasAuriculares), GETDATE(), NULL, 1)

DECLARE @Procedures_ConchectomiaTerapeutica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ConchectomiaTerapeutica
VALUES ('Conchectomia terapêutica', (SELECT ID FROM @ProcedureGroups_CirurgiasAuriculares), GETDATE(), NULL, 1)

DECLARE @Procedures_OtohematomaTratamentoCirurgico table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_OtohematomaTratamentoCirurgico
VALUES ('Otohematoma - tratamento cirúrgico', (SELECT ID FROM @ProcedureGroups_CirurgiasAuriculares), GETDATE(), NULL, 1)

-- Cirurgias Bucofaciais
DECLARE @ProcedureGroups_CirurgiasBucofaciais table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasBucofaciais
VALUES ('Cirurgias Bucofaciais', GETDATE(), NULL, 1)

DECLARE @Procedures_OsteossinteseMandibular table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_OsteossinteseMandibular
VALUES ('Osteossíntese Mandibular', (SELECT ID FROM @ProcedureGroups_CirurgiasBucofaciais), GETDATE(), NULL, 1)

-- Cirurgias Digestivas
DECLARE @ProcedureGroups_CirurgiasDigestivas table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasDigestivas
VALUES ('Cirurgias Digestivas', GETDATE(), NULL, 1)

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

-- Cirurgias Gerais
DECLARE @ProcedureGroups_CirurgiasGerais table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasGerais
VALUES ('Cirurgias Gerais', GETDATE(), NULL, 1)

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

-- Cirurgias Gênitourinárias
DECLARE @ProcedureGroups_CirurgiasGenitourinarias table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasGenitourinarias
VALUES ('Cirurgias Gênitourinárias', GETDATE(), NULL, 1)

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

-- Cirurgias Oculares
DECLARE @ProcedureGroups_CirurgiasOculares table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasOculares
VALUES ('Cirurgias Oculares', GETDATE(), NULL, 1)

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

-- Cirurgias Ortopédicas
DECLARE @ProcedureGroups_CirurgiasOrtopedicas table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasOrtopedicas
VALUES ('Cirurgias Ortopédicas', GETDATE(), NULL, 1)

DECLARE @Procedures_AmputacaoFalange table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AmputacaoFalange
VALUES ('Amputação de falange', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

DECLARE @Procedures_AmputacaoMembros table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AmputacaoMembros
VALUES ('Amputação de membros', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

DECLARE @Procedures_RetiradaImplantesOrtopedicos table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RetiradaImplantesOrtopedicos
VALUES ('Retirada de implantes ortopédicos', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

DECLARE @Procedures_RetiradaFixadorExterno table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RetiradaFixadorExterno
VALUES ('Retirada de fixador externo', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

DECLARE @Procedures_Osteossintese table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Osteossintese
VALUES ('Osteossíntese', (SELECT ID FROM @ProcedureGroups_CirurgiasOrtopedicas), GETDATE(), NULL, 1)

--Exames Cardiológicos
DECLARE @ProcedureGroups_ExamesCardiologicos table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_ExamesCardiologicos
VALUES ('Exames Cardiológicos', GETDATE(), NULL, 1)

DECLARE @Procedures_AfericaoPressaoArterial table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AfericaoPressaoArterial
VALUES ('Aferição de pressão arterial', (SELECT ID FROM @ProcedureGroups_ExamesCardiologicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Eletrocardiograma table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Eletrocardiograma
VALUES ('Eletrocardiograma', (SELECT ID FROM @ProcedureGroups_ExamesCardiologicos), GETDATE(), NULL, 1)

DECLARE @Procedures_Ecodopplercardiograma table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Ecodopplercardiograma
VALUES ('Ecodopplercardiograma', (SELECT ID FROM @ProcedureGroups_ExamesCardiologicos), GETDATE(), NULL, 1)

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

-- Herniorrafia
DECLARE @ProcedureGroups_Herniorrafia table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Herniorrafia
VALUES ('Herniorrafia', GETDATE(), NULL, 1)

DECLARE @Procedures_HerniaUmbilical table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_HerniaUmbilical
VALUES ('Hérnia Umbilical', (SELECT ID FROM @ProcedureGroups_Herniorrafia), GETDATE(), NULL, 1)

DECLARE @Procedures_HerniaPerineal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_HerniaPerineal
VALUES ('Hérnia Perineal', (SELECT ID FROM @ProcedureGroups_Herniorrafia), GETDATE(), NULL, 1)

DECLARE @Procedures_HerniaInguinal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_HerniaInguinal
VALUES ('Hérnia inguinal', (SELECT ID FROM @ProcedureGroups_Herniorrafia), GETDATE(), NULL, 1)

DECLARE @Procedures_HerniaDiafragmatica table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_HerniaDiafragmatica
VALUES ('Hérnia Diafragmática', (SELECT ID FROM @ProcedureGroups_Herniorrafia), GETDATE(), NULL, 1)

--Internação
DECLARE @ProcedureGroups_Internacao table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Internacao
VALUES ('Internação', GETDATE(), NULL, 1)

DECLARE @Procedures_DayCareAte12h table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_DayCareAte12h
VALUES ('Day Care Até 12h', (SELECT ID FROM @ProcedureGroups_Internacao), GETDATE(), NULL, 1)

DECLARE @Procedures_Internacao24Horas table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Internacao24Horas
VALUES ('Internação 24 Horas', (SELECT ID FROM @ProcedureGroups_Internacao), GETDATE(), NULL, 1)

DECLARE @Procedures_InternacaoSemiIntensiva table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_InternacaoSemiIntensiva
VALUES ('Internação Semi-Intensiva', (SELECT ID FROM @ProcedureGroups_Internacao), GETDATE(), NULL, 1)

--Medicamentos
DECLARE @ProcedureGroups_Medicamentos table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Medicamentos
VALUES ('Medicamentos', GETDATE(), NULL, 1)

DECLARE @Procedures_AplicacaoMedicacoesInjetaveisIMSC table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AplicacaoMedicacoesInjetaveisIMSC
VALUES ('Aplicação de medicações injetáveis IM/SC', (SELECT ID FROM @ProcedureGroups_Medicamentos), GETDATE(), NULL, 1)

DECLARE @Procedures_ColetaMaterialExamesG table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_ColetaMaterialExamesG
VALUES ('Coleta de material para exames', (SELECT ID FROM @ProcedureGroups_Medicamentos), GETDATE(), NULL, 1)

DECLARE @Procedures_AplicacaoVacina table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_AplicacaoVacina
VALUES ('Aplicação de vacina', (SELECT ID FROM @ProcedureGroups_Medicamentos), GETDATE(), NULL, 1)

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

DECLARE @Procedures_RemocaoEspinhosOuricos table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_RemocaoEspinhosOuricos
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

-- Serviços
DECLARE @ProcedureGroups_Servicos table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Servicos
VALUES ('Serviços', GETDATE(), NULL, 1)

DECLARE @Procedures_Microchipagem table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_Microchipagem
VALUES ('Microchipagem', (SELECT ID FROM @ProcedureGroups_Servicos), GETDATE(), NULL, 1)

DECLARE @Procedures_LocacaoSalaAtendimentoVolante table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_LocacaoSalaAtendimentoVolante
VALUES ('Locação de Sala de Atendimento Volante', (SELECT ID FROM @ProcedureGroups_Servicos), GETDATE(), NULL, 1)

--Transfusão
DECLARE @ProcedureGroups_Transfusao table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Transfusao
VALUES ('Transfusão', GETDATE(), NULL, 1)

DECLARE @Procedures_TesteCompatibilidade table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TesteCompatibilidade
VALUES ('Teste de compatibilidade', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_TaxaTransfusaoSanguinea table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_TaxaTransfusaoSanguinea
VALUES ('Taxa para transfusão sanguínea', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_BolsaPlasmaFrescoCongelado table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BolsaPlasmaFrescoCongelado
VALUES ('Bolsa plasma fresco congelado', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_BolsaConcentradoPlaquetas table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BolsaConcentradoPlaquetas
VALUES ('Bolsa concentrado de plaquetas', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_BolsaConcentradoHemacias table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BolsaConcentradoHemacias
VALUES ('Bolsa concentrado de hemácias', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

DECLARE @Procedures_BolsaSangueTotal table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_BolsaSangueTotal
VALUES ('Bolsa sangue total', (SELECT ID FROM @ProcedureGroups_Transfusao), GETDATE(), NULL, 1)

--Vacinas
DECLARE @ProcedureGroups_Vacinas table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Vacinas
VALUES ('Vacinas', GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaPolivalente table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaPolivalente
VALUES ('Vacina polivalente', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaRaiva table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaRaiva
VALUES ('Vacina raiva', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaTriplice table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaTriplice
VALUES ('Vacina triplice / quadrupla', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaQuintupla table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaQuintupla
VALUES ('Vacina quintupla', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

DECLARE @Procedures_VacinaGripePneumonia table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_VacinaGripePneumonia
VALUES ('Vacina gripe/pneumonia', (SELECT ID FROM @ProcedureGroups_Vacinas), GETDATE(), NULL, 1)

--Planos
DECLARE @HealthPlan_Green table (ID int)
INSERT INTO HealthPlans
OUTPUT Inserted.ID INTO @HealthPlan_Green
VALUES ('VetCard - Green', 29.99, 'Plano Básico', GETDATE(), NULL, 1)

DECLARE @HealthPlan_Gold table (ID int)
INSERT INTO HealthPlans
OUTPUT Inserted.ID INTO @HealthPlan_Gold
VALUES ('VetCard - Gold', 89.99, 'Plano Básico', GETDATE(), NULL, 1)

DECLARE @HealthPlan_Black table (ID int)
INSERT INTO HealthPlans
OUTPUT Inserted.ID INTO @HealthPlan_Black
VALUES ('VetCard - Black', 199.90, 'Plano Básico', GETDATE(), NULL, 1)

--Green
INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30.00, NULL, 0, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_Consulta8as18), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30.00, NULL, 0, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_Consulta18as00), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30.00, NULL, 0, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_ConsultaPediatricaDefinicaoProtocoloVacinal), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0, NULL, 30, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_Retornos8as18), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00, 4, 2, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_VacinaPolivalente), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00, 1, 2, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_VacinaRaiva), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00, 3, 2, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_VacinaTriplice), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00, 10, 60, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_Hemograma), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00, 10, 60, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_AlaninaAminotransferase), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00, 10, 60, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_Creatinina), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00, 10, 60, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_FosfataseAlcalina), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00, 10, 60, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_Ureia), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00, 10, 50, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_AplicacaoMedicacoesInjetaveisIMSC), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(10.00, NULL, 0, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_ColetaMaterialExamesG), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(10.00, NULL, 0, (SELECT ID FROM @HealthPlan_Green), (SELECT ID FROM @Procedures_AplicacaoVacina), GETDATE(), NULL, 1, NULL, 'Value')


--Gold
INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00, NULL, 0, (SELECT ID FROM @HealthPlan_Gold), (SELECT ID FROM @Procedures_Consulta8as18), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00, NULL, 0, (SELECT ID FROM @HealthPlan_Gold), (SELECT ID FROM @Procedures_Consulta18as00), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00, NULL, 0, (SELECT ID FROM @HealthPlan_Gold), (SELECT ID FROM @Procedures_ConsultaPediatricaDefinicaoProtocoloVacinal), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0, NULL, 30, (SELECT ID FROM @HealthPlan_Gold), (SELECT ID FROM @Procedures_Retornos8as18), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,4,2,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_VacinaPolivalente),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,1,2,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_VacinaRaiva),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,2,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_VacinaTriplice),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,2,2,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_VacinaQuintupla),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30.00,2,2,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_VacinaGripePneumonia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Hemograma),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AlaninaAminotransferase),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Creatinina),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_FosfataseAlcalina),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Ureia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Urinalise),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_PesquisaEctoparasitasPele),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_PesquisaEctoparasitasOuvido),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Glicose),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Triglicerideos),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Albumina),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Colesterol),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Potassio),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Sodio),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Frutosamina),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_PesquisaHematozoarios),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_GlicemiaFita),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Cloro),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Magnesio),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Ferro),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Amilase),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Amonia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Hematocrito),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ProteinasTotaisFracoes),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CK),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ColetaCistosentese),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BabesiaIgg),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BabesiaIgm),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Erliquia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Fiv),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Parvovirus),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CinomoseIgg),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CinomoseIgm),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(10.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ColetaMaterialExames),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AplicacaoInjecaoSCIM),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CurativoSimples),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_SuturaPeleSimples),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_DrenagemAbscesso),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_SoroterapiaFluidoterapia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,10,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_DesobstrucaoUretral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AplicacaoIV),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_FluidoterapiaColoidal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_FluidoterapiaHipertonicaManitol),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Reanimacao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_LimpezaDebridamento),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_RetiradaAnzolTopico),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AmputacaoUnha),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_LavagemGastrica),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CarvaoAtivadoLavagemGastrica),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_LavagemVesical),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Inalacao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_SedacaoTranquilizacao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_RetiradaMiase),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Oxigenoterapia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CurativoComplexo),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ResseccaoVerruga),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_LavagemIntestinal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ImobilizacaoFraturasSimples),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(40.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Abdominocentese),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Toracocentese),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(90.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_RemocaoEspinhosOuricos),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(300.00,NULL,45,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Pericardiocentese),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(12.00,NULL,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_TesteFluoresceinaJonesUnilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(15.00,15,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_TesteSchirmerBilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(15.00,15,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_TesteRosaBengalaBilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(15.00,NULL,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ColirioAnestesicounilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,20,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_SessaoQuimioterapia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,15,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_DebridamentoCorneaSwab),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,NULL,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Flushing),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,15,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_EpilacaoMecanica),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AcompanhamentoRetornoUltrassonograficoAbdominal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_RaioXPorPosicaoProjecao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_UltrassonografiaAbdominal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_RaioXPlantaoPorPosicaoProjecao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_UltrassonografiaOcularBilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_UltrassonografiaEncefalica),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_UltrassonografiaArticular),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_UltrassonografiaAbdominalPlantao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,7,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_UltrassonografiaCervical),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,NULL,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AnestesiaLocal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AnestesiaGeralAmbulatorialIntravenosa),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(55.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BloqueiosRegionais),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(150.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AnestesiaInalatoriaGrupo1),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(200.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AnestesiaInalatoriaGrupo2),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(250.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AnestesiaInalatoriaGrupo3),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(15.00,5,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AfericaoPressaoArterial),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100.00,2,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Eletrocardiograma),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(200.00,2,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Ecodopplercardiograma),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60.00,10,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_DayCareAte12h),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(150.00,10,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Internacao24Horas),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(200.00,10,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_InternacaoSemiIntensiva),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(40.00,NULL,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_TesteCompatibilidade),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80.00,15,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_TaxaTransfusaoSanguinea),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(90.00,NULL,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BolsaPlasmaFrescoCongelado),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(120.00,NULL,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BolsaConcentradoPlaquetas),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(150.00,NULL,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BolsaConcentradoHemacias),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(150.00,NULL,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BolsaSangueTotal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AblacaoBolsaEscrotal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ProlapsoUretra),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CastracaoMacho),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Cistotomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_PolipoVaginal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_OvarioRemanescente),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Cistorrafia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Ureterostomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_PiometraCotoUterino),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CastracaoFemea),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Uretrostomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_OvariohisterectomiaTerapêutica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ProlapsoUteroReducaoCirurgica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_UreterostomiaBilateral),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Penectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_MastectomiaTotal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_NeoplasiaMamariaCadeiaBilateral),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CastracaoCriptorquida),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_LavagemOtologica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ExcisaoPolipoOtologico),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ConchectomiaTerapeutica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_OtohematomaTratamentoCirurgico),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BlocoCirurgico),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BiopsiaLinfonodoColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ResseccaoPregaCutaneaFacial),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BiopsiaTriadeFelinaColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_NodulectomiaP),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BiopsiaGastricaColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BiopsiaIntestinalColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BiopsiaOsseaColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_RejeicaoSuturaMusculaturaPele),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_NodulectomiaM),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Linfadenectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_LaparotomiaExploratoria),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Evisceracao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AbalacaoGlandulaAdanal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_BiopsiaHepaticaColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_TaxaAnaplastiaRetalho),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_NodulectomiaG),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Eventracao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AdicionalAnestesiaPlantao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AdicionalCirurgiaPlantao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_OsteossinteseMandibular),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AmputacaoFalange),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_AmputacaoMembros),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_RetiradaImplantesOrtopedicos),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_RetiradaFixadorExterno),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Osteossintese),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_HerniaUmbilical),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_HerniaPerineal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_HerniaInguinal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_HerniaDiafragmatica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CorrecaoEntropioEctropioUnilateral),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_EnucleacaoRetiradaGloboOcular),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ReducaoProtrusaoGloboOcular),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ExcisaoGlandulaTerceiraPalpebra),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ReposicaoGlandulaTerceiraPalpebra),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ExcisaoNeoplasiaPalpebralReconstrucao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Tarsorrafia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_EversaoCartilagemTerceiraPalpebra),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CorrecaoUlceraCornea),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_CorrecaoTriquiaseDistiquiaseCiliosEctopicos),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Enterectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ProlapsoRetoReducao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_EsofagotomiaRetiradaCorpoEstranho),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_GastrostomiaGastrotomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Esplenectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Sialoadenectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_GastrectomiaParcial),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Enterotomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Enteroanastomose),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Colonopexia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_ProlapsoRetoAmputacao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_TorcaoDilatacaoGastricaReducaoGastropexia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,3,120,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_TorcaoDilatacaoGastricaReducaoGastropexiaGastrectomiaParcialEsplenectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(69.00,1,0,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_Microchipagem),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,1,60,(SELECT ID FROM @HealthPlan_Gold),(SELECT ID FROM @Procedures_LocacaoSalaAtendimentoVolante),GETDATE(),NULL,1,NULL,'Value')


--Black
INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0, NULL, 0, (SELECT ID FROM @HealthPlan_Black), (SELECT ID FROM @Procedures_Consulta8as18), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0, NULL, 0, (SELECT ID FROM @HealthPlan_Black), (SELECT ID FROM @Procedures_Consulta18as00), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0, NULL, 0, (SELECT ID FROM @HealthPlan_Black), (SELECT ID FROM @Procedures_ConsultaPediatricaDefinicaoProtocoloVacinal), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0, NULL, 30, (SELECT ID FROM @HealthPlan_Black), (SELECT ID FROM @Procedures_Retornos8as18), GETDATE(), NULL, 1, NULL, 'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,4,2,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_VacinaPolivalente),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,1,2,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_VacinaRaiva),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,3,2,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_VacinaTriplice),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,2,2,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_VacinaQuintupla),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30,2,2,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_VacinaGripePneumonia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Hemograma),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AlaninaAminotransferase),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Creatinina),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_FosfataseAlcalina),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Ureia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Urinalise),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_PesquisaEctoparasitasPele),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_PesquisaEctoparasitasOuvido),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Glicose),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Triglicerideos),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Albumina),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Colesterol),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Potassio),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Sodio),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Frutosamina),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_PesquisaHematozoarios),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_GlicemiaFita),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Cloro),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Magnesio),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Ferro),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Amilase),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Amonia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Hematocrito),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ProteinasTotaisFracoes),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CK),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(22,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ColetaCistosentese),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BabesiaIgg),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BabesiaIgm),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Erliquia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Fiv),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Parvovirus),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CinomoseIgg),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CinomoseIgm),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ColetaMaterialExames),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AplicacaoInjecaoSCIM),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CurativoSimples),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_SuturaPeleSimples),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_DrenagemAbscesso),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_SoroterapiaFluidoterapia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,10,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_DesobstrucaoUretral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AplicacaoIV),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_FluidoterapiaColoidal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_FluidoterapiaHipertonicaManitol),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Reanimacao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_LimpezaDebridamento),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_RetiradaAnzolTopico),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AmputacaoUnha),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_LavagemGastrica),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CarvaoAtivadoLavagemGastrica),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_LavagemVesical),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Inalacao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_SedacaoTranquilizacao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_RetiradaMiase),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Oxigenoterapia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CurativoComplexo),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ResseccaoVerruga),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(30,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_LavagemIntestinal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ImobilizacaoFraturasSimples),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(40,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Abdominocentese),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Toracocentese),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(90,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_RemocaoEspinhosOuricos),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(300,NULL,45,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Pericardiocentese),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(12,NULL,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_TesteFluoresceinaJonesUnilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(15,15,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_TesteSchirmerBilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(15,15,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_TesteRosaBengalaBilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(15,NULL,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ColirioAnestesicounilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,20,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_SessaoQuimioterapia),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,15,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_DebridamentoCorneaSwab),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50,NULL,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Flushing),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100,15,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_EpilacaoMecanica),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AcompanhamentoRetornoUltrassonograficoAbdominal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_RaioXPorPosicaoProjecao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_UltrassonografiaAbdominal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_RaioXPlantaoPorPosicaoProjecao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_UltrassonografiaOcularBilateral),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_UltrassonografiaEncefalica),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_UltrassonografiaArticular),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_UltrassonografiaAbdominalPlantao),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,7,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_UltrassonografiaCervical),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,NULL,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AnestesiaLocal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(100,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AnestesiaGeralAmbulatorialIntravenosa),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(55,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BloqueiosRegionais),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(150,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AnestesiaInalatoriaGrupo1),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(200,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AnestesiaInalatoriaGrupo2),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(250,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AnestesiaInalatoriaGrupo3),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(15,5,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AfericaoPressaoArterial),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(40,2,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Eletrocardiograma),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,2,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Ecodopplercardiograma),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(60,10,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_DayCareAte12h),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(150,10,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Internacao24Horas),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(200,10,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_InternacaoSemiIntensiva),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(40,NULL,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_TesteCompatibilidade),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(80,15,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_TaxaTransfusaoSanguinea),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(90,NULL,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BolsaPlasmaFrescoCongelado),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(120,NULL,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BolsaConcentradoPlaquetas),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(150,NULL,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BolsaConcentradoHemacias),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(150,NULL,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BolsaSangueTotal),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AblacaoBolsaEscrotal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ProlapsoUretra),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,1,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CastracaoMacho),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Cistotomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_PolipoVaginal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_OvarioRemanescente),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Cistorrafia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Ureterostomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_PiometraCotoUterino),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,1,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CastracaoFemea),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Uretrostomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_OvariohisterectomiaTerapêutica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ProlapsoUteroReducaoCirurgica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_UreterostomiaBilateral),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Penectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_MastectomiaTotal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_NeoplasiaMamariaCadeiaBilateral),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CastracaoCriptorquida),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_LavagemOtologica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ExcisaoPolipoOtologico),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ConchectomiaTerapeutica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_OtohematomaTratamentoCirurgico),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BlocoCirurgico),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BiopsiaLinfonodoColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ResseccaoPregaCutaneaFacial),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BiopsiaTriadeFelinaColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_NodulectomiaP),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BiopsiaGastricaColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BiopsiaIntestinalColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BiopsiaOsseaColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_RejeicaoSuturaMusculaturaPele),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_NodulectomiaM),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Linfadenectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_LaparotomiaExploratoria),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Evisceracao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AbalacaoGlandulaAdanal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_BiopsiaHepaticaColeta),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_TaxaAnaplastiaRetalho),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_NodulectomiaG),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Eventracao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AdicionalAnestesiaPlantao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AdicionalCirurgiaPlantao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_OsteossinteseMandibular),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AmputacaoFalange),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_AmputacaoMembros),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_RetiradaImplantesOrtopedicos),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_RetiradaFixadorExterno),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Osteossintese),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_HerniaUmbilical),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_HerniaPerineal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_HerniaInguinal),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_HerniaDiafragmatica),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CorrecaoEntropioEctropioUnilateral),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_EnucleacaoRetiradaGloboOcular),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ReducaoProtrusaoGloboOcular),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ExcisaoGlandulaTerceiraPalpebra),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ReposicaoGlandulaTerceiraPalpebra),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ExcisaoNeoplasiaPalpebralReconstrucao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Tarsorrafia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_EversaoCartilagemTerceiraPalpebra),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CorrecaoUlceraCornea),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_CorrecaoTriquiaseDistiquiaseCiliosEctopicos),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Enterectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ProlapsoRetoReducao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_EsofagotomiaRetiradaCorpoEstranho),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_GastrostomiaGastrotomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Esplenectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Sialoadenectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_GastrectomiaParcial),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Enterotomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Enteroanastomose),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Colonopexia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_ProlapsoRetoAmputacao),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_TorcaoDilatacaoGastricaReducaoGastropexia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(20.00,3,120,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_TorcaoDilatacaoGastricaReducaoGastropexiaGastrectomiaParcialEsplenectomia),GETDATE(),NULL,1,NULL,'Percent')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(0,1,0,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_Microchipagem),GETDATE(),NULL,1,NULL,'Value')

INSERT INTO ProcedureHealthPlans([Coparticipation],[AnnualLimit],[Lack],[HealthPlanId],[ProcedureId],[CreatedDate],[UpdatedDate],[Active],[Observation],[CoparticipationUnit])
VALUES(50.00,1,60,(SELECT ID FROM @HealthPlan_Black),(SELECT ID FROM @Procedures_LocacaoSalaAtendimentoVolante),GETDATE(),NULL,1,NULL,'Value')
