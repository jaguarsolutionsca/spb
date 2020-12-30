

CREATE FUNCTION dbo.jag_GetLotSuperficieContingentee
	(
		@LotID INT,
		@Annee INT = NULL
	)
RETURNS float
AS

BEGIN

	declare @SupContingente float

	declare @UtiliserLotsContingentes bit
	set @UtiliserLotsContingentes = 0

	if ((select count(*) from jag_SystemEx WHERE [Name] = 'UtiliserLotsContingentes') > 0)
	BEGIN
		if ((SELECT UPPER([Value]) FROM jag_SystemEx WHERE [Name] = 'UtiliserLotsContingentes') = 'TRUE')
		BEGIN
			SET @UtiliserLotsContingentes = 1
		END	
	END
	
	IF (@UtiliserLotsContingentes = 1)
	BEGIN
		select
		@SupContingente = LC.SuperficieContingentee
		from LotContingente LC
		WHERE LC.Annee = @Annee
		AND (LC.LotID = @LotID)
	END
	ELSE 
	BEGIN
		SELECT @SupContingente = Superficie_boisee FROM Lot L WHERE L.[ID] = @LotID
	END


	SET @SupContingente = (CASE WHEN @SupContingente IS NOT NULL THEN @SupContingente ELSE 0 END)

RETURN @SupContingente
END


