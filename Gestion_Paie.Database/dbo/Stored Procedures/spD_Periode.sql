

Create Procedure [spD_Periode]

-- Delete a specific record from table [Periode]

(
 @Annee [int] -- for [Periode].[Annee] column
,@SemaineNo [int] -- for [Periode].[SemaineNo] column
)

-- Returns the number of deleted records

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Delete From [dbo].[Periode]

Where
    ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@SemaineNo Is Null) Or ([SemaineNo] = @SemaineNo))

Set NoCount Off

Return(@@RowCount)


