

Create Function [fnGestionVolume_Full]

(
 @ID [int] = Null
,@UsineID [varchar](6) = Null
,@UniteMesureID [varchar](6) = Null
,@ProducteurID [varchar](15) = Null
,@LotID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [GestionVolume].[ID]
,[GestionVolume].[DateLivraison]
,[GestionVolume].[UsineID]
,[GestionVolume].[UniteMesureID]
,[GestionVolume].[ProducteurID]
,[GestionVolume].[Annee]
,[GestionVolume].[Periode]
,[GestionVolume].[LotID]
,[GestionVolume].[DateEntree]
,[Usine1].[ID] [UsineID_ID]
,[Usine1].[Description] [UsineID_Description]
,[Usine1].[UtilisationID] [UsineID_UtilisationID]
,[Usine1].[Paye_producteur] [UsineID_Paye_producteur]
,[Usine1].[Paye_transporteur] [UsineID_Paye_transporteur]
,[Usine1].[Specification] [UsineID_Specification]
,[Usine1].[Compte_a_recevoir] [UsineID_Compte_a_recevoir]
,[Usine1].[Compte_ajustement] [UsineID_Compte_ajustement]
,[Usine1].[Compte_transporteur] [UsineID_Compte_transporteur]
,[Usine1].[Compte_producteur] [UsineID_Compte_producteur]
,[Usine1].[Compte_preleve_plan_conjoint] [UsineID_Compte_preleve_plan_conjoint]
,[Usine1].[Compte_preleve_fond_roulement] [UsineID_Compte_preleve_fond_roulement]
,[Usine1].[Compte_preleve_fond_forestier] [UsineID_Compte_preleve_fond_forestier]
,[Usine1].[Compte_preleve_divers] [UsineID_Compte_preleve_divers]
,[Usine1].[Compte_mise_en_commun] [UsineID_Compte_mise_en_commun]
,[Usine1].[Compte_surcharge] [UsineID_Compte_surcharge]
,[Usine1].[Compte_indexation_carburant] [UsineID_Compte_indexation_carburant]
,[Usine1].[Actif] [UsineID_Actif]
,[Usine1].[NePaiePasTPS] [UsineID_NePaiePasTPS]
,[Usine1].[NePaiePasTVQ] [UsineID_NePaiePasTVQ]
,[Usine1].[NoTPS] [UsineID_NoTPS]
,[Usine1].[NoTVQ] [UsineID_NoTVQ]
,[Usine1].[Compte_chargeur] [UsineID_Compte_chargeur]
,[Usine1].[UsineGestionVolume] [UsineID_UsineGestionVolume]
,[Usine1].[AuSoinsDe] [UsineID_AuSoinsDe]
,[Usine1].[Rue] [UsineID_Rue]
,[Usine1].[Ville] [UsineID_Ville]
,[Usine1].[PaysID] [UsineID_PaysID]
,[Usine1].[Code_postal] [UsineID_Code_postal]
,[Usine1].[Telephone] [UsineID_Telephone]
,[Usine1].[Telephone_Poste] [UsineID_Telephone_Poste]
,[Usine1].[Telecopieur] [UsineID_Telecopieur]
,[Usine1].[Telephone2] [UsineID_Telephone2]
,[Usine1].[Telephone2_Desc] [UsineID_Telephone2_Desc]
,[Usine1].[Telephone2_Poste] [UsineID_Telephone2_Poste]
,[Usine1].[Telephone3] [UsineID_Telephone3]
,[Usine1].[Telephone3_Desc] [UsineID_Telephone3_Desc]
,[Usine1].[Telephone3_Poste] [UsineID_Telephone3_Poste]
,[Usine1].[Email] [UsineID_Email]
,[UniteMesure2].[ID] [UniteMesureID_ID]
,[UniteMesure2].[Description] [UniteMesureID_Description]
,[UniteMesure2].[Nb_decimale] [UniteMesureID_Nb_decimale]
,[UniteMesure2].[Actif] [UniteMesureID_Actif]
,[UniteMesure2].[UseMontant] [UniteMesureID_UseMontant]
,[UniteMesure2].[Montant_Preleve_plan_conjoint] [UniteMesureID_Montant_Preleve_plan_conjoint]
,[UniteMesure2].[Montant_Preleve_fond_roulement] [UniteMesureID_Montant_Preleve_fond_roulement]
,[UniteMesure2].[Montant_Preleve_fond_forestier] [UniteMesureID_Montant_Preleve_fond_forestier]
,[UniteMesure2].[Montant_Preleve_divers] [UniteMesureID_Montant_Preleve_divers]
,[UniteMesure2].[Pourc_Preleve_plan_conjoint] [UniteMesureID_Pourc_Preleve_plan_conjoint]
,[UniteMesure2].[Pourc_Preleve_fond_roulement] [UniteMesureID_Pourc_Preleve_fond_roulement]
,[UniteMesure2].[Pourc_Preleve_fond_forestier] [UniteMesureID_Pourc_Preleve_fond_forestier]
,[UniteMesure2].[Pourc_Preleve_divers] [UniteMesureID_Pourc_Preleve_divers]
,[Fournisseur3].[ID] [ProducteurID_ID]
,[Fournisseur3].[CleTri] [ProducteurID_CleTri]
,[Fournisseur3].[Nom] [ProducteurID_Nom]
,[Fournisseur3].[AuSoinsDe] [ProducteurID_AuSoinsDe]
,[Fournisseur3].[Rue] [ProducteurID_Rue]
,[Fournisseur3].[Ville] [ProducteurID_Ville]
,[Fournisseur3].[PaysID] [ProducteurID_PaysID]
,[Fournisseur3].[Code_postal] [ProducteurID_Code_postal]
,[Fournisseur3].[Telephone] [ProducteurID_Telephone]
,[Fournisseur3].[Telephone_Poste] [ProducteurID_Telephone_Poste]
,[Fournisseur3].[Telecopieur] [ProducteurID_Telecopieur]
,[Fournisseur3].[Telephone2] [ProducteurID_Telephone2]
,[Fournisseur3].[Telephone2_Desc] [ProducteurID_Telephone2_Desc]
,[Fournisseur3].[Telephone2_Poste] [ProducteurID_Telephone2_Poste]
,[Fournisseur3].[Telephone3] [ProducteurID_Telephone3]
,[Fournisseur3].[Telephone3_Desc] [ProducteurID_Telephone3_Desc]
,[Fournisseur3].[Telephone3_Poste] [ProducteurID_Telephone3_Poste]
,[Fournisseur3].[No_membre] [ProducteurID_No_membre]
,[Fournisseur3].[Resident] [ProducteurID_Resident]
,[Fournisseur3].[Email] [ProducteurID_Email]
,[Fournisseur3].[WWW] [ProducteurID_WWW]
,[Fournisseur3].[Commentaires] [ProducteurID_Commentaires]
,[Fournisseur3].[AfficherCommentaires] [ProducteurID_AfficherCommentaires]
,[Fournisseur3].[DepotDirect] [ProducteurID_DepotDirect]
,[Fournisseur3].[InstitutionBanquaireID] [ProducteurID_InstitutionBanquaireID]
,[Fournisseur3].[Banque_transit] [ProducteurID_Banque_transit]
,[Fournisseur3].[Banque_folio] [ProducteurID_Banque_folio]
,[Fournisseur3].[No_TPS] [ProducteurID_No_TPS]
,[Fournisseur3].[No_TVQ] [ProducteurID_No_TVQ]
,[Fournisseur3].[PayerA] [ProducteurID_PayerA]
,[Fournisseur3].[PayerAID] [ProducteurID_PayerAID]
,[Fournisseur3].[Statut] [ProducteurID_Statut]
,[Fournisseur3].[Rep_Nom] [ProducteurID_Rep_Nom]
,[Fournisseur3].[Rep_Telephone] [ProducteurID_Rep_Telephone]
,[Fournisseur3].[Rep_Telephone_Poste] [ProducteurID_Rep_Telephone_Poste]
,[Fournisseur3].[Rep_Email] [ProducteurID_Rep_Email]
,[Fournisseur3].[EnAnglais] [ProducteurID_EnAnglais]
,[Fournisseur3].[Actif] [ProducteurID_Actif]
,[Fournisseur3].[MRCProducteurID] [ProducteurID_MRCProducteurID]
,[Fournisseur3].[PaiementManuel] [ProducteurID_PaiementManuel]
,[Fournisseur3].[Journal] [ProducteurID_Journal]
,[Fournisseur3].[RecoitTPS] [ProducteurID_RecoitTPS]
,[Fournisseur3].[RecoitTVQ] [ProducteurID_RecoitTVQ]
,[Fournisseur3].[ModifierTrigger] [ProducteurID_ModifierTrigger]
,[Fournisseur3].[IsProducteur] [ProducteurID_IsProducteur]
,[Fournisseur3].[IsTransporteur] [ProducteurID_IsTransporteur]
,[Fournisseur3].[IsChargeur] [ProducteurID_IsChargeur]
,[Fournisseur3].[IsAutre] [ProducteurID_IsAutre]
,[Fournisseur3].[AfficherCommentairesSurPermit] [ProducteurID_AfficherCommentairesSurPermit]
,[Fournisseur3].[PasEmissionPermis] [ProducteurID_PasEmissionPermis]
,[Fournisseur3].[Generique] [ProducteurID_Generique]
,[Lot4].[CantonID] [LotID_CantonID]
,[Lot4].[Rang] [LotID_Rang]
,[Lot4].[Lot] [LotID_Lot]
,[Lot4].[MunicipaliteID] [LotID_MunicipaliteID]
,[Lot4].[Superficie_total] [LotID_Superficie_total]
,[Lot4].[Superficie_boisee] [LotID_Superficie_boisee]
,[Lot4].[ProprietaireID] [LotID_ProprietaireID]
,[Lot4].[ContingentID] [LotID_ContingentID]
,[Lot4].[Contingent_Date] [LotID_Contingent_Date]
,[Lot4].[Droit_coupeID] [LotID_Droit_coupeID]
,[Lot4].[Droit_coupe_Date] [LotID_Droit_coupe_Date]
,[Lot4].[Entente_paiementID] [LotID_Entente_paiementID]
,[Lot4].[Entente_paiement_Date] [LotID_Entente_paiement_Date]
,[Lot4].[Actif] [LotID_Actif]
,[Lot4].[ID] [LotID_ID]
,[Lot4].[Sequence] [LotID_Sequence]
,[Lot4].[Partie] [LotID_Partie]
,[Lot4].[Matricule] [LotID_Matricule]
,[Lot4].[ZoneID] [LotID_ZoneID]
,[Lot4].[Secteur] [LotID_Secteur]
,[Lot4].[Cadastre] [LotID_Cadastre]

From [dbo].[GestionVolume] [GestionVolume]
    Left Outer Join [dbo].[Usine] [Usine1] On [GestionVolume].[UsineID] = [Usine1].[ID]
        Left Outer Join [dbo].[UniteMesure] [UniteMesure2] On [GestionVolume].[UniteMesureID] = [UniteMesure2].[ID]
            Left Outer Join [dbo].[Fournisseur] [Fournisseur3] On [GestionVolume].[ProducteurID] = [Fournisseur3].[ID]
                Left Outer Join [dbo].[Lot] [Lot4] On [GestionVolume].[LotID] = [Lot4].[ID]

Where

    ((@ID Is Null) Or ([GestionVolume].[ID] = @ID))
And ((@UsineID Is Null) Or ([GestionVolume].[UsineID] = @UsineID))
And ((@UniteMesureID Is Null) Or ([GestionVolume].[UniteMesureID] = @UniteMesureID))
And ((@ProducteurID Is Null) Or ([GestionVolume].[ProducteurID] = @ProducteurID))
And ((@LotID Is Null) Or ([GestionVolume].[LotID] = @LotID))
)



