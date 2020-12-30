

Create Procedure [spS_InstitutionBanquaire_Display]

(
 @ID [varchar](3) = Null -- for [InstitutionBanquaire].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [InstitutionBanquaire_Records].[ID1]
,[InstitutionBanquaire_Records].[Display]

From [fnInstitutionBanquaire_Display](@ID) As [InstitutionBanquaire_Records]

Return(@@RowCount)


