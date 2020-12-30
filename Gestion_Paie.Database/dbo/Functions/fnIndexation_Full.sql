

Create Function [fnIndexation_Full]

(
 @ID [int] = Null
,@ContratID [varchar](10) = Null
,@TypeIndexation [char](1) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Indexation].[ID]
,[Indexation].[DateIndexation]
,[Indexation].[ContratID]
,[Indexation].[Periode_Debut]
,[Indexation].[Periode_Fin]
,[Indexation].[TypeIndexation]
,[Indexation].[PourcentageDuMontant]
,[Indexation].[Facture]
,[Indexation].[IndexationTransporteur]
,[Indexation].[Date_Debut]
,[Indexation].[Date_Fin]
,[Indexation].[IndexationManuelle]
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
,[TypeIndexation2].[ID] [TypeIndexation_ID]
,[TypeIndexation2].[Description] [TypeIndexation_Description]

From [dbo].[Indexation] [Indexation]
    Left Outer Join [dbo].[Contrat] [Contrat1] On [Indexation].[ContratID] = [Contrat1].[ID]
        Left Outer Join [dbo].[TypeIndexation] [TypeIndexation2] On [Indexation].[TypeIndexation] = [TypeIndexation2].[ID]

Where

    ((@ID Is Null) Or ([Indexation].[ID] = @ID))
And ((@ContratID Is Null) Or ([Indexation].[ContratID] = @ContratID))
And ((@TypeIndexation Is Null) Or ([Indexation].[TypeIndexation] = @TypeIndexation))
)



