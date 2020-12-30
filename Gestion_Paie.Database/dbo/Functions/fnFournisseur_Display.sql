CREATE Function [dbo].[fnFournisseur_Display]
(
 @ID [varchar](15) = Null
,@PaysID [varchar](2) = Null
,@InstitutionBanquaireID [varchar](3) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[Telephone2_Desc] As [Display]
	
From [dbo].[Fournisseur]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@PaysID Is Null) Or ([PaysID] = @PaysID))
And ((@InstitutionBanquaireID Is Null) Or ([InstitutionBanquaireID] = @InstitutionBanquaireID))

Order By [Display]
)


