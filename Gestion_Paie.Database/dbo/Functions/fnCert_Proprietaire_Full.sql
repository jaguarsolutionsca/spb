CREATE FUNCTION [dbo].[fnCert_Proprietaire_Full]
(@Agence VARCHAR (10)=Null, @NO_ACT VARCHAR (10)=Null, @FournisseurID VARCHAR (15)=Null)
RETURNS TABLE 
AS
RETURN 
    (
Select
 [Cert_Proprietaire].[Agence]
,[Cert_Proprietaire].[NO_ACT]
,[Cert_Proprietaire].[Nom]
,[Cert_Proprietaire].[Representant]
,[Cert_Proprietaire].[ADRESSE]
,[Cert_Proprietaire].[Ville]
,[Cert_Proprietaire].[CODE_POST]
,[Cert_Proprietaire].[TEL_RES]
,[Cert_Proprietaire].[TEL_BUR]
,[Cert_Proprietaire].[FournisseurID]
,[Cert_Proprietaire].[FournisseurNom]
,[Cert_Proprietaire].[Traite]
,[Cert_Proprietaire].[Methode]
,[Fournisseur1].[ID] [FournisseurID_ID]
,[Fournisseur1].[CleTri] [FournisseurID_CleTri]
,[Fournisseur1].[Nom] [FournisseurID_Nom]
,[Fournisseur1].[AuSoinsDe] [FournisseurID_AuSoinsDe]
,[Fournisseur1].[Rue] [FournisseurID_Rue]
,[Fournisseur1].[Ville] [FournisseurID_Ville]
,[Fournisseur1].[PaysID] [FournisseurID_PaysID]
,[Fournisseur1].[Code_postal] [FournisseurID_Code_postal]
,[Fournisseur1].[Telephone] [FournisseurID_Telephone]
,[Fournisseur1].[Telephone_Poste] [FournisseurID_Telephone_Poste]
,[Fournisseur1].[Telecopieur] [FournisseurID_Telecopieur]
,[Fournisseur1].[Telephone2] [FournisseurID_Telephone2]
,[Fournisseur1].[Telephone2_Desc] [FournisseurID_Telephone2_Desc]
,[Fournisseur1].[Telephone2_Poste] [FournisseurID_Telephone2_Poste]
,[Fournisseur1].[Telephone3] [FournisseurID_Telephone3]
,[Fournisseur1].[Telephone3_Desc] [FournisseurID_Telephone3_Desc]
,[Fournisseur1].[Telephone3_Poste] [FournisseurID_Telephone3_Poste]
,[Fournisseur1].[No_membre] [FournisseurID_No_membre]
,[Fournisseur1].[Resident] [FournisseurID_Resident]
,[Fournisseur1].[Email] [FournisseurID_Email]
,[Fournisseur1].[WWW] [FournisseurID_WWW]
,[Fournisseur1].[Commentaires] [FournisseurID_Commentaires]
,[Fournisseur1].[AfficherCommentaires] [FournisseurID_AfficherCommentaires]
,[Fournisseur1].[DepotDirect] [FournisseurID_DepotDirect]
,[Fournisseur1].[InstitutionBanquaireID] [FournisseurID_InstitutionBanquaireID]
,[Fournisseur1].[Banque_transit] [FournisseurID_Banque_transit]
,[Fournisseur1].[Banque_folio] [FournisseurID_Banque_folio]
,[Fournisseur1].[No_TPS] [FournisseurID_No_TPS]
,[Fournisseur1].[No_TVQ] [FournisseurID_No_TVQ]
,[Fournisseur1].[PayerA] [FournisseurID_PayerA]
,[Fournisseur1].[PayerAID] [FournisseurID_PayerAID]
,[Fournisseur1].[Statut] [FournisseurID_Statut]
,[Fournisseur1].[Rep_Nom] [FournisseurID_Rep_Nom]
,[Fournisseur1].[Rep_Telephone] [FournisseurID_Rep_Telephone]
,[Fournisseur1].[Rep_Telephone_Poste] [FournisseurID_Rep_Telephone_Poste]
,[Fournisseur1].[Rep_Email] [FournisseurID_Rep_Email]
,[Fournisseur1].[EnAnglais] [FournisseurID_EnAnglais]
,[Fournisseur1].[Actif] [FournisseurID_Actif]
,[Fournisseur1].[MRCProducteurID] [FournisseurID_MRCProducteurID]
,[Fournisseur1].[PaiementManuel] [FournisseurID_PaiementManuel]
,[Fournisseur1].[Journal] [FournisseurID_Journal]
,[Fournisseur1].[RecoitTPS] [FournisseurID_RecoitTPS]
,[Fournisseur1].[RecoitTVQ] [FournisseurID_RecoitTVQ]
,[Fournisseur1].[ModifierTrigger] [FournisseurID_ModifierTrigger]
,[Fournisseur1].[IsProducteur] [FournisseurID_IsProducteur]
,[Fournisseur1].[IsTransporteur] [FournisseurID_IsTransporteur]
,[Fournisseur1].[IsChargeur] [FournisseurID_IsChargeur]
,[Fournisseur1].[IsAutre] [FournisseurID_IsAutre]
,[Fournisseur1].[AfficherCommentairesSurPermit] [FournisseurID_AfficherCommentairesSurPermit]
,[Fournisseur1].[PasEmissionPermis] [FournisseurID_PasEmissionPermis]
,[Fournisseur1].[Generique] [FournisseurID_Generique]
,[Fournisseur1].[Membre_OGC] [FournisseurID_Membre_OGC]
,[Fournisseur1].[InscritTPS] [FournisseurID_InscritTPS]
,[Fournisseur1].[InscritTVQ] [FournisseurID_InscritTVQ]
,[Fournisseur1].[IsOGC] [FournisseurID_IsOGC]

From [dbo].[Cert_Proprietaire] [Cert_Proprietaire]
    Left Outer Join [dbo].[Fournisseur] [Fournisseur1] On [Cert_Proprietaire].[FournisseurID] = [Fournisseur1].[ID]

Where

    ((@Agence Is Null) Or ([Cert_Proprietaire].[Agence] = @Agence))
And ((@NO_ACT Is Null) Or ([Cert_Proprietaire].[NO_ACT] = @NO_ACT))
And ((@FournisseurID Is Null) Or ([Cert_Proprietaire].[FournisseurID] = @FournisseurID))
)



