

CREATE FUNCTION dbo.jag_GetVolumePrevueContrat
	(
		@Annee INT,
		@RegroupementID VARCHAR(6),
		@UniteMesureID VARCHAR(6)
	)
RETURNS FLOAT
AS

BEGIN
	DECLARE @volume INT
	
	SELECT
	@volume = SUM(Quantite_prevue * (CASE WHEN CU.Facteur IS NOT NULL THEN CU.Facteur ELSE 0 END))
	FROM Contrat_EssenceUnite CEU
		INNER JOIN Contrat C ON C.[ID] = CEU.ContratID
		LEFT OUTER JOIN Contingentement Co ON Co.Annee = @Annee AND Co.RegroupementID = @RegroupementID
		LEFT OUTER JOIN Contingentement_Unite CU ON CU.ContingentementID = Co.ID AND CU.UniteID = @UniteMesureID
	WHERE ((@Annee IS NULL)OR(C.Annee = @Annee))
	AND CEU.[EssenceID] IN (SELECT [ID] FROM Essence WHERE RegroupementID = @RegroupementID)
	
RETURN @volume
END









