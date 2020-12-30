

Create Procedure [spS_Usine_Display]

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
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Usine_Records].[ID1]
,[Usine_Records].[Display]

From [fnUsine_Display](@ID, @UtilisationID, @Compte_a_recevoir, @Compte_ajustement, @Compte_transporteur, @Compte_producteur, @Compte_preleve_plan_conjoint, @Compte_preleve_fond_roulement, @Compte_preleve_fond_forestier, @Compte_preleve_divers, @Compte_mise_en_commun, @Compte_surcharge, @Compte_indexation_carburant, @PaysID) As [Usine_Records]

Return(@@RowCount)


