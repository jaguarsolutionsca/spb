

CREATE PROCEDURE dbo.jag_EffacerCalculs
	(
		@LivraisonID int
	)
AS

DELETE FROM AjustementCalcule_Transporteur WHERE LivraisonID = @LivraisonID AND ((Facture = 0) OR (Facture IS NULL))

DELETE FROM AjustementCalcule_Producteur 
WHERE LivraisonDetailID in (SELECT [ID] FROM Livraison_Detail WHERE LivraisonID = @LivraisonID)
AND ((Facture = 0) OR (Facture IS NULL))

DELETE FROM AjustementCalcule_Usine 
WHERE LivraisonDetailID in (SELECT [ID] FROM Livraison_Detail WHERE LivraisonID = @LivraisonID)
AND ((Facture = 0) OR (Facture IS NULL))

DELETE FROM IndexationCalcule_Transporteur WHERE LivraisonID = @LivraisonID AND ((Facture = 0) OR (Facture IS NULL))
DELETE FROM IndexationCalcule_Producteur WHERE LivraisonID = @LivraisonID AND ((Facture = 0) OR (Facture IS NULL))








