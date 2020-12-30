

CREATE PROCEDURE dbo.jag_Get_UsineUniteMesure_From_Livraisons
	(
		@DateDebut SMALLDATETIME,
		@DateFin SMALLDATETIME,
		@UsineDebut VARCHAR(6),
		@UsineFin VARCHAR(6)
	)
AS

SET NOCOUNT ON

SELECT DISTINCT
C.UsineID,
L.UniteMesureID
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID

where 
	( L.Facture = 1 )
AND ((@UsineDebut	is null) or (C.UsineID >= @UsineDebut))
AND ((@UsineFin 	is null) or (C.UsineID <= @UsineFin))
AND ((@DateDebut 	is null) or (DATEDIFF(day, @DateDebut, L.DatePaye) >= 0))
AND ((@DateFin 		is null) or (DATEDIFF(day, @DateFin, L.DatePaye) <= 0))



