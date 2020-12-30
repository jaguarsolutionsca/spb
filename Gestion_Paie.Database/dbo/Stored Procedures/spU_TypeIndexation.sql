

Create Procedure [spU_TypeIndexation]

-- Update an existing record in [TypeIndexation] table

(
  @ID [char](1) -- for [TypeIndexation].[ID] column
, @Description [varchar](50) = Null -- for [TypeIndexation].[Description] column
, @ConsiderNull_Description bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0


Update [dbo].[TypeIndexation]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


