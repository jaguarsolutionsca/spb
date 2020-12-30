

CREATE FUNCTION dbo.jag_GetVolumeAccordeContingentement
	(
		@Annee INT,
		@RegroupementID INT
	)
RETURNS FLOAT
AS

BEGIN
	DECLARE @volume INT
	
	select
	@volume = SUM(Volume_Accorde)
	from Contingentement_Producteur CP
	where CP.[ContingentementID] in (select [ID] from Contingentement where Annee = @Annee AND ContingentUsine = 0 AND RegroupementID = @RegroupementID)
	
RETURN @volume
END









