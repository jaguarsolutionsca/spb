

CREATE FUNCTION dbo.jag_GetSuperficieContingente
	(
		@Annee INT,
		@PeriodeContingentement INT,
		@ContingentUsine BIT,	
		@ProducteurID varchar(6)
	)
RETURNS float
AS

BEGIN

	declare @SupContingente float

	set @SupContingente =
   	(select top 1 Superficie_Contingentee
	from Contingentement_Producteur CP
		INNER JOIN Contingentement C ON C.[ID] = CP.ContingentementID
	WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
	AND (CP.ProducteurID = @ProducteurID)
	AND (C.ContingentUsine = @ContingentUsine)

	order by date_modification desc
	)

if @SupContingente is null 
BEGIN
	set @SupContingente = 0
END

RETURN @SupContingente
END












