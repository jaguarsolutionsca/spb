

Create Function [fnLot_SuperficieBoisee_Display]
(
 @Annee [datetime] = Null
,@LotID [int] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Annee] As [ID1]
,[LotID] As [ID2]
,[LotID] As [Display]
	
From [dbo].[Lot_SuperficieBoisee]

Where
    ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@LotID Is Null) Or ([LotID] = @LotID))

Order By [Display]
)


