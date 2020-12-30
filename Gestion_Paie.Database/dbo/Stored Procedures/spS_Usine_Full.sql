

Create Procedure [spS_Usine_Full]

/*
Retrieve specific records from the [Usine] table, as well as all its foreign tables, depending on the input parameters you supply:
	[UsineUtilisation] (via [UtilisationID])
	[Compte] (via [Compte_a_recevoir])
	[Compte] (via [Compte_ajustement])
	[Compte] (via [Compte_transporteur])
	[Compte] (via [Compte_producteur])
	[Compte] (via [Compte_preleve_plan_conjoint])
	[Compte] (via [Compte_preleve_fond_roulement])
	[Compte] (via [Compte_preleve_fond_forestier])
	[Compte] (via [Compte_preleve_divers])
	[Compte] (via [Compte_mise_en_commun])
	[Compte] (via [Compte_surcharge])
	[Compte] (via [Compte_indexation_carburant])
	[Pays] (via [PaysID])
*/

(
 @ID [varchar](6) = Null -- for [Usine].[ID] column
,@UtilisationID [int] = Null -- for [Usine].[UtilisationID] column
,@Compte_a_recevoir [int] = Null -- for [Usine].[Compte_a_recevoir] column
,@Compte_ajustement [int] = Null -- for [Usine].[Compte_ajustement] column
,@Compte_transporteur [int] = Null -- for [Usine].[Compte_transporteur] column
,@Compte_producteur [int] = Null -- for [Usine].[Compte_producteur] column
,@Compte_preleve_plan_conjoint [int] = Null -- for [Usine].[Compte_preleve_plan_conjoint] column
,@Compte_preleve_fond_roulement [int] = Null -- for [Usine].[Compte_preleve_fond_roulement] column
,@Compte_preleve_fond_forestier [int] = Null -- for [Usine].[Compte_preleve_fond_forestier] column
,@Compte_preleve_divers [int] = Null -- for [Usine].[Compte_preleve_divers] column
,@Compte_mise_en_commun [int] = Null -- for [Usine].[Compte_mise_en_commun] column
,@Compte_surcharge [int] = Null -- for [Usine].[Compte_surcharge] column
,@Compte_indexation_carburant [int] = Null -- for [Usine].[Compte_indexation_carburant] column
,@PaysID [varchar](2) = Null -- for [Usine].[PaysID] column
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

		 [Usine_Records].[ID]
		,[Usine_Records].[Description]
		,[Usine_Records].[UtilisationID]
		,[Usine_Records].[Paye_producteur]
		,[Usine_Records].[Paye_transporteur]
		,[Usine_Records].[Specification]
		,[Usine_Records].[Compte_a_recevoir]
		,[Usine_Records].[Compte_ajustement]
		,[Usine_Records].[Compte_transporteur]
		,[Usine_Records].[Compte_producteur]
		,[Usine_Records].[Compte_preleve_plan_conjoint]
		,[Usine_Records].[Compte_preleve_fond_roulement]
		,[Usine_Records].[Compte_preleve_fond_forestier]
		,[Usine_Records].[Compte_preleve_divers]
		,[Usine_Records].[Compte_mise_en_commun]
		,[Usine_Records].[Compte_surcharge]
		,[Usine_Records].[Compte_indexation_carburant]
		,[Usine_Records].[Actif]
		,[Usine_Records].[NePaiePasTPS]
		,[Usine_Records].[NePaiePasTVQ]
		,[Usine_Records].[NoTPS]
		,[Usine_Records].[NoTVQ]
		,[Usine_Records].[Compte_chargeur]
		,[Usine_Records].[UsineGestionVolume]
		,[Usine_Records].[AuSoinsDe]
		,[Usine_Records].[Rue]
		,[Usine_Records].[Ville]
		,[Usine_Records].[PaysID]
		,[Usine_Records].[Code_postal]
		,[Usine_Records].[Telephone]
		,[Usine_Records].[Telephone_Poste]
		,[Usine_Records].[Telecopieur]
		,[Usine_Records].[Telephone2]
		,[Usine_Records].[Telephone2_Desc]
		,[Usine_Records].[Telephone2_Poste]
		,[Usine_Records].[Telephone3]
		,[Usine_Records].[Telephone3_Desc]
		,[Usine_Records].[Telephone3_Poste]
		,[Usine_Records].[Email]
		,[Usine_Records].[UtilisationID_ID]
		,[Usine_Records].[UtilisationID_Description]
		,[Usine_Records].[UtilisationID_Actif]
		,[Usine_Records].[Compte_a_recevoir_ID]
		,[Usine_Records].[Compte_a_recevoir_Description]
		,[Usine_Records].[Compte_a_recevoir_CategoryID]
		,[Usine_Records].[Compte_a_recevoir_isTaxe]
		,[Usine_Records].[Compte_a_recevoir_Actif]
		,[Usine_Records].[Compte_ajustement_ID]
		,[Usine_Records].[Compte_ajustement_Description]
		,[Usine_Records].[Compte_ajustement_CategoryID]
		,[Usine_Records].[Compte_ajustement_isTaxe]
		,[Usine_Records].[Compte_ajustement_Actif]
		,[Usine_Records].[Compte_transporteur_ID]
		,[Usine_Records].[Compte_transporteur_Description]
		,[Usine_Records].[Compte_transporteur_CategoryID]
		,[Usine_Records].[Compte_transporteur_isTaxe]
		,[Usine_Records].[Compte_transporteur_Actif]
		,[Usine_Records].[Compte_producteur_ID]
		,[Usine_Records].[Compte_producteur_Description]
		,[Usine_Records].[Compte_producteur_CategoryID]
		,[Usine_Records].[Compte_producteur_isTaxe]
		,[Usine_Records].[Compte_producteur_Actif]
		,[Usine_Records].[Compte_preleve_plan_conjoint_ID]
		,[Usine_Records].[Compte_preleve_plan_conjoint_Description]
		,[Usine_Records].[Compte_preleve_plan_conjoint_CategoryID]
		,[Usine_Records].[Compte_preleve_plan_conjoint_isTaxe]
		,[Usine_Records].[Compte_preleve_plan_conjoint_Actif]
		,[Usine_Records].[Compte_preleve_fond_roulement_ID]
		,[Usine_Records].[Compte_preleve_fond_roulement_Description]
		,[Usine_Records].[Compte_preleve_fond_roulement_CategoryID]
		,[Usine_Records].[Compte_preleve_fond_roulement_isTaxe]
		,[Usine_Records].[Compte_preleve_fond_roulement_Actif]
		,[Usine_Records].[Compte_preleve_fond_forestier_ID]
		,[Usine_Records].[Compte_preleve_fond_forestier_Description]
		,[Usine_Records].[Compte_preleve_fond_forestier_CategoryID]
		,[Usine_Records].[Compte_preleve_fond_forestier_isTaxe]
		,[Usine_Records].[Compte_preleve_fond_forestier_Actif]
		,[Usine_Records].[Compte_preleve_divers_ID]
		,[Usine_Records].[Compte_preleve_divers_Description]
		,[Usine_Records].[Compte_preleve_divers_CategoryID]
		,[Usine_Records].[Compte_preleve_divers_isTaxe]
		,[Usine_Records].[Compte_preleve_divers_Actif]
		,[Usine_Records].[Compte_mise_en_commun_ID]
		,[Usine_Records].[Compte_mise_en_commun_Description]
		,[Usine_Records].[Compte_mise_en_commun_CategoryID]
		,[Usine_Records].[Compte_mise_en_commun_isTaxe]
		,[Usine_Records].[Compte_mise_en_commun_Actif]
		,[Usine_Records].[Compte_surcharge_ID]
		,[Usine_Records].[Compte_surcharge_Description]
		,[Usine_Records].[Compte_surcharge_CategoryID]
		,[Usine_Records].[Compte_surcharge_isTaxe]
		,[Usine_Records].[Compte_surcharge_Actif]
		,[Usine_Records].[Compte_indexation_carburant_ID]
		,[Usine_Records].[Compte_indexation_carburant_Description]
		,[Usine_Records].[Compte_indexation_carburant_CategoryID]
		,[Usine_Records].[Compte_indexation_carburant_isTaxe]
		,[Usine_Records].[Compte_indexation_carburant_Actif]
		,[Usine_Records].[PaysID_ID]
		,[Usine_Records].[PaysID_Nom]
		,[Usine_Records].[PaysID_CodePostal_InputMask]
		,[Usine_Records].[PaysID_Actif]

		From [fnUsine_Full](@ID, @UtilisationID, @Compte_a_recevoir, @Compte_ajustement, @Compte_transporteur, @Compte_producteur, @Compte_preleve_plan_conjoint, @Compte_preleve_fond_roulement, @Compte_preleve_fond_forestier, @Compte_preleve_divers, @Compte_mise_en_commun, @Compte_surcharge, @Compte_indexation_carburant, @PaysID) As [Usine_Records]
	End

Else

	Begin
		Select

		 [Usine_Records].[ID]
		,[Usine_Records].[Description]
		,[Usine_Records].[UtilisationID]
		,[Usine_Records].[Paye_producteur]
		,[Usine_Records].[Paye_transporteur]
		,[Usine_Records].[Specification]
		,[Usine_Records].[Compte_a_recevoir]
		,[Usine_Records].[Compte_ajustement]
		,[Usine_Records].[Compte_transporteur]
		,[Usine_Records].[Compte_producteur]
		,[Usine_Records].[Compte_preleve_plan_conjoint]
		,[Usine_Records].[Compte_preleve_fond_roulement]
		,[Usine_Records].[Compte_preleve_fond_forestier]
		,[Usine_Records].[Compte_preleve_divers]
		,[Usine_Records].[Compte_mise_en_commun]
		,[Usine_Records].[Compte_surcharge]
		,[Usine_Records].[Compte_indexation_carburant]
		,[Usine_Records].[Actif]
		,[Usine_Records].[NePaiePasTPS]

		,[Usine_Records].[NePaiePasTVQ]
		,[Usine_Records].[NoTPS]
		,[Usine_Records].[NoTVQ]
		,[Usine_Records].[Compte_chargeur]
		,[Usine_Records].[UsineGestionVolume]
		,[Usine_Records].[AuSoinsDe]
		,[Usine_Records].[Rue]
		,[Usine_Records].[Ville]
		,[Usine_Records].[PaysID]
		,[Usine_Records].[Code_postal]
		,[Usine_Records].[Telephone]
		,[Usine_Records].[Telephone_Poste]
		,[Usine_Records].[Telecopieur]
		,[Usine_Records].[Telephone2]
		,[Usine_Records].[Telephone2_Desc]
		,[Usine_Records].[Telephone2_Poste]
		,[Usine_Records].[Telephone3]
		,[Usine_Records].[Telephone3_Desc]
		,[Usine_Records].[Telephone3_Poste]
		,[Usine_Records].[Email]
		,[Usine_Records].[UtilisationID_ID]
		,[Usine_Records].[UtilisationID_Description]
		,[Usine_Records].[UtilisationID_Actif]
		,[Usine_Records].[Compte_a_recevoir_ID]
		,[Usine_Records].[Compte_a_recevoir_Description]
		,[Usine_Records].[Compte_a_recevoir_CategoryID]
		,[Usine_Records].[Compte_a_recevoir_isTaxe]
		,[Usine_Records].[Compte_a_recevoir_Actif]
		,[Usine_Records].[Compte_ajustement_ID]
		,[Usine_Records].[Compte_ajustement_Description]
		,[Usine_Records].[Compte_ajustement_CategoryID]
		,[Usine_Records].[Compte_ajustement_isTaxe]
		,[Usine_Records].[Compte_ajustement_Actif]
		,[Usine_Records].[Compte_transporteur_ID]
		,[Usine_Records].[Compte_transporteur_Description]
		,[Usine_Records].[Compte_transporteur_CategoryID]
		,[Usine_Records].[Compte_transporteur_isTaxe]
		,[Usine_Records].[Compte_transporteur_Actif]
		,[Usine_Records].[Compte_producteur_ID]
		,[Usine_Records].[Compte_producteur_Description]
		,[Usine_Records].[Compte_producteur_CategoryID]
		,[Usine_Records].[Compte_producteur_isTaxe]
		,[Usine_Records].[Compte_producteur_Actif]
		,[Usine_Records].[Compte_preleve_plan_conjoint_ID]
		,[Usine_Records].[Compte_preleve_plan_conjoint_Description]
		,[Usine_Records].[Compte_preleve_plan_conjoint_CategoryID]
		,[Usine_Records].[Compte_preleve_plan_conjoint_isTaxe]
		,[Usine_Records].[Compte_preleve_plan_conjoint_Actif]
		,[Usine_Records].[Compte_preleve_fond_roulement_ID]
		,[Usine_Records].[Compte_preleve_fond_roulement_Description]
		,[Usine_Records].[Compte_preleve_fond_roulement_CategoryID]
		,[Usine_Records].[Compte_preleve_fond_roulement_isTaxe]
		,[Usine_Records].[Compte_preleve_fond_roulement_Actif]
		,[Usine_Records].[Compte_preleve_fond_forestier_ID]
		,[Usine_Records].[Compte_preleve_fond_forestier_Description]
		,[Usine_Records].[Compte_preleve_fond_forestier_CategoryID]
		,[Usine_Records].[Compte_preleve_fond_forestier_isTaxe]
		,[Usine_Records].[Compte_preleve_fond_forestier_Actif]
		,[Usine_Records].[Compte_preleve_divers_ID]
		,[Usine_Records].[Compte_preleve_divers_Description]
		,[Usine_Records].[Compte_preleve_divers_CategoryID]
		,[Usine_Records].[Compte_preleve_divers_isTaxe]
		,[Usine_Records].[Compte_preleve_divers_Actif]
		,[Usine_Records].[Compte_mise_en_commun_ID]
		,[Usine_Records].[Compte_mise_en_commun_Description]
		,[Usine_Records].[Compte_mise_en_commun_CategoryID]
		,[Usine_Records].[Compte_mise_en_commun_isTaxe]
		,[Usine_Records].[Compte_mise_en_commun_Actif]
		,[Usine_Records].[Compte_surcharge_ID]
		,[Usine_Records].[Compte_surcharge_Description]
		,[Usine_Records].[Compte_surcharge_CategoryID]
		,[Usine_Records].[Compte_surcharge_isTaxe]
		,[Usine_Records].[Compte_surcharge_Actif]
		,[Usine_Records].[Compte_indexation_carburant_ID]
		,[Usine_Records].[Compte_indexation_carburant_Description]
		,[Usine_Records].[Compte_indexation_carburant_CategoryID]
		,[Usine_Records].[Compte_indexation_carburant_isTaxe]
		,[Usine_Records].[Compte_indexation_carburant_Actif]
		,[Usine_Records].[PaysID_ID]
		,[Usine_Records].[PaysID_Nom]
		,[Usine_Records].[PaysID_CodePostal_InputMask]
		,[Usine_Records].[PaysID_Actif]

		From [fnUsine_Full](@ID, @UtilisationID, @Compte_a_recevoir, @Compte_ajustement, @Compte_transporteur, @Compte_producteur, @Compte_preleve_plan_conjoint, @Compte_preleve_fond_roulement, @Compte_preleve_fond_forestier, @Compte_preleve_divers, @Compte_mise_en_commun, @Compte_surcharge, @Compte_indexation_carburant, @PaysID) As [Usine_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


