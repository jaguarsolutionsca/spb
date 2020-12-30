

CREATE Procedure [spU_Indexation_EssenceUnite]

-- Update an existing record in [Indexation_EssenceUnite] table

(
  @ID [int] -- for [Indexation_EssenceUnite].[ID] column
, @IndexationID [int] = Null -- for [Indexation_EssenceUnite].[IndexationID] column
, @ConsiderNull_IndexationID bit = 0
, @ContratID [varchar](10) = Null -- for [Indexation_EssenceUnite].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @EssenceID [varchar](6) = Null -- for [Indexation_EssenceUnite].[EssenceID] column
, @ConsiderNull_EssenceID bit = 0
, @Code [char](4) = Null -- for [Indexation_EssenceUnite].[Code] column
, @ConsiderNull_Code bit = 0
, @UniteID [varchar](6) = Null -- for [Indexation_EssenceUnite].[UniteID] column
, @ConsiderNull_UniteID bit = 0
, @Taux [real] = Null -- for [Indexation_EssenceUnite].[Taux] column
, @ConsiderNull_Taux bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_IndexationID Is Null
	Set @ConsiderNull_IndexationID = 0

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0

If @ConsiderNull_UniteID Is Null
	Set @ConsiderNull_UniteID = 0

If @ConsiderNull_Taux Is Null
	Set @ConsiderNull_Taux = 0


Update [dbo].[Indexation_EssenceUnite]

Set
	 [IndexationID] = Case @ConsiderNull_IndexationID When 0 Then IsNull(@IndexationID, [IndexationID]) When 1 Then @IndexationID End
	,[ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End
	,[UniteID] = Case @ConsiderNull_UniteID When 0 Then IsNull(@UniteID, [UniteID]) When 1 Then @UniteID End
	,[Taux] = Case @ConsiderNull_Taux When 0 Then IsNull(@Taux, [Taux]) When 1 Then @Taux End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


