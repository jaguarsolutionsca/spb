

CREATE Procedure [spS_Indexation_EssenceUnite_SelectDisplay]

-- Retrieve specific records from the [Indexation_EssenceUnite] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Indexation_EssenceUnite].[ID] column
,@IndexationID [int] = Null -- for [Indexation_EssenceUnite].[IndexationID] column
,@ContratID [varchar](10) = Null -- for [Indexation_EssenceUnite].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Indexation_EssenceUnite].[EssenceID] column
,@Code [char](4) = Null -- for [Indexation_EssenceUnite].[Code] column
,@UniteID [varchar](6) = Null -- for [Indexation_EssenceUnite].[UniteID] column
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

		 [Indexation_EssenceUnite_Records].[ID]
		,[Indexation_EssenceUnite_Records].[IndexationID]
		,[Indexation_EssenceUnite_Records].[IndexationID_Display]
		,[Indexation_EssenceUnite_Records].[ContratID]
		,[Indexation_EssenceUnite_Records].[ContratID_Display]
		,[Indexation_EssenceUnite_Records].[EssenceID]
		,[Indexation_EssenceUnite_Records].[EssenceID_Display]
		,[Indexation_EssenceUnite_Records].[Code]
		,[Indexation_EssenceUnite_Records].[Code_Display]
		,[Indexation_EssenceUnite_Records].[UniteID]
		,[Indexation_EssenceUnite_Records].[UniteID_Display]
		,[Indexation_EssenceUnite_Records].[Taux]

		From [fnIndexation_EssenceUnite_SelectDisplay](@ID, @IndexationID, @ContratID, @EssenceID, @Code, @UniteID) As [Indexation_EssenceUnite_Records]
	End

Else

	Begin
		Select

		 [Indexation_EssenceUnite_Records].[ID]
		,[Indexation_EssenceUnite_Records].[IndexationID]
		,[Indexation_EssenceUnite_Records].[IndexationID_Display]
		,[Indexation_EssenceUnite_Records].[ContratID]
		,[Indexation_EssenceUnite_Records].[ContratID_Display]
		,[Indexation_EssenceUnite_Records].[EssenceID]
		,[Indexation_EssenceUnite_Records].[EssenceID_Display]
		,[Indexation_EssenceUnite_Records].[Code]
		,[Indexation_EssenceUnite_Records].[Code_Display]
		,[Indexation_EssenceUnite_Records].[UniteID]
		,[Indexation_EssenceUnite_Records].[UniteID_Display]
		,[Indexation_EssenceUnite_Records].[Taux]

		From [fnIndexation_EssenceUnite_SelectDisplay](@ID, @IndexationID, @ContratID, @EssenceID, @Code, @UniteID) As [Indexation_EssenceUnite_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


