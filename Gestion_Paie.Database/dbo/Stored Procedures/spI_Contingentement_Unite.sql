

Create Procedure [spI_Contingentement_Unite]

-- Inserts a new record in [Contingentement_Unite] table
(
  @ContingentementID [int] -- for [Contingentement_Unite].[ContingentementID] column
, @UniteID [varchar](6) -- for [Contingentement_Unite].[UniteID] column
, @Facteur [float] = Null  -- for [Contingentement_Unite].[Facteur] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Contingentement_Unite]
(
	  [ContingentementID]
	, [UniteID]
	, [Facteur]
)

Values
(
	  @ContingentementID
	, @UniteID
	, @Facteur
)

Set NoCount Off

Return(0)


