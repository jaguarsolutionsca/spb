

CREATE FUNCTION dbo.jag_GetDroitCoupeLot
	(
		@ProducteurID VARCHAR(15),
		@Date smalldatetime
	)
RETURNS TABLE 

AS

Return
(
	
	SELECT
	L.CantonID,
	L.Rang,
	L.Lot
	FROM Lot L
	WHERE ((L.Droit_coupe_Date IS NOT NULL) AND (L.Droit_coupe_Date >= @Date) AND (Droit_coupeID = @ProducteurID))
	OR (((L.Droit_coupe_Date IS NULL) OR (L.Droit_coupe_Date < @Date)) AND (ProprietaireID = @ProducteurID))

)









