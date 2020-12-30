








CREATE PROCEDURE dbo.jag_GetPrev_GestionVolumeID
	(
		@ID INT output
	)
AS

DECLARE @ID_prev INT
SET @ID_prev = @ID

SELECT TOP 1
@ID = [ID]
FROM GestionVolume
WHERE [ID] < @ID
ORDER BY [ID] DESC

IF (@ID = @ID_prev)
BEGIN
	SET @ID = NULL
END








