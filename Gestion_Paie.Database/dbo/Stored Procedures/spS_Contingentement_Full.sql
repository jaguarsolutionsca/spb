
CREATE Procedure [spS_Contingentement_Full]

/*
Retrieve specific records from the [Contingentement] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Usine] (via [UsineID])
	[EssenceRegroupement] (via [RegroupementID])
	[Essence] (via [EssenceID])
	[UniteMesure] (via [UniteMesureID])
*/

(
 @ID [int] = Null -- for [Contingentement].[ID] column
,@UsineID [varchar](6) = Null -- for [Contingentement].[UsineID] column
,@RegroupementID [int] = Null -- for [Contingentement].[RegroupementID] column
,@EssenceID [varchar](6) = Null -- for [Contingentement].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [Contingentement].[UniteMesureID] column
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

		 [Contingentement_Records].[ID]
		,[Contingentement_Records].[ContingentUsine]
		,[Contingentement_Records].[UsineID]
		,[Contingentement_Records].[RegroupementID]
		,[Contingentement_Records].[Annee]
		,[Contingentement_Records].[PeriodeContingentement]
		,[Contingentement_Records].[PeriodeDebut]
		,[Contingentement_Records].[PeriodeFin]
		,[Contingentement_Records].[EssenceID]
		,[Contingentement_Records].[UniteMesureID]
		,[Contingentement_Records].[Volume_Usine]
		,[Contingentement_Records].[Facteur]
		,[Contingentement_Records].[Volume_Fixe]
		,[Contingentement_Records].[Date_Calcul]
		,[Contingentement_Records].[CalculAccepte]
		,[Contingentement_Records].[Code]
		,[Contingentement_Records].[Volume_Regroupement]
		,[Contingentement_Records].[Volume_RegroupementPourcentage]
		,[Contingentement_Records].[MaxVolumeFixe_Pourcentage]
		,[Contingentement_Records].[MaxVolumeFixe_ContingentementID]
		,[Contingentement_Records].[UseVolumeFixeUnique]
		,[Contingentement_Records].[MasseContingentVoyageDefaut]
		,[Contingentement_Records].[UsineID_ID]
		,[Contingentement_Records].[UsineID_Description]
		,[Contingentement_Records].[UsineID_UtilisationID]
		,[Contingentement_Records].[UsineID_Paye_producteur]
		,[Contingentement_Records].[UsineID_Paye_transporteur]
		,[Contingentement_Records].[UsineID_Specification]
		,[Contingentement_Records].[UsineID_Compte_a_recevoir]
		,[Contingentement_Records].[UsineID_Compte_ajustement]
		,[Contingentement_Records].[UsineID_Compte_transporteur]
		,[Contingentement_Records].[UsineID_Compte_producteur]
		,[Contingentement_Records].[UsineID_Compte_preleve_plan_conjoint]
		,[Contingentement_Records].[UsineID_Compte_preleve_fond_roulement]
		,[Contingentement_Records].[UsineID_Compte_preleve_fond_forestier]
		,[Contingentement_Records].[UsineID_Compte_preleve_divers]
		,[Contingentement_Records].[UsineID_Compte_mise_en_commun]
		,[Contingentement_Records].[UsineID_Compte_surcharge]
		,[Contingentement_Records].[UsineID_Compte_indexation_carburant]
		,[Contingentement_Records].[UsineID_Actif]
		,[Contingentement_Records].[UsineID_NePaiePasTPS]
		,[Contingentement_Records].[UsineID_NePaiePasTVQ]
		,[Contingentement_Records].[UsineID_NoTPS]
		,[Contingentement_Records].[UsineID_NoTVQ]
		,[Contingentement_Records].[UsineID_Compte_chargeur]
		,[Contingentement_Records].[UsineID_UsineGestionVolume]
		,[Contingentement_Records].[UsineID_AuSoinsDe]
		,[Contingentement_Records].[UsineID_Rue]
		,[Contingentement_Records].[UsineID_Ville]
		,[Contingentement_Records].[UsineID_PaysID]
		,[Contingentement_Records].[UsineID_Code_postal]
		,[Contingentement_Records].[UsineID_Telephone]
		,[Contingentement_Records].[UsineID_Telephone_Poste]
		,[Contingentement_Records].[UsineID_Telecopieur]
		,[Contingentement_Records].[UsineID_Telephone2]
		,[Contingentement_Records].[UsineID_Telephone2_Desc]
		,[Contingentement_Records].[UsineID_Telephone2_Poste]
		,[Contingentement_Records].[UsineID_Telephone3]
		,[Contingentement_Records].[UsineID_Telephone3_Desc]
		,[Contingentement_Records].[UsineID_Telephone3_Poste]
		,[Contingentement_Records].[UsineID_Email]
		,[Contingentement_Records].[RegroupementID_ID]
		,[Contingentement_Records].[RegroupementID_Description]
		,[Contingentement_Records].[RegroupementID_Actif]
		,[Contingentement_Records].[EssenceID_ID]
		,[Contingentement_Records].[EssenceID_Description]
		,[Contingentement_Records].[EssenceID_RegroupementID]
		,[Contingentement_Records].[EssenceID_ContingentID]
		,[Contingentement_Records].[EssenceID_RepartitionID]
		,[Contingentement_Records].[EssenceID_Actif]
		,[Contingentement_Records].[UniteMesureID_ID]
		,[Contingentement_Records].[UniteMesureID_Description]
		,[Contingentement_Records].[UniteMesureID_Nb_decimale]
		,[Contingentement_Records].[UniteMesureID_Actif]
		,[Contingentement_Records].[UniteMesureID_UseMontant]
		,[Contingentement_Records].[UniteMesureID_Montant_Preleve_plan_conjoint]
		,[Contingentement_Records].[UniteMesureID_Montant_Preleve_fond_roulement]
		,[Contingentement_Records].[UniteMesureID_Montant_Preleve_fond_forestier]
		,[Contingentement_Records].[UniteMesureID_Montant_Preleve_divers]
		,[Contingentement_Records].[UniteMesureID_Pourc_Preleve_plan_conjoint]
		,[Contingentement_Records].[UniteMesureID_Pourc_Preleve_fond_roulement]
		,[Contingentement_Records].[UniteMesureID_Pourc_Preleve_fond_forestier]
		,[Contingentement_Records].[UniteMesureID_Pourc_Preleve_divers]

		From [fnContingentement_Full](@ID, @UsineID, @RegroupementID, @EssenceID, @UniteMesureID) As [Contingentement_Records]
	End

Else

	Begin
		Select

		 [Contingentement_Records].[ID]
		,[Contingentement_Records].[ContingentUsine]
		,[Contingentement_Records].[UsineID]
		,[Contingentement_Records].[RegroupementID]
		,[Contingentement_Records].[Annee]
		,[Contingentement_Records].[PeriodeContingentement]
		,[Contingentement_Records].[PeriodeDebut]
		,[Contingentement_Records].[PeriodeFin]
		,[Contingentement_Records].[EssenceID]
		,[Contingentement_Records].[UniteMesureID]
		,[Contingentement_Records].[Volume_Usine]
		,[Contingentement_Records].[Facteur]
		,[Contingentement_Records].[Volume_Fixe]
		,[Contingentement_Records].[Date_Calcul]
		,[Contingentement_Records].[CalculAccepte]
		,[Contingentement_Records].[Code]
		,[Contingentement_Records].[Volume_Regroupement]
		,[Contingentement_Records].[Volume_RegroupementPourcentage]
		,[Contingentement_Records].[MaxVolumeFixe_Pourcentage]
		,[Contingentement_Records].[MaxVolumeFixe_ContingentementID]
		,[Contingentement_Records].[UseVolumeFixeUnique]
		,[Contingentement_Records].[MasseContingentVoyageDefaut]
		,[Contingentement_Records].[UsineID_ID]
		,[Contingentement_Records].[UsineID_Description]
		,[Contingentement_Records].[UsineID_UtilisationID]
		,[Contingentement_Records].[UsineID_Paye_producteur]
		,[Contingentement_Records].[UsineID_Paye_transporteur]
		,[Contingentement_Records].[UsineID_Specification]
		,[Contingentement_Records].[UsineID_Compte_a_recevoir]
		,[Contingentement_Records].[UsineID_Compte_ajustement]
		,[Contingentement_Records].[UsineID_Compte_transporteur]
		,[Contingentement_Records].[UsineID_Compte_producteur]
		,[Contingentement_Records].[UsineID_Compte_preleve_plan_conjoint]
		,[Contingentement_Records].[UsineID_Compte_preleve_fond_roulement]
		,[Contingentement_Records].[UsineID_Compte_preleve_fond_forestier]
		,[Contingentement_Records].[UsineID_Compte_preleve_divers]
		,[Contingentement_Records].[UsineID_Compte_mise_en_commun]
		,[Contingentement_Records].[UsineID_Compte_surcharge]
		,[Contingentement_Records].[UsineID_Compte_indexation_carburant]
		,[Contingentement_Records].[UsineID_Actif]
		,[Contingentement_Records].[UsineID_NePaiePasTPS]
		,[Contingentement_Records].[UsineID_NePaiePasTVQ]
		,[Contingentement_Records].[UsineID_NoTPS]
		,[Contingentement_Records].[UsineID_NoTVQ]
		,[Contingentement_Records].[UsineID_Compte_chargeur]
		,[Contingentement_Records].[UsineID_UsineGestionVolume]
		,[Contingentement_Records].[UsineID_AuSoinsDe]
		,[Contingentement_Records].[UsineID_Rue]
		,[Contingentement_Records].[UsineID_Ville]
		,[Contingentement_Records].[UsineID_PaysID]
		,[Contingentement_Records].[UsineID_Code_postal]
		,[Contingentement_Records].[UsineID_Telephone]
		,[Contingentement_Records].[UsineID_Telephone_Poste]
		,[Contingentement_Records].[UsineID_Telecopieur]
		,[Contingentement_Records].[UsineID_Telephone2]
		,[Contingentement_Records].[UsineID_Telephone2_Desc]
		,[Contingentement_Records].[UsineID_Telephone2_Poste]
		,[Contingentement_Records].[UsineID_Telephone3]
		,[Contingentement_Records].[UsineID_Telephone3_Desc]
		,[Contingentement_Records].[UsineID_Telephone3_Poste]
		,[Contingentement_Records].[UsineID_Email]
		,[Contingentement_Records].[RegroupementID_ID]
		,[Contingentement_Records].[RegroupementID_Description]
		,[Contingentement_Records].[RegroupementID_Actif]
		,[Contingentement_Records].[EssenceID_ID]
		,[Contingentement_Records].[EssenceID_Description]
		,[Contingentement_Records].[EssenceID_RegroupementID]
		,[Contingentement_Records].[EssenceID_ContingentID]
		,[Contingentement_Records].[EssenceID_RepartitionID]
		,[Contingentement_Records].[EssenceID_Actif]
		,[Contingentement_Records].[UniteMesureID_ID]
		,[Contingentement_Records].[UniteMesureID_Description]
		,[Contingentement_Records].[UniteMesureID_Nb_decimale]
		,[Contingentement_Records].[UniteMesureID_Actif]
		,[Contingentement_Records].[UniteMesureID_UseMontant]
		,[Contingentement_Records].[UniteMesureID_Montant_Preleve_plan_conjoint]
		,[Contingentement_Records].[UniteMesureID_Montant_Preleve_fond_roulement]
		,[Contingentement_Records].[UniteMesureID_Montant_Preleve_fond_forestier]
		,[Contingentement_Records].[UniteMesureID_Montant_Preleve_divers]
		,[Contingentement_Records].[UniteMesureID_Pourc_Preleve_plan_conjoint]
		,[Contingentement_Records].[UniteMesureID_Pourc_Preleve_fond_roulement]
		,[Contingentement_Records].[UniteMesureID_Pourc_Preleve_fond_forestier]
		,[Contingentement_Records].[UniteMesureID_Pourc_Preleve_divers]

		From [fnContingentement_Full](@ID, @UsineID, @RegroupementID, @EssenceID, @UniteMesureID) As [Contingentement_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)

