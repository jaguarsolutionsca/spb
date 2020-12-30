

Create Procedure [spD_LotContingente]

-- Delete a specific record from table [LotContingente]

(
 @LotID [int] -- for [LotContingente].[LotID] column
,@Annee [int] -- for [LotContingente].[Annee] column
,@FournisseurID [varchar](15) -- for [LotContingente].[FournisseurID] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[LotContingente]

Where
    ((@LotID Is Null) Or ([LotID] = @LotID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@FournisseurID Is Null) Or ([FournisseurID] = @FournisseurID))

Set NoCount Off

Return(@@RowCount)


