﻿CREATE FUNCTION [dbo].[fnLivraison_Permis_Full]
(@LivraisonID INT=Null, @PermisID INT=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select TOP 100 PERCENT
 [Livraison_Permis].[LivraisonID]
,[Livraison_Permis].[PermisID]
,[Livraison_Permis].[NumeroFactureUsine]
,[Livraison1].[ID] [LivraisonID_ID]
,[Livraison1].[DateLivraison] [LivraisonID_DateLivraison]
,[Livraison1].[DatePaye] [LivraisonID_DatePaye]
,[Livraison1].[ContratID] [LivraisonID_ContratID]
,[Livraison1].[UniteMesureID] [LivraisonID_UniteMesureID]
,[Livraison1].[EssenceID] [LivraisonID_EssenceID]
,[Livraison1].[Sciage] [LivraisonID_Sciage]
,[Livraison1].[NumeroFactureUsine] [LivraisonID_NumeroFactureUsine]
,[Livraison1].[DroitCoupeID] [LivraisonID_DroitCoupeID]
,[Livraison1].[EntentePaiementID] [LivraisonID_EntentePaiementID]
,[Livraison1].[TransporteurID] [LivraisonID_TransporteurID]
,[Livraison1].[VR] [LivraisonID_VR]
,[Livraison1].[MasseLimite] [LivraisonID_MasseLimite]
,[Livraison1].[VolumeBrut] [LivraisonID_VolumeBrut]
,[Livraison1].[VolumeTare] [LivraisonID_VolumeTare]
,[Livraison1].[VolumeTransporte] [LivraisonID_VolumeTransporte]
,[Livraison1].[VolumeSurcharge] [LivraisonID_VolumeSurcharge]
,[Livraison1].[VolumeAPayer] [LivraisonID_VolumeAPayer]
,[Livraison1].[Annee] [LivraisonID_Annee]
,[Livraison1].[Periode] [LivraisonID_Periode]
,[Livraison1].[DateCalcul] [LivraisonID_DateCalcul]
,[Livraison1].[Taux_Transporteur] [LivraisonID_Taux_Transporteur]
,[Livraison1].[Montant_Transporteur] [LivraisonID_Montant_Transporteur]
,[Livraison1].[Montant_Usine] [LivraisonID_Montant_Usine]
,[Livraison1].[Montant_Producteur1] [LivraisonID_Montant_Producteur1]
,[Livraison1].[Montant_Producteur2] [LivraisonID_Montant_Producteur2]
,[Livraison1].[Montant_Preleve_Plan_Conjoint] [LivraisonID_Montant_Preleve_Plan_Conjoint]
,[Livraison1].[Montant_Preleve_Fond_Roulement] [LivraisonID_Montant_Preleve_Fond_Roulement]
,[Livraison1].[Montant_Preleve_Fond_Forestier] [LivraisonID_Montant_Preleve_Fond_Forestier]
,[Livraison1].[Montant_Preleve_Divers] [LivraisonID_Montant_Preleve_Divers]
,[Livraison1].[Montant_Surcharge] [LivraisonID_Montant_Surcharge]
,[Livraison1].[Montant_MiseEnCommun] [LivraisonID_Montant_MiseEnCommun]
,[Livraison1].[Facture] [LivraisonID_Facture]
,[Livraison1].[Producteur1_FactureID] [LivraisonID_Producteur1_FactureID]
,[Livraison1].[Producteur2_FactureID] [LivraisonID_Producteur2_FactureID]
,[Livraison1].[Transporteur_FactureID] [LivraisonID_Transporteur_FactureID]
,[Livraison1].[Usine_FactureID] [LivraisonID_Usine_FactureID]
,[Livraison1].[ErreurCalcul] [LivraisonID_ErreurCalcul]
,[Livraison1].[ErreurDescription] [LivraisonID_ErreurDescription]
,[Livraison1].[LotID] [LivraisonID_LotID]
,[Livraison1].[Taux_Transporteur_Override] [LivraisonID_Taux_Transporteur_Override]
,[Livraison1].[PaieTransporteur] [LivraisonID_PaieTransporteur]
,[Livraison1].[VolumeSurcharge_Override] [LivraisonID_VolumeSurcharge_Override]
,[Livraison1].[SurchargeManuel] [LivraisonID_SurchargeManuel]
,[Livraison1].[Code] [LivraisonID_Code]
,[Livraison1].[NombrePermis] [LivraisonID_NombrePermis]
,[Livraison1].[ZoneID] [LivraisonID_ZoneID]
,[Livraison1].[MunicipaliteID] [LivraisonID_MunicipaliteID]
,[Livraison1].[ChargeurID] [LivraisonID_ChargeurID]
,[Livraison1].[Montant_Chargeur] [LivraisonID_Montant_Chargeur]
,[Livraison1].[Frais_ChargeurAuProducteur] [LivraisonID_Frais_ChargeurAuProducteur]
,[Livraison1].[Frais_ChargeurAuTransporteur] [LivraisonID_Frais_ChargeurAuTransporteur]
,[Livraison1].[Frais_AutresAuProducteur] [LivraisonID_Frais_AutresAuProducteur]
,[Livraison1].[Frais_AutresAuProducteurDescription] [LivraisonID_Frais_AutresAuProducteurDescription]
,[Livraison1].[Frais_AutresAuTransporteur] [LivraisonID_Frais_AutresAuTransporteur]
,[Livraison1].[Frais_AutresAuTransporteurDescription] [LivraisonID_Frais_AutresAuTransporteurDescription]
,[Livraison1].[Frais_CompensationDeDeplacement] [LivraisonID_Frais_CompensationDeDeplacement]
,[Livraison1].[Chargeur_FactureID] [LivraisonID_Chargeur_FactureID]
,[Livraison1].[Commentaires_Producteur] [LivraisonID_Commentaires_Producteur]
,[Livraison1].[Commentaires_Transporteur] [LivraisonID_Commentaires_Transporteur]
,[Livraison1].[Commentaires_Chargeur] [LivraisonID_Commentaires_Chargeur]
,[Livraison1].[TauxChargeurAuProducteur] [LivraisonID_TauxChargeurAuProducteur]
,[Livraison1].[TauxChargeurAuTransporteur] [LivraisonID_TauxChargeurAuTransporteur]
,[Livraison1].[Frais_AutresRevenusTransporteur] [LivraisonID_Frais_AutresRevenusTransporteur]
,[Livraison1].[Frais_AutresRevenusTransporteurDescription] [LivraisonID_Frais_AutresRevenusTransporteurDescription]
,[Livraison1].[Frais_AutresRevenusProducteur] [LivraisonID_Frais_AutresRevenusProducteur]
,[Livraison1].[Frais_AutresRevenusProducteurDescription] [LivraisonID_Frais_AutresRevenusProducteurDescription]
,[Permit2].[ID] [PermisID_ID]
,[Permit2].[DatePermit] [PermisID_DatePermit]
,[Permit2].[DateDebut] [PermisID_DateDebut]
,[Permit2].[DateFin] [PermisID_DateFin]
,[Permit2].[Annee] [PermisID_Annee]
,[Permit2].[Periode] [PermisID_Periode]
,[Permit2].[ContratID] [PermisID_ContratID]
,[Permit2].[EssenceID] [PermisID_EssenceID]
,[Permit2].[PermitSciage] [PermisID_PermitSciage]
,[Permit2].[TransporteurID] [PermisID_TransporteurID]
,[Permit2].[VR] [PermisID_VR]
,[Permit2].[ProducteurDroitCoupeID] [PermisID_ProducteurDroitCoupeID]
,[Permit2].[ProducteurEntentePaiementID] [PermisID_ProducteurEntentePaiementID]
,[Permit2].[PermitLivre] [PermisID_PermitLivre]
,[Permit2].[PermitImprime] [PermisID_PermitImprime]
,[Permit2].[PermitAnnule] [PermisID_PermitAnnule]
,[Permit2].[LotID] [PermisID_LotID]
,[Permit2].[EssenceSciage] [PermisID_EssenceSciage]
,[Permit2].[Code] [PermisID_Code]
,[Permit2].[Remarques] [PermisID_Remarques]
,[Permit2].[ChargeurID] [PermisID_ChargeurID]
,[Permit2].[ZoneID] [PermisID_ZoneID]
,[Permit2].[MunicipaliteID] [PermisID_MunicipaliteID]

From [dbo].[Livraison_Permis] [Livraison_Permis]
    Inner Join [dbo].[Livraison] [Livraison1] On [Livraison_Permis].[LivraisonID] = [Livraison1].[ID]
        Inner Join [dbo].[Permit] [Permit2] On [Livraison_Permis].[PermisID] = [Permit2].[ID]

Where

    ((@LivraisonID Is Null) Or ([Livraison_Permis].[LivraisonID] = @LivraisonID))
And ((@PermisID Is Null) Or ([Livraison_Permis].[PermisID] = @PermisID))
)



