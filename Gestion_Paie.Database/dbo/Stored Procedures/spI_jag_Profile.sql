

Create Procedure [spI_jag_Profile]

-- Inserts a new record in [jag_Profile] table
(
  @ID [int] -- for [jag_Profile].[ID] column
, @Nom [varchar](100) = Null  -- for [jag_Profile].[Nom] column
, @Password [varchar](20) = Null  -- for [jag_Profile].[Password] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[jag_Profile]
(
	  [ID]
	, [Nom]
	, [Password]
)

Values
(
	  @ID
	, @Nom
	, @Password
)

Set NoCount Off

Return(0)


