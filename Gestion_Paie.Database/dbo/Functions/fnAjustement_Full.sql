
CREATE Function [fnAjustement_Full]

(
 @ID [int] = Null
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
 [Ajustement].[ID]
,[Ajustement].[ContratID]
,[Ajustement].[DateAjustement]
,[Ajustement].[Periode_Debut]
,[Ajustement].[Periode_Fin]
,[Ajustement].[Facture]
,[Ajustement].[UsePeriodes]
,[Ajustement].[Date_Debut]
,[Ajustement].[Date_Fin]
,[Ajustement].[ProducteurID]
,[Ajustement].[TransporteurID]
,[Ajustement].[IsRistourne]
,[Contrat1].[ID] [ContratID_ID]
,[Contrat1].[Description] [ContratID_Description]
,[Contrat1].[UsineID] [ContratID_UsineID]
,[Contrat1].[Annee] [ContratID_Annee]
,[Contrat1].[Date_debut] [ContratID_Date_debut]
,[Contrat1].[Date_fin] [ContratID_Date_fin]
,[Contrat1].[Actif] [ContratID_Actif]
,[Contrat1].[PaieTransporteur] [ContratID_PaieTransporteur]
,[Contrat1].[Taux_Surcharge] [ContratID_Taux_Surcharge]
,[Contrat1].[SurchargeManuel] [ContratID_SurchargeManuel]
,[Contrat1].[TxTransSameProd] [ContratID_TxTransSameProd]

From [dbo].[Ajustement] [Ajustement]
    Inner Join [dbo].[Contrat] [Contrat1] On [Ajustement].[ContratID] = [Contrat1].[ID]

Where

    ((@ID Is Null) Or ([Ajustement].[ID] = @ID))
And ((@ContratID Is Null) Or ([Ajustement].[ContratID] = @ContratID))
)

