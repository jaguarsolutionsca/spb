

Create Procedure [spD_TypeInvoiceClientAcomba]

-- Delete a specific record from table [TypeInvoiceClientAcomba]

(
 @ID [int] -- for [TypeInvoiceClientAcomba].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[TypeInvoiceClientAcomba]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


