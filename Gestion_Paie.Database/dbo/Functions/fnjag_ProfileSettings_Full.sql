

Create Function [fnjag_ProfileSettings_Full]

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
Select TOP 100 PERCENT
 [jag_ProfileSettings].[ProfileID]
,[jag_ProfileSettings].[Name]
,[jag_ProfileSettings].[Value]
,[jag_Profile1].[ID] [ProfileID_ID]
,[jag_Profile1].[Nom] [ProfileID_Nom]
,[jag_Profile1].[Password] [ProfileID_Password]

From [dbo].[jag_ProfileSettings] [jag_ProfileSettings]
    Inner Join [dbo].[jag_Profile] [jag_Profile1] On [jag_ProfileSettings].[ProfileID] = [jag_Profile1].[ID]

Where

    ((@ProfileID Is Null) Or ([jag_ProfileSettings].[ProfileID] = @ProfileID))
And ((@Name Is Null) Or ([jag_ProfileSettings].[Name] = @Name))
)



