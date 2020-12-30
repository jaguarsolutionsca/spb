

CREATE Procedure [spS_Contrat_Full]

/*
Retrieve specific records from the [Contrat] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Usine] (via [UsineID])
*/

(
 @ID [varchar](10) = Null -- for [Contrat].[ID] column
,@UsineID [varchar](6) = Null -- for [Contrat].[UsineID] column
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

		 [Contrat_Records].[ID]
		,[Contrat_Records].[Description]
		,[Contrat_Records].[UsineID]
		,[Contrat_Records].[Annee]
		,[Contrat_Records].[Date_debut]
		,[Contrat_Records].[Date_fin]
		,[Contrat_Records].[Actif]
		,[Contrat_Records].[PaieTransporteur]
		,[Contrat_Records].[Taux_Surcharge]
		,[Contrat_Records].[SurchargeManuel]
		,[Contrat_Records].[TxTransSameProd]
		,[Contrat_Records].[UsineID_ID]
		,[Contrat_Records].[UsineID_Description]
		,[Contrat_Records].[UsineID_UtilisationID]
		,[Contrat_Records].[UsineID_Paye_producteur]
		,[Contrat_Records].[UsineID_Paye_transporteur]
		,[Contrat_Records].[UsineID_Specification]
		,[Contrat_Records].[UsineID_Compte_a_recevoir]
		,[Contrat_Records].[UsineID_Compte_ajustement]
		,[Contrat_Records].[UsineID_Compte_transporteur]
		,[Contrat_Records].[UsineID_Compte_producteur]
		,[Contrat_Records].[UsineID_Compte_preleve_plan_conjoint]
		,[Contrat_Records].[UsineID_Compte_preleve_fond_roulement]
		,[Contrat_Records].[UsineID_Compte_preleve_fond_forestier]
		,[Contrat_Records].[UsineID_Compte_preleve_divers]
		,[Contrat_Records].[UsineID_Compte_mise_en_commun]
		,[Contrat_Records].[UsineID_Compte_surcharge]
		,[Contrat_Records].[UsineID_Compte_indexation_carburant]
		,[Contrat_Records].[UsineID_Actif]
		,[Contrat_Records].[UsineID_NePaiePasTPS]
		,[Contrat_Records].[UsineID_NePaiePasTVQ]
		,[Contrat_Records].[UsineID_NoTPS]
		,[Contrat_Records].[UsineID_NoTVQ]
		,[Contrat_Records].[UsineID_Compte_chargeur]
		,[Contrat_Records].[UsineID_UsineGestionVolume]
		,[Contrat_Records].[UsineID_AuSoinsDe]
		,[Contrat_Records].[UsineID_Rue]
		,[Contrat_Records].[UsineID_Ville]
		,[Contrat_Records].[UsineID_PaysID]
		,[Contrat_Records].[UsineID_Code_postal]
		,[Contrat_Records].[UsineID_Telephone]
		,[Contrat_Records].[UsineID_Telephone_Poste]
		,[Contrat_Records].[UsineID_Telecopieur]
		,[Contrat_Records].[UsineID_Telephone2]
		,[Contrat_Records].[UsineID_Telephone2_Desc]
		,[Contrat_Records].[UsineID_Telephone2_Poste]
		,[Contrat_Records].[UsineID_Telephone3]
		,[Contrat_Records].[UsineID_Telephone3_Desc]
		,[Contrat_Records].[UsineID_Telephone3_Poste]
		,[Contrat_Records].[UsineID_Email]

		From [fnContrat_Full](@ID, @UsineID) As [Contrat_Records]
	End

Else

	Begin
		Select

		 [Contrat_Records].[ID]
		,[Contrat_Records].[Description]
		,[Contrat_Records].[UsineID]
		,[Contrat_Records].[Annee]
		,[Contrat_Records].[Date_debut]
		,[Contrat_Records].[Date_fin]
		,[Contrat_Records].[Actif]
		,[Contrat_Records].[PaieTransporteur]
		,[Contrat_Records].[Taux_Surcharge]
		,[Contrat_Records].[SurchargeManuel]
		,[Contrat_Records].[TxTransSameProd]
		,[Contrat_Records].[UsineID_ID]
		,[Contrat_Records].[UsineID_Description]
		,[Contrat_Records].[UsineID_UtilisationID]
		,[Contrat_Records].[UsineID_Paye_producteur]
		,[Contrat_Records].[UsineID_Paye_transporteur]
		,[Contrat_Records].[UsineID_Specification]
		,[Contrat_Records].[UsineID_Compte_a_recevoir]
		,[Contrat_Records].[UsineID_Compte_ajustement]
		,[Contrat_Records].[UsineID_Compte_transporteur]
		,[Contrat_Records].[UsineID_Compte_producteur]
		,[Contrat_Records].[UsineID_Compte_preleve_plan_conjoint]
		,[Contrat_Records].[UsineID_Compte_preleve_fond_roulement]
		,[Contrat_Records].[UsineID_Compte_preleve_fond_forestier]
		,[Contrat_Records].[UsineID_Compte_preleve_divers]
		,[Contrat_Records].[UsineID_Compte_mise_en_commun]
		,[Contrat_Records].[UsineID_Compte_surcharge]
		,[Contrat_Records].[UsineID_Compte_indexation_carburant]
		,[Contrat_Records].[UsineID_Actif]
		,[Contrat_Records].[UsineID_NePaiePasTPS]
		,[Contrat_Records].[UsineID_NePaiePasTVQ]
		,[Contrat_Records].[UsineID_NoTPS]
		,[Contrat_Records].[UsineID_NoTVQ]
		,[Contrat_Records].[UsineID_Compte_chargeur]
		,[Contrat_Records].[UsineID_UsineGestionVolume]
		,[Contrat_Records].[UsineID_AuSoinsDe]
		,[Contrat_Records].[UsineID_Rue]
		,[Contrat_Records].[UsineID_Ville]
		,[Contrat_Records].[UsineID_PaysID]
		,[Contrat_Records].[UsineID_Code_postal]
		,[Contrat_Records].[UsineID_Telephone]
		,[Contrat_Records].[UsineID_Telephone_Poste]
		,[Contrat_Records].[UsineID_Telecopieur]
		,[Contrat_Records].[UsineID_Telephone2]
		,[Contrat_Records].[UsineID_Telephone2_Desc]
		,[Contrat_Records].[UsineID_Telephone2_Poste]
		,[Contrat_Records].[UsineID_Telephone3]
		,[Contrat_Records].[UsineID_Telephone3_Desc]
		,[Contrat_Records].[UsineID_Telephone3_Poste]
		,[Contrat_Records].[UsineID_Email]

		From [fnContrat_Full](@ID, @UsineID) As [Contrat_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


