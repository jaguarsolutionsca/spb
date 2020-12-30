

Create Function [fnLotContingente_SelectDisplay]
(
 @LotID [int] = Null
,@Annee [int] = Null
,@FournisseurID [varchar](15) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [LotContingente].[LotID]
	,[Lot1].[Display] [LotID_Display]
	,[LotContingente].[Annee]
	,[LotContingente].[SuperficieContingentee]
	,[LotContingente].[Override]
	,[LotContingente].[FournisseurID]
	,[Fournisseur2].[Display] [FournisseurID_Display]

From [dbo].[LotContingente]
    Inner Join [fnLot_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Lot1] On [LotID] = [Lot1].[ID1]
        Inner Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur2] On [FournisseurID] = [Fournisseur2].[ID1]

Where

    ((@LotID Is Null) Or ([LotID] = @LotID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
)


