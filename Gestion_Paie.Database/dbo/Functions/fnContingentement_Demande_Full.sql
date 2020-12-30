
CREATE Function [fnContingentement_Demande_Full]

(
 @ID [int] = Null
,@ProducteurID [varchar](15) = Null
,@TransporteurID [varchar](15) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
 [Contingentement_Demande].[ID]
,[Contingentement_Demande].[Annee]
,[Contingentement_Demande].[ProducteurID]
,[Contingentement_Demande].[TransporteurID]
,[Contingentement_Demande].[Superficie_Boisee]
,[Contingentement_Demande].[Remarques]
,[Contingentement_Demande].[DateModification]
,[Fournisseur1].[ID] [ProducteurID_ID]
,[Fournisseur1].[CleTri] [ProducteurID_CleTri]
,[Fournisseur1].[Nom] [ProducteurID_Nom]
,[Fournisseur1].[AuSoinsDe] [ProducteurID_AuSoinsDe]
,[Fournisseur1].[Rue] [ProducteurID_Rue]
,[Fournisseur1].[Ville] [ProducteurID_Ville]
,[Fournisseur1].[PaysID] [ProducteurID_PaysID]
,[Fournisseur1].[Code_postal] [ProducteurID_Code_postal]
,[Fournisseur1].[Telephone] [ProducteurID_Telephone]
,[Fournisseur1].[Telephone_Poste] [ProducteurID_Telephone_Poste]
,[Fournisseur1].[Telecopieur] [ProducteurID_Telecopieur]
,[Fournisseur1].[Telephone2] [ProducteurID_Telephone2]
,[Fournisseur1].[Telephone2_Desc] [ProducteurID_Telephone2_Desc]
,[Fournisseur1].[Telephone2_Poste] [ProducteurID_Telephone2_Poste]
,[Fournisseur1].[Telephone3] [ProducteurID_Telephone3]
,[Fournisseur1].[Telephone3_Desc] [ProducteurID_Telephone3_Desc]
,[Fournisseur1].[Telephone3_Poste] [ProducteurID_Telephone3_Poste]
,[Fournisseur1].[No_membre] [ProducteurID_No_membre]
,[Fournisseur1].[Resident] [ProducteurID_Resident]
,[Fournisseur1].[Email] [ProducteurID_Email]
,[Fournisseur1].[WWW] [ProducteurID_WWW]
,[Fournisseur1].[Commentaires] [ProducteurID_Commentaires]
,[Fournisseur1].[AfficherCommentaires] [ProducteurID_AfficherCommentaires]
,[Fournisseur1].[DepotDirect] [ProducteurID_DepotDirect]
,[Fournisseur1].[InstitutionBanquaireID] [ProducteurID_InstitutionBanquaireID]
,[Fournisseur1].[Banque_transit] [ProducteurID_Banque_transit]
,[Fournisseur1].[Banque_folio] [ProducteurID_Banque_folio]
,[Fournisseur1].[No_TPS] [ProducteurID_No_TPS]
,[Fournisseur1].[No_TVQ] [ProducteurID_No_TVQ]
,[Fournisseur1].[PayerA] [ProducteurID_PayerA]
,[Fournisseur1].[PayerAID] [ProducteurID_PayerAID]
,[Fournisseur1].[Statut] [ProducteurID_Statut]
,[Fournisseur1].[Rep_Nom] [ProducteurID_Rep_Nom]
,[Fournisseur1].[Rep_Telephone] [ProducteurID_Rep_Telephone]
,[Fournisseur1].[Rep_Telephone_Poste] [ProducteurID_Rep_Telephone_Poste]
,[Fournisseur1].[Rep_Email] [ProducteurID_Rep_Email]
,[Fournisseur1].[EnAnglais] [ProducteurID_EnAnglais]
,[Fournisseur1].[Actif] [ProducteurID_Actif]
,[Fournisseur1].[MRCProducteurID] [ProducteurID_MRCProducteurID]
,[Fournisseur1].[PaiementManuel] [ProducteurID_PaiementManuel]
,[Fournisseur1].[Journal] [ProducteurID_Journal]
,[Fournisseur1].[RecoitTPS] [ProducteurID_RecoitTPS]
,[Fournisseur1].[RecoitTVQ] [ProducteurID_RecoitTVQ]
,[Fournisseur1].[ModifierTrigger] [ProducteurID_ModifierTrigger]
,[Fournisseur1].[IsProducteur] [ProducteurID_IsProducteur]
,[Fournisseur1].[IsTransporteur] [ProducteurID_IsTransporteur]
,[Fournisseur1].[IsChargeur] [ProducteurID_IsChargeur]
,[Fournisseur1].[IsAutre] [ProducteurID_IsAutre]
,[Fournisseur1].[AfficherCommentairesSurPermit] [ProducteurID_AfficherCommentairesSurPermit]
,[Fournisseur1].[PasEmissionPermis] [ProducteurID_PasEmissionPermis]
,[Fournisseur1].[Generique] [ProducteurID_Generique]
,[Fournisseur1].[Membre_OGC] [ProducteurID_Membre_OGC]
,[Fournisseur1].[InscritTPS] [ProducteurID_InscritTPS]
,[Fournisseur1].[InscritTVQ] [ProducteurID_InscritTVQ]
,[Fournisseur1].[IsOGC] [ProducteurID_IsOGC]
,[Fournisseur2].[ID] [TransporteurID_ID]
,[Fournisseur2].[CleTri] [TransporteurID_CleTri]
,[Fournisseur2].[Nom] [TransporteurID_Nom]
,[Fournisseur2].[AuSoinsDe] [TransporteurID_AuSoinsDe]
,[Fournisseur2].[Rue] [TransporteurID_Rue]
,[Fournisseur2].[Ville] [TransporteurID_Ville]
,[Fournisseur2].[PaysID] [TransporteurID_PaysID]
,[Fournisseur2].[Code_postal] [TransporteurID_Code_postal]
,[Fournisseur2].[Telephone] [TransporteurID_Telephone]
,[Fournisseur2].[Telephone_Poste] [TransporteurID_Telephone_Poste]
,[Fournisseur2].[Telecopieur] [TransporteurID_Telecopieur]
,[Fournisseur2].[Telephone2] [TransporteurID_Telephone2]
,[Fournisseur2].[Telephone2_Desc] [TransporteurID_Telephone2_Desc]
,[Fournisseur2].[Telephone2_Poste] [TransporteurID_Telephone2_Poste]
,[Fournisseur2].[Telephone3] [TransporteurID_Telephone3]
,[Fournisseur2].[Telephone3_Desc] [TransporteurID_Telephone3_Desc]
,[Fournisseur2].[Telephone3_Poste] [TransporteurID_Telephone3_Poste]
,[Fournisseur2].[No_membre] [TransporteurID_No_membre]
,[Fournisseur2].[Resident] [TransporteurID_Resident]
,[Fournisseur2].[Email] [TransporteurID_Email]
,[Fournisseur2].[WWW] [TransporteurID_WWW]
,[Fournisseur2].[Commentaires] [TransporteurID_Commentaires]
,[Fournisseur2].[AfficherCommentaires] [TransporteurID_AfficherCommentaires]
,[Fournisseur2].[DepotDirect] [TransporteurID_DepotDirect]
,[Fournisseur2].[InstitutionBanquaireID] [TransporteurID_InstitutionBanquaireID]
,[Fournisseur2].[Banque_transit] [TransporteurID_Banque_transit]
,[Fournisseur2].[Banque_folio] [TransporteurID_Banque_folio]
,[Fournisseur2].[No_TPS] [TransporteurID_No_TPS]
,[Fournisseur2].[No_TVQ] [TransporteurID_No_TVQ]
,[Fournisseur2].[PayerA] [TransporteurID_PayerA]
,[Fournisseur2].[PayerAID] [TransporteurID_PayerAID]
,[Fournisseur2].[Statut] [TransporteurID_Statut]
,[Fournisseur2].[Rep_Nom] [TransporteurID_Rep_Nom]
,[Fournisseur2].[Rep_Telephone] [TransporteurID_Rep_Telephone]
,[Fournisseur2].[Rep_Telephone_Poste] [TransporteurID_Rep_Telephone_Poste]
,[Fournisseur2].[Rep_Email] [TransporteurID_Rep_Email]
,[Fournisseur2].[EnAnglais] [TransporteurID_EnAnglais]
,[Fournisseur2].[Actif] [TransporteurID_Actif]
,[Fournisseur2].[MRCProducteurID] [TransporteurID_MRCProducteurID]
,[Fournisseur2].[PaiementManuel] [TransporteurID_PaiementManuel]
,[Fournisseur2].[Journal] [TransporteurID_Journal]
,[Fournisseur2].[RecoitTPS] [TransporteurID_RecoitTPS]
,[Fournisseur2].[RecoitTVQ] [TransporteurID_RecoitTVQ]
,[Fournisseur2].[ModifierTrigger] [TransporteurID_ModifierTrigger]
,[Fournisseur2].[IsProducteur] [TransporteurID_IsProducteur]
,[Fournisseur2].[IsTransporteur] [TransporteurID_IsTransporteur]
,[Fournisseur2].[IsChargeur] [TransporteurID_IsChargeur]
,[Fournisseur2].[IsAutre] [TransporteurID_IsAutre]
,[Fournisseur2].[AfficherCommentairesSurPermit] [TransporteurID_AfficherCommentairesSurPermit]
,[Fournisseur2].[PasEmissionPermis] [TransporteurID_PasEmissionPermis]
,[Fournisseur2].[Generique] [TransporteurID_Generique]
,[Fournisseur2].[Membre_OGC] [TransporteurID_Membre_OGC]
,[Fournisseur2].[InscritTPS] [TransporteurID_InscritTPS]
,[Fournisseur2].[InscritTVQ] [TransporteurID_InscritTVQ]
,[Fournisseur2].[IsOGC] [TransporteurID_IsOGC]

From [dbo].[Contingentement_Demande] [Contingentement_Demande]
    Left Outer Join [dbo].[Fournisseur] [Fournisseur1] On [Contingentement_Demande].[ProducteurID] = [Fournisseur1].[ID]
        Left Outer Join [dbo].[Fournisseur] [Fournisseur2] On [Contingentement_Demande].[TransporteurID] = [Fournisseur2].[ID]

Where

    ((@ID Is Null) Or ([Contingentement_Demande].[ID] = @ID))
And ((@ProducteurID Is Null) Or ([Contingentement_Demande].[ProducteurID] = @ProducteurID))
And ((@TransporteurID Is Null) Or ([Contingentement_Demande].[TransporteurID] = @TransporteurID))
)

