CREATE PROCEDURE [dbo].[jag_GetCalculs_Ajustement]
	(
		@AjustementID int
	)
AS

DECLARE @Facture bit 
select @Facture = (select Facture from Ajustement where [ID] = @AjustementID)

If (@Facture is Null) or (@Facture = 0) 
Begin
	Exec jag_Calculate_Ajustement @AjustementID
END

SELECT
Livraison_Detail.LivraisonID,
AjustementCalcule_Producteur.EssenceID,
AjustementCalcule_Producteur.Code,
AjustementCalcule_Producteur.UniteID,
AjustementCalcule_Producteur.ProducteurID,
AjustementCalcule_Producteur.ProducteurID + ' - ' + Fournisseur.Nom AS [Producteur],
AjustementCalcule_Producteur.Volume,
AjustementCalcule_Producteur.Taux,
AjustementCalcule_Producteur.Montant,
Fournisseur.Actif
FROM AjustementCalcule_Producteur
	INNER JOIN Livraison_Detail ON Livraison_Detail.[ID] = LivraisonDetailID
	INNER JOIN Fournisseur ON Fournisseur.[ID] = AjustementCalcule_Producteur.ProducteurID
WHERE AjustementID = @AjustementID
ORDER BY Livraison_Detail.LivraisonID, AjustementCalcule_Producteur.EssenceID, AjustementCalcule_Producteur.UniteID, AjustementCalcule_Producteur.ProducteurID, AjustementCalcule_Producteur.Montant DESC

SELECT
Livraison_Detail.LivraisonID,
AjustementCalcule_Usine.EssenceID,
AjustementCalcule_Usine.Code,
AjustementCalcule_Usine.UniteID,
AjustementCalcule_Usine.UsineID,
Usine.[Description] AS [Usine],
AjustementCalcule_Usine.Volume,
AjustementCalcule_Usine.Taux,
AjustementCalcule_Usine.Montant
FROM AjustementCalcule_Usine
	INNER JOIN Livraison_Detail ON Livraison_Detail.[ID] = LivraisonDetailID
	INNER JOIN Usine ON Usine.[ID] = AjustementCalcule_Usine.UsineID
WHERE AjustementID = @AjustementID
ORDER BY Livraison_Detail.LivraisonID, AjustementCalcule_Usine.EssenceID, AjustementCalcule_Usine.UniteID, AjustementCalcule_Usine.UsineID, AjustementCalcule_Usine.Montant DESC

SELECT
AjustementCalcule_Transporteur.LivraisonID,
AjustementCalcule_Transporteur.UniteID,
AjustementCalcule_Transporteur.MunicipaliteID,
AjustementCalcule_Transporteur.ZoneID,
AjustementCalcule_Transporteur.TransporteurID,
AjustementCalcule_Transporteur.TransporteurID + ' - ' + Fournisseur.Nom AS [Transporteur],
AjustementCalcule_Transporteur.Volume,
AjustementCalcule_Transporteur.Taux,
AjustementCalcule_Transporteur.Montant
FROM AjustementCalcule_Transporteur
	INNER JOIN Fournisseur ON Fournisseur.[ID] = AjustementCalcule_Transporteur.TransporteurID
WHERE AjustementID = @AjustementID
ORDER BY AjustementCalcule_Transporteur.LivraisonID, AjustementCalcule_Transporteur.UniteID, AjustementCalcule_Transporteur.MunicipaliteID, AjustementCalcule_Transporteur.ZoneID, AjustementCalcule_Transporteur.TransporteurID, AjustementCalcule_Transporteur.Montant DESC

SELECT
Livraison_Detail.LivraisonID,
AjustementCalcule_TransporteurEssence.EssenceID,
AjustementCalcule_TransporteurEssence.Code,
AjustementCalcule_TransporteurEssence.UniteID,
AjustementCalcule_TransporteurEssence.TransporteurID,
AjustementCalcule_TransporteurEssence.TransporteurID + ' - ' + Fournisseur.Nom AS [Transporteur],
AjustementCalcule_TransporteurEssence.Volume,
AjustementCalcule_TransporteurEssence.Taux,
AjustementCalcule_TransporteurEssence.Montant,
Fournisseur.Actif
FROM AjustementCalcule_TransporteurEssence
	INNER JOIN Livraison_Detail ON Livraison_Detail.[ID] = LivraisonDetailID
	INNER JOIN Fournisseur ON Fournisseur.[ID] = AjustementCalcule_TransporteurEssence.TransporteurID
WHERE AjustementID = @AjustementID
ORDER BY Livraison_Detail.LivraisonID, AjustementCalcule_TransporteurEssence.EssenceID, AjustementCalcule_TransporteurEssence.UniteID, AjustementCalcule_TransporteurEssence.TransporteurID, AjustementCalcule_TransporteurEssence.Montant DESC
