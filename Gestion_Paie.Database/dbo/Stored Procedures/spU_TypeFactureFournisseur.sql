

Create Procedure [spU_TypeFactureFournisseur]

-- Update an existing record in [TypeFactureFournisseur] table

(
  @ID [char](1) -- for [TypeFactureFournisseur].[ID] column
, @Description [varchar](25) = Null -- for [TypeFactureFournisseur].[Description] column
, @ConsiderNull_Description bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0


Update [dbo].[TypeFactureFournisseur]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


