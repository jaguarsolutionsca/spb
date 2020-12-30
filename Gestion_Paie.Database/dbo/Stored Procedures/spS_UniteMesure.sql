

Create Procedure [spS_UniteMesure]

-- Retrieve specific records from the [UniteMesure] table depending on the input parameters you supply.

(
 @ID [varchar](6) = Null -- for [UniteMesure].[ID] column
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

		 [UniteMesure_Records].[ID]
		,[UniteMesure_Records].[Description]
		,[UniteMesure_Records].[Nb_decimale]
		,[UniteMesure_Records].[Actif]
		,[UniteMesure_Records].[UseMontant]
		,[UniteMesure_Records].[Montant_Preleve_plan_conjoint]
		,[UniteMesure_Records].[Montant_Preleve_fond_roulement]
		,[UniteMesure_Records].[Montant_Preleve_fond_forestier]
		,[UniteMesure_Records].[Montant_Preleve_divers]
		,[UniteMesure_Records].[Pourc_Preleve_plan_conjoint]
		,[UniteMesure_Records].[Pourc_Preleve_fond_roulement]
		,[UniteMesure_Records].[Pourc_Preleve_fond_forestier]
		,[UniteMesure_Records].[Pourc_Preleve_divers]

		From [fnUniteMesure](@ID) As [UniteMesure_Records]
	End

Else

	Begin
		Select

		 [UniteMesure_Records].[ID]
		,[UniteMesure_Records].[Description]
		,[UniteMesure_Records].[Nb_decimale]
		,[UniteMesure_Records].[Actif]
		,[UniteMesure_Records].[UseMontant]
		,[UniteMesure_Records].[Montant_Preleve_plan_conjoint]
		,[UniteMesure_Records].[Montant_Preleve_fond_roulement]
		,[UniteMesure_Records].[Montant_Preleve_fond_forestier]
		,[UniteMesure_Records].[Montant_Preleve_divers]
		,[UniteMesure_Records].[Pourc_Preleve_plan_conjoint]
		,[UniteMesure_Records].[Pourc_Preleve_fond_roulement]
		,[UniteMesure_Records].[Pourc_Preleve_fond_forestier]
		,[UniteMesure_Records].[Pourc_Preleve_divers]

		From [fnUniteMesure](@ID) As [UniteMesure_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


