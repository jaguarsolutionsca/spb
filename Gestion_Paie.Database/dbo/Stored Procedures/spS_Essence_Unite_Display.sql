

Create Procedure [spS_Essence_Unite_Display]

(
 @EssenceID [varchar](6) = Null -- for [Essence_Unite].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [Essence_Unite].[UniteID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Essence_Unite_Records].[ID1]
,[Essence_Unite_Records].[ID2]
,[Essence_Unite_Records].[Display]

From [fnEssence_Unite_Display](@EssenceID, @UniteID) As [Essence_Unite_Records]

Return(@@RowCount)


