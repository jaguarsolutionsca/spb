

Create Function [fnEssence_Display]
(
 @ID [varchar](6) = Null
,@RegroupementID [int] = Null
,@ContingentID [int] = Null
,@RepartitionID [int] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Description] As [Display]
	
From [dbo].[Essence]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@RegroupementID Is Null) Or ([RegroupementID] = @RegroupementID))
And ((@ContingentID Is Null) Or ([ContingentID] = @ContingentID))
And ((@RepartitionID Is Null) Or ([RepartitionID] = @RepartitionID))

Order By [Display]
)


