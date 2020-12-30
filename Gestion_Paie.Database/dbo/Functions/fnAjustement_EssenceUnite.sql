CREATE Function [dbo].[fnAjustement_EssenceUnite]
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
Select TOP 100 PERCENT
 [AjustementID]
,[EssenceID]
,[UniteID]
,[ContratID]
,[Taux_usine]
,[Taux_producteur]
,[Taux_transporteur]
,[Date_Modification]
,[Code]

From [dbo].[Ajustement_EssenceUnite]

Where

    ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
)
