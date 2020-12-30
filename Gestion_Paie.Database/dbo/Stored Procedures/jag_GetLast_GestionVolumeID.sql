








CREATE PROCEDURE dbo.jag_GetLast_GestionVolumeID
	(
		@ID INT = NULL output
	)
AS

SET @ID = NULL

SELECT TOP 1
@ID = [ID]
FROM GestionVolume
ORDER BY [ID] DESC








