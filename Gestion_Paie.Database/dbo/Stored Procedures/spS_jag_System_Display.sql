

CREATE Procedure [spS_jag_System_Display]

(
 @Fournisseur_PlanConjoint [varchar](15) = Null -- for [jag_System].[Fournisseur_PlanConjoint] column
,@Fournisseur_Surcharge [varchar](15) = Null -- for [jag_System].[Fournisseur_Surcharge] column
,@Compte_Paiements [int] = Null -- for [jag_System].[Compte_Paiements] column
,@Compte_ARecevoir [int] = Null -- for [jag_System].[Compte_ARecevoir] column
,@Compte_APayer [int] = Null -- for [jag_System].[Compte_APayer] column
,@Compte_DuAuxProducteurs [int] = Null -- for [jag_System].[Compte_DuAuxProducteurs] column
,@Compte_TPSpercues [int] = Null -- for [jag_System].[Compte_TPSpercues] column
,@Compte_TPSpayees [int] = Null -- for [jag_System].[Compte_TPSpayees] column
,@Compte_TVQpercues [int] = Null -- for [jag_System].[Compte_TVQpercues] column
,@Compte_TVQpayees [int] = Null -- for [jag_System].[Compte_TVQpayees] column
,@Fournisseur_Fond_Roulement [varchar](15) = Null -- for [jag_System].[Fournisseur_Surcharge] column
,@Fournisseur_Fond_Forestier [varchar](15) = Null -- for [jag_System].[Fournisseur_Surcharge] column
,@Fournisseur_Preleve_Divers [varchar](15) = Null -- for [jag_System].[Fournisseur_Surcharge] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [jag_System_Records].[Display]

From [fnjag_System_Display](@Fournisseur_PlanConjoint, @Fournisseur_Surcharge, @Compte_Paiements, @Compte_ARecevoir, @Compte_APayer, @Compte_DuAuxProducteurs, @Compte_TPSpercues, @Compte_TPSpayees, @Compte_TVQpercues, @Compte_TVQpayees,@Fournisseur_Fond_Roulement,@Fournisseur_Fond_Forestier,@Fournisseur_Preleve_Divers) As [jag_System_Records]

Return(@@RowCount)


