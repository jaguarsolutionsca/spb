CREATE Procedure [dbo].[spS_Fournisseur_Full]

/*
Retrieve specific records from the [Fournisseur] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Pays] (via [PaysID])
	[InstitutionBanquaire] (via [InstitutionBanquaireID])
*/

(
 @ID [varchar](15) = Null -- for [Fournisseur].[ID] column
,@PaysID [varchar](2) = Null -- for [Fournisseur].[PaysID] column
,@InstitutionBanquaireID [varchar](3) = Null -- for [Fournisseur].[InstitutionBanquaireID] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Fournisseur_Records].[ID]
		,[Fournisseur_Records].[CleTri]
		,[Fournisseur_Records].[Nom]
		,[Fournisseur_Records].[AuSoinsDe]
		,[Fournisseur_Records].[Rue]
		,[Fournisseur_Records].[Ville]
		,[Fournisseur_Records].[PaysID]
		,[Fournisseur_Records].[Code_postal]
		,[Fournisseur_Records].[Telephone]
		,[Fournisseur_Records].[Telephone_Poste]
		,[Fournisseur_Records].[Telecopieur]
		,[Fournisseur_Records].[Telephone2]
		,[Fournisseur_Records].[Telephone2_Desc]
		,[Fournisseur_Records].[Telephone2_Poste]
		,[Fournisseur_Records].[Telephone3]
		,[Fournisseur_Records].[Telephone3_Desc]
		,[Fournisseur_Records].[Telephone3_Poste]
		,[Fournisseur_Records].[No_membre]
		,[Fournisseur_Records].[Resident]
		,[Fournisseur_Records].[Email]
		,[Fournisseur_Records].[WWW]
		,[Fournisseur_Records].[Commentaires]
		,[Fournisseur_Records].[AfficherCommentaires]
		,[Fournisseur_Records].[DepotDirect]
		,[Fournisseur_Records].[InstitutionBanquaireID]
		,[Fournisseur_Records].[Banque_transit]
		,[Fournisseur_Records].[Banque_folio]
		,[Fournisseur_Records].[No_TPS]
		,[Fournisseur_Records].[No_TVQ]
		,[Fournisseur_Records].[PayerA]
		,[Fournisseur_Records].[PayerAID]
		,[Fournisseur_Records].[Statut]
		,[Fournisseur_Records].[Rep_Nom]
		,[Fournisseur_Records].[Rep_Telephone]
		,[Fournisseur_Records].[Rep_Telephone_Poste]
		,[Fournisseur_Records].[Rep_Email]
		,[Fournisseur_Records].[EnAnglais]
		,[Fournisseur_Records].[Actif]
		,[Fournisseur_Records].[MRCProducteurID]
		,[Fournisseur_Records].[PaiementManuel]
		,[Fournisseur_Records].[Journal]
		,[Fournisseur_Records].[RecoitTPS]
		,[Fournisseur_Records].[RecoitTVQ]
		,[Fournisseur_Records].[ModifierTrigger]
		,[Fournisseur_Records].[IsProducteur]
		,[Fournisseur_Records].[IsTransporteur]
		,[Fournisseur_Records].[IsChargeur]
		,[Fournisseur_Records].[IsAutre]
		,[Fournisseur_Records].[AfficherCommentairesSurPermit]
		,[Fournisseur_Records].[PasEmissionPermis]
		,[Fournisseur_Records].[Generique]
		,[Fournisseur_Records].[Membre_OGC]
		,[Fournisseur_Records].[InscritTPS]
		,[Fournisseur_Records].[InscritTVQ]
		,[Fournisseur_Records].[IsOGC]
		,[Fournisseur_Records].[Rep2_Nom]
		,[Fournisseur_Records].[Rep2_Telephone]
		,[Fournisseur_Records].[Rep2_Telephone_Poste]
		,[Fournisseur_Records].[Rep2_Email]
		,[Fournisseur_Records].[Rep2_Commentaires]
		,[Fournisseur_Records].[PaysID_ID]
		,[Fournisseur_Records].[PaysID_Nom]
		,[Fournisseur_Records].[PaysID_CodePostal_InputMask]
		,[Fournisseur_Records].[PaysID_Actif]
		,[Fournisseur_Records].[InstitutionBanquaireID_ID]
		,[Fournisseur_Records].[InstitutionBanquaireID_Description]
		,[Fournisseur_Records].[InstitutionBanquaireID_Actif]

		From [fnFournisseur_Full](@ID, @PaysID, @InstitutionBanquaireID) As [Fournisseur_Records]
	End

Else

	Begin
		Select

		 [Fournisseur_Records].[ID]
		,[Fournisseur_Records].[CleTri]
		,[Fournisseur_Records].[Nom]
		,[Fournisseur_Records].[AuSoinsDe]
		,[Fournisseur_Records].[Rue]
		,[Fournisseur_Records].[Ville]
		,[Fournisseur_Records].[PaysID]
		,[Fournisseur_Records].[Code_postal]
		,[Fournisseur_Records].[Telephone]
		,[Fournisseur_Records].[Telephone_Poste]
		,[Fournisseur_Records].[Telecopieur]
		,[Fournisseur_Records].[Telephone2]
		,[Fournisseur_Records].[Telephone2_Desc]
		,[Fournisseur_Records].[Telephone2_Poste]
		,[Fournisseur_Records].[Telephone3]
		,[Fournisseur_Records].[Telephone3_Desc]
		,[Fournisseur_Records].[Telephone3_Poste]
		,[Fournisseur_Records].[No_membre]
		,[Fournisseur_Records].[Resident]
		,[Fournisseur_Records].[Email]
		,[Fournisseur_Records].[WWW]
		,[Fournisseur_Records].[Commentaires]
		,[Fournisseur_Records].[AfficherCommentaires]
		,[Fournisseur_Records].[DepotDirect]
		,[Fournisseur_Records].[InstitutionBanquaireID]
		,[Fournisseur_Records].[Banque_transit]
		,[Fournisseur_Records].[Banque_folio]
		,[Fournisseur_Records].[No_TPS]
		,[Fournisseur_Records].[No_TVQ]
		,[Fournisseur_Records].[PayerA]
		,[Fournisseur_Records].[PayerAID]
		,[Fournisseur_Records].[Statut]
		,[Fournisseur_Records].[Rep_Nom]
		,[Fournisseur_Records].[Rep_Telephone]
		,[Fournisseur_Records].[Rep_Telephone_Poste]
		,[Fournisseur_Records].[Rep_Email]
		,[Fournisseur_Records].[EnAnglais]
		,[Fournisseur_Records].[Actif]
		,[Fournisseur_Records].[MRCProducteurID]
		,[Fournisseur_Records].[PaiementManuel]
		,[Fournisseur_Records].[Journal]
		,[Fournisseur_Records].[RecoitTPS]
		,[Fournisseur_Records].[RecoitTVQ]
		,[Fournisseur_Records].[ModifierTrigger]
		,[Fournisseur_Records].[IsProducteur]
		,[Fournisseur_Records].[IsTransporteur]
		,[Fournisseur_Records].[IsChargeur]
		,[Fournisseur_Records].[IsAutre]
		,[Fournisseur_Records].[AfficherCommentairesSurPermit]
		,[Fournisseur_Records].[PasEmissionPermis]
		,[Fournisseur_Records].[Generique]
		,[Fournisseur_Records].[Membre_OGC]
		,[Fournisseur_Records].[InscritTPS]
		,[Fournisseur_Records].[InscritTVQ]
		,[Fournisseur_Records].[IsOGC]
		,[Fournisseur_Records].[Rep2_Nom]
		,[Fournisseur_Records].[Rep2_Telephone]
		,[Fournisseur_Records].[Rep2_Telephone_Poste]
		,[Fournisseur_Records].[Rep2_Email]
		,[Fournisseur_Records].[Rep2_Commentaires]
		,[Fournisseur_Records].[PaysID_ID]
		,[Fournisseur_Records].[PaysID_Nom]
		,[Fournisseur_Records].[PaysID_CodePostal_InputMask]
		,[Fournisseur_Records].[PaysID_Actif]
		,[Fournisseur_Records].[InstitutionBanquaireID_ID]
		,[Fournisseur_Records].[InstitutionBanquaireID_Description]
		,[Fournisseur_Records].[InstitutionBanquaireID_Actif]

		From [fnFournisseur_Full](@ID, @PaysID, @InstitutionBanquaireID) As [Fournisseur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)




