CREATE Procedure [dbo].[spD_Fournisseur]

-- Delete a specific record from table [Fournisseur]

(
 @ID [varchar](15) -- for [Fournisseur].[ID] column
,@PaysID [varchar](2) = Null -- for [Fournisseur].[PaysID] column
,@InstitutionBanquaireID [varchar](3) = Null -- for [Fournisseur].[InstitutionBanquaireID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Fournisseur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@PaysID Is Null) Or ([PaysID] = @PaysID))
And ((@InstitutionBanquaireID Is Null) Or ([InstitutionBanquaireID] = @InstitutionBanquaireID))

Set NoCount Off

Return(@@RowCount)


