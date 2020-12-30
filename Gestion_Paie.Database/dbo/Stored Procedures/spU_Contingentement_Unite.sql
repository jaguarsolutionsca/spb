

Create Procedure [spU_Contingentement_Unite]

-- Update an existing record in [Contingentement_Unite] table

(
  @ContingentementID [int] -- for [Contingentement_Unite].[ContingentementID] column
, @UniteID [varchar](6) -- for [Contingentement_Unite].[UniteID] column
, @Facteur [float] = Null -- for [Contingentement_Unite].[Facteur] column
, @ConsiderNull_Facteur bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Facteur Is Null
	Set @ConsiderNull_Facteur = 0


Update [dbo].[Contingentement_Unite]

Set
	 [Facteur] = Case @ConsiderNull_Facteur When 0 Then IsNull(@Facteur, [Facteur]) When 1 Then @Facteur End

Where
	     ([ContingentementID] = @ContingentementID)
	And ([UniteID] = @UniteID)

Set NoCount Off

Return(0)


