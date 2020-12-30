

Create Function [fnjag_ProfileSettings_SelectDisplay]
(
 @ProfileID [int] = Null
,@Name [varchar](500) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [jag_ProfileSettings].[ProfileID]
	,[jag_Profile1].[Display] [ProfileID_Display]
	,[jag_ProfileSettings].[Name]
	,[jag_ProfileSettings].[Value]

From [dbo].[jag_ProfileSettings]
    Inner Join [fnjag_Profile_Display](Null) [jag_Profile1] On [ProfileID] = [jag_Profile1].[ID1]

Where

    ((@ProfileID Is Null) Or ([ProfileID] = @ProfileID))
And ((@Name Is Null) Or ([Name] = @Name))
)


