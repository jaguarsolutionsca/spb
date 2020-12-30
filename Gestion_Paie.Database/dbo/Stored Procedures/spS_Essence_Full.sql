

Create Procedure [spS_Essence_Full]

/*
Retrieve specific records from the [Essence] table, as well as all its foreign tables, depending on the input parameters you supply:
	[EssenceRegroupement] (via [RegroupementID])
	[EssenceContingent] (via [ContingentID])
	[EssenceRepartition] (via [RepartitionID])
*/

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
		,[Essence_Records].[RegroupementID_ID]
		,[Essence_Records].[RegroupementID_Description]
		,[Essence_Records].[RegroupementID_Actif]
		,[Essence_Records].[ContingentID_ID]
		,[Essence_Records].[ContingentID_Description]
		,[Essence_Records].[ContingentID_Actif]
		,[Essence_Records].[RepartitionID_ID]
		,[Essence_Records].[RepartitionID_Description]
		,[Essence_Records].[RepartitionID_Actif]

		From [fnEssence_Full](@ID, @RegroupementID, @ContingentID, @RepartitionID) As [Essence_Records]
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
		,[Essence_Records].[RegroupementID_ID]
		,[Essence_Records].[RegroupementID_Description]
		,[Essence_Records].[RegroupementID_Actif]
		,[Essence_Records].[ContingentID_ID]
		,[Essence_Records].[ContingentID_Description]
		,[Essence_Records].[ContingentID_Actif]
		,[Essence_Records].[RepartitionID_ID]
		,[Essence_Records].[RepartitionID_Description]
		,[Essence_Records].[RepartitionID_Actif]

		From [fnEssence_Full](@ID, @RegroupementID, @ContingentID, @RepartitionID) As [Essence_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


