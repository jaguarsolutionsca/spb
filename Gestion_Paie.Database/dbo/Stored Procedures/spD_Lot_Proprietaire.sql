

Create Procedure [spD_Lot_Proprietaire]

-- Delete a specific record from table [Lot_Proprietaire]

(
 @ProprietaireID [varchar](15) -- for [Lot_Proprietaire].[ProprietaireID] column
,@DateDebut [datetime] -- for [Lot_Proprietaire].[DateDebut] column
,@LotID [int] -- for [Lot_Proprietaire].[LotID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Lot_Proprietaire]

Where
    ((@ProprietaireID Is Null) Or ([ProprietaireID] = @ProprietaireID))
And ((@DateDebut Is Null) Or ([DateDebut] = @DateDebut))
And ((@LotID Is Null) Or ([LotID] = @LotID))

Set NoCount Off

Return(@@RowCount)


