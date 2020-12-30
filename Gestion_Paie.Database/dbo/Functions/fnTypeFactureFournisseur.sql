

Create Function [fnTypeFactureFournisseur]
(
 @ID [char](1) = Null
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

From [dbo].[TypeFactureFournisseur]

Where

    ((@ID Is Null) Or ([ID] = @ID))
)


