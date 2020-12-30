CREATE Function [dbo].[fnAjustement_EssenceUnite_SelectDisplay]
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
	,[Ajustement1].[Display] [AjustementID_Display]
	,[Ajustement_EssenceUnite].[EssenceID]
	,[Contrat_EssenceUnite2].[Display] [EssenceID_Display]
	,[Ajustement_EssenceUnite].[UniteID]
	,[Contrat_EssenceUnite3].[Display] [UniteID_Display]
	,[Ajustement_EssenceUnite].[ContratID]
	,[Contrat_EssenceUnite4].[Display] [ContratID_Display]
	,[Ajustement_EssenceUnite].[Taux_usine]
	,[Ajustement_EssenceUnite].[Taux_producteur]
	,[Ajustement_EssenceUnite].[Taux_transporteur]
	,[Ajustement_EssenceUnite].[Date_Modification]
	,[Ajustement_EssenceUnite].[Code]
	,[Contrat_EssenceUnite5].[Display] [Code_Display]

From [dbo].[Ajustement_EssenceUnite]
    Inner Join [fnAjustement_Display](Null, Null) [Ajustement1] On [AjustementID] = [Ajustement1].[ID1]
        Inner Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite2] On [EssenceID] = [Contrat_EssenceUnite2].[ID2]
            Inner Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite3] On [UniteID] = [Contrat_EssenceUnite3].[ID3]
                Inner Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite4] On [ContratID] = [Contrat_EssenceUnite4].[ID1]
                    Inner Join [fnContrat_EssenceUnite_Display](Null, Null, Null, Null) [Contrat_EssenceUnite5] On [Code] = [Contrat_EssenceUnite5].[ID4]

Where

    ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@Code Is Null) Or ([Code] = @Code))
And ((@ContratID Is Null) Or ([ContratID] = @ContratID))
)
