CREATE Procedure [dbo].[spS_Ajustement_EssenceUnite_Full]

/*
Retrieve specific records from the [Ajustement_EssenceUnite] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Ajustement] (via [AjustementID])
	[Contrat_EssenceUnite] (via [EssenceID])
	[Contrat_EssenceUnite] (via [UniteID])
	[Contrat_EssenceUnite] (via [ContratID])
	[Contrat_EssenceUnite] (via [Code])
*/

(
 @AjustementID [int] = Null -- for [Ajustement_EssenceUnite].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [Ajustement_EssenceUnite].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [Ajustement_EssenceUnite].[UniteID] column
,@Code [char](4) = Null -- for [Ajustement_EssenceUnite].[Code] column
,@ContratID [varchar](10) = Null -- for [Ajustement_EssenceUnite].[ContratID] column
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

		 [Ajustement_EssenceUnite_Records].[AjustementID]
		,[Ajustement_EssenceUnite_Records].[EssenceID]
		,[Ajustement_EssenceUnite_Records].[UniteID]
		,[Ajustement_EssenceUnite_Records].[ContratID]
		,[Ajustement_EssenceUnite_Records].[Taux_usine]
		,[Ajustement_EssenceUnite_Records].[Taux_producteur]
		,[Ajustement_EssenceUnite_Records].[Taux_transporteur]
		,[Ajustement_EssenceUnite_Records].[Date_Modification]
		,[Ajustement_EssenceUnite_Records].[Code]
		,[Ajustement_EssenceUnite_Records].[ContratID_ContratID]
		,[Ajustement_EssenceUnite_Records].[ContratID_EssenceID]
		,[Ajustement_EssenceUnite_Records].[ContratID_UniteID]
		,[Ajustement_EssenceUnite_Records].[ContratID_Code]
		,[Ajustement_EssenceUnite_Records].[ContratID_Quantite_prevue]
		,[Ajustement_EssenceUnite_Records].[ContratID_Taux_usine]
		,[Ajustement_EssenceUnite_Records].[ContratID_Taux_producteur]
		,[Ajustement_EssenceUnite_Records].[ContratID_Actif]
		,[Ajustement_EssenceUnite_Records].[ContratID_Description]

		From [fnAjustement_EssenceUnite_Full](@AjustementID, @EssenceID, @UniteID, @Code, @ContratID) As [Ajustement_EssenceUnite_Records]
	End

Else

	Begin
		Select

		 [Ajustement_EssenceUnite_Records].[AjustementID]
		,[Ajustement_EssenceUnite_Records].[EssenceID]
		,[Ajustement_EssenceUnite_Records].[UniteID]
		,[Ajustement_EssenceUnite_Records].[ContratID]
		,[Ajustement_EssenceUnite_Records].[Taux_usine]
		,[Ajustement_EssenceUnite_Records].[Taux_producteur]
		,[Ajustement_EssenceUnite_Records].[Taux_transporteur]
		,[Ajustement_EssenceUnite_Records].[Date_Modification]
		,[Ajustement_EssenceUnite_Records].[Code]
		,[Ajustement_EssenceUnite_Records].[ContratID_ContratID]
		,[Ajustement_EssenceUnite_Records].[ContratID_EssenceID]
		,[Ajustement_EssenceUnite_Records].[ContratID_UniteID]
		,[Ajustement_EssenceUnite_Records].[ContratID_Code]
		,[Ajustement_EssenceUnite_Records].[ContratID_Quantite_prevue]
		,[Ajustement_EssenceUnite_Records].[ContratID_Taux_usine]
		,[Ajustement_EssenceUnite_Records].[ContratID_Taux_producteur]
		,[Ajustement_EssenceUnite_Records].[ContratID_Actif]
		,[Ajustement_EssenceUnite_Records].[ContratID_Description]

		From [fnAjustement_EssenceUnite_Full](@AjustementID, @EssenceID, @UniteID, @Code, @ContratID) As [Ajustement_EssenceUnite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)
