

Create Function [fnContrat_SelectDisplay]
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
Select
	 [Contrat].[ID]
	,[Contrat].[Description]
	,[Contrat].[UsineID]
	,[Usine1].[Display] [UsineID_Display]
	,[Contrat].[Annee]
	,[Contrat].[Date_debut]
	,[Contrat].[Date_fin]
	,[Contrat].[Actif]
	,[Contrat].[PaieTransporteur]
	,[Contrat].[Taux_Surcharge]
	,[Contrat].[SurchargeManuel]
	,[Contrat].[TxTransSameProd]

From [dbo].[Contrat]
    Left Outer Join [fnUsine_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Usine1] On [UsineID] = [Usine1].[ID1]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
)


