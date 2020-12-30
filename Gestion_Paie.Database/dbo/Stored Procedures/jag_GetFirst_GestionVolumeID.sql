








CREATE PROCEDURE dbo.jag_GetFirst_GestionVolumeID
	(
		@ID INT = NULL output
	)
AS

SET @ID = NULL

SELECT TOP 1
@ID = [ID]
FROM GestionVolume
ORDER BY [ID]








