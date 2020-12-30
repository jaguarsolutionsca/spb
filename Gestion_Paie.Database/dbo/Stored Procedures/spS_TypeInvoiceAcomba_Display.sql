

Create Procedure [spS_TypeInvoiceAcomba_Display]

(
 @ID [int] = Null -- for [TypeInvoiceAcomba].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [TypeInvoiceAcomba_Records].[ID1]
,[TypeInvoiceAcomba_Records].[Display]

From [fnTypeInvoiceAcomba_Display](@ID) As [TypeInvoiceAcomba_Records]

Return(@@RowCount)


