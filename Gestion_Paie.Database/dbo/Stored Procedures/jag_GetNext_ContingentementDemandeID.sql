


CREATE PROCEDURE [dbo].[jag_GetNext_ContingentementDemandeID]
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Contingentement_Demande
WHERE [ID] > @ID
ORDER BY [ID] ASC

IF (NOT EXISTS (SELECT * FROM Contingentement_Demande WHERE [ID] = @ID))
BEGIN
	exec jag_GetLast_ContingentementDemandeID @ID out
END

RETURN 










