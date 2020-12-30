
CREATE Procedure [spD_Contingentement]

-- Delete a specific record from table [Contingentement]

(
 @ID [int] -- for [Contingentement].[ID] column
,@UsineID [varchar](6) = Null -- for [Contingentement].[UsineID] column
,@RegroupementID [int] = Null -- for [Contingentement].[RegroupementID] column
,@EssenceID [varchar](6) = Null -- for [Contingentement].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [Contingentement].[UniteMesureID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Contingentement]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@RegroupementID Is Null) Or ([RegroupementID] = @RegroupementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))

Set NoCount Off

Return(@@RowCount)

