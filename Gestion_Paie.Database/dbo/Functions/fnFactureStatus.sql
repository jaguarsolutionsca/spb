

Create Function [fnFactureStatus]
(
 @ID [varchar](15) = Null
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

From [dbo].[FactureStatus]

Where

    ((@ID Is Null) Or ([ID] = @ID))
)


