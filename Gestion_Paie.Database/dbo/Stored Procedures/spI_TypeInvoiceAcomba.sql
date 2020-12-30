

Create Procedure [spI_TypeInvoiceAcomba]

-- Inserts a new record in [TypeInvoiceAcomba] table
(
  @ID [int] -- for [TypeInvoiceAcomba].[ID] column
, @Description [varchar](15) = Null  -- for [TypeInvoiceAcomba].[Description] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[TypeInvoiceAcomba]
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


