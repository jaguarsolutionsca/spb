

Create Function [fnLot_SuperficieBoisee]
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
Select TOP 100 PERCENT
 [Annee]
,[Superficie_boisee]
,[LotID]

From [dbo].[Lot_SuperficieBoisee]

Where

    ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@LotID Is Null) Or ([LotID] = @LotID))
)


