

CREATE PROCEDURE [dbo].[jag_AutorisationDesLivraisonsSommaireTransporteur]
	(
		@Annee INT,
		@PeriodeContingentement INT,
		@ContingentUsine BIT,		
		@TransporteurID VARCHAR(15)
	)

AS

SET NOCOUNT ON

IF NOT EXISTS (SELECT *
		FROM Contingentement_Producteur CP
			INNER JOIN Contingentement C ON C.[ID] = CP.[ContingentementID]
			INNER JOIN Contingentement_Demande CD ON CD.[ProducteurID] = CP.[ProducteurID] AND CD.[Annee] = C.[Annee]
		WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
		AND (CD.TransporteurID = @TransporteurID)
		AND (C.ContingentUsine = @ContingentUsine)
		AND (CP.Volume_Accorde > 0)
		AND (C.CalculAccepte = 1))
BEGIN
	RETURN
END


IF (@ContingentUsine = 1)
BEGIN
	SELECT
	E.[Description] AS [Essence],
	UM.[ID] AS [Unite],
	U.[Description] AS [Usine],
	sum(CP.Volume_Accorde) AS [Volume_Alloue]
	FROM Contingentement C
		INNER JOIN Contingentement_Producteur CP ON CP.[ContingentementID] = C.[ID]
		INNER JOIN Contingentement_Demande CD ON CD.[ProducteurID] = CP.[ProducteurID] AND CD.[Annee] = C.[Annee]
		INNER JOIN Fournisseur F ON F.[ID] = CP.[ProducteurID]
		INNER JOIN Essence E ON E.[ID] = C.EssenceID
		INNER JOIN UniteMesure UM ON UM.[ID] = C.UniteMesureID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
	AND (CD.TransporteurID = @TransporteurID)
	AND (C.ContingentUsine = @ContingentUsine)
	AND (CP.Volume_Accorde > 0)	
	AND (C.CalculAccepte = 1)
	Group by E.[Description], UM.[ID],U.[Description]
END
ELSE IF (@ContingentUsine = 0)
BEGIN
SELECT
	ER.[Description] AS [Regroupement],
	UM.[ID] AS [Unite],
	sum(CP.Volume_Accorde) AS [Volume_Alloue]
	FROM Contingentement C
		INNER JOIN Contingentement_Producteur CP ON CP.[ContingentementID] = C.[ID]
		INNER JOIN Contingentement_Demande CD ON CD.[ProducteurID] = CP.[ProducteurID] AND CD.[Annee] = C.[Annee]
		INNER JOIN Fournisseur F ON F.[ID] = CP.[ProducteurID]
		INNER JOIN EssenceRegroupement ER ON ER.[ID] = C.RegroupementID
		INNER JOIN UniteMesure UM ON UM.[ID] = C.UniteMesureID
	WHERE ((C.Annee = @Annee) AND (C.PeriodeContingentement = @PeriodeContingentement))
	AND (CD.TransporteurID = @TransporteurID)
	AND (C.ContingentUsine = @ContingentUsine)
	AND (CP.Volume_Accorde > 0)	
	AND (C.CalculAccepte = 1)
	Group by ER.[Description], UM.[ID]
END








