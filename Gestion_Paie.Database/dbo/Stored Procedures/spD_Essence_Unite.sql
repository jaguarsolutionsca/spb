

Create Procedure [spD_Essence_Unite]

-- Delete a specific record from table [Essence_Unite]

(
 @EssenceID [varchar](6) -- for [Essence_Unite].[EssenceID] column
,@UniteID [varchar](6) -- for [Essence_Unite].[UniteID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Essence_Unite]

Where
    ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))

Set NoCount Off

Return(@@RowCount)


