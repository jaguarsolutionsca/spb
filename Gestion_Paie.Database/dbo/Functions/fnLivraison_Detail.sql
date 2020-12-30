

Create Function [fnLivraison_Detail]
(
 @ID [int] = Null
,@LivraisonID [int] = Null
,@ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@UniteMesureID [varchar](6) = Null
,@ProducteurID [varchar](15) = Null
,@ContingentementID [int] = Null
,@Code [char](4) = Null
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
,[LivraisonID]
,[ContratID]
,[EssenceID]
,[UniteMesureID]
,[ProducteurID]
,[Droit_Coupe]
,[VolumeBrut]
,[VolumeReduction]
,[VolumeNet]
,[VolumeContingente]
,[ContingentementID]
,[DateCalcul]
,[Taux_Usine]
,[Montant_Usine]
,[Taux_Producteur]
,[Montant_ProducteurBrut]
,[Taux_TransporteurMoyen]
,[Taux_TransporteurMoyen_Override]
,[Montant_TransporteurMoyen]
,[Taux_Preleve_Plan_Conjoint]
,[Montant_Preleve_Plan_Conjoint]
,[Taux_Preleve_Fond_Roulement]
,[Montant_Preleve_Fond_Roulement]
,[Taux_Preleve_Fond_Forestier]
,[Montant_Preleve_Fond_Forestier]
,[Taux_Preleve_Divers]
,[Montant_Preleve_Divers]
,[Montant_ProducteurNet]
,[Taux_Producteur_Override]
,[Taux_Usine_Override]
,[Code]
,[UsePreleveMontant]

From [dbo].[Livraison_Detail]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@LivraisonID Is Null) Or ([LivraisonID] = @LivraisonID))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteMesureID Is Null) Or ([UniteMesureID] = @UniteMesureID))
And ((@ProducteurID Is Null) Or ([ProducteurID] = @ProducteurID))
And ((@ContingentementID Is Null) Or ([ContingentementID] = @ContingentementID))
And ((@Code Is Null) Or ([Code] = @Code))
)


