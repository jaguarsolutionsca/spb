﻿
CREATE Function [fnLot_Full]

(
 @ID [int] = Null
,@CantonID [varchar](6) = Null
,@MunicipaliteID [varchar](6) = Null
,@ProprietaireID [varchar](15) = Null
,@ContingentID [varchar](15) = Null
,@Droit_coupeID [varchar](15) = Null
,@Entente_paiementID [varchar](15) = Null
,@ZoneID [varchar](2) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
 [Lot].[CantonID]
,[Lot].[Rang]
,[Lot].[Lot]
,[Lot].[MunicipaliteID]
,[Lot].[Superficie_total]
,[Lot].[Superficie_boisee]
,[Lot].[ProprietaireID]
,[Lot].[ContingentID]
,[Lot].[Contingent_Date]
,[Lot].[Droit_coupeID]
,[Lot].[Droit_coupe_Date]
,[Lot].[Entente_paiementID]
,[Lot].[Entente_paiement_Date]
,[Lot].[Actif]
,[Lot].[ID]
,[Lot].[Sequence]
,[Lot].[Partie]
,[Lot].[Matricule]
,[Lot].[ZoneID]
,[Lot].[Secteur]
,[Lot].[Cadastre]
,[Lot].[Reforme]
,[Lot].[LotsComplementaires]
,[Lot].[Certifie]
,[Lot].[NumeroCertification]
,[Lot].[OGC]
,[Canton1].[ID] [CantonID_ID]
,[Canton1].[Description] [CantonID_Description]
,[Canton1].[Actif] [CantonID_Actif]
,[Municipalite_Zone2].[ID] [MunicipaliteID_ID]
,[Municipalite_Zone2].[MunicipaliteID] [MunicipaliteID_MunicipaliteID]
,[Municipalite_Zone2].[Description] [MunicipaliteID_Description]
,[Municipalite_Zone2].[Actif] [MunicipaliteID_Actif]
,[Fournisseur3].[ID] [ProprietaireID_ID]
,[Fournisseur3].[CleTri] [ProprietaireID_CleTri]
,[Fournisseur3].[Nom] [ProprietaireID_Nom]
,[Fournisseur3].[AuSoinsDe] [ProprietaireID_AuSoinsDe]
,[Fournisseur3].[Rue] [ProprietaireID_Rue]
,[Fournisseur3].[Ville] [ProprietaireID_Ville]
,[Fournisseur3].[PaysID] [ProprietaireID_PaysID]
,[Fournisseur3].[Code_postal] [ProprietaireID_Code_postal]
,[Fournisseur3].[Telephone] [ProprietaireID_Telephone]
,[Fournisseur3].[Telephone_Poste] [ProprietaireID_Telephone_Poste]
,[Fournisseur3].[Telecopieur] [ProprietaireID_Telecopieur]
,[Fournisseur3].[Telephone2] [ProprietaireID_Telephone2]
,[Fournisseur3].[Telephone2_Desc] [ProprietaireID_Telephone2_Desc]
,[Fournisseur3].[Telephone2_Poste] [ProprietaireID_Telephone2_Poste]
,[Fournisseur3].[Telephone3] [ProprietaireID_Telephone3]
,[Fournisseur3].[Telephone3_Desc] [ProprietaireID_Telephone3_Desc]
,[Fournisseur3].[Telephone3_Poste] [ProprietaireID_Telephone3_Poste]
,[Fournisseur3].[No_membre] [ProprietaireID_No_membre]
,[Fournisseur3].[Resident] [ProprietaireID_Resident]
,[Fournisseur3].[Email] [ProprietaireID_Email]
,[Fournisseur3].[WWW] [ProprietaireID_WWW]
,[Fournisseur3].[Commentaires] [ProprietaireID_Commentaires]
,[Fournisseur3].[AfficherCommentaires] [ProprietaireID_AfficherCommentaires]
,[Fournisseur3].[DepotDirect] [ProprietaireID_DepotDirect]
,[Fournisseur3].[InstitutionBanquaireID] [ProprietaireID_InstitutionBanquaireID]
,[Fournisseur3].[Banque_transit] [ProprietaireID_Banque_transit]
,[Fournisseur3].[Banque_folio] [ProprietaireID_Banque_folio]
,[Fournisseur3].[No_TPS] [ProprietaireID_No_TPS]
,[Fournisseur3].[No_TVQ] [ProprietaireID_No_TVQ]
,[Fournisseur3].[PayerA] [ProprietaireID_PayerA]
,[Fournisseur3].[PayerAID] [ProprietaireID_PayerAID]
,[Fournisseur3].[Statut] [ProprietaireID_Statut]
,[Fournisseur3].[Rep_Nom] [ProprietaireID_Rep_Nom]
,[Fournisseur3].[Rep_Telephone] [ProprietaireID_Rep_Telephone]
,[Fournisseur3].[Rep_Telephone_Poste] [ProprietaireID_Rep_Telephone_Poste]
,[Fournisseur3].[Rep_Email] [ProprietaireID_Rep_Email]
,[Fournisseur3].[EnAnglais] [ProprietaireID_EnAnglais]
,[Fournisseur3].[Actif] [ProprietaireID_Actif]
,[Fournisseur3].[MRCProducteurID] [ProprietaireID_MRCProducteurID]
,[Fournisseur3].[PaiementManuel] [ProprietaireID_PaiementManuel]
,[Fournisseur3].[Journal] [ProprietaireID_Journal]
,[Fournisseur3].[RecoitTPS] [ProprietaireID_RecoitTPS]
,[Fournisseur3].[RecoitTVQ] [ProprietaireID_RecoitTVQ]
,[Fournisseur3].[ModifierTrigger] [ProprietaireID_ModifierTrigger]
,[Fournisseur3].[IsProducteur] [ProprietaireID_IsProducteur]
,[Fournisseur3].[IsTransporteur] [ProprietaireID_IsTransporteur]
,[Fournisseur3].[IsChargeur] [ProprietaireID_IsChargeur]
,[Fournisseur3].[IsAutre] [ProprietaireID_IsAutre]
,[Fournisseur3].[AfficherCommentairesSurPermit] [ProprietaireID_AfficherCommentairesSurPermit]
,[Fournisseur3].[PasEmissionPermis] [ProprietaireID_PasEmissionPermis]
,[Fournisseur3].[Generique] [ProprietaireID_Generique]
,[Fournisseur3].[Membre_OGC] [ProprietaireID_Membre_OGC]
,[Fournisseur3].[InscritTPS] [ProprietaireID_InscritTPS]
,[Fournisseur3].[InscritTVQ] [ProprietaireID_InscritTVQ]
,[Fournisseur4].[ID] [ContingentID_ID]
,[Fournisseur4].[CleTri] [ContingentID_CleTri]
,[Fournisseur4].[Nom] [ContingentID_Nom]
,[Fournisseur4].[AuSoinsDe] [ContingentID_AuSoinsDe]
,[Fournisseur4].[Rue] [ContingentID_Rue]
,[Fournisseur4].[Ville] [ContingentID_Ville]
,[Fournisseur4].[PaysID] [ContingentID_PaysID]
,[Fournisseur4].[Code_postal] [ContingentID_Code_postal]
,[Fournisseur4].[Telephone] [ContingentID_Telephone]
,[Fournisseur4].[Telephone_Poste] [ContingentID_Telephone_Poste]
,[Fournisseur4].[Telecopieur] [ContingentID_Telecopieur]
,[Fournisseur4].[Telephone2] [ContingentID_Telephone2]
,[Fournisseur4].[Telephone2_Desc] [ContingentID_Telephone2_Desc]
,[Fournisseur4].[Telephone2_Poste] [ContingentID_Telephone2_Poste]
,[Fournisseur4].[Telephone3] [ContingentID_Telephone3]
,[Fournisseur4].[Telephone3_Desc] [ContingentID_Telephone3_Desc]
,[Fournisseur4].[Telephone3_Poste] [ContingentID_Telephone3_Poste]
,[Fournisseur4].[No_membre] [ContingentID_No_membre]
,[Fournisseur4].[Resident] [ContingentID_Resident]
,[Fournisseur4].[Email] [ContingentID_Email]
,[Fournisseur4].[WWW] [ContingentID_WWW]
,[Fournisseur4].[Commentaires] [ContingentID_Commentaires]
,[Fournisseur4].[AfficherCommentaires] [ContingentID_AfficherCommentaires]
,[Fournisseur4].[DepotDirect] [ContingentID_DepotDirect]
,[Fournisseur4].[InstitutionBanquaireID] [ContingentID_InstitutionBanquaireID]
,[Fournisseur4].[Banque_transit] [ContingentID_Banque_transit]
,[Fournisseur4].[Banque_folio] [ContingentID_Banque_folio]
,[Fournisseur4].[No_TPS] [ContingentID_No_TPS]
,[Fournisseur4].[No_TVQ] [ContingentID_No_TVQ]
,[Fournisseur4].[PayerA] [ContingentID_PayerA]
,[Fournisseur4].[PayerAID] [ContingentID_PayerAID]
,[Fournisseur4].[Statut] [ContingentID_Statut]
,[Fournisseur4].[Rep_Nom] [ContingentID_Rep_Nom]
,[Fournisseur4].[Rep_Telephone] [ContingentID_Rep_Telephone]
,[Fournisseur4].[Rep_Telephone_Poste] [ContingentID_Rep_Telephone_Poste]
,[Fournisseur4].[Rep_Email] [ContingentID_Rep_Email]
,[Fournisseur4].[EnAnglais] [ContingentID_EnAnglais]
,[Fournisseur4].[Actif] [ContingentID_Actif]
,[Fournisseur4].[MRCProducteurID] [ContingentID_MRCProducteurID]
,[Fournisseur4].[PaiementManuel] [ContingentID_PaiementManuel]
,[Fournisseur4].[Journal] [ContingentID_Journal]
,[Fournisseur4].[RecoitTPS] [ContingentID_RecoitTPS]
,[Fournisseur4].[RecoitTVQ] [ContingentID_RecoitTVQ]
,[Fournisseur4].[ModifierTrigger] [ContingentID_ModifierTrigger]
,[Fournisseur4].[IsProducteur] [ContingentID_IsProducteur]
,[Fournisseur4].[IsTransporteur] [ContingentID_IsTransporteur]
,[Fournisseur4].[IsChargeur] [ContingentID_IsChargeur]
,[Fournisseur4].[IsAutre] [ContingentID_IsAutre]
,[Fournisseur4].[AfficherCommentairesSurPermit] [ContingentID_AfficherCommentairesSurPermit]
,[Fournisseur4].[PasEmissionPermis] [ContingentID_PasEmissionPermis]
,[Fournisseur4].[Generique] [ContingentID_Generique]
,[Fournisseur4].[Membre_OGC] [ContingentID_Membre_OGC]
,[Fournisseur4].[InscritTPS] [ContingentID_InscritTPS]
,[Fournisseur4].[InscritTVQ] [ContingentID_InscritTVQ]
,[Fournisseur5].[ID] [Droit_coupeID_ID]
,[Fournisseur5].[CleTri] [Droit_coupeID_CleTri]
,[Fournisseur5].[Nom] [Droit_coupeID_Nom]
,[Fournisseur5].[AuSoinsDe] [Droit_coupeID_AuSoinsDe]
,[Fournisseur5].[Rue] [Droit_coupeID_Rue]
,[Fournisseur5].[Ville] [Droit_coupeID_Ville]
,[Fournisseur5].[PaysID] [Droit_coupeID_PaysID]
,[Fournisseur5].[Code_postal] [Droit_coupeID_Code_postal]
,[Fournisseur5].[Telephone] [Droit_coupeID_Telephone]
,[Fournisseur5].[Telephone_Poste] [Droit_coupeID_Telephone_Poste]
,[Fournisseur5].[Telecopieur] [Droit_coupeID_Telecopieur]
,[Fournisseur5].[Telephone2] [Droit_coupeID_Telephone2]
,[Fournisseur5].[Telephone2_Desc] [Droit_coupeID_Telephone2_Desc]
,[Fournisseur5].[Telephone2_Poste] [Droit_coupeID_Telephone2_Poste]
,[Fournisseur5].[Telephone3] [Droit_coupeID_Telephone3]
,[Fournisseur5].[Telephone3_Desc] [Droit_coupeID_Telephone3_Desc]
,[Fournisseur5].[Telephone3_Poste] [Droit_coupeID_Telephone3_Poste]
,[Fournisseur5].[No_membre] [Droit_coupeID_No_membre]
,[Fournisseur5].[Resident] [Droit_coupeID_Resident]
,[Fournisseur5].[Email] [Droit_coupeID_Email]
,[Fournisseur5].[WWW] [Droit_coupeID_WWW]
,[Fournisseur5].[Commentaires] [Droit_coupeID_Commentaires]
,[Fournisseur5].[AfficherCommentaires] [Droit_coupeID_AfficherCommentaires]
,[Fournisseur5].[DepotDirect] [Droit_coupeID_DepotDirect]
,[Fournisseur5].[InstitutionBanquaireID] [Droit_coupeID_InstitutionBanquaireID]
,[Fournisseur5].[Banque_transit] [Droit_coupeID_Banque_transit]
,[Fournisseur5].[Banque_folio] [Droit_coupeID_Banque_folio]
,[Fournisseur5].[No_TPS] [Droit_coupeID_No_TPS]
,[Fournisseur5].[No_TVQ] [Droit_coupeID_No_TVQ]
,[Fournisseur5].[PayerA] [Droit_coupeID_PayerA]
,[Fournisseur5].[PayerAID] [Droit_coupeID_PayerAID]
,[Fournisseur5].[Statut] [Droit_coupeID_Statut]
,[Fournisseur5].[Rep_Nom] [Droit_coupeID_Rep_Nom]
,[Fournisseur5].[Rep_Telephone] [Droit_coupeID_Rep_Telephone]
,[Fournisseur5].[Rep_Telephone_Poste] [Droit_coupeID_Rep_Telephone_Poste]
,[Fournisseur5].[Rep_Email] [Droit_coupeID_Rep_Email]
,[Fournisseur5].[EnAnglais] [Droit_coupeID_EnAnglais]
,[Fournisseur5].[Actif] [Droit_coupeID_Actif]
,[Fournisseur5].[MRCProducteurID] [Droit_coupeID_MRCProducteurID]
,[Fournisseur5].[PaiementManuel] [Droit_coupeID_PaiementManuel]
,[Fournisseur5].[Journal] [Droit_coupeID_Journal]
,[Fournisseur5].[RecoitTPS] [Droit_coupeID_RecoitTPS]
,[Fournisseur5].[RecoitTVQ] [Droit_coupeID_RecoitTVQ]
,[Fournisseur5].[ModifierTrigger] [Droit_coupeID_ModifierTrigger]
,[Fournisseur5].[IsProducteur] [Droit_coupeID_IsProducteur]
,[Fournisseur5].[IsTransporteur] [Droit_coupeID_IsTransporteur]
,[Fournisseur5].[IsChargeur] [Droit_coupeID_IsChargeur]
,[Fournisseur5].[IsAutre] [Droit_coupeID_IsAutre]
,[Fournisseur5].[AfficherCommentairesSurPermit] [Droit_coupeID_AfficherCommentairesSurPermit]
,[Fournisseur5].[PasEmissionPermis] [Droit_coupeID_PasEmissionPermis]
,[Fournisseur5].[Generique] [Droit_coupeID_Generique]
,[Fournisseur5].[Membre_OGC] [Droit_coupeID_Membre_OGC]
,[Fournisseur5].[InscritTPS] [Droit_coupeID_InscritTPS]
,[Fournisseur5].[InscritTVQ] [Droit_coupeID_InscritTVQ]
,[Fournisseur6].[ID] [Entente_paiementID_ID]
,[Fournisseur6].[CleTri] [Entente_paiementID_CleTri]
,[Fournisseur6].[Nom] [Entente_paiementID_Nom]
,[Fournisseur6].[AuSoinsDe] [Entente_paiementID_AuSoinsDe]
,[Fournisseur6].[Rue] [Entente_paiementID_Rue]
,[Fournisseur6].[Ville] [Entente_paiementID_Ville]
,[Fournisseur6].[PaysID] [Entente_paiementID_PaysID]
,[Fournisseur6].[Code_postal] [Entente_paiementID_Code_postal]
,[Fournisseur6].[Telephone] [Entente_paiementID_Telephone]
,[Fournisseur6].[Telephone_Poste] [Entente_paiementID_Telephone_Poste]
,[Fournisseur6].[Telecopieur] [Entente_paiementID_Telecopieur]
,[Fournisseur6].[Telephone2] [Entente_paiementID_Telephone2]
,[Fournisseur6].[Telephone2_Desc] [Entente_paiementID_Telephone2_Desc]
,[Fournisseur6].[Telephone2_Poste] [Entente_paiementID_Telephone2_Poste]
,[Fournisseur6].[Telephone3] [Entente_paiementID_Telephone3]
,[Fournisseur6].[Telephone3_Desc] [Entente_paiementID_Telephone3_Desc]
,[Fournisseur6].[Telephone3_Poste] [Entente_paiementID_Telephone3_Poste]
,[Fournisseur6].[No_membre] [Entente_paiementID_No_membre]
,[Fournisseur6].[Resident] [Entente_paiementID_Resident]
,[Fournisseur6].[Email] [Entente_paiementID_Email]
,[Fournisseur6].[WWW] [Entente_paiementID_WWW]
,[Fournisseur6].[Commentaires] [Entente_paiementID_Commentaires]
,[Fournisseur6].[AfficherCommentaires] [Entente_paiementID_AfficherCommentaires]
,[Fournisseur6].[DepotDirect] [Entente_paiementID_DepotDirect]
,[Fournisseur6].[InstitutionBanquaireID] [Entente_paiementID_InstitutionBanquaireID]
,[Fournisseur6].[Banque_transit] [Entente_paiementID_Banque_transit]
,[Fournisseur6].[Banque_folio] [Entente_paiementID_Banque_folio]
,[Fournisseur6].[No_TPS] [Entente_paiementID_No_TPS]
,[Fournisseur6].[No_TVQ] [Entente_paiementID_No_TVQ]
,[Fournisseur6].[PayerA] [Entente_paiementID_PayerA]
,[Fournisseur6].[PayerAID] [Entente_paiementID_PayerAID]
,[Fournisseur6].[Statut] [Entente_paiementID_Statut]
,[Fournisseur6].[Rep_Nom] [Entente_paiementID_Rep_Nom]
,[Fournisseur6].[Rep_Telephone] [Entente_paiementID_Rep_Telephone]
,[Fournisseur6].[Rep_Telephone_Poste] [Entente_paiementID_Rep_Telephone_Poste]
,[Fournisseur6].[Rep_Email] [Entente_paiementID_Rep_Email]
,[Fournisseur6].[EnAnglais] [Entente_paiementID_EnAnglais]
,[Fournisseur6].[Actif] [Entente_paiementID_Actif]
,[Fournisseur6].[MRCProducteurID] [Entente_paiementID_MRCProducteurID]
,[Fournisseur6].[PaiementManuel] [Entente_paiementID_PaiementManuel]
,[Fournisseur6].[Journal] [Entente_paiementID_Journal]
,[Fournisseur6].[RecoitTPS] [Entente_paiementID_RecoitTPS]
,[Fournisseur6].[RecoitTVQ] [Entente_paiementID_RecoitTVQ]
,[Fournisseur6].[ModifierTrigger] [Entente_paiementID_ModifierTrigger]
,[Fournisseur6].[IsProducteur] [Entente_paiementID_IsProducteur]
,[Fournisseur6].[IsTransporteur] [Entente_paiementID_IsTransporteur]
,[Fournisseur6].[IsChargeur] [Entente_paiementID_IsChargeur]
,[Fournisseur6].[IsAutre] [Entente_paiementID_IsAutre]
,[Fournisseur6].[AfficherCommentairesSurPermit] [Entente_paiementID_AfficherCommentairesSurPermit]
,[Fournisseur6].[PasEmissionPermis] [Entente_paiementID_PasEmissionPermis]
,[Fournisseur6].[Generique] [Entente_paiementID_Generique]
,[Fournisseur6].[Membre_OGC] [Entente_paiementID_Membre_OGC]
,[Fournisseur6].[InscritTPS] [Entente_paiementID_InscritTPS]
,[Fournisseur6].[InscritTVQ] [Entente_paiementID_InscritTVQ]
,[Municipalite_Zone7].[ID] [ZoneID_ID]
,[Municipalite_Zone7].[MunicipaliteID] [ZoneID_MunicipaliteID]
,[Municipalite_Zone7].[Description] [ZoneID_Description]
,[Municipalite_Zone7].[Actif] [ZoneID_Actif]

From [dbo].[Lot] [Lot]
    Left Outer Join [dbo].[Canton] [Canton1] On [Lot].[CantonID] = [Canton1].[ID]
        Left Outer Join [dbo].[Municipalite_Zone] [Municipalite_Zone2] On [Lot].[MunicipaliteID] = [Municipalite_Zone2].[MunicipaliteID]
            Left Outer Join [dbo].[Fournisseur] [Fournisseur3] On [Lot].[ProprietaireID] = [Fournisseur3].[ID]
                Left Outer Join [dbo].[Fournisseur] [Fournisseur4] On [Lot].[ContingentID] = [Fournisseur4].[ID]
                    Left Outer Join [dbo].[Fournisseur] [Fournisseur5] On [Lot].[Droit_coupeID] = [Fournisseur5].[ID]
                        Left Outer Join [dbo].[Fournisseur] [Fournisseur6] On [Lot].[Entente_paiementID] = [Fournisseur6].[ID]
                            Left Outer Join [dbo].[Municipalite_Zone] [Municipalite_Zone7] On [Lot].[ZoneID] = [Municipalite_Zone7].[ID]

Where

    ((@ID Is Null) Or ([Lot].[ID] = @ID))
And ((@CantonID Is Null) Or ([Lot].[CantonID] = @CantonID))
And ((@MunicipaliteID Is Null) Or ([Lot].[MunicipaliteID] = @MunicipaliteID))
And ((@ProprietaireID Is Null) Or ([Lot].[ProprietaireID] = @ProprietaireID))
And ((@ContingentID Is Null) Or ([Lot].[ContingentID] = @ContingentID))
And ((@Droit_coupeID Is Null) Or ([Lot].[Droit_coupeID] = @Droit_coupeID))
And ((@Entente_paiementID Is Null) Or ([Lot].[Entente_paiementID] = @Entente_paiementID))
And ((@ZoneID Is Null) Or ([Lot].[ZoneID] = @ZoneID))
)
