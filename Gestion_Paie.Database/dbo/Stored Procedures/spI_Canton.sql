

Create Procedure [spI_Canton]

-- Inserts a new record in [Canton] table
(
  @ID [varchar](6) -- for [Canton].[ID] column
, @Description [varchar](50) = Null  -- for [Canton].[Description] column
, @Actif [bit] = Null  -- for [Canton].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Canton]
(
	  [ID]
	, [Description]
	, [Actif]
)

Values
(
	  @ID
	, @Description
	, @Actif
)

Set NoCount Off

Return(0)


