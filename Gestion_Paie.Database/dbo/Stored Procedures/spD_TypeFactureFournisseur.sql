

Create Procedure [spD_TypeFactureFournisseur]

-- Delete a specific record from table [TypeFactureFournisseur]

(
 @ID [char](1) -- for [TypeFactureFournisseur].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[TypeFactureFournisseur]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


