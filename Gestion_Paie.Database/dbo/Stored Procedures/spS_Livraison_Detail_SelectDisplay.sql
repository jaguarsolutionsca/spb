

Create Procedure [spS_Livraison_Detail_SelectDisplay]

-- Retrieve specific records from the [Livraison_Detail] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Livraison_Detail].[ID] column
,@LivraisonID [int] = Null -- for [Livraison_Detail].[LivraisonID] column
,@ContratID [varchar](10) = Null -- for [Livraison_Detail].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Livraison_Detail].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [Livraison_Detail].[UniteMesureID] column
,@ProducteurID [varchar](15) = Null -- for [Livraison_Detail].[ProducteurID] column
,@ContingentementID [int] = Null -- for [Livraison_Detail].[ContingentementID] column
,@Code [char](4) = Null -- for [Livraison_Detail].[Code] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Livraison_Detail_Records].[ID]
		,[Livraison_Detail_Records].[LivraisonID]
		,[Livraison_Detail_Records].[LivraisonID_Display]
		,[Livraison_Detail_Records].[ContratID]
		,[Livraison_Detail_Records].[ContratID_Display]
		,[Livraison_Detail_Records].[EssenceID]
		,[Livraison_Detail_Records].[EssenceID_Display]
		,[Livraison_Detail_Records].[UniteMesureID]
		,[Livraison_Detail_Records].[UniteMesureID_Display]
		,[Livraison_Detail_Records].[ProducteurID]
		,[Livraison_Detail_Records].[ProducteurID_Display]
		,[Livraison_Detail_Records].[Droit_Coupe]
		,[Livraison_Detail_Records].[VolumeBrut]
		,[Livraison_Detail_Records].[VolumeReduction]
		,[Livraison_Detail_Records].[VolumeNet]
		,[Livraison_Detail_Records].[VolumeContingente]
		,[Livraison_Detail_Records].[ContingentementID]
		,[Livraison_Detail_Records].[ContingentementID_Display]
		,[Livraison_Detail_Records].[DateCalcul]
		,[Livraison_Detail_Records].[Taux_Usine]
		,[Livraison_Detail_Records].[Montant_Usine]
		,[Livraison_Detail_Records].[Taux_Producteur]
		,[Livraison_Detail_Records].[Montant_ProducteurBrut]
		,[Livraison_Detail_Records].[Taux_TransporteurMoyen]
		,[Livraison_Detail_Records].[Taux_TransporteurMoyen_Override]
		,[Livraison_Detail_Records].[Montant_TransporteurMoyen]
		,[Livraison_Detail_Records].[Taux_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[Montant_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[Taux_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[Montant_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[Taux_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[Montant_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[Taux_Preleve_Divers]
		,[Livraison_Detail_Records].[Montant_Preleve_Divers]
		,[Livraison_Detail_Records].[Montant_ProducteurNet]
		,[Livraison_Detail_Records].[Taux_Producteur_Override]
		,[Livraison_Detail_Records].[Taux_Usine_Override]
		,[Livraison_Detail_Records].[Code]
		,[Livraison_Detail_Records].[Code_Display]
		,[Livraison_Detail_Records].[UsePreleveMontant]

		From [fnLivraison_Detail_SelectDisplay](@ID, @LivraisonID, @ContratID, @EssenceID, @UniteMesureID, @ProducteurID, @ContingentementID, @Code) As [Livraison_Detail_Records]
	End

Else

	Begin
		Select

		 [Livraison_Detail_Records].[ID]
		,[Livraison_Detail_Records].[LivraisonID]
		,[Livraison_Detail_Records].[LivraisonID_Display]
		,[Livraison_Detail_Records].[ContratID]
		,[Livraison_Detail_Records].[ContratID_Display]
		,[Livraison_Detail_Records].[EssenceID]
		,[Livraison_Detail_Records].[EssenceID_Display]
		,[Livraison_Detail_Records].[UniteMesureID]
		,[Livraison_Detail_Records].[UniteMesureID_Display]
		,[Livraison_Detail_Records].[ProducteurID]
		,[Livraison_Detail_Records].[ProducteurID_Display]
		,[Livraison_Detail_Records].[Droit_Coupe]
		,[Livraison_Detail_Records].[VolumeBrut]
		,[Livraison_Detail_Records].[VolumeReduction]
		,[Livraison_Detail_Records].[VolumeNet]
		,[Livraison_Detail_Records].[VolumeContingente]
		,[Livraison_Detail_Records].[ContingentementID]
		,[Livraison_Detail_Records].[ContingentementID_Display]
		,[Livraison_Detail_Records].[DateCalcul]
		,[Livraison_Detail_Records].[Taux_Usine]
		,[Livraison_Detail_Records].[Montant_Usine]
		,[Livraison_Detail_Records].[Taux_Producteur]
		,[Livraison_Detail_Records].[Montant_ProducteurBrut]
		,[Livraison_Detail_Records].[Taux_TransporteurMoyen]
		,[Livraison_Detail_Records].[Taux_TransporteurMoyen_Override]
		,[Livraison_Detail_Records].[Montant_TransporteurMoyen]
		,[Livraison_Detail_Records].[Taux_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[Montant_Preleve_Plan_Conjoint]
		,[Livraison_Detail_Records].[Taux_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[Montant_Preleve_Fond_Roulement]
		,[Livraison_Detail_Records].[Taux_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[Montant_Preleve_Fond_Forestier]
		,[Livraison_Detail_Records].[Taux_Preleve_Divers]
		,[Livraison_Detail_Records].[Montant_Preleve_Divers]
		,[Livraison_Detail_Records].[Montant_ProducteurNet]
		,[Livraison_Detail_Records].[Taux_Producteur_Override]
		,[Livraison_Detail_Records].[Taux_Usine_Override]
		,[Livraison_Detail_Records].[Code]
		,[Livraison_Detail_Records].[Code_Display]
		,[Livraison_Detail_Records].[UsePreleveMontant]

		From [fnLivraison_Detail_SelectDisplay](@ID, @LivraisonID, @ContratID, @EssenceID, @UniteMesureID, @ProducteurID, @ContingentementID, @Code) As [Livraison_Detail_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


