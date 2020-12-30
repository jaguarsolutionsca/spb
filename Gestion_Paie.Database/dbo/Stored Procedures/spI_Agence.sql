

Create Procedure [spI_Agence]

-- Inserts a new record in [Agence] table
(
  @ID [varchar](4) -- for [Agence].[ID] column
, @Description [varchar](150) = Null  -- for [Agence].[Description] column
, @Actif [bit] = Null  -- for [Agence].[Actif] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Agence]
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


