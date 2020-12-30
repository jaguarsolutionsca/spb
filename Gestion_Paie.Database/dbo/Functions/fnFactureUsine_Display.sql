

Create Function [fnFactureUsine_Display]
(
 @ID [int] = Null
,@Annee [int] = Null
,@Periode [int] = Null
,@ContratID [varchar](10) = Null
)


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID] As [ID1]
,[ID] As [Display]
	
From [dbo].[FactureUsine]

Where
    ((@ID Is Null) Or ([ID] = @ID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@Periode Is Null) Or ([Periode] = @Periode))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))

Order By [Display]
)


