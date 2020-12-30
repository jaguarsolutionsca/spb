

Create Function [fnContrat]
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
 [ID]
,[Description]
,[UsineID]
,[Annee]
,[Date_debut]
,[Date_fin]
,[Actif]
,[PaieTransporteur]
,[Taux_Surcharge]
,[SurchargeManuel]
,[TxTransSameProd]

From [dbo].[Contrat]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
)


