

Create Function [fnLotContingente_Display]
(
 @LotID [int] = Null
,@Annee [int] = Null
,@FournisseurID [varchar](15) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [LotID] As [ID1]
,[Annee] As [ID2]
,[FournisseurID] As [ID3]
,[FournisseurID] As [Display]
	
From [dbo].[LotContingente]

Where
    ((@LotID Is Null) Or ([LotID] = @LotID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))

Order By [Display]
)


