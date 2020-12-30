

Create Procedure [spS_Contrat_EssenceUnite_Full]

/*
Retrieve specific records from the [Contrat_EssenceUnite] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Contrat] (via [ContratID])
	[Essence_Unite] (via [EssenceID])
	[Essence_Unite] (via [UniteID])
*/

(
 @ContratID [varchar](10) = Null -- for [Contrat_EssenceUnite].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Contrat_EssenceUnite].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [Contrat_EssenceUnite].[UniteID] column
,@Code [char](4) = Null -- for [Contrat_EssenceUnite].[Code] column
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

		 [Contrat_EssenceUnite_Records].[ContratID]
		,[Contrat_EssenceUnite_Records].[EssenceID]
		,[Contrat_EssenceUnite_Records].[UniteID]
		,[Contrat_EssenceUnite_Records].[Code]
		,[Contrat_EssenceUnite_Records].[Quantite_prevue]
		,[Contrat_EssenceUnite_Records].[Taux_usine]
		,[Contrat_EssenceUnite_Records].[Taux_producteur]
		,[Contrat_EssenceUnite_Records].[Actif]
		,[Contrat_EssenceUnite_Records].[Description]

		From [fnContrat_EssenceUnite_Full](@ContratID, @EssenceID, @UniteID, @Code) As [Contrat_EssenceUnite_Records]
	End

Else

	Begin
		Select

		 [Contrat_EssenceUnite_Records].[ContratID]
		,[Contrat_EssenceUnite_Records].[EssenceID]
		,[Contrat_EssenceUnite_Records].[UniteID]
		,[Contrat_EssenceUnite_Records].[Code]
		,[Contrat_EssenceUnite_Records].[Quantite_prevue]
		,[Contrat_EssenceUnite_Records].[Taux_usine]
		,[Contrat_EssenceUnite_Records].[Taux_producteur]
		,[Contrat_EssenceUnite_Records].[Actif]
		,[Contrat_EssenceUnite_Records].[Description]

		From [fnContrat_EssenceUnite_Full](@ContratID, @EssenceID, @UniteID, @Code) As [Contrat_EssenceUnite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


