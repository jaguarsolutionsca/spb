

Create Procedure [spU_Municipalite]

-- Update an existing record in [Municipalite] table

(
  @ID [varchar](6) -- for [Municipalite].[ID] column
, @Description [varchar](50) = Null -- for [Municipalite].[Description] column
, @ConsiderNull_Description bit = 0
, @MrcID [varchar](6) = Null -- for [Municipalite].[MrcID] column
, @ConsiderNull_MrcID bit = 0
, @AgenceID [varchar](4) = Null -- for [Municipalite].[AgenceID] column
, @ConsiderNull_AgenceID bit = 0
, @Actif [bit] = Null -- for [Municipalite].[Actif] column
, @ConsiderNull_Actif bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0

If @ConsiderNull_MrcID Is Null
	Set @ConsiderNull_MrcID = 0

If @ConsiderNull_AgenceID Is Null
	Set @ConsiderNull_AgenceID = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[Municipalite]

Set
	 [Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End
	,[MrcID] = Case @ConsiderNull_MrcID When 0 Then IsNull(@MrcID, [MrcID]) When 1 Then @MrcID End
	,[AgenceID] = Case @ConsiderNull_AgenceID When 0 Then IsNull(@AgenceID, [AgenceID]) When 1 Then @AgenceID End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


