

Create Procedure [spI_TypeIndexation]

-- Inserts a new record in [TypeIndexation] table
(
  @ID [char](1) -- for [TypeIndexation].[ID] column
, @Description [varchar](50) = Null  -- for [TypeIndexation].[Description] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[TypeIndexation]
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


