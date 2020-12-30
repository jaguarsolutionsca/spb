

Create Procedure [spU_Livraison_Detail]

-- Update an existing record in [Livraison_Detail] table

(
  @ID [int] -- for [Livraison_Detail].[ID] column
, @LivraisonID [int] -- for [Livraison_Detail].[LivraisonID] column
, @ConsiderNull_LivraisonID bit = 0
, @ContratID [varchar](10) -- for [Livraison_Detail].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @EssenceID [varchar](6) -- for [Livraison_Detail].[EssenceID] column
, @ConsiderNull_EssenceID bit = 0
, @UniteMesureID [varchar](6) -- for [Livraison_Detail].[UniteMesureID] column
, @ConsiderNull_UniteMesureID bit = 0
, @ProducteurID [varchar](15) -- for [Livraison_Detail].[ProducteurID] column
, @ConsiderNull_ProducteurID bit = 0
, @Droit_Coupe [bit] = Null -- for [Livraison_Detail].[Droit_Coupe] column
, @ConsiderNull_Droit_Coupe bit = 0
, @VolumeBrut [float] = Null -- for [Livraison_Detail].[VolumeBrut] column
, @ConsiderNull_VolumeBrut bit = 0
, @VolumeReduction [float] = Null -- for [Livraison_Detail].[VolumeReduction] column
, @ConsiderNull_VolumeReduction bit = 0
, @VolumeNet [float] = Null -- for [Livraison_Detail].[VolumeNet] column
, @ConsiderNull_VolumeNet bit = 0
, @VolumeContingente [float] = Null -- for [Livraison_Detail].[VolumeContingente] column
, @ConsiderNull_VolumeContingente bit = 0
, @ContingentementID [int] = Null -- for [Livraison_Detail].[ContingentementID] column
, @ConsiderNull_ContingentementID bit = 0
, @DateCalcul [datetime] = Null -- for [Livraison_Detail].[DateCalcul] column
, @ConsiderNull_DateCalcul bit = 0
, @Taux_Usine [float] = Null -- for [Livraison_Detail].[Taux_Usine] column
, @ConsiderNull_Taux_Usine bit = 0
, @Montant_Usine [float] = Null -- for [Livraison_Detail].[Montant_Usine] column
, @ConsiderNull_Montant_Usine bit = 0
, @Taux_Producteur [float] = Null -- for [Livraison_Detail].[Taux_Producteur] column
, @ConsiderNull_Taux_Producteur bit = 0
, @Montant_ProducteurBrut [float] = Null -- for [Livraison_Detail].[Montant_ProducteurBrut] column
, @ConsiderNull_Montant_ProducteurBrut bit = 0
, @Taux_TransporteurMoyen [float] = Null -- for [Livraison_Detail].[Taux_TransporteurMoyen] column
, @ConsiderNull_Taux_TransporteurMoyen bit = 0
, @Taux_TransporteurMoyen_Override [bit] = Null -- for [Livraison_Detail].[Taux_TransporteurMoyen_Override] column
, @ConsiderNull_Taux_TransporteurMoyen_Override bit = 0
, @Montant_TransporteurMoyen [float] = Null -- for [Livraison_Detail].[Montant_TransporteurMoyen] column
, @ConsiderNull_Montant_TransporteurMoyen bit = 0
, @Taux_Preleve_Plan_Conjoint [float] = Null -- for [Livraison_Detail].[Taux_Preleve_Plan_Conjoint] column
, @ConsiderNull_Taux_Preleve_Plan_Conjoint bit = 0
, @Montant_Preleve_Plan_Conjoint [float] = Null -- for [Livraison_Detail].[Montant_Preleve_Plan_Conjoint] column
, @ConsiderNull_Montant_Preleve_Plan_Conjoint bit = 0
, @Taux_Preleve_Fond_Roulement [float] = Null -- for [Livraison_Detail].[Taux_Preleve_Fond_Roulement] column
, @ConsiderNull_Taux_Preleve_Fond_Roulement bit = 0
, @Montant_Preleve_Fond_Roulement [float] = Null -- for [Livraison_Detail].[Montant_Preleve_Fond_Roulement] column
, @ConsiderNull_Montant_Preleve_Fond_Roulement bit = 0
, @Taux_Preleve_Fond_Forestier [float] = Null -- for [Livraison_Detail].[Taux_Preleve_Fond_Forestier] column
, @ConsiderNull_Taux_Preleve_Fond_Forestier bit = 0
, @Montant_Preleve_Fond_Forestier [float] = Null -- for [Livraison_Detail].[Montant_Preleve_Fond_Forestier] column
, @ConsiderNull_Montant_Preleve_Fond_Forestier bit = 0
, @Taux_Preleve_Divers [float] = Null -- for [Livraison_Detail].[Taux_Preleve_Divers] column
, @ConsiderNull_Taux_Preleve_Divers bit = 0
, @Montant_Preleve_Divers [float] = Null -- for [Livraison_Detail].[Montant_Preleve_Divers] column
, @ConsiderNull_Montant_Preleve_Divers bit = 0
, @Montant_ProducteurNet [float] = Null -- for [Livraison_Detail].[Montant_ProducteurNet] column
, @ConsiderNull_Montant_ProducteurNet bit = 0
, @Taux_Producteur_Override [bit] = Null -- for [Livraison_Detail].[Taux_Producteur_Override] column
, @ConsiderNull_Taux_Producteur_Override bit = 0
, @Taux_Usine_Override [bit] = Null -- for [Livraison_Detail].[Taux_Usine_Override] column
, @ConsiderNull_Taux_Usine_Override bit = 0
, @Code [char](4) = Null -- for [Livraison_Detail].[Code] column
, @ConsiderNull_Code bit = 0
, @UsePreleveMontant [bit] = Null -- for [Livraison_Detail].[UsePreleveMontant] column
, @ConsiderNull_UsePreleveMontant bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_LivraisonID Is Null
	Set @ConsiderNull_LivraisonID = 0

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_UniteMesureID Is Null
	Set @ConsiderNull_UniteMesureID = 0

If @ConsiderNull_ProducteurID Is Null
	Set @ConsiderNull_ProducteurID = 0

If @ConsiderNull_Droit_Coupe Is Null
	Set @ConsiderNull_Droit_Coupe = 0

If @ConsiderNull_VolumeBrut Is Null
	Set @ConsiderNull_VolumeBrut = 0

If @ConsiderNull_VolumeReduction Is Null
	Set @ConsiderNull_VolumeReduction = 0

If @ConsiderNull_VolumeNet Is Null
	Set @ConsiderNull_VolumeNet = 0

If @ConsiderNull_VolumeContingente Is Null
	Set @ConsiderNull_VolumeContingente = 0

If @ConsiderNull_ContingentementID Is Null
	Set @ConsiderNull_ContingentementID = 0

If @ConsiderNull_DateCalcul Is Null
	Set @ConsiderNull_DateCalcul = 0

If @ConsiderNull_Taux_Usine Is Null
	Set @ConsiderNull_Taux_Usine = 0

If @ConsiderNull_Montant_Usine Is Null
	Set @ConsiderNull_Montant_Usine = 0

If @ConsiderNull_Taux_Producteur Is Null
	Set @ConsiderNull_Taux_Producteur = 0

If @ConsiderNull_Montant_ProducteurBrut Is Null
	Set @ConsiderNull_Montant_ProducteurBrut = 0

If @ConsiderNull_Taux_TransporteurMoyen Is Null
	Set @ConsiderNull_Taux_TransporteurMoyen = 0

If @ConsiderNull_Taux_TransporteurMoyen_Override Is Null
	Set @ConsiderNull_Taux_TransporteurMoyen_Override = 0

If @ConsiderNull_Montant_TransporteurMoyen Is Null
	Set @ConsiderNull_Montant_TransporteurMoyen = 0

If @ConsiderNull_Taux_Preleve_Plan_Conjoint Is Null
	Set @ConsiderNull_Taux_Preleve_Plan_Conjoint = 0

If @ConsiderNull_Montant_Preleve_Plan_Conjoint Is Null
	Set @ConsiderNull_Montant_Preleve_Plan_Conjoint = 0

If @ConsiderNull_Taux_Preleve_Fond_Roulement Is Null
	Set @ConsiderNull_Taux_Preleve_Fond_Roulement = 0

If @ConsiderNull_Montant_Preleve_Fond_Roulement Is Null
	Set @ConsiderNull_Montant_Preleve_Fond_Roulement = 0

If @ConsiderNull_Taux_Preleve_Fond_Forestier Is Null
	Set @ConsiderNull_Taux_Preleve_Fond_Forestier = 0

If @ConsiderNull_Montant_Preleve_Fond_Forestier Is Null
	Set @ConsiderNull_Montant_Preleve_Fond_Forestier = 0

If @ConsiderNull_Taux_Preleve_Divers Is Null
	Set @ConsiderNull_Taux_Preleve_Divers = 0

If @ConsiderNull_Montant_Preleve_Divers Is Null
	Set @ConsiderNull_Montant_Preleve_Divers = 0

If @ConsiderNull_Montant_ProducteurNet Is Null
	Set @ConsiderNull_Montant_ProducteurNet = 0

If @ConsiderNull_Taux_Producteur_Override Is Null
	Set @ConsiderNull_Taux_Producteur_Override = 0

If @ConsiderNull_Taux_Usine_Override Is Null
	Set @ConsiderNull_Taux_Usine_Override = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0

If @ConsiderNull_UsePreleveMontant Is Null
	Set @ConsiderNull_UsePreleveMontant = 0


Update [dbo].[Livraison_Detail]

Set
	 [LivraisonID] = Case @ConsiderNull_LivraisonID When 0 Then IsNull(@LivraisonID, [LivraisonID]) When 1 Then @LivraisonID End
	,[ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[UniteMesureID] = Case @ConsiderNull_UniteMesureID When 0 Then IsNull(@UniteMesureID, [UniteMesureID]) When 1 Then @UniteMesureID End
	,[ProducteurID] = Case @ConsiderNull_ProducteurID When 0 Then IsNull(@ProducteurID, [ProducteurID]) When 1 Then @ProducteurID End
	,[Droit_Coupe] = Case @ConsiderNull_Droit_Coupe When 0 Then IsNull(@Droit_Coupe, [Droit_Coupe]) When 1 Then @Droit_Coupe End
	,[VolumeBrut] = Case @ConsiderNull_VolumeBrut When 0 Then IsNull(@VolumeBrut, [VolumeBrut]) When 1 Then @VolumeBrut End
	,[VolumeReduction] = Case @ConsiderNull_VolumeReduction When 0 Then IsNull(@VolumeReduction, [VolumeReduction]) When 1 Then @VolumeReduction End
	,[VolumeNet] = Case @ConsiderNull_VolumeNet When 0 Then IsNull(@VolumeNet, [VolumeNet]) When 1 Then @VolumeNet End
	,[VolumeContingente] = Case @ConsiderNull_VolumeContingente When 0 Then IsNull(@VolumeContingente, [VolumeContingente]) When 1 Then @VolumeContingente End
	,[ContingentementID] = Case @ConsiderNull_ContingentementID When 0 Then IsNull(@ContingentementID, [ContingentementID]) When 1 Then @ContingentementID End
	,[DateCalcul] = Case @ConsiderNull_DateCalcul When 0 Then IsNull(@DateCalcul, [DateCalcul]) When 1 Then @DateCalcul End
	,[Taux_Usine] = Case @ConsiderNull_Taux_Usine When 0 Then IsNull(@Taux_Usine, [Taux_Usine]) When 1 Then @Taux_Usine End
	,[Montant_Usine] = Case @ConsiderNull_Montant_Usine When 0 Then IsNull(@Montant_Usine, [Montant_Usine]) When 1 Then @Montant_Usine End
	,[Taux_Producteur] = Case @ConsiderNull_Taux_Producteur When 0 Then IsNull(@Taux_Producteur, [Taux_Producteur]) When 1 Then @Taux_Producteur End
	,[Montant_ProducteurBrut] = Case @ConsiderNull_Montant_ProducteurBrut When 0 Then IsNull(@Montant_ProducteurBrut, [Montant_ProducteurBrut]) When 1 Then @Montant_ProducteurBrut End
	,[Taux_TransporteurMoyen] = Case @ConsiderNull_Taux_TransporteurMoyen When 0 Then IsNull(@Taux_TransporteurMoyen, [Taux_TransporteurMoyen]) When 1 Then @Taux_TransporteurMoyen End
	,[Taux_TransporteurMoyen_Override] = Case @ConsiderNull_Taux_TransporteurMoyen_Override When 0 Then IsNull(@Taux_TransporteurMoyen_Override, [Taux_TransporteurMoyen_Override]) When 1 Then @Taux_TransporteurMoyen_Override End
	,[Montant_TransporteurMoyen] = Case @ConsiderNull_Montant_TransporteurMoyen When 0 Then IsNull(@Montant_TransporteurMoyen, [Montant_TransporteurMoyen]) When 1 Then @Montant_TransporteurMoyen End
	,[Taux_Preleve_Plan_Conjoint] = Case @ConsiderNull_Taux_Preleve_Plan_Conjoint When 0 Then IsNull(@Taux_Preleve_Plan_Conjoint, [Taux_Preleve_Plan_Conjoint]) When 1 Then @Taux_Preleve_Plan_Conjoint End
	,[Montant_Preleve_Plan_Conjoint] = Case @ConsiderNull_Montant_Preleve_Plan_Conjoint When 0 Then IsNull(@Montant_Preleve_Plan_Conjoint, [Montant_Preleve_Plan_Conjoint]) When 1 Then @Montant_Preleve_Plan_Conjoint End
	,[Taux_Preleve_Fond_Roulement] = Case @ConsiderNull_Taux_Preleve_Fond_Roulement When 0 Then IsNull(@Taux_Preleve_Fond_Roulement, [Taux_Preleve_Fond_Roulement]) When 1 Then @Taux_Preleve_Fond_Roulement End
	,[Montant_Preleve_Fond_Roulement] = Case @ConsiderNull_Montant_Preleve_Fond_Roulement When 0 Then IsNull(@Montant_Preleve_Fond_Roulement, [Montant_Preleve_Fond_Roulement]) When 1 Then @Montant_Preleve_Fond_Roulement End
	,[Taux_Preleve_Fond_Forestier] = Case @ConsiderNull_Taux_Preleve_Fond_Forestier When 0 Then IsNull(@Taux_Preleve_Fond_Forestier, [Taux_Preleve_Fond_Forestier]) When 1 Then @Taux_Preleve_Fond_Forestier End
	,[Montant_Preleve_Fond_Forestier] = Case @ConsiderNull_Montant_Preleve_Fond_Forestier When 0 Then IsNull(@Montant_Preleve_Fond_Forestier, [Montant_Preleve_Fond_Forestier]) When 1 Then @Montant_Preleve_Fond_Forestier End
	,[Taux_Preleve_Divers] = Case @ConsiderNull_Taux_Preleve_Divers When 0 Then IsNull(@Taux_Preleve_Divers, [Taux_Preleve_Divers]) When 1 Then @Taux_Preleve_Divers End
	,[Montant_Preleve_Divers] = Case @ConsiderNull_Montant_Preleve_Divers When 0 Then IsNull(@Montant_Preleve_Divers, [Montant_Preleve_Divers]) When 1 Then @Montant_Preleve_Divers End
	,[Montant_ProducteurNet] = Case @ConsiderNull_Montant_ProducteurNet When 0 Then IsNull(@Montant_ProducteurNet, [Montant_ProducteurNet]) When 1 Then @Montant_ProducteurNet End
	,[Taux_Producteur_Override] = Case @ConsiderNull_Taux_Producteur_Override When 0 Then IsNull(@Taux_Producteur_Override, [Taux_Producteur_Override]) When 1 Then @Taux_Producteur_Override End
	,[Taux_Usine_Override] = Case @ConsiderNull_Taux_Usine_Override When 0 Then IsNull(@Taux_Usine_Override, [Taux_Usine_Override]) When 1 Then @Taux_Usine_Override End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End
	,[UsePreleveMontant] = Case @ConsiderNull_UsePreleveMontant When 0 Then IsNull(@UsePreleveMontant, [UsePreleveMontant]) When 1 Then @UsePreleveMontant End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


