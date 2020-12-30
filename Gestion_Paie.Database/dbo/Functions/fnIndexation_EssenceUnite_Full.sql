

Create Function [fnIndexation_EssenceUnite_Full]

(
 @ID [int] = Null
,@IndexationID [int] = Null
,@ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@Code [char](4) = Null
,@UniteID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Indexation_EssenceUnite].[ID]
,[Indexation_EssenceUnite].[IndexationID]
,[Indexation_EssenceUnite].[ContratID]
,[Indexation_EssenceUnite].[EssenceID]
,[Indexation_EssenceUnite].[Code]
,[Indexation_EssenceUnite].[UniteID]
,[Indexation_EssenceUnite].[Taux]
,[Indexation1].[ID] [IndexationID_ID]
,[Indexation1].[DateIndexation] [IndexationID_DateIndexation]
,[Indexation1].[ContratID] [IndexationID_ContratID]
,[Indexation1].[Periode_Debut] [IndexationID_Periode_Debut]
,[Indexation1].[Periode_Fin] [IndexationID_Periode_Fin]
,[Indexation1].[TypeIndexation] [IndexationID_TypeIndexation]
,[Indexation1].[PourcentageDuMontant] [IndexationID_PourcentageDuMontant]
,[Indexation1].[Facture] [IndexationID_Facture]
,[Indexation1].[IndexationTransporteur] [IndexationID_IndexationTransporteur]
,[Indexation1].[Date_Debut] [IndexationID_Date_Debut]
,[Indexation1].[Date_Fin] [IndexationID_Date_Fin]
,[Indexation1].[IndexationManuelle] [IndexationID_IndexationManuelle]
,[Contrat_EssenceUnite2].[ContratID] [ContratID_ContratID]
,[Contrat_EssenceUnite2].[EssenceID] [ContratID_EssenceID]
,[Contrat_EssenceUnite2].[UniteID] [ContratID_UniteID]
,[Contrat_EssenceUnite2].[Code] [ContratID_Code]
,[Contrat_EssenceUnite2].[Quantite_prevue] [ContratID_Quantite_prevue]
,[Contrat_EssenceUnite2].[Taux_usine] [ContratID_Taux_usine]
,[Contrat_EssenceUnite2].[Taux_producteur] [ContratID_Taux_producteur]
,[Contrat_EssenceUnite2].[Actif] [ContratID_Actif]
,[Contrat_EssenceUnite2].[Description] [ContratID_Description]
,[Contrat_EssenceUnite3].[ContratID] [EssenceID_ContratID]
,[Contrat_EssenceUnite3].[EssenceID] [EssenceID_EssenceID]
,[Contrat_EssenceUnite3].[UniteID] [EssenceID_UniteID]
,[Contrat_EssenceUnite3].[Code] [EssenceID_Code]
,[Contrat_EssenceUnite3].[Quantite_prevue] [EssenceID_Quantite_prevue]
,[Contrat_EssenceUnite3].[Taux_usine] [EssenceID_Taux_usine]
,[Contrat_EssenceUnite3].[Taux_producteur] [EssenceID_Taux_producteur]
,[Contrat_EssenceUnite3].[Actif] [EssenceID_Actif]
,[Contrat_EssenceUnite3].[Description] [EssenceID_Description]
,[Contrat_EssenceUnite4].[ContratID] [Code_ContratID]
,[Contrat_EssenceUnite4].[EssenceID] [Code_EssenceID]
,[Contrat_EssenceUnite4].[UniteID] [Code_UniteID]
,[Contrat_EssenceUnite4].[Code] [Code_Code]
,[Contrat_EssenceUnite4].[Quantite_prevue] [Code_Quantite_prevue]
,[Contrat_EssenceUnite4].[Taux_usine] [Code_Taux_usine]
,[Contrat_EssenceUnite4].[Taux_producteur] [Code_Taux_producteur]
,[Contrat_EssenceUnite4].[Actif] [Code_Actif]
,[Contrat_EssenceUnite4].[Description] [Code_Description]
,[Contrat_EssenceUnite5].[ContratID] [UniteID_ContratID]
,[Contrat_EssenceUnite5].[EssenceID] [UniteID_EssenceID]
,[Contrat_EssenceUnite5].[UniteID] [UniteID_UniteID]
,[Contrat_EssenceUnite5].[Code] [UniteID_Code]
,[Contrat_EssenceUnite5].[Quantite_prevue] [UniteID_Quantite_prevue]
,[Contrat_EssenceUnite5].[Taux_usine] [UniteID_Taux_usine]
,[Contrat_EssenceUnite5].[Taux_producteur] [UniteID_Taux_producteur]
,[Contrat_EssenceUnite5].[Actif] [UniteID_Actif]
,[Contrat_EssenceUnite5].[Description] [UniteID_Description]

From [dbo].[Indexation_EssenceUnite] [Indexation_EssenceUnite]
    Left Outer Join [dbo].[Indexation] [Indexation1] On [Indexation_EssenceUnite].[IndexationID] = [Indexation1].[ID]
        Left Outer Join [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite2] On [Indexation_EssenceUnite].[ContratID] = [Contrat_EssenceUnite2].[ContratID]
            Left Outer Join [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite3] On [Indexation_EssenceUnite].[EssenceID] = [Contrat_EssenceUnite3].[EssenceID]
                Left Outer Join [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite4] On [Indexation_EssenceUnite].[Code] = [Contrat_EssenceUnite4].[Code]
                    Left Outer Join [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite5] On [Indexation_EssenceUnite].[UniteID] = [Contrat_EssenceUnite5].[UniteID]

Where

    ((@ID Is Null) Or ([Indexation_EssenceUnite].[ID] = @ID))
And ((@IndexationID Is Null) Or ([Indexation_EssenceUnite].[IndexationID] = @IndexationID))
And ((@ContratID Is Null) Or ([Indexation_EssenceUnite].[ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([Indexation_EssenceUnite].[EssenceID] = @EssenceID))
And ((@Code Is Null) Or ([Indexation_EssenceUnite].[Code] = @Code))
And ((@UniteID Is Null) Or ([Indexation_EssenceUnite].[UniteID] = @UniteID))
)



