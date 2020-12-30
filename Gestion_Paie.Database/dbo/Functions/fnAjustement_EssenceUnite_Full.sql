CREATE Function [dbo].[fnAjustement_EssenceUnite_Full]

(
 @AjustementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@Code [char](4) = Null
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
 [Ajustement_EssenceUnite].[AjustementID]
,[Ajustement_EssenceUnite].[EssenceID]
,[Ajustement_EssenceUnite].[UniteID]
,[Ajustement_EssenceUnite].[ContratID]
,[Ajustement_EssenceUnite].[Taux_usine]
,[Ajustement_EssenceUnite].[Taux_producteur]
,[Ajustement_EssenceUnite].[Taux_transporteur]
,[Ajustement_EssenceUnite].[Date_Modification]
,[Ajustement_EssenceUnite].[Code]
,[Ajustement1].[ID] [AjustementID_ID]
,[Ajustement1].[ContratID] [AjustementID_ContratID]
,[Ajustement1].[DateAjustement] [AjustementID_DateAjustement]
,[Ajustement1].[Periode_Debut] [AjustementID_Periode_Debut]
,[Ajustement1].[Periode_Fin] [AjustementID_Periode_Fin]
,[Ajustement1].[Facture] [AjustementID_Facture]
,[Ajustement1].[UsePeriodes] [AjustementID_UsePeriodes]
,[Ajustement1].[Date_Debut] [AjustementID_Date_Debut]
,[Ajustement1].[Date_Fin] [AjustementID_Date_Fin]
,[Ajustement1].[ProducteurID] [AjustementID_ProducteurID]
,[Ajustement1].[TransporteurID] [AjustementID_TransporteurID]
,[Ajustement1].[IsRistourne] [AjustementID_IsRistourne]
,[Contrat_EssenceUnite2].[ContratID] [EssenceID_ContratID]
,[Contrat_EssenceUnite2].[EssenceID] [EssenceID_EssenceID]
,[Contrat_EssenceUnite2].[UniteID] [EssenceID_UniteID]
,[Contrat_EssenceUnite2].[Code] [EssenceID_Code]
,[Contrat_EssenceUnite2].[Quantite_prevue] [EssenceID_Quantite_prevue]
,[Contrat_EssenceUnite2].[Taux_usine] [EssenceID_Taux_usine]
,[Contrat_EssenceUnite2].[Taux_producteur] [EssenceID_Taux_producteur]
,[Contrat_EssenceUnite2].[Actif] [EssenceID_Actif]
,[Contrat_EssenceUnite2].[Description] [EssenceID_Description]
,[Contrat_EssenceUnite3].[ContratID] [UniteID_ContratID]
,[Contrat_EssenceUnite3].[EssenceID] [UniteID_EssenceID]
,[Contrat_EssenceUnite3].[UniteID] [UniteID_UniteID]
,[Contrat_EssenceUnite3].[Code] [UniteID_Code]
,[Contrat_EssenceUnite3].[Quantite_prevue] [UniteID_Quantite_prevue]
,[Contrat_EssenceUnite3].[Taux_usine] [UniteID_Taux_usine]
,[Contrat_EssenceUnite3].[Taux_producteur] [UniteID_Taux_producteur]
,[Contrat_EssenceUnite3].[Actif] [UniteID_Actif]
,[Contrat_EssenceUnite3].[Description] [UniteID_Description]
,[Contrat_EssenceUnite4].[ContratID] [ContratID_ContratID]
,[Contrat_EssenceUnite4].[EssenceID] [ContratID_EssenceID]
,[Contrat_EssenceUnite4].[UniteID] [ContratID_UniteID]
,[Contrat_EssenceUnite4].[Code] [ContratID_Code]
,[Contrat_EssenceUnite4].[Quantite_prevue] [ContratID_Quantite_prevue]
,[Contrat_EssenceUnite4].[Taux_usine] [ContratID_Taux_usine]
,[Contrat_EssenceUnite4].[Taux_producteur] [ContratID_Taux_producteur]
,[Contrat_EssenceUnite4].[Actif] [ContratID_Actif]
,[Contrat_EssenceUnite4].[Description] [ContratID_Description]
,[Contrat_EssenceUnite5].[ContratID] [Code_ContratID]
,[Contrat_EssenceUnite5].[EssenceID] [Code_EssenceID]
,[Contrat_EssenceUnite5].[UniteID] [Code_UniteID]
,[Contrat_EssenceUnite5].[Code] [Code_Code]
,[Contrat_EssenceUnite5].[Quantite_prevue] [Code_Quantite_prevue]
,[Contrat_EssenceUnite5].[Taux_usine] [Code_Taux_usine]
,[Contrat_EssenceUnite5].[Taux_producteur] [Code_Taux_producteur]
,[Contrat_EssenceUnite5].[Actif] [Code_Actif]
,[Contrat_EssenceUnite5].[Description] [Code_Description]

From [dbo].[Ajustement_EssenceUnite] [Ajustement_EssenceUnite]
    Inner Join [dbo].[Ajustement] [Ajustement1] On [Ajustement_EssenceUnite].[AjustementID] = [Ajustement1].[ID]
        Inner Join [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite2] On [Ajustement_EssenceUnite].[EssenceID] = [Contrat_EssenceUnite2].[EssenceID]
            Inner Join [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite3] On [Ajustement_EssenceUnite].[UniteID] = [Contrat_EssenceUnite3].[UniteID]
                Inner Join [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite4] On [Ajustement_EssenceUnite].[ContratID] = [Contrat_EssenceUnite4].[ContratID]
                    Inner Join [dbo].[Contrat_EssenceUnite] [Contrat_EssenceUnite5] On [Ajustement_EssenceUnite].[Code] = [Contrat_EssenceUnite5].[Code]

Where

    ((@AjustementID Is Null) Or ([Ajustement_EssenceUnite].[AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([Ajustement_EssenceUnite].[EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([Ajustement_EssenceUnite].[UniteID] = @UniteID))
And ((@Code Is Null) Or ([Ajustement_EssenceUnite].[Code] = @Code))
And ((@ContratID Is Null) Or ([Ajustement_EssenceUnite].[ContratID] = @ContratID))
)
