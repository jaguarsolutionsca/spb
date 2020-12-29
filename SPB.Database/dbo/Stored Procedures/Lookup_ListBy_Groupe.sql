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
		CAST(ROW_NUMBER() OVER(order by ID) as int) [id],
		0 [cie],
		ID [code],
		Nom [description],
		NULL [value1],
		NULL [value2],
		NULL [value3],
		1950 [started],
		NULL [ended],
		NULL [sortOrder],
		CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.Pays
	ORDER BY Nom

ELSE IF @groupe = 'institutionBanquaire'
	SELECT
		CAST(ID as int) [id],
		0 [cie],
		ID [code],
		Description,
		NULL [value1],
		NULL [value2],
		NULL [value3],
		1950 [started],
		NULL [ended],
		NULL [sortOrder],
		CAST(0 as bit) [disabled]
	FROM Gestion_Paie.dbo.InstitutionBanquaire
	WHERE Actif = 1
	ORDER BY Description

;

END