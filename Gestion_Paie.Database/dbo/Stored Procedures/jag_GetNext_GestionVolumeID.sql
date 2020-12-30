








CREATE PROCEDURE dbo.jag_GetNext_GestionVolumeID
	(
		@ID INT output
	)
AS

DECLARE @ID_prev INT
SET @ID_prev = @ID

SELECT TOP 1
@ID = [ID]
FROM GestionVolume
WHERE [ID] > @ID
ORDER BY [ID]

IF (@ID = @ID_prev)
BEGIN
	SET @ID = NULL
END








