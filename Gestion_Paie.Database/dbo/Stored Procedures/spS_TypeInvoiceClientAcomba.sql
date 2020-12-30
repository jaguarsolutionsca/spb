

Create Procedure [spS_TypeInvoiceClientAcomba]

-- Retrieve specific records from the [TypeInvoiceClientAcomba] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [TypeInvoiceClientAcomba].[ID] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [TypeInvoiceClientAcomba_Records].[ID]
		,[TypeInvoiceClientAcomba_Records].[Description]

		From [fnTypeInvoiceClientAcomba](@ID) As [TypeInvoiceClientAcomba_Records]
	End

Else

	Begin
		Select

		 [TypeInvoiceClientAcomba_Records].[ID]
		,[TypeInvoiceClientAcomba_Records].[Description]

		From [fnTypeInvoiceClientAcomba](@ID) As [TypeInvoiceClientAcomba_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


