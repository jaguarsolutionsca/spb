

Create Procedure [spI_MRC]

-- Inserts a new record in [MRC] table
(
  @ID [varchar](6) -- for [MRC].[ID] column
, @Description [varchar](50) = Null  -- for [MRC].[Description] column
, @Actif [bit] = Null  -- for [MRC].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[MRC]
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


