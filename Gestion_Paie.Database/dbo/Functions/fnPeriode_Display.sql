

Create Function [fnPeriode_Display]
(
 @Annee [int] = Null
,@SemaineNo [int] = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Annee] As [ID1]
,[SemaineNo] As [ID2]
,[SemaineNo] As [Display]
	
From [dbo].[Periode]

Where
    ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@SemaineNo Is Null) Or ([SemaineNo] = @SemaineNo))

Order By [Display]
)


