


CREATE PROCEDURE [dbo].[jag_GetLast_ContingentementDemandeID]
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Contingentement_Demande
ORDER BY [ID] desc
	
RETURN 




