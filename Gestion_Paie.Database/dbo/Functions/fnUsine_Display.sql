

Create Function [fnUsine_Display]
(
 @ID [varchar](6) = Null
,@UtilisationID [int] = Null
,@Compte_a_recevoir [int] = Null
,@Compte_ajustement [int] = Null
,@Compte_transporteur [int] = Null
,@Compte_producteur [int] = Null
,@Compte_preleve_plan_conjoint [int] = Null
,@Compte_preleve_fond_roulement [int] = Null
,@Compte_preleve_fond_forestier [int] = Null
,@Compte_preleve_divers [int] = Null
,@Compte_mise_en_commun [int] = Null
,@Compte_surcharge [int] = Null
,@Compte_indexation_carburant [int] = Null
,@PaysID [varchar](2) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Description] As [Display]
	
From [dbo].[Usine]

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

Order By [Display]
)


