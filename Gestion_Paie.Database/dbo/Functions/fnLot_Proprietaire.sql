

Create Function [fnLot_Proprietaire]
(
 @ProprietaireID [varchar](15) = Null
,@DateDebut [datetime] = Null
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
 [ProprietaireID]
,[DateDebut]
,[DateFin]
,[LotID]

From [dbo].[Lot_Proprietaire]

Where

    ((@ProprietaireID Is Null) Or ([ProprietaireID] = @ProprietaireID))
And ((@DateDebut Is Null) Or ([DateDebut] = @DateDebut))
And ((@LotID Is Null) Or ([LotID] = @LotID))
)


