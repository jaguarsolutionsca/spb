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
		pt.ID [id],
		0 [cie],
		pt.ID [code],
		pt.Nom [description],
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.Pays pt
	ORDER BY pt.Nom

ELSE IF @groupe = 'institutionBanquaire'
	SELECT
		pt.ID [id],
		0 [cie],
		pt.ID [code],
		pt.Description,
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.InstitutionBanquaire pt
	WHERE pt.Actif = 1
	ORDER BY Description

ELSE IF @groupe = 'compte'
	SELECT
		pt.ID [id],
		0 [cie],
		pt.ID [code],
		pt.Description,
		pt.Description [value1],
		NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.Compte pt
	INNER JOIN Gestion_Paie.dbo.CompteCategory cc ON pt.[ID] = CategoryID
	WHERE Actif = 1
	ORDER BY pt.[ID]

ELSE IF @groupe = 'autreFournisseur'
	SELECT
		pt.ID [id],
		0 [cie],
		pt.ID [code],
		pt.Nom [Description],
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.Fournisseur pt
	WHERE pt.Actif = 1 AND pt.IsAutre = 1
	ORDER BY pt.ID

ELSE IF @groupe = 'canton'
	SELECT
		pt.ID [id],
		0 [cie],
		pt.ID [code],
		pt.Description [Description],
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.fnCanton(null) pt
	ORDER BY pt.Description

ELSE IF @groupe = 'municipalite'
	SELECT
		pt.ID [id],
		0 [cie],
		pt.ID [code],
		pt.Description [Description],
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.fnMunicipalite(null, null, null) pt
	ORDER BY pt.Description

ELSE IF @groupe = 'proprietaire'
	SELECT
		pt.ID [id],
		0 [cie],
		pt.ID [code],
		pt.Nom [Description],
		NULL [value1], NULL [value2], NULL [value3],
		1950 [started], NULL [ended], NULL [sortOrder], CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.Fournisseur pt
	WHERE pt.Actif = 1 AND pt.IsProducteur = 1
	ORDER BY pt.ID
;

END