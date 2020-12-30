

Create Procedure [spU_Compte]

-- Update an existing record in [Compte] table

(
  @ID [int] -- for [Compte].[ID] column
, @Description [varchar](50) = Null -- for [Compte].[Description] column
, @ConsiderNull_Description bit = 0
, @CategoryID [int] = Null -- for [Compte].[CategoryID] column
, @ConsiderNull_CategoryID bit = 0
, @isTaxe [bit] = Null -- for [Compte].[isTaxe] column
, @ConsiderNull_isTaxe bit = 0
, @Actif [bit] = Null -- for [Compte].[Actif] column
, @ConsiderNull_Actif bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_CategoryID Is Null
	Set @ConsiderNull_CategoryID = 0

If @ConsiderNull_isTaxe Is Null
	Set @ConsiderNull_isTaxe = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[Compte]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[CategoryID] = Case @ConsiderNull_CategoryID When 0 Then IsNull(@CategoryID, [CategoryID]) When 1 Then @CategoryID End
	,[isTaxe] = Case @ConsiderNull_isTaxe When 0 Then IsNull(@isTaxe, [isTaxe]) When 1 Then @isTaxe End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


