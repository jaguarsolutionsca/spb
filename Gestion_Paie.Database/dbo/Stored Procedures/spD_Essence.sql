

Create Procedure [spD_Essence]

-- Delete a specific record from table [Essence]

(
 @ID [varchar](6) -- for [Essence].[ID] column
,@RegroupementID [int] = Null -- for [Essence].[RegroupementID] column
,@ContingentID [int] = Null -- for [Essence].[ContingentID] column
,@RepartitionID [int] = Null -- for [Essence].[RepartitionID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Essence]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@RegroupementID Is Null) Or ([RegroupementID] = @RegroupementID))
And ((@ContingentID Is Null) Or ([ContingentID] = @ContingentID))
And ((@RepartitionID Is Null) Or ([RepartitionID] = @RepartitionID))

Set NoCount Off

Return(@@RowCount)


