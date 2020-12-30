

CREATE PROCEDURE dbo.jag_Get_UsineUniteMesure_From_Factures
	(
		@DateDebut SMALLDATETIME,
		@DateFin SMALLDATETIME
	)
AS

SET NOCOUNT ON

SELECT DISTINCT
C.UsineID,
L.UniteMesureID
FROM Livraison L
	INNER JOIN FactureClient FC ON FC.[ID] = L.Usine_FactureID
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
AND ( L.Facture = 1 )
AND ( DATEDIFF(day, @DateDebut, FC.DateFacture) >= 0 AND DATEDIFF(day, @DateFin, FC.DateFacture) <= 0)








