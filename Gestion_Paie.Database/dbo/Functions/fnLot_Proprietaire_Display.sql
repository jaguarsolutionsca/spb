

Create Function [fnLot_Proprietaire_Display]
(
 @ProprietaireID [varchar](15) = Null
,@DateDebut [datetime] = Null
,@LotID [int] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ProprietaireID] As [ID1]
,[DateDebut] As [ID2]
,[LotID] As [ID3]
,[LotID] As [Display]
	
From [dbo].[Lot_Proprietaire]

Where
    ((@ProprietaireID Is Null) Or ([ProprietaireID] = @ProprietaireID))
And ((@DateDebut Is Null) Or ([DateDebut] = @DateDebut))
And ((@LotID Is Null) Or ([LotID] = @LotID))

Order By [Display]
)


