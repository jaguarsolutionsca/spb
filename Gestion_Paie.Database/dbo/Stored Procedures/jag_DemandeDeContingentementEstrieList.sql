CREATE PROCEDURE [dbo].[jag_DemandeDeContingentementEstrieList]
@ProducteurDebut VARCHAR (15)=NULL, @ProducteurFin VARCHAR (15)=NULL, @LivraisonDemandeAnnee INT=NULL
AS
SET NOCOUNT ON


DECLARE @prods TABLE
(
	ProdID VARCHAR(15)
)


IF (@LivraisonDemandeAnnee IS NOT NULL)
BEGIN

	INSERT INTO @prods
	SELECT DISTINCT DroitCoupeID 
	FROM Livraison L 
	WHERE L.Facture=1 AND L.Annee >= @LivraisonDemandeAnnee
	and((@ProducteurDebut IS NULL) OR (DroitCoupeID >= @ProducteurDebut)) AND ((@ProducteurFin IS NULL) OR (DroitCoupeID <= @ProducteurFin))
	
	INSERT INTO @prods
	SELECT DISTINCT EntentePaiementID 
	FROM Livraison L 
	WHERE L.Facture=1 AND L.Annee >= @LivraisonDemandeAnnee AND EntentePaiementID NOT IN (SELECT ProdID FROM @prods)
	and((@ProducteurDebut IS NULL) OR ([EntentePaiementID] >= @ProducteurDebut)) AND ((@ProducteurFin IS NULL) OR ([EntentePaiementID] <= @ProducteurFin))
	
	INSERT INTO @prods
	SELECT DISTINCT ProducteurID 
	FROM contingentement_Demande D 
	WHERE  D.Annee >= @LivraisonDemandeAnnee AND ProducteurID NOT IN (SELECT ProdID FROM @prods)
	and((@ProducteurDebut IS NULL) OR (ProducteurID >= @ProducteurDebut)) AND ((@ProducteurFin IS NULL) OR (ProducteurID <= @ProducteurFin))	
	
END


SELECT 
[ID]
FROM Fournisseur
WHERE (((@ProducteurDebut IS NULL) OR ([ID] >= @ProducteurDebut)) AND ((@ProducteurFin IS NULL) OR ([ID] <= @ProducteurFin)))
AND Fournisseur.Actif = 1
and ((@LivraisonDemandeAnnee IS NULL) or ([ID] in (SELECT ProdID FROM @prods)))
ORDER BY RIGHT(('0000000000000000000000000' + [ID]),15)


