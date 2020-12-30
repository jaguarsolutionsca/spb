

Create Procedure [spU_TypeFacture]

-- Update an existing record in [TypeFacture] table

(
  @ID [char](1) -- for [TypeFacture].[ID] column
, @Description [varchar](25) = Null -- for [TypeFacture].[Description] column
, @ConsiderNull_Description bit = 0
, @FactureDescriptionMask [varchar](200) = Null -- for [TypeFacture].[FactureDescriptionMask] column
, @ConsiderNull_FactureDescriptionMask bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_FactureDescriptionMask Is Null
	Set @ConsiderNull_FactureDescriptionMask = 0


Update [dbo].[TypeFacture]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[FactureDescriptionMask] = Case @ConsiderNull_FactureDescriptionMask When 0 Then IsNull(@FactureDescriptionMask, [FactureDescriptionMask]) When 1 Then @FactureDescriptionMask End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


