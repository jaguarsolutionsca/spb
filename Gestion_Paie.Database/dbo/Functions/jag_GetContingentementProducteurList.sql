CREATE FUNCTION [dbo].[jag_GetContingentementProducteurList]
(@Annee INT, @PeriodeContingentement INT)
RETURNS TABLE 
AS
RETURN 
    (

	SELECT DISTINCT
	ProducteurID
	FROM Contingentement_Producteur CP
	WHERE CP.ContingentementID IN 
	(
		SELECT [ID] FROM Contingentement C
		WHERE ((@Annee IS NULL) OR (C.Annee = @Annee))
		AND ((@PeriodeContingentement IS NULL) OR (C.PeriodeContingentement = @PeriodeContingentement))
	)
	
)



