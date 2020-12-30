

Create Function [fnjag_SystemEx]
(
 @Name [varchar](50) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Name]
,[Value]

From [dbo].[jag_SystemEx]

Where

    ((@Name Is Null) Or ([Name] = @Name))
)


