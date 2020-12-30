

CREATE FUNCTION dbo.jag_GetContingentementUniteFacteur
	(
		@UsineID varchar(6),
		@Annee INT,
		@EssenceID varchar(6),
		@Code char(4),
		@UniteMesureID varchar(6)
	)
RETURNS FLOAT
AS

BEGIN
	DECLARE @Facteur FLOAT
	
	SELECT TOP 1 @Facteur = CU.Facteur FROM Contingentement_Unite CU 
		INNER JOIN Contingentement C ON C.[ID] = CU.ContingentementID
	WHERE ((@Annee IS NULL) OR (C.Annee = @Annee))
	AND C.UsineID = @UsineID
	AND C.EssenceID = @EssenceID
	AND C.Code = @Code
	AND C.UniteMesureID = @UniteMesureID
	AND CU.UniteID = @UniteMesureID
	AND CU.Facteur <> 0
	ORDER BY PeriodeContingentement ASC
	
	IF (@Facteur IS NULL) SET @Facteur = 0

RETURN @Facteur
END









