

Create Procedure [spI_jag_ProfileSettings]

-- Inserts a new record in [jag_ProfileSettings] table
(
  @ProfileID [int] -- for [jag_ProfileSettings].[ProfileID] column
, @Name [varchar](500) -- for [jag_ProfileSettings].[Name] column
, @Value [varchar](500) = Null  -- for [jag_ProfileSettings].[Value] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[jag_ProfileSettings]
(
	  [ProfileID]
	, [Name]
	, [Value]
)

Values
(
	  @ProfileID
	, @Name
	, @Value
)

Set NoCount Off

Return(0)


