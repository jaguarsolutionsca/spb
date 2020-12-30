

Create Procedure [spU_EssenceRepartition]

-- Update an existing record in [EssenceRepartition] table

(
  @ID [int] -- for [EssenceRepartition].[ID] column
, @Description [varchar](25) = Null -- for [EssenceRepartition].[Description] column
, @ConsiderNull_Description bit = 0
, @Actif [bit] = Null -- for [EssenceRepartition].[Actif] column
, @ConsiderNull_Actif bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[EssenceRepartition]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


