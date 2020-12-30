

CREATE Function [fnFactureUsine_Full]

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
,[FactureUsine].[Periode]
,[FactureUsine].[ContratID]
,[FactureUsine].[Sciage]
,[FactureUsine].[EssenceSciage]
,[FactureUsine].[NumeroFactureUsine]
,[FactureUsine].[ProducteurID]
,[FactureUsine].[Livraison]
,[Periode1].[Annee] [Annee_Annee]
,[Periode1].[SemaineNo] [Annee_SemaineNo]
,[Periode1].[DateDebut] [Annee_DateDebut]
,[Periode1].[DateFin] [Annee_DateFin]
,[Periode1].[PeriodeContingentement] [Annee_PeriodeContingentement]
,[Periode2].[Annee] [Periode_Annee]
,[Periode2].[SemaineNo] [Periode_SemaineNo]
,[Periode2].[DateDebut] [Periode_DateDebut]
,[Periode2].[DateFin] [Periode_DateFin]
,[Periode2].[PeriodeContingentement] [Periode_PeriodeContingentement]
,[Contrat3].[ID] [ContratID_ID]
,[Contrat3].[Description] [ContratID_Description]
,[Contrat3].[UsineID] [ContratID_UsineID]
,[Contrat3].[Annee] [ContratID_Annee]
,[Contrat3].[Date_debut] [ContratID_Date_debut]
,[Contrat3].[Date_fin] [ContratID_Date_fin]
,[Contrat3].[Actif] [ContratID_Actif]
,[Contrat3].[PaieTransporteur] [ContratID_PaieTransporteur]
,[Contrat3].[Taux_Surcharge] [ContratID_Taux_Surcharge]
,[Contrat3].[SurchargeManuel] [ContratID_SurchargeManuel]
,[Contrat3].[TxTransSameProd] [ContratID_TxTransSameProd]

From [dbo].[FactureUsine] [FactureUsine]
    Left Outer Join [dbo].[Periode] [Periode1] On [FactureUsine].[Annee] = [Periode1].[Annee]
        Left Outer Join [dbo].[Periode] [Periode2] On [FactureUsine].[Periode] = [Periode2].[SemaineNo]
            Left Outer Join [dbo].[Contrat] [Contrat3] On [FactureUsine].[ContratID] = [Contrat3].[ID]

Where

    ((@ID Is Null) Or ([FactureUsine].[ID] = @ID))
And ((@Annee Is Null) Or ([FactureUsine].[Annee] = @Annee))
And ((@Periode Is Null) Or ([FactureUsine].[Periode] = @Periode))
And ((@ContratID Is Null) Or ([FactureUsine].[ContratID] = @ContratID))
)


