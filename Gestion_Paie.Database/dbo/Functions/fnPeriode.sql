

Create Function [fnPeriode]
(
 @Annee [int] = Null
,@SemaineNo [int] = Null
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
,[SemaineNo]
,[DateDebut]
,[DateFin]
,[PeriodeContingentement]

From [dbo].[Periode]

Where

    ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@SemaineNo Is Null) Or ([SemaineNo] = @SemaineNo))
)


