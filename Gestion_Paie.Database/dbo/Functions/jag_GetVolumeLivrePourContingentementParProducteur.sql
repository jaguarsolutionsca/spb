

CREATE FUNCTION dbo.jag_GetVolumeLivrePourContingentementParProducteur
	(
		@ContingentementID int,
		@ProducteurID varchar(15)
	)
RETURNS float
AS

BEGIN
	declare @Volume float

	SELECT 
	@Volume = SUM(LD.VolumeContingente * (CASE WHEN CU.Facteur IS NOT NULL THEN CU.Facteur ELSE 0 END))
	FROM Livraison_Detail LD
		LEFT OUTER JOIN Contingentement_Unite CU ON CU.ContingentementID = LD.ContingentementID AND CU.UniteID = LD.UniteMesureID
	WHERE (LD.ContingentementID = @ContingentementID )
	AND ((@ProducteurID IS NULL) OR (LD.ProducteurID = @ProducteurID))
	
	SELECT @Volume = (CASE WHEN @Volume IS NOT NULL THEN @Volume ELSE 0 END)

RETURN @Volume
END









