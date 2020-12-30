

CREATE PROCEDURE [dbo].[jag_Get_SurfaceContingente]
	(
		@Annee int,
		@ContingentID varchar(15) = null,
		@DateContingent datetime = Null
	)
AS

declare @UtiliserLotsContingentes bit
set @UtiliserLotsContingentes = 0

if ((select count(*) from jag_SystemEx WHERE [Name] = 'UtiliserLotsContingentes') > 0)
BEGIN
	if ((SELECT UPPER([Value]) FROM jag_SystemEx WHERE [Name] = 'UtiliserLotsContingentes') = 'TRUE')
	BEGIN
		SET @UtiliserLotsContingentes = 1
	END	
END

IF (@UtiliserLotsContingentes = 0)
BEGIN
	Select
	dbo.jag_CalculateSuperficieContingente(sum(L.Superficie_boisee)) AS [SuperficieContingentee]

	From Lot L
	WHERE (L.ID in (select [ID] from dbo.jag_GetLotsForContingentID(@ContingentID, @DateContingent)))
	AND ((L.Actif = 1) OR (L.Actif IS NULL))
	AND ((L.OGC = 0) OR (L.OGC IS NULL))
END
ELSE
BEGIN
	select
	dbo.jag_CalculateSuperficieContingente(sum(LC.SuperficieContingentee)) AS [SuperficieContingentee]
	from LotContingente LC
		INNER JOIN Lot L ON L.[ID] = LC.LotID
	WHERE LC.Annee = @Annee
	AND LC.FournisseurID = @ContingentID
	AND ((L.Actif = 1) OR (L.Actif IS NULL))
	AND ((L.OGC = 0) OR (L.OGC IS NULL))
END



