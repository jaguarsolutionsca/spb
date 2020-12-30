

Create Procedure [spI_Livraison_Detail]

-- Inserts a new record in [Livraison_Detail] table
(
  @ID [int] = Null Output -- for [Livraison_Detail].[ID] column
, @LivraisonID [int] = Null  -- for [Livraison_Detail].[LivraisonID] column
, @ContratID [varchar](10) = Null  -- for [Livraison_Detail].[ContratID] column
, @EssenceID [varchar](6) = Null  -- for [Livraison_Detail].[EssenceID] column
, @UniteMesureID [varchar](6) = Null  -- for [Livraison_Detail].[UniteMesureID] column
, @ProducteurID [varchar](15) = Null  -- for [Livraison_Detail].[ProducteurID] column
, @Droit_Coupe [bit] = Null  -- for [Livraison_Detail].[Droit_Coupe] column
, @VolumeBrut [float] = Null  -- for [Livraison_Detail].[VolumeBrut] column
, @VolumeReduction [float] = Null  -- for [Livraison_Detail].[VolumeReduction] column
, @VolumeNet [float] = Null  -- for [Livraison_Detail].[VolumeNet] column
, @VolumeContingente [float] = Null  -- for [Livraison_Detail].[VolumeContingente] column
, @ContingentementID [int] = Null  -- for [Livraison_Detail].[ContingentementID] column
, @DateCalcul [datetime] = Null  -- for [Livraison_Detail].[DateCalcul] column
, @Taux_Usine [float] = Null  -- for [Livraison_Detail].[Taux_Usine] column
, @Montant_Usine [float] = Null  -- for [Livraison_Detail].[Montant_Usine] column
, @Taux_Producteur [float] = Null  -- for [Livraison_Detail].[Taux_Producteur] column
, @Montant_ProducteurBrut [float] = Null  -- for [Livraison_Detail].[Montant_ProducteurBrut] column
, @Taux_TransporteurMoyen [float] = Null  -- for [Livraison_Detail].[Taux_TransporteurMoyen] column
, @Taux_TransporteurMoyen_Override [bit] = Null  -- for [Livraison_Detail].[Taux_TransporteurMoyen_Override] column
, @Montant_TransporteurMoyen [float] = Null  -- for [Livraison_Detail].[Montant_TransporteurMoyen] column
, @Taux_Preleve_Plan_Conjoint [float] = Null  -- for [Livraison_Detail].[Taux_Preleve_Plan_Conjoint] column
, @Montant_Preleve_Plan_Conjoint [float] = Null  -- for [Livraison_Detail].[Montant_Preleve_Plan_Conjoint] column
, @Taux_Preleve_Fond_Roulement [float] = Null  -- for [Livraison_Detail].[Taux_Preleve_Fond_Roulement] column
, @Montant_Preleve_Fond_Roulement [float] = Null  -- for [Livraison_Detail].[Montant_Preleve_Fond_Roulement] column
, @Taux_Preleve_Fond_Forestier [float] = Null  -- for [Livraison_Detail].[Taux_Preleve_Fond_Forestier] column
, @Montant_Preleve_Fond_Forestier [float] = Null  -- for [Livraison_Detail].[Montant_Preleve_Fond_Forestier] column
, @Taux_Preleve_Divers [float] = Null  -- for [Livraison_Detail].[Taux_Preleve_Divers] column
, @Montant_Preleve_Divers [float] = Null  -- for [Livraison_Detail].[Montant_Preleve_Divers] column
, @Montant_ProducteurNet [float] = Null  -- for [Livraison_Detail].[Montant_ProducteurNet] column
, @Taux_Producteur_Override [bit] = Null  -- for [Livraison_Detail].[Taux_Producteur_Override] column
, @Taux_Usine_Override [bit] = Null  -- for [Livraison_Detail].[Taux_Usine_Override] column
, @Code [char](4) = Null  -- for [Livraison_Detail].[Code] column
, @UsePreleveMontant [bit] = Null  -- for [Livraison_Detail].[UsePreleveMontant] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ID Is Null
	Begin

		Insert Into [dbo].[Livraison_Detail]
		(
			  [LivraisonID]
			, [ContratID]
			, [EssenceID]
			, [UniteMesureID]
			, [ProducteurID]
			, [Droit_Coupe]
			, [VolumeBrut]
			, [VolumeReduction]
			, [VolumeNet]
			, [VolumeContingente]
			, [ContingentementID]
			, [DateCalcul]
			, [Taux_Usine]
			, [Montant_Usine]
			, [Taux_Producteur]
			, [Montant_ProducteurBrut]
			, [Taux_TransporteurMoyen]
			, [Taux_TransporteurMoyen_Override]
			, [Montant_TransporteurMoyen]
			, [Taux_Preleve_Plan_Conjoint]
			, [Montant_Preleve_Plan_Conjoint]
			, [Taux_Preleve_Fond_Roulement]
			, [Montant_Preleve_Fond_Roulement]
			, [Taux_Preleve_Fond_Forestier]
			, [Montant_Preleve_Fond_Forestier]
			, [Taux_Preleve_Divers]
			, [Montant_Preleve_Divers]
			, [Montant_ProducteurNet]
			, [Taux_Producteur_Override]
			, [Taux_Usine_Override]
			, [Code]
			, [UsePreleveMontant]
		)

		Values
		(
			  @LivraisonID
			, @ContratID
			, @EssenceID
			, @UniteMesureID
			, @ProducteurID
			, @Droit_Coupe
			, @VolumeBrut
			, @VolumeReduction
			, @VolumeNet
			, @VolumeContingente
			, @ContingentementID
			, @DateCalcul
			, @Taux_Usine
			, @Montant_Usine
			, @Taux_Producteur
			, @Montant_ProducteurBrut
			, @Taux_TransporteurMoyen
			, @Taux_TransporteurMoyen_Override
			, @Montant_TransporteurMoyen
			, @Taux_Preleve_Plan_Conjoint
			, @Montant_Preleve_Plan_Conjoint
			, @Taux_Preleve_Fond_Roulement
			, @Montant_Preleve_Fond_Roulement
			, @Taux_Preleve_Fond_Forestier
			, @Montant_Preleve_Fond_Forestier
			, @Taux_Preleve_Divers
			, @Montant_Preleve_Divers
			, @Montant_ProducteurNet
			, @Taux_Producteur_Override
			, @Taux_Usine_Override
			, @Code
			, @UsePreleveMontant
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[Livraison_Detail] On

		Insert Into [dbo].[Livraison_Detail]
		(
			  [ID]
			, [LivraisonID]
			, [ContratID]
			, [EssenceID]
			, [UniteMesureID]
			, [ProducteurID]
			, [Droit_Coupe]
			, [VolumeBrut]
			, [VolumeReduction]
			, [VolumeNet]
			, [VolumeContingente]
			, [ContingentementID]
			, [DateCalcul]
			, [Taux_Usine]
			, [Montant_Usine]
			, [Taux_Producteur]
			, [Montant_ProducteurBrut]
			, [Taux_TransporteurMoyen]
			, [Taux_TransporteurMoyen_Override]
			, [Montant_TransporteurMoyen]
			, [Taux_Preleve_Plan_Conjoint]
			, [Montant_Preleve_Plan_Conjoint]
			, [Taux_Preleve_Fond_Roulement]
			, [Montant_Preleve_Fond_Roulement]
			, [Taux_Preleve_Fond_Forestier]
			, [Montant_Preleve_Fond_Forestier]
			, [Taux_Preleve_Divers]
			, [Montant_Preleve_Divers]
			, [Montant_ProducteurNet]
			, [Taux_Producteur_Override]
			, [Taux_Usine_Override]
			, [Code]
			, [UsePreleveMontant]
		)

		Values
		(
			  @ID
			, @LivraisonID
			, @ContratID
			, @EssenceID
			, @UniteMesureID
			, @ProducteurID
			, @Droit_Coupe
			, @VolumeBrut
			, @VolumeReduction
			, @VolumeNet
			, @VolumeContingente
			, @ContingentementID
			, @DateCalcul
			, @Taux_Usine
			, @Montant_Usine
			, @Taux_Producteur
			, @Montant_ProducteurBrut
			, @Taux_TransporteurMoyen
			, @Taux_TransporteurMoyen_Override
			, @Montant_TransporteurMoyen
			, @Taux_Preleve_Plan_Conjoint
			, @Montant_Preleve_Plan_Conjoint
			, @Taux_Preleve_Fond_Roulement
			, @Montant_Preleve_Fond_Roulement
			, @Taux_Preleve_Fond_Forestier
			, @Montant_Preleve_Fond_Forestier
			, @Taux_Preleve_Divers
			, @Montant_Preleve_Divers
			, @Montant_ProducteurNet
			, @Taux_Producteur_Override
			, @Taux_Usine_Override
			, @Code
			, @UsePreleveMontant
		)

		Set Identity_Insert [dbo].[Livraison_Detail] Off

	End

Set NoCount Off

Return(0)


