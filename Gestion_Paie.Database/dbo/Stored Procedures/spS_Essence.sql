

Create Procedure [spS_Essence]

-- Retrieve specific records from the [Essence] table depending on the input parameters you supply.

(
 @ID [varchar](6) = Null -- for [Essence].[ID] column
,@RegroupementID [int] = Null -- for [Essence].[RegroupementID] column
,@ContingentID [int] = Null -- for [Essence].[ContingentID] column
,@RepartitionID [int] = Null -- for [Essence].[RepartitionID] column
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

		 [Essence_Records].[ID]
		,[Essence_Records].[Description]
		,[Essence_Records].[RegroupementID]
		,[Essence_Records].[ContingentID]
		,[Essence_Records].[RepartitionID]
		,[Essence_Records].[Actif]

		From [fnEssence](@ID, @RegroupementID, @ContingentID, @RepartitionID) As [Essence_Records]
	End

Else

	Begin
		Select

		 [Essence_Records].[ID]
		,[Essence_Records].[Description]
		,[Essence_Records].[RegroupementID]
		,[Essence_Records].[ContingentID]
		,[Essence_Records].[RepartitionID]
		,[Essence_Records].[Actif]

		From [fnEssence](@ID, @RegroupementID, @ContingentID, @RepartitionID) As [Essence_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


