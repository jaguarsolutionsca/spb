

Create Procedure [spI_TypeInvoiceClientAcomba]

-- Inserts a new record in [TypeInvoiceClientAcomba] table
(
  @ID [int] -- for [TypeInvoiceClientAcomba].[ID] column
, @Description [varchar](25) = Null  -- for [TypeInvoiceClientAcomba].[Description] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[TypeInvoiceClientAcomba]
(
	  [ID]
	, [Description]
)

Values
(
	  @ID
	, @Description
)

Set NoCount Off

Return(0)


