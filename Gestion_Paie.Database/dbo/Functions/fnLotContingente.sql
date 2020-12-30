

Create Function [fnLotContingente]
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
Select TOP 100 PERCENT
 [LotID]
,[Annee]
,[SuperficieContingentee]
,[Override]
,[FournisseurID]

From [dbo].[LotContingente]

Where

    ((@LotID Is Null) Or ([LotID] = @LotID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))
)


