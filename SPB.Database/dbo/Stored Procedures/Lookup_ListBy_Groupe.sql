CREATE PROCEDURE [dbo].[Lookup_ListBy_Groupe]
(
	@groupe nvarchar(50),
    @year int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;

IF @groupe = 'pays'
	SELECT
		ID [id],
		0 [cie],
		ID [code],
		Nom [description],
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.Pays
	ORDER BY Nom

ELSE IF @groupe = 'institutionBanquaire'
	SELECT
		ID [id],
		0 [cie],
		ID [code],
		Description,
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.InstitutionBanquaire
	WHERE Actif = 1
	ORDER BY Description

ELSE IF @groupe = 'compte'
	SELECT
		c.ID [id],
		0 [cie],
		c.ID [code],
		c.Description,
		cc.Description [value1],
		NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.Compte c
	INNER JOIN Gestion_Paie.dbo.CompteCategory cc ON cc.[ID] = CategoryID
	WHERE Actif = 1
	ORDER BY c.[ID]

ELSE IF @groupe = 'fournisseur'
	SELECT
		f.ID [id],
		0 [cie],
		f.ID [code],
		f.Nom [Description],
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.Fournisseur f
	WHERE f.Actif = 1 AND f.IsAutre = 1
	ORDER BY f.ID
;

END