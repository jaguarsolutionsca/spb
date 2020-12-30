

Create Function [fnjag_Profile]
(
 @ID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[Nom]
,[Password]

From [dbo].[jag_Profile]

Where

    ((@ID Is Null) Or ([ID] = @ID))
)


