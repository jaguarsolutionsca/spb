CREATE FUNCTION [dbo].[jag_GetVolumeLivrePourContingentementParProducteurPeriode]
(@ContingentementID INT, @ProducteurID VARCHAR (15), @PeriodeFin INT)
RETURNS FLOAT
AS
BEGIN
	declare @Volume float

	SELECT 
	@Volume = SUM(LD.VolumeContingente * (CASE WHEN CU.Facteur IS NOT NULL THEN CU.Facteur ELSE 0 END))
	FROM Livraison_Detail LD
		LEFT OUTER JOIN Contingentement_Unite CU ON CU.ContingentementID = LD.ContingentementID AND CU.UniteID = LD.UniteMesureID
		left join Livraison L on L.ID = LD.LivraisonID
	WHERE (LD.ContingentementID = @ContingentementID )
	AND ((@ProducteurID IS NULL) OR (LD.ProducteurID = @ProducteurID))
	AND ((@PeriodeFin IS NULL) OR (L.Periode <= @PeriodeFin))
	
	SELECT @Volume = (CASE WHEN @Volume IS NOT NULL THEN @Volume ELSE 0 END)

RETURN @Volume
END


