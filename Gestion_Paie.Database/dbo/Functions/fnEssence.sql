

Create Function [fnEssence]
(
 @ID [varchar](6) = Null
,@RegroupementID [int] = Null
,@ContingentID [int] = Null
,@RepartitionID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[Description]
,[RegroupementID]
,[ContingentID]
,[RepartitionID]
,[Actif]

From [dbo].[Essence]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@RegroupementID Is Null) Or ([RegroupementID] = @RegroupementID))
And ((@ContingentID Is Null) Or ([ContingentID] = @ContingentID))
And ((@RepartitionID Is Null) Or ([RepartitionID] = @RepartitionID))
)


