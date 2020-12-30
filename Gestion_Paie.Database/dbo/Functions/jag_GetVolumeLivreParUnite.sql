

CREATE FUNCTION dbo.jag_GetVolumeLivreParUnite
	(
		@ContingentementID INT,
		@UniteID varchar(6)
	)
RETURNS FLOAT
AS

BEGIN
	DECLARE @Volume FLOAT
	
	SELECT
	@Volume = SUM(VolumeContingente)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE (LD.ContingentementID = @ContingentementID)
	AND ((@UniteID IS NULL) OR (L.UniteMesureID = @UniteID))
	
	SET @Volume = (CASE WHEN @Volume IS NOT NULL THEN @Volume ELSE 0 END)
	
RETURN @volume
END









