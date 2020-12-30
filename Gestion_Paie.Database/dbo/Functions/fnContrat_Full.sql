

Create Function [fnContrat_Full]

(
 @ID [varchar](10) = Null
,@UsineID [varchar](6) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [Contrat].[ID]
,[Contrat].[Description]
,[Contrat].[UsineID]
,[Contrat].[Annee]
,[Contrat].[Date_debut]
,[Contrat].[Date_fin]
,[Contrat].[Actif]
,[Contrat].[PaieTransporteur]
,[Contrat].[Taux_Surcharge]
,[Contrat].[SurchargeManuel]
,[Contrat].[TxTransSameProd]
,[Usine1].[ID] [UsineID_ID]
,[Usine1].[Description] [UsineID_Description]
,[Usine1].[UtilisationID] [UsineID_UtilisationID]
,[Usine1].[Paye_producteur] [UsineID_Paye_producteur]
,[Usine1].[Paye_transporteur] [UsineID_Paye_transporteur]
,[Usine1].[Specification] [UsineID_Specification]
,[Usine1].[Compte_a_recevoir] [UsineID_Compte_a_recevoir]
,[Usine1].[Compte_ajustement] [UsineID_Compte_ajustement]
,[Usine1].[Compte_transporteur] [UsineID_Compte_transporteur]
,[Usine1].[Compte_producteur] [UsineID_Compte_producteur]
,[Usine1].[Compte_preleve_plan_conjoint] [UsineID_Compte_preleve_plan_conjoint]
,[Usine1].[Compte_preleve_fond_roulement] [UsineID_Compte_preleve_fond_roulement]
,[Usine1].[Compte_preleve_fond_forestier] [UsineID_Compte_preleve_fond_forestier]
,[Usine1].[Compte_preleve_divers] [UsineID_Compte_preleve_divers]
,[Usine1].[Compte_mise_en_commun] [UsineID_Compte_mise_en_commun]
,[Usine1].[Compte_surcharge] [UsineID_Compte_surcharge]
,[Usine1].[Compte_indexation_carburant] [UsineID_Compte_indexation_carburant]
,[Usine1].[Actif] [UsineID_Actif]
,[Usine1].[NePaiePasTPS] [UsineID_NePaiePasTPS]
,[Usine1].[NePaiePasTVQ] [UsineID_NePaiePasTVQ]
,[Usine1].[NoTPS] [UsineID_NoTPS]
,[Usine1].[NoTVQ] [UsineID_NoTVQ]
,[Usine1].[Compte_chargeur] [UsineID_Compte_chargeur]
,[Usine1].[UsineGestionVolume] [UsineID_UsineGestionVolume]
,[Usine1].[AuSoinsDe] [UsineID_AuSoinsDe]
,[Usine1].[Rue] [UsineID_Rue]
,[Usine1].[Ville] [UsineID_Ville]
,[Usine1].[PaysID] [UsineID_PaysID]
,[Usine1].[Code_postal] [UsineID_Code_postal]
,[Usine1].[Telephone] [UsineID_Telephone]
,[Usine1].[Telephone_Poste] [UsineID_Telephone_Poste]
,[Usine1].[Telecopieur] [UsineID_Telecopieur]
,[Usine1].[Telephone2] [UsineID_Telephone2]
,[Usine1].[Telephone2_Desc] [UsineID_Telephone2_Desc]
,[Usine1].[Telephone2_Poste] [UsineID_Telephone2_Poste]
,[Usine1].[Telephone3] [UsineID_Telephone3]
,[Usine1].[Telephone3_Desc] [UsineID_Telephone3_Desc]
,[Usine1].[Telephone3_Poste] [UsineID_Telephone3_Poste]
,[Usine1].[Email] [UsineID_Email]

From [dbo].[Contrat] [Contrat]
    Left Outer Join [dbo].[Usine] [Usine1] On [Contrat].[UsineID] = [Usine1].[ID]

Where

    ((@ID Is Null) Or ([Contrat].[ID] = @ID))
And ((@UsineID Is Null) Or ([Contrat].[UsineID] = @UsineID))
)



