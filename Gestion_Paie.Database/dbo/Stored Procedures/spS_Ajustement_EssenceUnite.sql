CREATE Procedure [dbo].[spS_Ajustement_EssenceUnite]

-- Retrieve specific records from the [Ajustement_EssenceUnite] table depending on the input parameters you supply.

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

		From [fnAjustement_EssenceUnite](@AjustementID, @EssenceID, @UniteID, @Code, @ContratID) As [Ajustement_EssenceUnite_Records]
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

		From [fnAjustement_EssenceUnite](@AjustementID, @EssenceID, @UniteID, @Code, @ContratID) As [Ajustement_EssenceUnite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)
