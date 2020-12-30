

Create Procedure [spU_TypeInvoiceClientAcomba]

-- Update an existing record in [TypeInvoiceClientAcomba] table

(
  @ID [int] -- for [TypeInvoiceClientAcomba].[ID] column
, @Description [varchar](25) = Null -- for [TypeInvoiceClientAcomba].[Description] column
, @ConsiderNull_Description bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0


Update [dbo].[TypeInvoiceClientAcomba]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


