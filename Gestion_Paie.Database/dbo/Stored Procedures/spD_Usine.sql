

Create Procedure [spD_Usine]

-- Delete a specific record from table [Usine]

(
 @ID [varchar](6) -- for [Usine].[ID] column
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

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Usine]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@UtilisationID Is Null) Or ([UtilisationID] = @UtilisationID))
And ((@Compte_a_recevoir Is Null) Or ([Compte_a_recevoir] = @Compte_a_recevoir))
And ((@Compte_ajustement Is Null) Or ([Compte_ajustement] = @Compte_ajustement))
And ((@Compte_transporteur Is Null) Or ([Compte_transporteur] = @Compte_transporteur))
And ((@Compte_producteur Is Null) Or ([Compte_producteur] = @Compte_producteur))
And ((@Compte_preleve_plan_conjoint Is Null) Or ([Compte_preleve_plan_conjoint] = @Compte_preleve_plan_conjoint))
And ((@Compte_preleve_fond_roulement Is Null) Or ([Compte_preleve_fond_roulement] = @Compte_preleve_fond_roulement))
And ((@Compte_preleve_fond_forestier Is Null) Or ([Compte_preleve_fond_forestier] = @Compte_preleve_fond_forestier))
And ((@Compte_preleve_divers Is Null) Or ([Compte_preleve_divers] = @Compte_preleve_divers))
And ((@Compte_mise_en_commun Is Null) Or ([Compte_mise_en_commun] = @Compte_mise_en_commun))
And ((@Compte_surcharge Is Null) Or ([Compte_surcharge] = @Compte_surcharge))
And ((@Compte_indexation_carburant Is Null) Or ([Compte_indexation_carburant] = @Compte_indexation_carburant))
And ((@PaysID Is Null) Or ([PaysID] = @PaysID))

Set NoCount Off

Return(@@RowCount)


