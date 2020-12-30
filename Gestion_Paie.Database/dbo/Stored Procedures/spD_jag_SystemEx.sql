

Create Procedure [spD_jag_SystemEx]

-- Delete a specific record from table [jag_SystemEx]

(
 @Name [varchar](50) -- for [jag_SystemEx].[Name] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[jag_SystemEx]

Where
    ((@Name Is Null) Or ([Name] = @Name))

Set NoCount Off

Return(@@RowCount)


