

CREATE Procedure [spS_jag_System_SelectDisplay]

-- Retrieve specific records from the [jag_System] table depending on the input parameters you supply.

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
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
,@Fournisseur_Fond_Roulement [varchar](15) = Null -- for [jag_System].[Fournisseur_Surcharge] column
,@Fournisseur_Fond_Forestier [varchar](15) = Null -- for [jag_System].[Fournisseur_Surcharge] column
,@Fournisseur_Preleve_Divers [varchar](15) = Null -- for [jag_System].[Fournisseur_Surcharge] column
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

		 [jag_System_Records].[Fournisseur_PlanConjoint]
		,[jag_System_Records].[Fournisseur_PlanConjoint_Display]
		,[jag_System_Records].[Fournisseur_Surcharge]
		,[jag_System_Records].[Fournisseur_Surcharge_Display]
		,[jag_System_Records].[Compte_Paiements]
		,[jag_System_Records].[Compte_Paiements_Display]
		,[jag_System_Records].[Compte_ARecevoir]
		,[jag_System_Records].[Compte_ARecevoir_Display]
		,[jag_System_Records].[Compte_APayer]
		,[jag_System_Records].[Compte_APayer_Display]
		,[jag_System_Records].[Compte_DuAuxProducteurs]
		,[jag_System_Records].[Compte_DuAuxProducteurs_Display]
		,[jag_System_Records].[Compte_TPSpercues]
		,[jag_System_Records].[Compte_TPSpercues_Display]
		,[jag_System_Records].[Compte_TPSpayees]
		,[jag_System_Records].[Compte_TPSpayees_Display]
		,[jag_System_Records].[Compte_TVQpercues]
		,[jag_System_Records].[Compte_TVQpercues_Display]
		,[jag_System_Records].[Compte_TVQpayees]
		,[jag_System_Records].[Compte_TVQpayees_Display]
		,[jag_System_Records].[Taux_TPS]
		,[jag_System_Records].[Taux_TVQ]
		,[jag_System_Records].[Fournisseur_Fond_Roulement]
		,[jag_System_Records].[Fournisseur_Fond_Roulement_Display]
		,[jag_System_Records].[Fournisseur_Fond_Forestier]
		,[jag_System_Records].[Fournisseur_Fond_Forestier_Display]
		,[jag_System_Records].[Fournisseur_Preleve_Divers]
		,[jag_System_Records].[Fournisseur_Preleve_Divers_Display]

		From [fnjag_System_SelectDisplay](@Fournisseur_PlanConjoint, @Fournisseur_Surcharge, @Compte_Paiements, @Compte_ARecevoir, @Compte_APayer, @Compte_DuAuxProducteurs, @Compte_TPSpercues, @Compte_TPSpayees, @Compte_TVQpercues, @Compte_TVQpayees,@Fournisseur_Fond_Roulement,@Fournisseur_Fond_Forestier,@Fournisseur_Preleve_Divers) As [jag_System_Records]

	End

Else

	Begin
		Select

		 [jag_System_Records].[Fournisseur_PlanConjoint]
		,[jag_System_Records].[Fournisseur_PlanConjoint_Display]
		,[jag_System_Records].[Fournisseur_Surcharge]
		,[jag_System_Records].[Fournisseur_Surcharge_Display]
		,[jag_System_Records].[Compte_Paiements]
		,[jag_System_Records].[Compte_Paiements_Display]
		,[jag_System_Records].[Compte_ARecevoir]
		,[jag_System_Records].[Compte_ARecevoir_Display]
		,[jag_System_Records].[Compte_APayer]
		,[jag_System_Records].[Compte_APayer_Display]
		,[jag_System_Records].[Compte_DuAuxProducteurs]
		,[jag_System_Records].[Compte_DuAuxProducteurs_Display]
		,[jag_System_Records].[Compte_TPSpercues]
		,[jag_System_Records].[Compte_TPSpercues_Display]
		,[jag_System_Records].[Compte_TPSpayees]
		,[jag_System_Records].[Compte_TPSpayees_Display]
		,[jag_System_Records].[Compte_TVQpercues]
		,[jag_System_Records].[Compte_TVQpercues_Display]
		,[jag_System_Records].[Compte_TVQpayees]
		,[jag_System_Records].[Compte_TVQpayees_Display]
		,[jag_System_Records].[Taux_TPS]
		,[jag_System_Records].[Taux_TVQ]
		,[jag_System_Records].[Fournisseur_Fond_Roulement]
		,[jag_System_Records].[Fournisseur_Fond_Roulement_Display]
		,[jag_System_Records].[Fournisseur_Fond_Forestier]
		,[jag_System_Records].[Fournisseur_Fond_Forestier_Display]
		,[jag_System_Records].[Fournisseur_Preleve_Divers]
		,[jag_System_Records].[Fournisseur_Preleve_Divers_Display]

		From [fnjag_System_SelectDisplay](@Fournisseur_PlanConjoint, @Fournisseur_Surcharge, @Compte_Paiements, @Compte_ARecevoir, @Compte_APayer, @Compte_DuAuxProducteurs, @Compte_TPSpercues, @Compte_TPSpayees, @Compte_TVQpercues, @Compte_TVQpayees,@Fournisseur_Fond_Roulement,@Fournisseur_Fond_Forestier,@Fournisseur_Preleve_Divers) As [jag_System_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


