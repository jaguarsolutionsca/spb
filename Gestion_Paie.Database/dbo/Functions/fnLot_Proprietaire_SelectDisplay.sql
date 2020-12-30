

Create Function [fnLot_Proprietaire_SelectDisplay]
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
Select
	 [Lot_Proprietaire].[ProprietaireID]
	,[Fournisseur1].[Display] [ProprietaireID_Display]
	,[Lot_Proprietaire].[DateDebut]
	,[Lot_Proprietaire].[DateFin]
	,[Lot_Proprietaire].[LotID]
	,[Lot2].[Display] [LotID_Display]

From [dbo].[Lot_Proprietaire]
    Inner Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur1] On [ProprietaireID] = [Fournisseur1].[ID1]
        Inner Join [fnLot_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Lot2] On [LotID] = [Lot2].[ID1]

Where

    ((@ProprietaireID Is Null) Or ([ProprietaireID] = @ProprietaireID))
And ((@DateDebut Is Null) Or ([DateDebut] = @DateDebut))
And ((@LotID Is Null) Or ([LotID] = @LotID))
)


