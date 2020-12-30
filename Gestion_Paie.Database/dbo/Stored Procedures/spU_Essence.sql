

Create Procedure [spU_Essence]

-- Update an existing record in [Essence] table

(
  @ID [varchar](6) -- for [Essence].[ID] column
, @Description [varchar](25) = Null -- for [Essence].[Description] column
, @ConsiderNull_Description bit = 0
, @RegroupementID [int] = Null -- for [Essence].[RegroupementID] column
, @ConsiderNull_RegroupementID bit = 0
, @ContingentID [int] = Null -- for [Essence].[ContingentID] column
, @ConsiderNull_ContingentID bit = 0
, @RepartitionID [int] = Null -- for [Essence].[RepartitionID] column
, @ConsiderNull_RepartitionID bit = 0
, @Actif [bit] = Null -- for [Essence].[Actif] column
, @ConsiderNull_Actif bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_RegroupementID Is Null
	Set @ConsiderNull_RegroupementID = 0

If @ConsiderNull_ContingentID Is Null
	Set @ConsiderNull_ContingentID = 0

If @ConsiderNull_RepartitionID Is Null
	Set @ConsiderNull_RepartitionID = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[Essence]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[RegroupementID] = Case @ConsiderNull_RegroupementID When 0 Then IsNull(@RegroupementID, [RegroupementID]) When 1 Then @RegroupementID End
	,[ContingentID] = Case @ConsiderNull_ContingentID When 0 Then IsNull(@ContingentID, [ContingentID]) When 1 Then @ContingentID End
	,[RepartitionID] = Case @ConsiderNull_RepartitionID When 0 Then IsNull(@RepartitionID, [RepartitionID]) When 1 Then @RepartitionID End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


