﻿

Create Procedure [spS_TypeInvoiceAcomba]

-- Retrieve specific records from the [TypeInvoiceAcomba] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [TypeInvoiceAcomba].[ID] column
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

		 [TypeInvoiceAcomba_Records].[ID]
		,[TypeInvoiceAcomba_Records].[Description]

		From [fnTypeInvoiceAcomba](@ID) As [TypeInvoiceAcomba_Records]
	End

Else

	Begin
		Select

		 [TypeInvoiceAcomba_Records].[ID]
		,[TypeInvoiceAcomba_Records].[Description]

		From [fnTypeInvoiceAcomba](@ID) As [TypeInvoiceAcomba_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


