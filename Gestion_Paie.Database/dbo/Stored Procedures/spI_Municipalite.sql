

Create Procedure [spI_Municipalite]

-- Inserts a new record in [Municipalite] table
(
  @ID [varchar](6) -- for [Municipalite].[ID] column
, @Description [varchar](50) = Null  -- for [Municipalite].[Description] column
, @MrcID [varchar](6) = Null  -- for [Municipalite].[MrcID] column
, @AgenceID [varchar](4) = Null  -- for [Municipalite].[AgenceID] column
, @Actif [bit] = Null  -- for [Municipalite].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Municipalite]
(
	  [ID]
	, [Description]
	, [MrcID]
	, [AgenceID]
	, [Actif]
)

Values
(
	  @ID
	, @Description
	, @MrcID
	, @AgenceID
	, @Actif
)

Set NoCount Off

Return(0)


