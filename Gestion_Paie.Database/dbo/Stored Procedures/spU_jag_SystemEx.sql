

Create Procedure [spU_jag_SystemEx]

-- Update an existing record in [jag_SystemEx] table

(
  @Name [varchar](50) -- for [jag_SystemEx].[Name] column
, @Value [varchar](500) = Null -- for [jag_SystemEx].[Value] column
, @ConsiderNull_Value bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Value Is Null
	Set @ConsiderNull_Value = 0


Update [dbo].[jag_SystemEx]

Set
	 [Value] = Case @ConsiderNull_Value When 0 Then IsNull(@Value, [Value]) When 1 Then @Value End

Where
	     ([Name] = @Name)

Set NoCount Off

Return(0)


