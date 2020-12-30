

Create Function [fnAjustementCalcule_Usine_SelectDisplay]
(
 @ID [int] = Null
,@AjustementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@LivraisonDetailID [int] = Null
,@UsineID [varchar](6) = Null
,@FactureID [int] = Null
,@Code [char](4) = Null
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select
	 [AjustementCalcule_Usine].[ID]
	,[AjustementCalcule_Usine].[DateCalcul]
	,[AjustementCalcule_Usine].[AjustementID]
	,[Ajustement_EssenceUnite1].[Display] [AjustementID_Display]
	,[AjustementCalcule_Usine].[EssenceID]
	,[Ajustement_EssenceUnite2].[Display] [EssenceID_Display]
	,[AjustementCalcule_Usine].[UniteID]
	,[Ajustement_EssenceUnite3].[Display] [UniteID_Display]
	,[AjustementCalcule_Usine].[LivraisonDetailID]
	,[Livraison_Detail4].[Display] [LivraisonDetailID_Display]
	,[AjustementCalcule_Usine].[UsineID]
	,[Usine5].[Display] [UsineID_Display]
	,[AjustementCalcule_Usine].[Volume]
	,[AjustementCalcule_Usine].[Taux]
	,[AjustementCalcule_Usine].[Montant]
	,[AjustementCalcule_Usine].[Facture]
	,[AjustementCalcule_Usine].[FactureID]
	,[FactureClient6].[Display] [FactureID_Display]
	,[AjustementCalcule_Usine].[ErreurCalcul]
	,[AjustementCalcule_Usine].[ErreurDescription]
	,[AjustementCalcule_Usine].[Code]
	,[Ajustement_EssenceUnite7].[Display] [Code_Display]

From [dbo].[AjustementCalcule_Usine]
    Left Outer Join [fnAjustement_EssenceUnite_Display](Null, Null, Null, Null, Null) [Ajustement_EssenceUnite1] On [AjustementID] = [Ajustement_EssenceUnite1].[ID1]
        Left Outer Join [fnAjustement_EssenceUnite_Display](Null, Null, Null, Null, Null) [Ajustement_EssenceUnite2] On [EssenceID] = [Ajustement_EssenceUnite2].[ID2]
            Left Outer Join [fnAjustement_EssenceUnite_Display](Null, Null, Null, Null, Null) [Ajustement_EssenceUnite3] On [UniteID] = [Ajustement_EssenceUnite3].[ID3]
                Left Outer Join [fnLivraison_Detail_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Livraison_Detail4] On [LivraisonDetailID] = [Livraison_Detail4].[ID1]
                    Left Outer Join [fnUsine_Display](Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null) [Usine5] On [UsineID] = [Usine5].[ID1]
                        Left Outer Join [fnFactureClient_Display](Null, Null, Null, Null, Null, Null) [FactureClient6] On [FactureID] = [FactureClient6].[ID1]
                            Left Outer Join [fnAjustement_EssenceUnite_Display](Null, Null, Null, Null, Null) [Ajustement_EssenceUnite7] On [Code] = [Ajustement_EssenceUnite7].[ID4]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([LivraisonDetailID] = @LivraisonDetailID))
And ((@UsineID Is Null) Or ([UsineID] = @UsineID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Code Is Null) Or ([Code] = @Code))
)


