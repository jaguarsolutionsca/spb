

CREATE PROCEDURE dbo.jag_DemandeDeContingentementList
	(
		@ProducteurDebut VARCHAR(15) = NULL,
		@ProducteurFin VARCHAR(15) = NULL,
		@ContinAnnee INT = NULL,
		@ContinPeriode INT = NULL,
		@LivraisonAnnee INT = NULL
	)

AS

SET NOCOUNT ON

DECLARE @ContinDernierePeriode BIT
SET @ContinDernierePeriode = 0

DECLARE @Date SMALLDATETIME
SET @Date = GetDate()

DECLARE @prods TABLE
(
	ProdID VARCHAR(15)
)

DECLARE @prods2 TABLE
(
	ProdID VARCHAR(15)
)

IF (@LivraisonAnnee IS NOT NULL)
BEGIN
	INSERT INTO @prods2
	SELECT DISTINCT DroitCoupeID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee
	
	INSERT INTO @prods2
	SELECT DISTINCT EntentePaiementID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee AND EntentePaiementID NOT IN (SELECT ProdID FROM @prods2)
END

IF ((@ContinAnnee IS NOT NULL) AND (@ContinPeriode IS NOT NULL))
BEGIN
	SET @ContinDernierePeriode = 1
END

IF (@ContinDernierePeriode = 1)
BEGIN
	INSERT INTO @prods
	SELECT DISTINCT
	ProducteurID
	FROM Contingentement_Producteur CP
		INNER JOIN Contingentement C ON C.[ID] = CP.ContingentementID
	WHERE (C.Annee = @ContinAnnee)
	AND (C.PeriodeContingentement = @ContinPeriode)
END

SELECT
[ID]
FROM Fournisseur
WHERE (((@ProducteurDebut IS NULL) OR ([ID] >= @ProducteurDebut)) AND ((@ProducteurFin IS NULL) OR ([ID] <= @ProducteurFin)))
AND dbo.jag_GetCountDroitCoupeLot (Fournisseur.[ID], @Date) > 0
AND Fournisseur.Actif = 1
AND ((@ContinDernierePeriode = 0) OR ([ID] in (SELECT ProdID FROM @prods)))
AND ((@LivraisonAnnee IS NULL) OR ([ID] in (SELECT ProdID FROM @prods2)))
ORDER BY RIGHT(('0000000000000000000000000' + [ID]),15)


