

CREATE Function [fnjag_System_SelectDisplay]
(
 @Fournisseur_PlanConjoint [varchar](15) = Null
,@Fournisseur_Surcharge [varchar](15) = Null
,@Compte_Paiements [int] = Null
,@Compte_ARecevoir [int] = Null
,@Compte_APayer [int] = Null
,@Compte_DuAuxProducteurs [int] = Null
,@Compte_TPSpercues [int] = Null
,@Compte_TPSpayees [int] = Null
,@Compte_TVQpercues [int] = Null
,@Compte_TVQpayees [int] = Null
,@Fournisseur_Fond_Roulement [varchar](15) = Null
,@Fournisseur_Fond_Forestier [varchar](15) = Null
,@Fournisseur_Preleve_Divers [varchar](15) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [jag_System].[Fournisseur_PlanConjoint]
	,[Fournisseur1].[Display] [Fournisseur_PlanConjoint_Display]
	,[jag_System].[Fournisseur_Surcharge]
	,[Fournisseur2].[Display] [Fournisseur_Surcharge_Display]
	,[jag_System].[Compte_Paiements]
	,[Compte3].[Display] [Compte_Paiements_Display]
	,[jag_System].[Compte_ARecevoir]
	,[Compte4].[Display] [Compte_ARecevoir_Display]
	,[jag_System].[Compte_APayer]
	,[Compte5].[Display] [Compte_APayer_Display]
	,[jag_System].[Compte_DuAuxProducteurs]
	,[Compte6].[Display] [Compte_DuAuxProducteurs_Display]
	,[jag_System].[Compte_TPSpercues]
	,[Compte7].[Display] [Compte_TPSpercues_Display]
	,[jag_System].[Compte_TPSpayees]
	,[Compte8].[Display] [Compte_TPSpayees_Display]
	,[jag_System].[Compte_TVQpercues]
	,[Compte9].[Display] [Compte_TVQpercues_Display]
	,[jag_System].[Compte_TVQpayees]
	,[Compte10].[Display] [Compte_TVQpayees_Display]
	,[jag_System].[Taux_TPS]
	,[jag_System].[Taux_TVQ]
	,[jag_System].[Fournisseur_Fond_Roulement]
	,[Fournisseur11].[Display] [Fournisseur_Fond_Roulement_Display]
	,[jag_System].[Fournisseur_Fond_Forestier]
	,[Fournisseur12].[Display] [Fournisseur_Fond_Forestier_Display]
	,[jag_System].[Fournisseur_Preleve_Divers]
	,[Fournisseur13].[Display] [Fournisseur_Preleve_Divers_Display]

From [dbo].[jag_System]
    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur1] On [Fournisseur_PlanConjoint] = [Fournisseur1].[ID1]
        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur2] On [Fournisseur_Surcharge] = [Fournisseur2].[ID1]
            Left Outer Join [fnCompte_Display](Null, Null) [Compte3] On [Compte_Paiements] = [Compte3].[ID1]
                Left Outer Join [fnCompte_Display](Null, Null) [Compte4] On [Compte_ARecevoir] = [Compte4].[ID1]
                    Left Outer Join [fnCompte_Display](Null, Null) [Compte5] On [Compte_APayer] = [Compte5].[ID1]
                        Left Outer Join [fnCompte_Display](Null, Null) [Compte6] On [Compte_DuAuxProducteurs] = [Compte6].[ID1]
                            Left Outer Join [fnCompte_Display](Null, Null) [Compte7] On [Compte_TPSpercues] = [Compte7].[ID1]
                                Left Outer Join [fnCompte_Display](Null, Null) [Compte8] On [Compte_TPSpayees] = [Compte8].[ID1]
                                    Left Outer Join [fnCompte_Display](Null, Null) [Compte9] On [Compte_TVQpercues] = [Compte9].[ID1]
                                        Left Outer Join [fnCompte_Display](Null, Null) [Compte10] On [Compte_TVQpayees] = [Compte10].[ID1]
									        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur11] On [Fournisseur_Fond_Roulement] = [Fournisseur11].[ID1]
										        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur12] On [Fournisseur_Fond_Forestier] = [Fournisseur12].[ID1]
											        Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur13] On [Fournisseur_Preleve_Divers] = [Fournisseur13].[ID1]

Where

    ((@Fournisseur_PlanConjoint Is Null) Or ([Fournisseur_PlanConjoint] = @Fournisseur_PlanConjoint))
And ((@Fournisseur_Surcharge Is Null) Or ([Fournisseur_Surcharge] = @Fournisseur_Surcharge))
And ((@Compte_Paiements Is Null) Or ([Compte_Paiements] = @Compte_Paiements))
And ((@Compte_ARecevoir Is Null) Or ([Compte_ARecevoir] = @Compte_ARecevoir))
And ((@Compte_APayer Is Null) Or ([Compte_APayer] = @Compte_APayer))
And ((@Compte_DuAuxProducteurs Is Null) Or ([Compte_DuAuxProducteurs] = @Compte_DuAuxProducteurs))
And ((@Compte_TPSpercues Is Null) Or ([Compte_TPSpercues] = @Compte_TPSpercues))
And ((@Compte_TPSpayees Is Null) Or ([Compte_TPSpayees] = @Compte_TPSpayees))
And ((@Compte_TVQpercues Is Null) Or ([Compte_TVQpercues] = @Compte_TVQpercues))
And ((@Compte_TVQpayees Is Null) Or ([Compte_TVQpayees] = @Compte_TVQpayees))
And ((@Fournisseur_Fond_Roulement Is Null) Or ([Fournisseur_Fond_Roulement] = @Fournisseur_Fond_Roulement))
And ((@Fournisseur_Fond_Forestier Is Null) Or ([Fournisseur_Fond_Forestier] = @Fournisseur_Fond_Forestier))
And ((@Fournisseur_Preleve_Divers Is Null) Or ([Fournisseur_Preleve_Divers] = @Fournisseur_Preleve_Divers))
)


