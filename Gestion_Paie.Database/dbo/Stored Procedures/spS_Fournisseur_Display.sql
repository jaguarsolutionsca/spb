
CREATE Procedure [dbo].[spS_Fournisseur_Display]

(
 @ID [varchar](15) = Null -- for [Fournisseur].[ID] column
,@PaysID [varchar](2) = Null -- for [Fournisseur].[PaysID] column
,@InstitutionBanquaireID [varchar](3) = Null -- for [Fournisseur].[InstitutionBanquaireID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Fournisseur_Records].[ID1]
,[Fournisseur_Records].[Display]

From [fnFournisseur_Display](@ID, @PaysID, @InstitutionBanquaireID) As [Fournisseur_Records]

Return(@@RowCount)

