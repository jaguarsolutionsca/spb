

Create Procedure [spI_jag_SystemEx]

-- Inserts a new record in [jag_SystemEx] table
(
  @Name [varchar](50) -- for [jag_SystemEx].[Name] column
, @Value [varchar](500) = Null  -- for [jag_SystemEx].[Value] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[jag_SystemEx]
(
	  [Name]
	, [Value]
)

Values
(
	  @Name
	, @Value
)

Set NoCount Off

Return(0)


