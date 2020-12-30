

Create Function [fnLot_SuperficieBoisee_SelectDisplay]
(
 @Annee [datetime] = Null
,@LotID [int] = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [Lot_SuperficieBoisee].[Annee]
	,[Lot_SuperficieBoisee].[Superficie_boisee]
	,[Lot_SuperficieBoisee].[LotID]
	,[Lot1].[Display] [LotID_Display]

From [dbo].[Lot_SuperficieBoisee]
    Inner Join [fnLot_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Lot1] On [LotID] = [Lot1].[ID1]

Where

    ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@LotID Is Null) Or ([LotID] = @LotID))
)


