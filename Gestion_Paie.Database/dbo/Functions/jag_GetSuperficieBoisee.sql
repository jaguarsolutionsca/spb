

CREATE FUNCTION dbo.jag_GetSuperficieBoisee
	(
	 @ProprietaireID varchar(6) = Null
	,@DateLimite datetime = Null
	)
RETURNS float
AS

BEGIN
	declare @SupBoisee float

	set @SupBoisee =
   (select sum(Superficie_boisee)
	from Lot
	where 
			((Lot.Droit_coupeID = @ProprietaireID)	AND (Lot.Droit_coupe_Date	>=  @DateLimite))
		OR	(((Lot.Droit_coupeID IS NULL)	OR	(Lot.Droit_coupeID = Lot.ProprietaireID))	AND (Lot.ProprietaireID		= @ProprietaireID))
		OR	((ProprietaireID = @ProprietaireID)	AND	(Droit_coupe_Date	< @DateLimite))		
	)
RETURN @SupBoisee
END









