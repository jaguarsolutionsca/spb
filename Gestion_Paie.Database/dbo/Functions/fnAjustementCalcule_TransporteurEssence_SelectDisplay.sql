CREATE Function [dbo].[fnAjustementCalcule_TransporteurEssence_SelectDisplay]
(
 @ID [int] = Null
,@AjustementID [int] = Null
,@EssenceID [varchar](6) = Null
,@UniteID [varchar](6) = Null
,@LivraisonDetailID [int] = Null
,@TransporteurID [varchar](15) = Null
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
	 [AjustementCalcule_TransporteurEssence].[ID]
	,[AjustementCalcule_TransporteurEssence].[DateCalcul]
	,[AjustementCalcule_TransporteurEssence].[AjustementID]
	,[Ajustement_EssenceUnite1].[Display] [AjustementID_Display]
	,[AjustementCalcule_TransporteurEssence].[EssenceID]
	,[Ajustement_EssenceUnite2].[Display] [EssenceID_Display]
	,[AjustementCalcule_TransporteurEssence].[UniteID]
	,[Ajustement_EssenceUnite3].[Display] [UniteID_Display]
	,[AjustementCalcule_TransporteurEssence].[LivraisonDetailID]
	,[Livraison_Detail4].[Display] [LivraisonDetailID_Display]
	,[AjustementCalcule_TransporteurEssence].[TransporteurID]
	,[Fournisseur5].[Display] [TransporteurID_Display]
	,[AjustementCalcule_TransporteurEssence].[Volume]
	,[AjustementCalcule_TransporteurEssence].[Taux]
	,[AjustementCalcule_TransporteurEssence].[Montant]
	,[AjustementCalcule_TransporteurEssence].[Facture]
	,[AjustementCalcule_TransporteurEssence].[FactureID]
	,[FactureFournisseur6].[Display] [FactureID_Display]
	,[AjustementCalcule_TransporteurEssence].[ErreurCalcul]
	,[AjustementCalcule_TransporteurEssence].[ErreurDescription]
	,[AjustementCalcule_TransporteurEssence].[Code]
	,[Ajustement_EssenceUnite7].[Display] [Code_Display]

From [dbo].[AjustementCalcule_TransporteurEssence]
    Left Outer Join [fnAjustement_EssenceUnite_Display](Null, Null, Null, Null, Null) [Ajustement_EssenceUnite1] On [AjustementID] = [Ajustement_EssenceUnite1].[ID1]
        Left Outer Join [fnAjustement_EssenceUnite_Display](Null, Null, Null, Null, Null) [Ajustement_EssenceUnite2] On [EssenceID] = [Ajustement_EssenceUnite2].[ID2]
            Left Outer Join [fnAjustement_EssenceUnite_Display](Null, Null, Null, Null, Null) [Ajustement_EssenceUnite3] On [UniteID] = [Ajustement_EssenceUnite3].[ID3]
                Left Outer Join [fnLivraison_Detail_Display](Null, Null, Null, Null, Null, Null, Null, Null) [Livraison_Detail4] On [LivraisonDetailID] = [Livraison_Detail4].[ID1]
                    Left Outer Join [fnFournisseur_Display](Null, Null, Null) [Fournisseur5] On [TransporteurID] = [Fournisseur5].[ID1]
                        Left Outer Join [fnFactureFournisseur_Display](Null, Null, Null, Null, Null, Null) [FactureFournisseur6] On [FactureID] = [FactureFournisseur6].[ID1]
                            Left Outer Join [fnAjustement_EssenceUnite_Display](Null, Null, Null, Null, Null) [Ajustement_EssenceUnite7] On [Code] = [Ajustement_EssenceUnite7].[ID4]

Where

    ((@ID Is Null) Or ([ID] = @ID))
And ((@AjustementID Is Null) Or ([AjustementID] = @AjustementID))
And ((@EssenceID Is Null) Or ([EssenceID] = @EssenceID))
And ((@UniteID Is Null) Or ([UniteID] = @UniteID))
And ((@LivraisonDetailID Is Null) Or ([LivraisonDetailID] = @LivraisonDetailID))
And ((@TransporteurID Is Null) Or ([TransporteurID] = @TransporteurID))
And ((@FactureID Is Null) Or ([FactureID] = @FactureID))
And ((@Code Is Null) Or ([Code] = @Code))
)
