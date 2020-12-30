

CREATE Function [fnjag_System_Display]
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


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Taux_TVQ] As [Display]
	
From [dbo].[jag_System]

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

Order By [Display]
)


