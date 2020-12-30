

Create Procedure [spS_TypeInvoiceClientAcomba_Display]

(
 @ID [int] = Null -- for [TypeInvoiceClientAcomba].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [TypeInvoiceClientAcomba_Records].[ID1]
,[TypeInvoiceClientAcomba_Records].[Display]

From [fnTypeInvoiceClientAcomba_Display](@ID) As [TypeInvoiceClientAcomba_Records]

Return(@@RowCount)


