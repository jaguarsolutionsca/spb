

Create Procedure [spS_TypeFactureFournisseur_Display]

(
 @ID [char](1) = Null -- for [TypeFactureFournisseur].[ID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [TypeFactureFournisseur_Records].[ID1]
,[TypeFactureFournisseur_Records].[Display]

From [fnTypeFactureFournisseur_Display](@ID) As [TypeFactureFournisseur_Records]

Return(@@RowCount)


