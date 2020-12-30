

Create Procedure [spD_Lot_SuperficieBoisee]

-- Delete a specific record from table [Lot_SuperficieBoisee]

(
 @Annee [datetime] -- for [Lot_SuperficieBoisee].[Annee] column
,@LotID [int] -- for [Lot_SuperficieBoisee].[LotID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Lot_SuperficieBoisee]

Where
    ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@LotID Is Null) Or ([LotID] = @LotID))

Set NoCount Off

Return(@@RowCount)


