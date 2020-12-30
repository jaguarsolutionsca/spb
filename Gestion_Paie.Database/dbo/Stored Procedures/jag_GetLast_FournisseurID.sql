

CREATE PROCEDURE dbo.jag_GetLast_FournisseurID
	(
		@ID varchar(15) output,
		@TypeFournisseurID char(1) = NULL
	)
AS
	
SELECT TOP 1
@ID = [ID]
FROM Fournisseur
WHERE ((@TypeFournisseurID IS NULL) OR 
((@TypeFournisseurID = 'P') and (IsProducteur = 1)) OR
((@TypeFournisseurID = 'T') and (IsTransporteur = 1)) OR
((@TypeFournisseurID = 'C') and (IsChargeur = 1)) OR
((@TypeFournisseurID = 'A') and (IsAutre = 1)))
ORDER BY [ID] DESC
	
RETURN 









