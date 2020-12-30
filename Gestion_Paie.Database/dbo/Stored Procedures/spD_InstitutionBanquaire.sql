

CREATE Procedure [spD_InstitutionBanquaire]

-- Delete a specific record from table [InstitutionBanquaire]

(
 @ID [varchar](3) -- for [InstitutionBanquaire].[ID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[InstitutionBanquaire]

Where
    ((@ID Is Null) Or ([ID] = @ID))

Set NoCount Off

Return(@@RowCount)


