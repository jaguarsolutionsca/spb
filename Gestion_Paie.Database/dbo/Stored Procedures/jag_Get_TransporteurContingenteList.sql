

CREATE PROCEDURE [dbo].[jag_Get_TransporteurContingenteList]
	(
		@TransporteurDebut VARCHAR(15),
		@TransporteurFin VARCHAR(15),
		@Annee INT,
		@PeriodeContingentement INT,
		@ContingentUsine BIT
	)
AS

SET NOCOUNT ON

SELECT DISTINCT
CD.TransporteurID,
F.[Nom],
C.Annee,
C.PeriodeContingentement,
C.ContingentUsine

FROM Contingentement C
	INNER JOIN Contingentement_Producteur CP ON CP.[ContingentementID] = C.[ID]
	INNER JOIN Contingentement_Demande CD ON CD.[ProducteurID] = CP.[ProducteurID] AND CD.[Annee] = C.[Annee]
	INNER JOIN Fournisseur F ON F.[ID] = CD.[TransporteurID]
WHERE ((@TransporteurDebut IS NULL) OR (CD.[TransporteurID] >= @TransporteurDebut))
AND ((@TransporteurFin IS NULL) OR (CD.[TransporteurID] <= @TransporteurFin))
AND ((@Annee IS NULL) OR (C.Annee = @Annee))
AND ((@PeriodeContingentement IS NULL) OR (C.PeriodeContingentement = @PeriodeContingentement))
AND (C.ContingentUsine = @ContingentUsine)
AND  (CD.[TransporteurID] is not null)
AND (C.CalculAccepte = 1)
ORDER BY F.[Nom]






