

Create Procedure [spU_jag_ProfileSettings]

-- Update an existing record in [jag_ProfileSettings] table

(
  @ProfileID [int] -- for [jag_ProfileSettings].[ProfileID] column
, @Name [varchar](500) -- for [jag_ProfileSettings].[Name] column
, @Value [varchar](500) = Null -- for [jag_ProfileSettings].[Value] column
, @ConsiderNull_Value bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Value Is Null
	Set @ConsiderNull_Value = 0


Update [dbo].[jag_ProfileSettings]

Set
	 [Value] = Case @ConsiderNull_Value When 0 Then IsNull(@Value, [Value]) When 1 Then @Value End

Where
	     ([ProfileID] = @ProfileID)
	And ([Name] = @Name)

Set NoCount Off

Return(0)


