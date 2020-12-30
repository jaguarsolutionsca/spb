

Create Procedure [spI_TypeFacture]

-- Inserts a new record in [TypeFacture] table
(
  @ID [char](1) -- for [TypeFacture].[ID] column
, @Description [varchar](25) = Null  -- for [TypeFacture].[Description] column
, @FactureDescriptionMask [varchar](200) = Null  -- for [TypeFacture].[FactureDescriptionMask] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[TypeFacture]
(
	  [ID]
	, [Description]
	, [FactureDescriptionMask]
)

Values
(
	  @ID
	, @Description
	, @FactureDescriptionMask
)

Set NoCount Off

Return(0)


