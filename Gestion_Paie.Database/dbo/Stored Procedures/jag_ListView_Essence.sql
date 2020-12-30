

CREATE Procedure jag_ListView_Essence
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
,@Actif bit = null
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


		Select

		 [Essence_Records].[Description]
		,[Essence_Records].[ID]
		,[Essence_Records].[RegroupementID_Description]
		--,[Essence_Records].[ContingentID_Description]
		,[Essence_Records].[RepartitionID_Description]
		,[Essence_Records].[Actif]

		From [fnEssence_Full](@ID, @RegroupementID, @ContingentID, @RepartitionID) As [Essence_Records]
		
		where ((@Actif is null) or ([Essence_Records].[Actif] = @Actif))

Return(@@RowCount)



