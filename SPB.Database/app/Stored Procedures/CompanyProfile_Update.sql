CREATE PROCEDURE [app].[CompanyProfile_Update]
(
	@_uid int,
	@cie int,
    @json nvarchar(MAX)
)
AS
BEGIN
SET NOCOUNT ON
;

--
-- Update Gestion_Paie.dbo.jag_SystemEx
--
DECLARE @table TABLE ([key] nvarchar(50), [value] nvarchar(500))
;
INSERT @table
SELECT
	[key],
	[value]
FROM openjson(@json)
;

UPDATE
	Gestion_Paie.dbo.jag_SystemEx
SET
	Gestion_Paie.dbo.jag_SystemEx.Value = cte.[value]
FROM
	Gestion_Paie.dbo.jag_SystemEx ps
INNER JOIN
	@table cte on 1=1
WHERE
	cte.[key] NOT LIKE 'fournisseur[_]%' AND 
	cte.[key] NOT LIKE 'compte[_]%' AND 
	cte.[key] NOT LIKE 'taux[_]%' AND
	cte.[key] COLLATE DATABASE_DEFAULT = ps.Name COLLATE DATABASE_DEFAULT
;


--
-- Update Gestion_Paie.dbo.jag_System
--
--
UPDATE Gestion_Paie.dbo.jag_System
SET
	Fournisseur_PlanConjoint = (SELECT [value] FROM @table WHERE [key] = 'Fournisseur_PlanConjoint'),
	Fournisseur_Surcharge = (SELECT [value] FROM @table WHERE [key] = 'Fournisseur_Surcharge'),
	Compte_Paiements = (SELECT [value] FROM @table WHERE [key] = 'Compte_Paiements'),
	Compte_ARecevoir = (SELECT [value] FROM @table WHERE [key] = 'Compte_ARecevoir'),
	Compte_APayer = (SELECT [value] FROM @table WHERE [key] = 'Compte_APayer'),
	Compte_DuAuxProducteurs = (SELECT [value] FROM @table WHERE [key] = 'Compte_DuAuxProducteurs'),
	Compte_TPSpercues = (SELECT [value] FROM @table WHERE [key] = 'Compte_TPSpercues'),
	Compte_TPSpayees = (SELECT [value] FROM @table WHERE [key] = 'Compte_TPSpayees'),
	Compte_TVQpercues = (SELECT [value] FROM @table WHERE [key] = 'Compte_TVQpercues'),
	Compte_TVQpayees = (SELECT [value] FROM @table WHERE [key] = 'Compte_TVQpayees'),
	Taux_TPS = (SELECT [value] FROM @table WHERE [key] = 'Taux_TPS'),
	Taux_TVQ = (SELECT [value] FROM @table WHERE [key] = 'Taux_TVQ'),
	Fournisseur_Fond_Roulement = (SELECT [value] FROM @table WHERE [key] = 'Fournisseur_Fond_Roulement'),
	Fournisseur_Fond_Forestier = (SELECT [value] FROM @table WHERE [key] = 'Fournisseur_Fond_Forestier'),
	Fournisseur_Preleve_Divers = (SELECT [value] FROM @table WHERE [key] = 'Fournisseur_Preleve_Divers')
;


END