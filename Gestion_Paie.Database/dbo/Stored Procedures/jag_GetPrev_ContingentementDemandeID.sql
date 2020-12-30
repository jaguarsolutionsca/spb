


CREATE PROCEDURE [dbo].[jag_GetPrev_ContingentementDemandeID]
	(
		@ID int output
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Contingentement_Demande
WHERE [ID] < @ID
ORDER BY [ID] desc

RETURN 










