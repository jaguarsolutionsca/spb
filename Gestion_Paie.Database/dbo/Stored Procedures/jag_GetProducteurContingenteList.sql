CREATE PROCEDURE [dbo].[jag_GetProducteurContingenteList]
@ProducteurDebut VARCHAR (15), @ProducteurFin VARCHAR (15), @Annee INT, @PeriodeContingentement INT, @ContingentUsine BIT, @Imprime BIT=null
AS
SET NOCOUNT ON

SELECT DISTINCT
CP.ProducteurID,
F.[Nom],
C.Annee,
C.PeriodeContingentement,
C.ContingentUsine,
CD.TransporteurID
FROM Contingentement C
	INNER JOIN Contingentement_Producteur CP ON CP.[ContingentementID] = C.[ID]
	INNER JOIN Fournisseur F ON F.[ID] = CP.ProducteurID
	INNER JOIN Contingentement_Demande CD ON CD.[ProducteurID] = CP.[ProducteurID] AND CD.[Annee] = C.[Annee]
WHERE ((@ProducteurDebut IS NULL) OR (CP.[ProducteurID] >= @ProducteurDebut))
AND ((@ProducteurFin IS NULL) OR (CP.[ProducteurID] <= @ProducteurFin))
AND ((@Annee IS NULL) OR (C.Annee = @Annee))
AND ((@PeriodeContingentement IS NULL) OR (C.PeriodeContingentement = @PeriodeContingentement))
AND (C.ContingentUsine = @ContingentUsine)
AND (C.CalculAccepte = 1)
and ((@Imprime is NULL) or (CP.Imprime = @Imprime))
ORDER BY F.[Nom]


