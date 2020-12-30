

Create Function [fnContrat_EssenceUnite]
(
 @ContratID [varchar](10) = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
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
 [ContratID]
,[EssenceID]
,[UniteID]
,[Code]
,[Quantite_prevue]
,[Taux_usine]
,[Taux_producteur]
,[Actif]
,[Description]

From [dbo].[Contrat_EssenceUnite]

Where

    ((@ContratID Is Null) Or ([ContratID] = @ContratID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@Code Is Null) Or ([Code] = @Code))
)


