CREATE PROCEDURE [dbo].[jag_GetCalculs_Livraison]
@LivraisonID INT
AS
DECLARE @Facture bit 
select @Facture = (select Facture from Livraison where [ID] = @LivraisonID)

If ((@Facture is Null) or (@Facture = 0))
Begin
	Exec jag_Calculate_Livraison @LivraisonID
END

UPDATE Livraison SET Frais_ChargeurAuProducteur = 0 WHERE Frais_ChargeurAuProducteur IS NULL
UPDATE Livraison SET Frais_ChargeurAuTransporteur = 0 WHERE Frais_ChargeurAuTransporteur IS NULL

SELECT
Livraison_Detail.[ID],
Livraison_Detail.EssenceID,
Livraison_Detail.Code,
Livraison_Detail.UniteMesureID,
Livraison_Detail.ProducteurID,
Livraison_Detail.ProducteurID + ' - ' + Fournisseur.Nom AS [Producteur],
L.MunicipaliteID,
L.MunicipaliteID + ' - ' + Municipalite.[Description] AS [Municipalite],
Livraison_Detail.VolumeNet AS [Volume],
Livraison_Detail.Taux_Usine AS [Taux],
(CASE WHEN Livraison_Detail.Taux_Usine_Override IS NULL THEN CONVERT(BIT,0) ELSE Livraison_Detail.Taux_Usine_Override END) AS [Taux_Usine_Override],
Livraison_Detail.Montant_Usine AS [Montant]
FROM Livraison_Detail
	INNER JOIN Livraison L ON L.[ID] = Livraison_Detail.LivraisonID
--	inner join Lot L on Livraison.LotID = L.ID
	INNER JOIN Fournisseur ON Fournisseur.[ID] = Livraison_Detail.ProducteurID
	INNER JOIN Municipalite ON Municipalite.[ID] = L.MunicipaliteID
WHERE [LivraisonID] = @LivraisonID
ORDER BY Livraison_Detail.EssenceID ASC, Livraison_Detail.Droit_Coupe DESC

SELECT
Livraison_Detail.[ID],
Livraison_Detail.EssenceID,
Livraison_Detail.Code,
Livraison_Detail.UniteMesureID,
Livraison_Detail.ProducteurID,
Livraison_Detail.ProducteurID + ' - ' + Fournisseur.Nom AS [Producteur],
L.MunicipaliteID,
L.MunicipaliteID + ' - ' + Municipalite.[Description] AS [Municipalite],
L.ZoneID,
L.ZoneID + ' - ' + Z.[Description] as Zone,
Livraison_Detail.VolumeNet AS [Volume],
Livraison_Detail.Taux_Producteur,
(CASE WHEN Livraison_Detail.Taux_Producteur_Override IS NULL THEN CONVERT(BIT,0) ELSE Livraison_Detail.Taux_Producteur_Override END) AS [Taux_Producteur_Override],
Livraison_Detail.Montant_ProducteurBrut,
Livraison_Detail.Taux_TransporteurMoyen,
(CASE WHEN Livraison_Detail.Taux_TransporteurMoyen_Override IS NOT NULL THEN Livraison_Detail.Taux_TransporteurMoyen_Override ELSE CONVERT(BIT,1) END) AS [Taux_TransporteurMoyen_Override],
Livraison_Detail.Montant_TransporteurMoyen,
Livraison_Detail.Taux_Preleve_Plan_Conjoint,
Livraison_Detail.Montant_Preleve_Plan_Conjoint,
Livraison_Detail.Taux_Preleve_Fond_Roulement,
Livraison_Detail.Montant_Preleve_Fond_Roulement,
Livraison_Detail.Taux_Preleve_Fond_Forestier,
Livraison_Detail.Montant_Preleve_Fond_Forestier,
Livraison_Detail.Taux_Preleve_Divers,
Livraison_Detail.Montant_Preleve_Divers,
ROUND((Livraison_Detail.Montant_Preleve_Plan_Conjoint + Livraison_Detail.Montant_Preleve_Fond_Roulement + Livraison_Detail.Montant_Preleve_Fond_Forestier + Livraison_Detail.Montant_Preleve_Divers),2) AS [Montant_Preleve],
Montant_ProducteurNet AS [Montant_ProducteurNet]
FROM Livraison_Detail
	INNER JOIN Livraison L ON L.[ID] = Livraison_Detail.LivraisonID
	INNER JOIN Fournisseur ON Fournisseur.[ID] = Livraison_Detail.ProducteurID
--	inner join Lot L on Livraison.LotID = L.ID
	inner join Municipalite_Zone as Z on L.ZoneID = Z.[ID] and L.MunicipaliteID = Z.[MunicipaliteID]
	INNER JOIN Municipalite ON Municipalite.[ID] = L.MunicipaliteID
WHERE [LivraisonID] = @LivraisonID
ORDER BY Livraison_Detail.EssenceID ASC, Livraison_Detail.Droit_Coupe DESC

SELECT
L.TransporteurID,
L.TransporteurID + ' - ' + Fournisseur.Nom AS [Transporteur],
L.UniteMesureID,
L.MunicipaliteID,
L.MunicipaliteID + ' - ' + Municipalite.[Description] AS [Municipalite],
L.VolumeAPayer,
L.VolumeSurcharge,
L.Taux_Transporteur AS [Taux],
(CASE WHEN L.Taux_Transporteur_Override IS NULL THEN CONVERT(BIT,0) ELSE L.Taux_Transporteur_Override END) AS [Taux_Transporteur_Override],
L.Montant_Transporteur,
L.Montant_Surcharge
FROM Livraison  L
	INNER JOIN Fournisseur ON Fournisseur.[ID] = L.TransporteurID
--	inner join Lot L on Livraison.LotID = L.ID
	INNER JOIN Municipalite ON Municipalite.[ID] = L.MunicipaliteID
WHERE L.[ID] = @LivraisonID

SELECT
Montant_Usine - Frais_AutresAuProducteur - Frais_AutresAuProducteurTransportSciage - Frais_AutresAuTransporteur + Frais_AutresRevenusProducteur + Frais_AutresRevenusTransporteur AS [Montant_Usine],
ROUND((Montant_Producteur1 - Frais_ChargeurAuProducteur - Frais_AutresAuProducteur - Frais_AutresAuProducteurTransportSciage - Frais_CompensationDeDeplacement + L.Montant_Producteur2 + L.Frais_AutresRevenusProducteur),2) AS [Montant_Producteur],
ROUND((L.Montant_Preleve_Plan_Conjoint),2) AS [Montant_Preleve_Plan_Conjoint],
ROUND((L.Montant_Preleve_Fond_Roulement),2) AS [Montant_Preleve_Fond_Roulement],
ROUND((L.Montant_Preleve_Fond_Forestier),2) AS [Montant_Preleve_Fond_Forestier],
ROUND((L.Montant_Preleve_Divers),2) AS [Montant_Preleve_Divers],
L.Montant_Chargeur,
Montant_Transporteur - Frais_ChargeurAuTransporteur - Frais_AutresAuTransporteur + Frais_AutresRevenusTransporteur + Frais_CompensationDeDeplacement AS [Montant_Transporteur],
L.Montant_Surcharge,
L.Montant_SurchargeProducteur,
Montant_MiseEnCommun AS [Montant_MiseEnCommun],
Frais_ChargeurAuProducteur,
(CASE WHEN TauxChargeurAuProducteur IS NOT NULL THEN TauxChargeurAuProducteur ELSE 0 END) AS [Taux_ChargeurAuProducteur],
Frais_ChargeurAuTransporteur,
(CASE WHEN TauxChargeurAuTransporteur IS NOT NULL THEN TauxChargeurAuTransporteur ELSE 0 END) AS [Taux_ChargeurAuTransporteur],
Frais_AutresAuProducteur,
Frais_AutresAuProducteurDescription,
Frais_AutresAuProducteurTransportSciage,
Frais_AutresAuTransporteur,
Frais_AutresAuTransporteurDescription,
Frais_CompensationDeDeplacement,
Frais_AutresRevenusProducteur,
Frais_AutresRevenusProducteurDescription,
Frais_AutresRevenusTransporteur,
Frais_AutresRevenusTransporteurDescription,
Commentaires_Producteur,
Commentaires_Transporteur,
Commentaires_Chargeur
FROM Livraison L
WHERE [ID] = @LivraisonID


