

Create Procedure [spI_CompteCategory]

-- Inserts a new record in [CompteCategory] table
(
  @ID [int] -- for [CompteCategory].[ID] column
, @Description [varchar](50) = Null  -- for [CompteCategory].[Description] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[CompteCategory]
(
	  [ID]
	, [Description]
)

Values
(
	  @ID
	, @Description
)

Set NoCount Off

Return(0)


