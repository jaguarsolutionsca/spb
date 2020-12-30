


CREATE PROCEDURE [dbo].[jag_GetFirst_ContingentementDemandeID]
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Contingentement_Demande
ORDER BY [ID] ASC
	
RETURN 




