-- Cirurgias Bucofaciais
DECLARE @ProcedureGroups_CirurgiasBucofaciais table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_CirurgiasBucofaciais
VALUES ('Cirurgias Bucofaciais', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Cirurgias Bucofaciais
DECLARE @Procedures_OsteossinteseMandibular table (ID int)
INSERT INTO [Procedures] ([Description], [ProcedureGroupId], [CreatedDate], [UpdatedDate], [Active])
OUTPUT Inserted.ID INTO @Procedures_OsteossinteseMandibular
VALUES ('Osteossíntese Mandibular', (SELECT ID FROM @ProcedureGroups_CirurgiasBucofaciais), GETDATE(), NULL, 1)
