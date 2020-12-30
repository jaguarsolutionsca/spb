

CREATE PROCEDURE dbo.jag_FactureUsinesList
	(
		@FactureID INT
	)
AS

SET NOCOUNT ON

SELECT DISTINCT
C.UsineID AS [UsineID]
FROM FactureFournisseur_Details FFD
	INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
	INNER JOIN Livraison L ON L.[ID] = FFD.RefID
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE FFD.FactureID = @FactureID
ORDER BY C.UsineID


