

CREATE Function [fnFactureUsine_SelectDisplay]
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
Select
	 [FactureUsine].[ID]
	,[FactureUsine].[DatePermis]
	,[FactureUsine].[DateLivraison]
	,[FactureUsine].[DatePaye]
	,[FactureUsine].[Annee]
	,[Periode1].[Display] [Annee_Display]
	,[FactureUsine].[Periode]
	,[Periode2].[Display] [Periode_Display]
	,[FactureUsine].[ContratID]
	,[Contrat3].[Display] [ContratID_Display]
	,[FactureUsine].[Sciage]
	,[FactureUsine].[EssenceSciage]
	,[FactureUsine].[NumeroFactureUsine]
	,[FactureUsine].[ProducteurID]
	,[FactureUsine].[Livraison]

From [dbo].[FactureUsine]
    Left Outer Join [fnPeriode_Display](Null, Null) [Periode1] On [Annee] = [Periode1].[ID1]
        Left Outer Join [fnPeriode_Display](Null, Null) [Periode2] On [Periode] = [Periode2].[ID2]
            Left Outer Join [fnContrat_Display](Null, Null) [Contrat3] On [ContratID] = [Contrat3].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@Annee Is Null) Or ([Annee] = @Annee))
And ((@Periode Is Null) Or ([Periode] = @Periode))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
)


