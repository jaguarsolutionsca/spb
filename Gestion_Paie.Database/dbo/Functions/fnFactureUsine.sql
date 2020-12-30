

CREATE Function [fnFactureUsine]
(
 @ID [int] = Null
,@Annee [int] = Null
,@Periode [int] = Null
,@ContratID [varchar](10) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [ID]
,[DatePermis]
,[DateLivraison]
,[DatePaye]
,[Annee]
,[Periode]
,[ContratID]
,[Sciage]
,[EssenceSciage]
,[NumeroFactureUsine]
,[ProducteurID]
,[Livraison]

From [dbo].[FactureUsine]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@Periode Is Null) Or ([Periode] = @Periode))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
)


