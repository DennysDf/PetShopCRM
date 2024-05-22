-- Herniorrafia
DECLARE @ProcedureGroups_Herniorrafia table (ID int)
INSERT INTO ProcedureGroups ([Description], [CreatedDate], [UpdatedDate], [Active]) 
OUTPUT Inserted.ID INTO @ProcedureGroups_Herniorrafia
VALUES ('Herniorrafia', GETDATE(), NULL, 1)

-- Inserindo procedimentos de Herniorrafia
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
