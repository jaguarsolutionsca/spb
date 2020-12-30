

Create Procedure [spS_Usine_SelectDisplay]

-- Retrieve specific records from the [Usine] table depending on the input parameters you supply.

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
		,[Usine_Records].[UtilisationID_Display]
		,[Usine_Records].[Paye_producteur]
		,[Usine_Records].[Paye_transporteur]
		,[Usine_Records].[Specification]
		,[Usine_Records].[Compte_a_recevoir]
		,[Usine_Records].[Compte_a_recevoir_Display]
		,[Usine_Records].[Compte_ajustement]
		,[Usine_Records].[Compte_ajustement_Display]
		,[Usine_Records].[Compte_transporteur]
		,[Usine_Records].[Compte_transporteur_Display]
		,[Usine_Records].[Compte_producteur]
		,[Usine_Records].[Compte_producteur_Display]
		,[Usine_Records].[Compte_preleve_plan_conjoint]
		,[Usine_Records].[Compte_preleve_plan_conjoint_Display]
		,[Usine_Records].[Compte_preleve_fond_roulement]
		,[Usine_Records].[Compte_preleve_fond_roulement_Display]
		,[Usine_Records].[Compte_preleve_fond_forestier]
		,[Usine_Records].[Compte_preleve_fond_forestier_Display]
		,[Usine_Records].[Compte_preleve_divers]
		,[Usine_Records].[Compte_preleve_divers_Display]
		,[Usine_Records].[Compte_mise_en_commun]
		,[Usine_Records].[Compte_mise_en_commun_Display]
		,[Usine_Records].[Compte_surcharge]
		,[Usine_Records].[Compte_surcharge_Display]
		,[Usine_Records].[Compte_indexation_carburant]
		,[Usine_Records].[Compte_indexation_carburant_Display]
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
		,[Usine_Records].[PaysID_Display]
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

		From [fnUsine_SelectDisplay](@ID, @UtilisationID, @Compte_a_recevoir, @Compte_ajustement, @Compte_transporteur, @Compte_producteur, @Compte_preleve_plan_conjoint, @Compte_preleve_fond_roulement, @Compte_preleve_fond_forestier, @Compte_preleve_divers, @Compte_mise_en_commun, @Compte_surcharge, @Compte_indexation_carburant, @PaysID) As [Usine_Records]
	End

Else

	Begin
		Select

		 [Usine_Records].[ID]
		,[Usine_Records].[Description]
		,[Usine_Records].[UtilisationID]
		,[Usine_Records].[UtilisationID_Display]
		,[Usine_Records].[Paye_producteur]
		,[Usine_Records].[Paye_transporteur]
		,[Usine_Records].[Specification]
		,[Usine_Records].[Compte_a_recevoir]
		,[Usine_Records].[Compte_a_recevoir_Display]
		,[Usine_Records].[Compte_ajustement]
		,[Usine_Records].[Compte_ajustement_Display]
		,[Usine_Records].[Compte_transporteur]
		,[Usine_Records].[Compte_transporteur_Display]
		,[Usine_Records].[Compte_producteur]
		,[Usine_Records].[Compte_producteur_Display]
		,[Usine_Records].[Compte_preleve_plan_conjoint]
		,[Usine_Records].[Compte_preleve_plan_conjoint_Display]
		,[Usine_Records].[Compte_preleve_fond_roulement]
		,[Usine_Records].[Compte_preleve_fond_roulement_Display]
		,[Usine_Records].[Compte_preleve_fond_forestier]
		,[Usine_Records].[Compte_preleve_fond_forestier_Display]
		,[Usine_Records].[Compte_preleve_divers]
		,[Usine_Records].[Compte_preleve_divers_Display]
		,[Usine_Records].[Compte_mise_en_commun]
		,[Usine_Records].[Compte_mise_en_commun_Display]
		,[Usine_Records].[Compte_surcharge]
		,[Usine_Records].[Compte_surcharge_Display]
		,[Usine_Records].[Compte_indexation_carburant]
		,[Usine_Records].[Compte_indexation_carburant_Display]
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
		,[Usine_Records].[PaysID_Display]
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

		From [fnUsine_SelectDisplay](@ID, @UtilisationID, @Compte_a_recevoir, @Compte_ajustement, @Compte_transporteur, @Compte_producteur, @Compte_preleve_plan_conjoint, @Compte_preleve_fond_roulement, @Compte_preleve_fond_forestier, @Compte_preleve_divers, @Compte_mise_en_commun, @Compte_surcharge, @Compte_indexation_carburant, @PaysID) As [Usine_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


