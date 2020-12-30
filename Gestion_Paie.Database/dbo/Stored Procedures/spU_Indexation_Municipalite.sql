

CREATE Procedure [spU_Indexation_Municipalite]

-- Update an existing record in [Indexation_Municipalite] table

(
  @ID [int] -- for [Indexation_Municipalite].[ID] column
, @IndexationID [int] = Null -- for [Indexation_Municipalite].[IndexationID] column
, @ConsiderNull_IndexationID bit = 0
, @MunicipaliteID [varchar](6) = Null -- for [Indexation_Municipalite].[MunicipaliteID] column
, @ConsiderNull_MunicipaliteID bit = 0
, @Montant [real] = Null -- for [Indexation_Municipalite].[Montant] column
, @ConsiderNull_Montant bit = 0
, @ZoneID [varchar](2) = Null -- for [Indexation_Municipalite].[ZoneID] column
, @ConsiderNull_ZoneID bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_IndexationID Is Null
	Set @ConsiderNull_IndexationID = 0

If @ConsiderNull_MunicipaliteID Is Null
	Set @ConsiderNull_MunicipaliteID = 0

If @ConsiderNull_Montant Is Null
	Set @ConsiderNull_Montant = 0

If @ConsiderNull_ZoneID Is Null
	Set @ConsiderNull_ZoneID = 0


Update [dbo].[Indexation_Municipalite]

Set
	 [IndexationID] = Case @ConsiderNull_IndexationID When 0 Then IsNull(@IndexationID, [IndexationID]) When 1 Then @IndexationID End
	,[MunicipaliteID] = Case @ConsiderNull_MunicipaliteID When 0 Then IsNull(@MunicipaliteID, [MunicipaliteID]) When 1 Then @MunicipaliteID End
	,[Montant] = Case @ConsiderNull_Montant When 0 Then IsNull(@Montant, [Montant]) When 1 Then @Montant End
	,[ZoneID] = Case @ConsiderNull_ZoneID When 0 Then IsNull(@ZoneID, [ZoneID]) When 1 Then @ZoneID End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


