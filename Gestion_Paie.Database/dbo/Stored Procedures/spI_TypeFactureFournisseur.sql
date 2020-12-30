

Create Procedure [spI_TypeFactureFournisseur]

-- Inserts a new record in [TypeFactureFournisseur] table
(
  @ID [char](1) -- for [TypeFactureFournisseur].[ID] column
, @Description [varchar](25) = Null  -- for [TypeFactureFournisseur].[Description] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[TypeFactureFournisseur]
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


