








CREATE PROCEDURE dbo.jag_GetSurface_Municipalite
	(
		@MunicipaliteID varchar(6)
	)
AS
	
	
SELECT 
sum(Superficie_total) as SuperficieTotale,
sum(Superficie_boisee) as SuperficieBoisee,
0 as SuperficieContingent
FROM Lot
where [MunicipaliteID] = @MunicipaliteID
	
RETURN








