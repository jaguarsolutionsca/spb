CREATE PROCEDURE [dbo].[spU_Livraison]
@ID INT, @DateLivraison SMALLDATETIME=Null, @ConsiderNull_DateLivraison BIT=0, @DatePaye SMALLDATETIME=Null, @ConsiderNull_DatePaye BIT=0, @ContratID VARCHAR (10)=Null, @ConsiderNull_ContratID BIT=0, @UniteMesureID VARCHAR (6)=Null, @ConsiderNull_UniteMesureID BIT=0, @EssenceID VARCHAR (6)=Null, @ConsiderNull_EssenceID BIT=0, @Sciage BIT=Null, @ConsiderNull_Sciage BIT=0, @NumeroFactureUsine VARCHAR (25)=Null, @ConsiderNull_NumeroFactureUsine BIT=0, @DroitCoupeID VARCHAR (15)=Null, @ConsiderNull_DroitCoupeID BIT=0, @EntentePaiementID VARCHAR (15)=Null, @ConsiderNull_EntentePaiementID BIT=0, @TransporteurID VARCHAR (15)=Null, @ConsiderNull_TransporteurID BIT=0, @VR VARCHAR (10)=Null, @ConsiderNull_VR BIT=0, @MasseLimite FLOAT=Null, @ConsiderNull_MasseLimite BIT=0, @VolumeBrut FLOAT=Null, @ConsiderNull_VolumeBrut BIT=0, @VolumeTare FLOAT=Null, @ConsiderNull_VolumeTare BIT=0, @VolumeTransporte FLOAT=Null, @ConsiderNull_VolumeTransporte BIT=0, @VolumeSurcharge FLOAT=Null, @ConsiderNull_VolumeSurcharge BIT=0, @VolumeAPayer FLOAT=Null, @ConsiderNull_VolumeAPayer BIT=0, @Annee INT=Null, @ConsiderNull_Annee BIT=0, @Periode INT=Null, @ConsiderNull_Periode BIT=0, @DateCalcul DATETIME=Null, @ConsiderNull_DateCalcul BIT=0, @Taux_Transporteur FLOAT=Null, @ConsiderNull_Taux_Transporteur BIT=0, @Montant_Transporteur FLOAT=Null, @ConsiderNull_Montant_Transporteur BIT=0, @Montant_Usine FLOAT=Null, @ConsiderNull_Montant_Usine BIT=0, @Montant_Producteur1 FLOAT=Null, @ConsiderNull_Montant_Producteur1 BIT=0, @Montant_Producteur2 FLOAT=Null, @ConsiderNull_Montant_Producteur2 BIT=0, @Montant_Preleve_Plan_Conjoint FLOAT=Null, @ConsiderNull_Montant_Preleve_Plan_Conjoint BIT=0, @Montant_Preleve_Fond_Roulement FLOAT=Null, @ConsiderNull_Montant_Preleve_Fond_Roulement BIT=0, @Montant_Preleve_Fond_Forestier FLOAT=Null, @ConsiderNull_Montant_Preleve_Fond_Forestier BIT=0, @Montant_Preleve_Divers FLOAT=Null, @ConsiderNull_Montant_Preleve_Divers BIT=0, @Montant_Surcharge FLOAT=Null, @ConsiderNull_Montant_Surcharge BIT=0, @Montant_MiseEnCommun REAL=Null, @ConsiderNull_Montant_MiseEnCommun BIT=0, @Facture BIT=Null, @ConsiderNull_Facture BIT=0, @Producteur1_FactureID INT=Null, @ConsiderNull_Producteur1_FactureID BIT=0, @Producteur2_FactureID INT=Null, @ConsiderNull_Producteur2_FactureID BIT=0, @Transporteur_FactureID INT=Null, @ConsiderNull_Transporteur_FactureID BIT=0, @Usine_FactureID INT=Null, @ConsiderNull_Usine_FactureID BIT=0, @ErreurCalcul BIT=Null, @ConsiderNull_ErreurCalcul BIT=0, @ErreurDescription VARCHAR (4000)=Null, @ConsiderNull_ErreurDescription BIT=0, @LotID INT=Null, @ConsiderNull_LotID BIT=0, @Taux_Transporteur_Override BIT=Null, @ConsiderNull_Taux_Transporteur_Override BIT=0, @PaieTransporteur BIT=Null, @ConsiderNull_PaieTransporteur BIT=0, @VolumeSurcharge_Override BIT=Null, @ConsiderNull_VolumeSurcharge_Override BIT=0, @SurchargeManuel BIT=Null, @ConsiderNull_SurchargeManuel BIT=0, @Code CHAR (4)=Null, @ConsiderNull_Code BIT=0, @NombrePermis INT=Null, @ConsiderNull_NombrePermis BIT=0, @ZoneID VARCHAR (2)=Null, @ConsiderNull_ZoneID BIT=0, @MunicipaliteID VARCHAR (6)=Null, @ConsiderNull_MunicipaliteID BIT=0, @ChargeurID VARCHAR (15)=Null, @ConsiderNull_ChargeurID BIT=0, @Montant_Chargeur FLOAT=Null, @ConsiderNull_Montant_Chargeur BIT=0, @Frais_ChargeurAuProducteur FLOAT=Null, @ConsiderNull_Frais_ChargeurAuProducteur BIT=0, @Frais_ChargeurAuTransporteur FLOAT=Null, @ConsiderNull_Frais_ChargeurAuTransporteur BIT=0, @Frais_AutresAuProducteur FLOAT=Null, @ConsiderNull_Frais_AutresAuProducteur BIT=0, @Frais_AutresAuProducteurDescription VARCHAR (50)=Null, @ConsiderNull_Frais_AutresAuProducteurDescription BIT=0, @Frais_AutresAuProducteurTransportSciage FLOAT=Null, @ConsiderNull_Frais_AutresAuProducteurTransportSciage BIT=0, @Frais_AutresAuTransporteur FLOAT=Null, @ConsiderNull_Frais_AutresAuTransporteur BIT=0, @Frais_AutresAuTransporteurDescription VARCHAR (50)=Null, @ConsiderNull_Frais_AutresAuTransporteurDescription BIT=0, @Frais_CompensationDeDeplacement FLOAT=Null, @ConsiderNull_Frais_CompensationDeDeplacement BIT=0, @Chargeur_FactureID INT=Null, @ConsiderNull_Chargeur_FactureID BIT=0, @Commentaires_Producteur VARCHAR (500)=Null, @ConsiderNull_Commentaires_Producteur BIT=0, @Commentaires_Transporteur VARCHAR (500)=Null, @ConsiderNull_Commentaires_Transporteur BIT=0, @Commentaires_Chargeur VARCHAR (500)=Null, @ConsiderNull_Commentaires_Chargeur BIT=0, @TauxChargeurAuProducteur FLOAT=Null, @ConsiderNull_TauxChargeurAuProducteur BIT=0, @TauxChargeurAuTransporteur FLOAT=Null, @ConsiderNull_TauxChargeurAuTransporteur BIT=0, @Frais_AutresRevenusTransporteur FLOAT=Null, @ConsiderNull_Frais_AutresRevenusTransporteur BIT=0, @Frais_AutresRevenusTransporteurDescription VARCHAR (50)=Null, @ConsiderNull_Frais_AutresRevenusTransporteurDescription BIT=0, @Frais_AutresRevenusProducteur FLOAT=Null, @ConsiderNull_Frais_AutresRevenusProducteur BIT=0, @Frais_AutresRevenusProducteurDescription VARCHAR (50)=Null, @ConsiderNull_Frais_AutresRevenusProducteurDescription BIT=0, @Montant_SurchargeProducteur FLOAT=Null, @ConsiderNull_Montant_SurchargeProducteur BIT=0, @KgVert_Brut INT=Null, @ConsiderNull_KgVert_Brut BIT=0, @KgVert_Tare INT=Null, @ConsiderNull_KgVert_Tare BIT=0, @KgVert_Net INT=Null, @ConsiderNull_KgVert_Net BIT=0, @KgVert_Rejets INT=Null, @ConsiderNull_KgVert_Rejets BIT=0, @KgVert_Paye INT=Null, @ConsiderNull_KgVert_Paye BIT=0, @Pourcent_Sec_Producteur FLOAT=Null, @ConsiderNull_Pourcent_Sec_Producteur BIT=0, @Pourcent_Sec_Producteur_Override BIT=Null, @ConsiderNull_Pourcent_Sec_Producteur_Override BIT=0, @TMA_Producteur FLOAT=Null, @ConsiderNull_TMA_Producteur BIT=0, @Pourcent_Sec_Transport FLOAT=Null, @ConsiderNull_Pourcent_Sec_Transport BIT=0, @Pourcent_Sec_Transport_Override BIT=Null, @ConsiderNull_Pourcent_Sec_Transport_Override BIT=0, @TMA_Transport FLOAT=Null, @ConsiderNull_TMA_Transport BIT=0, @IsTMA BIT=Null, @ConsiderNull_IsTMA BIT=0, @SuspendrePaiement BIT, @ConsiderNull_SuspendrePaiement BIT=0, @BonCommande VARCHAR (25)=Null, @ConsiderNull_BonCommande BIT=0
AS
Set NoCount On

If @ConsiderNull_DateLivraison Is Null
	Set @ConsiderNull_DateLivraison = 0

If @ConsiderNull_DatePaye Is Null
	Set @ConsiderNull_DatePaye = 0

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_UniteMesureID Is Null
	Set @ConsiderNull_UniteMesureID = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_Sciage Is Null
	Set @ConsiderNull_Sciage = 0

If @ConsiderNull_NumeroFactureUsine Is Null
	Set @ConsiderNull_NumeroFactureUsine = 0

If @ConsiderNull_DroitCoupeID Is Null
	Set @ConsiderNull_DroitCoupeID = 0

If @ConsiderNull_EntentePaiementID Is Null
	Set @ConsiderNull_EntentePaiementID = 0

If @ConsiderNull_TransporteurID Is Null
	Set @ConsiderNull_TransporteurID = 0

If @ConsiderNull_VR Is Null
	Set @ConsiderNull_VR = 0

If @ConsiderNull_MasseLimite Is Null
	Set @ConsiderNull_MasseLimite = 0

If @ConsiderNull_VolumeBrut Is Null
	Set @ConsiderNull_VolumeBrut = 0

If @ConsiderNull_VolumeTare Is Null
	Set @ConsiderNull_VolumeTare = 0

If @ConsiderNull_VolumeTransporte Is Null
	Set @ConsiderNull_VolumeTransporte = 0

If @ConsiderNull_VolumeSurcharge Is Null
	Set @ConsiderNull_VolumeSurcharge = 0

If @ConsiderNull_VolumeAPayer Is Null
	Set @ConsiderNull_VolumeAPayer = 0

If @ConsiderNull_Annee Is Null
	Set @ConsiderNull_Annee = 0

If @ConsiderNull_Periode Is Null
	Set @ConsiderNull_Periode = 0

If @ConsiderNull_DateCalcul Is Null
	Set @ConsiderNull_DateCalcul = 0

If @ConsiderNull_Taux_Transporteur Is Null
	Set @ConsiderNull_Taux_Transporteur = 0

If @ConsiderNull_Montant_Transporteur Is Null
	Set @ConsiderNull_Montant_Transporteur = 0

If @ConsiderNull_Montant_Usine Is Null
	Set @ConsiderNull_Montant_Usine = 0

If @ConsiderNull_Montant_Producteur1 Is Null
	Set @ConsiderNull_Montant_Producteur1 = 0

If @ConsiderNull_Montant_Producteur2 Is Null
	Set @ConsiderNull_Montant_Producteur2 = 0

If @ConsiderNull_Montant_Preleve_Plan_Conjoint Is Null
	Set @ConsiderNull_Montant_Preleve_Plan_Conjoint = 0

If @ConsiderNull_Montant_Preleve_Fond_Roulement Is Null
	Set @ConsiderNull_Montant_Preleve_Fond_Roulement = 0

If @ConsiderNull_Montant_Preleve_Fond_Forestier Is Null
	Set @ConsiderNull_Montant_Preleve_Fond_Forestier = 0

If @ConsiderNull_Montant_Preleve_Divers Is Null
	Set @ConsiderNull_Montant_Preleve_Divers = 0

If @ConsiderNull_Montant_Surcharge Is Null
	Set @ConsiderNull_Montant_Surcharge = 0

If @ConsiderNull_Montant_MiseEnCommun Is Null
	Set @ConsiderNull_Montant_MiseEnCommun = 0

If @ConsiderNull_Facture Is Null
	Set @ConsiderNull_Facture = 0

If @ConsiderNull_Producteur1_FactureID Is Null
	Set @ConsiderNull_Producteur1_FactureID = 0

If @ConsiderNull_Producteur2_FactureID Is Null
	Set @ConsiderNull_Producteur2_FactureID = 0

If @ConsiderNull_Transporteur_FactureID Is Null
	Set @ConsiderNull_Transporteur_FactureID = 0

If @ConsiderNull_Usine_FactureID Is Null
	Set @ConsiderNull_Usine_FactureID = 0

If @ConsiderNull_ErreurCalcul Is Null
	Set @ConsiderNull_ErreurCalcul = 0

If @ConsiderNull_ErreurDescription Is Null
	Set @ConsiderNull_ErreurDescription = 0

If @ConsiderNull_LotID Is Null
	Set @ConsiderNull_LotID = 0

If @ConsiderNull_Taux_Transporteur_Override Is Null
	Set @ConsiderNull_Taux_Transporteur_Override = 0

If @ConsiderNull_PaieTransporteur Is Null
	Set @ConsiderNull_PaieTransporteur = 0

If @ConsiderNull_VolumeSurcharge_Override Is Null
	Set @ConsiderNull_VolumeSurcharge_Override = 0

If @ConsiderNull_SurchargeManuel Is Null
	Set @ConsiderNull_SurchargeManuel = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0

If @ConsiderNull_NombrePermis Is Null
	Set @ConsiderNull_NombrePermis = 0

If @ConsiderNull_ZoneID Is Null
	Set @ConsiderNull_ZoneID = 0

If @ConsiderNull_MunicipaliteID Is Null
	Set @ConsiderNull_MunicipaliteID = 0

If @ConsiderNull_ChargeurID Is Null
	Set @ConsiderNull_ChargeurID = 0

If @ConsiderNull_Montant_Chargeur Is Null
	Set @ConsiderNull_Montant_Chargeur = 0

If @ConsiderNull_Frais_ChargeurAuProducteur Is Null
	Set @ConsiderNull_Frais_ChargeurAuProducteur = 0

If @ConsiderNull_Frais_ChargeurAuTransporteur Is Null
	Set @ConsiderNull_Frais_ChargeurAuTransporteur = 0

If @ConsiderNull_Frais_AutresAuProducteur Is Null
	Set @ConsiderNull_Frais_AutresAuProducteur = 0

If @ConsiderNull_Frais_AutresAuProducteurDescription Is Null
	Set @ConsiderNull_Frais_AutresAuProducteurDescription = 0

If @ConsiderNull_Frais_AutresAuProducteurTransportSciage Is Null
	Set @ConsiderNull_Frais_AutresAuProducteurTransportSciage = 0

If @ConsiderNull_Frais_AutresAuTransporteur Is Null
	Set @ConsiderNull_Frais_AutresAuTransporteur = 0

If @ConsiderNull_Frais_AutresAuTransporteurDescription Is Null
	Set @ConsiderNull_Frais_AutresAuTransporteurDescription = 0

If @ConsiderNull_Frais_CompensationDeDeplacement Is Null
	Set @ConsiderNull_Frais_CompensationDeDeplacement = 0

If @ConsiderNull_Chargeur_FactureID Is Null
	Set @ConsiderNull_Chargeur_FactureID = 0

If @ConsiderNull_Commentaires_Producteur Is Null
	Set @ConsiderNull_Commentaires_Producteur = 0

If @ConsiderNull_Commentaires_Transporteur Is Null
	Set @ConsiderNull_Commentaires_Transporteur = 0

If @ConsiderNull_Commentaires_Chargeur Is Null
	Set @ConsiderNull_Commentaires_Chargeur = 0

If @ConsiderNull_TauxChargeurAuProducteur Is Null
	Set @ConsiderNull_TauxChargeurAuProducteur = 0

If @ConsiderNull_TauxChargeurAuTransporteur Is Null
	Set @ConsiderNull_TauxChargeurAuTransporteur = 0

If @ConsiderNull_Frais_AutresRevenusTransporteur Is Null
	Set @ConsiderNull_Frais_AutresRevenusTransporteur = 0

If @ConsiderNull_Frais_AutresRevenusTransporteurDescription Is Null
	Set @ConsiderNull_Frais_AutresRevenusTransporteurDescription = 0

If @ConsiderNull_Frais_AutresRevenusProducteur Is Null
	Set @ConsiderNull_Frais_AutresRevenusProducteur = 0

If @ConsiderNull_Frais_AutresRevenusProducteurDescription Is Null
	Set @ConsiderNull_Frais_AutresRevenusProducteurDescription = 0

If @ConsiderNull_Montant_SurchargeProducteur Is Null
	Set @ConsiderNull_Montant_SurchargeProducteur = 0

If @ConsiderNull_KgVert_Brut Is Null
	Set @ConsiderNull_KgVert_Brut = 0

If @ConsiderNull_KgVert_Tare Is Null
	Set @ConsiderNull_KgVert_Tare = 0

If @ConsiderNull_KgVert_Net Is Null
	Set @ConsiderNull_KgVert_Net = 0

If @ConsiderNull_KgVert_Rejets Is Null
	Set @ConsiderNull_KgVert_Rejets = 0

If @ConsiderNull_KgVert_Paye Is Null
	Set @ConsiderNull_KgVert_Paye = 0

If @ConsiderNull_Pourcent_Sec_Producteur Is Null
	Set @ConsiderNull_Pourcent_Sec_Producteur = 0

If @ConsiderNull_Pourcent_Sec_Producteur_Override Is Null
	Set @ConsiderNull_Pourcent_Sec_Producteur_Override = 0

If @ConsiderNull_TMA_Producteur Is Null
	Set @ConsiderNull_TMA_Producteur = 0

If @ConsiderNull_Pourcent_Sec_Transport Is Null
	Set @ConsiderNull_Pourcent_Sec_Transport = 0

If @ConsiderNull_Pourcent_Sec_Transport_Override Is Null
	Set @ConsiderNull_Pourcent_Sec_Transport_Override = 0

If @ConsiderNull_TMA_Transport Is Null
	Set @ConsiderNull_TMA_Transport = 0

If @ConsiderNull_IsTMA Is Null
	Set @ConsiderNull_IsTMA = 0

If @ConsiderNull_SuspendrePaiement Is Null
	Set @ConsiderNull_SuspendrePaiement = 0

If @ConsiderNull_BonCommande Is Null
	Set @ConsiderNull_BonCommande = 0


Update [dbo].[Livraison]

Set
	 [DateLivraison] = Case @ConsiderNull_DateLivraison When 0 Then IsNull(@DateLivraison, [DateLivraison]) When 1 Then @DateLivraison End
	,[DatePaye] = Case @ConsiderNull_DatePaye When 0 Then IsNull(@DatePaye, [DatePaye]) When 1 Then @DatePaye End
	,[ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[UniteMesureID] = Case @ConsiderNull_UniteMesureID When 0 Then IsNull(@UniteMesureID, [UniteMesureID]) When 1 Then @UniteMesureID End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[Sciage] = Case @ConsiderNull_Sciage When 0 Then IsNull(@Sciage, [Sciage]) When 1 Then @Sciage End
	,[NumeroFactureUsine] = Case @ConsiderNull_NumeroFactureUsine When 0 Then IsNull(@NumeroFactureUsine, [NumeroFactureUsine]) When 1 Then @NumeroFactureUsine End
	,[DroitCoupeID] = Case @ConsiderNull_DroitCoupeID When 0 Then IsNull(@DroitCoupeID, [DroitCoupeID]) When 1 Then @DroitCoupeID End
	,[EntentePaiementID] = Case @ConsiderNull_EntentePaiementID When 0 Then IsNull(@EntentePaiementID, [EntentePaiementID]) When 1 Then @EntentePaiementID End
	,[TransporteurID] = Case @ConsiderNull_TransporteurID When 0 Then IsNull(@TransporteurID, [TransporteurID]) When 1 Then @TransporteurID End
	,[VR] = Case @ConsiderNull_VR When 0 Then IsNull(@VR, [VR]) When 1 Then @VR End
	,[MasseLimite] = Case @ConsiderNull_MasseLimite When 0 Then IsNull(@MasseLimite, [MasseLimite]) When 1 Then @MasseLimite End
	,[VolumeBrut] = Case @ConsiderNull_VolumeBrut When 0 Then IsNull(@VolumeBrut, [VolumeBrut]) When 1 Then @VolumeBrut End
	,[VolumeTare] = Case @ConsiderNull_VolumeTare When 0 Then IsNull(@VolumeTare, [VolumeTare]) When 1 Then @VolumeTare End
	,[VolumeTransporte] = Case @ConsiderNull_VolumeTransporte When 0 Then IsNull(@VolumeTransporte, [VolumeTransporte]) When 1 Then @VolumeTransporte End
	,[VolumeSurcharge] = Case @ConsiderNull_VolumeSurcharge When 0 Then IsNull(@VolumeSurcharge, [VolumeSurcharge]) When 1 Then @VolumeSurcharge End
	,[VolumeAPayer] = Case @ConsiderNull_VolumeAPayer When 0 Then IsNull(@VolumeAPayer, [VolumeAPayer]) When 1 Then @VolumeAPayer End
	,[Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[Periode] = Case @ConsiderNull_Periode When 0 Then IsNull(@Periode, [Periode]) When 1 Then @Periode End
	,[DateCalcul] = Case @ConsiderNull_DateCalcul When 0 Then IsNull(@DateCalcul, [DateCalcul]) When 1 Then @DateCalcul End
	,[Taux_Transporteur] = Case @ConsiderNull_Taux_Transporteur When 0 Then IsNull(@Taux_Transporteur, [Taux_Transporteur]) When 1 Then @Taux_Transporteur End
	,[Montant_Transporteur] = Case @ConsiderNull_Montant_Transporteur When 0 Then IsNull(@Montant_Transporteur, [Montant_Transporteur]) When 1 Then @Montant_Transporteur End
	,[Montant_Usine] = Case @ConsiderNull_Montant_Usine When 0 Then IsNull(@Montant_Usine, [Montant_Usine]) When 1 Then @Montant_Usine End
	,[Montant_Producteur1] = Case @ConsiderNull_Montant_Producteur1 When 0 Then IsNull(@Montant_Producteur1, [Montant_Producteur1]) When 1 Then @Montant_Producteur1 End
	,[Montant_Producteur2] = Case @ConsiderNull_Montant_Producteur2 When 0 Then IsNull(@Montant_Producteur2, [Montant_Producteur2]) When 1 Then @Montant_Producteur2 End
	,[Montant_Preleve_Plan_Conjoint] = Case @ConsiderNull_Montant_Preleve_Plan_Conjoint When 0 Then IsNull(@Montant_Preleve_Plan_Conjoint, [Montant_Preleve_Plan_Conjoint]) When 1 Then @Montant_Preleve_Plan_Conjoint End
	,[Montant_Preleve_Fond_Roulement] = Case @ConsiderNull_Montant_Preleve_Fond_Roulement When 0 Then IsNull(@Montant_Preleve_Fond_Roulement, [Montant_Preleve_Fond_Roulement]) When 1 Then @Montant_Preleve_Fond_Roulement End
	,[Montant_Preleve_Fond_Forestier] = Case @ConsiderNull_Montant_Preleve_Fond_Forestier When 0 Then IsNull(@Montant_Preleve_Fond_Forestier, [Montant_Preleve_Fond_Forestier]) When 1 Then @Montant_Preleve_Fond_Forestier End
	,[Montant_Preleve_Divers] = Case @ConsiderNull_Montant_Preleve_Divers When 0 Then IsNull(@Montant_Preleve_Divers, [Montant_Preleve_Divers]) When 1 Then @Montant_Preleve_Divers End
	,[Montant_Surcharge] = Case @ConsiderNull_Montant_Surcharge When 0 Then IsNull(@Montant_Surcharge, [Montant_Surcharge]) When 1 Then @Montant_Surcharge End
	,[Montant_MiseEnCommun] = Case @ConsiderNull_Montant_MiseEnCommun When 0 Then IsNull(@Montant_MiseEnCommun, [Montant_MiseEnCommun]) When 1 Then @Montant_MiseEnCommun End
	,[Facture] = Case @ConsiderNull_Facture When 0 Then IsNull(@Facture, [Facture]) When 1 Then @Facture End
	,[Producteur1_FactureID] = Case @ConsiderNull_Producteur1_FactureID When 0 Then IsNull(@Producteur1_FactureID, [Producteur1_FactureID]) When 1 Then @Producteur1_FactureID End
	,[Producteur2_FactureID] = Case @ConsiderNull_Producteur2_FactureID When 0 Then IsNull(@Producteur2_FactureID, [Producteur2_FactureID]) When 1 Then @Producteur2_FactureID End
	,[Transporteur_FactureID] = Case @ConsiderNull_Transporteur_FactureID When 0 Then IsNull(@Transporteur_FactureID, [Transporteur_FactureID]) When 1 Then @Transporteur_FactureID End
	,[Usine_FactureID] = Case @ConsiderNull_Usine_FactureID When 0 Then IsNull(@Usine_FactureID, [Usine_FactureID]) When 1 Then @Usine_FactureID End
	,[ErreurCalcul] = Case @ConsiderNull_ErreurCalcul When 0 Then IsNull(@ErreurCalcul, [ErreurCalcul]) When 1 Then @ErreurCalcul End
	,[ErreurDescription] = Case @ConsiderNull_ErreurDescription When 0 Then IsNull(@ErreurDescription, [ErreurDescription]) When 1 Then @ErreurDescription End
	,[LotID] = Case @ConsiderNull_LotID When 0 Then IsNull(@LotID, [LotID]) When 1 Then @LotID End
	,[Taux_Transporteur_Override] = Case @ConsiderNull_Taux_Transporteur_Override When 0 Then IsNull(@Taux_Transporteur_Override, [Taux_Transporteur_Override]) When 1 Then @Taux_Transporteur_Override End
	,[PaieTransporteur] = Case @ConsiderNull_PaieTransporteur When 0 Then IsNull(@PaieTransporteur, [PaieTransporteur]) When 1 Then @PaieTransporteur End
	,[VolumeSurcharge_Override] = Case @ConsiderNull_VolumeSurcharge_Override When 0 Then IsNull(@VolumeSurcharge_Override, [VolumeSurcharge_Override]) When 1 Then @VolumeSurcharge_Override End
	,[SurchargeManuel] = Case @ConsiderNull_SurchargeManuel When 0 Then IsNull(@SurchargeManuel, [SurchargeManuel]) When 1 Then @SurchargeManuel End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End
	,[NombrePermis] = Case @ConsiderNull_NombrePermis When 0 Then IsNull(@NombrePermis, [NombrePermis]) When 1 Then @NombrePermis End
	,[ZoneID] = Case @ConsiderNull_ZoneID When 0 Then IsNull(@ZoneID, [ZoneID]) When 1 Then @ZoneID End
	,[MunicipaliteID] = Case @ConsiderNull_MunicipaliteID When 0 Then IsNull(@MunicipaliteID, [MunicipaliteID]) When 1 Then @MunicipaliteID End
	,[ChargeurID] = Case @ConsiderNull_ChargeurID When 0 Then IsNull(@ChargeurID, [ChargeurID]) When 1 Then @ChargeurID End
	,[Montant_Chargeur] = Case @ConsiderNull_Montant_Chargeur When 0 Then IsNull(@Montant_Chargeur, [Montant_Chargeur]) When 1 Then @Montant_Chargeur End
	,[Frais_ChargeurAuProducteur] = Case @ConsiderNull_Frais_ChargeurAuProducteur When 0 Then IsNull(@Frais_ChargeurAuProducteur, [Frais_ChargeurAuProducteur]) When 1 Then @Frais_ChargeurAuProducteur End
	,[Frais_ChargeurAuTransporteur] = Case @ConsiderNull_Frais_ChargeurAuTransporteur When 0 Then IsNull(@Frais_ChargeurAuTransporteur, [Frais_ChargeurAuTransporteur]) When 1 Then @Frais_ChargeurAuTransporteur End
	,[Frais_AutresAuProducteur] = Case @ConsiderNull_Frais_AutresAuProducteur When 0 Then IsNull(@Frais_AutresAuProducteur, [Frais_AutresAuProducteur]) When 1 Then @Frais_AutresAuProducteur End
	,[Frais_AutresAuProducteurDescription] = Case @ConsiderNull_Frais_AutresAuProducteurDescription When 0 Then IsNull(@Frais_AutresAuProducteurDescription, [Frais_AutresAuProducteurDescription]) When 1 Then @Frais_AutresAuProducteurDescription End
	,[Frais_AutresAuProducteurTransportSciage] = Case @ConsiderNull_Frais_AutresAuProducteurTransportSciage When 0 Then IsNull(@Frais_AutresAuProducteurTransportSciage, [Frais_AutresAuProducteurTransportSciage]) When 1 Then @Frais_AutresAuProducteurTransportSciage End
	,[Frais_AutresAuTransporteur] = Case @ConsiderNull_Frais_AutresAuTransporteur When 0 Then IsNull(@Frais_AutresAuTransporteur, [Frais_AutresAuTransporteur]) When 1 Then @Frais_AutresAuTransporteur End
	,[Frais_AutresAuTransporteurDescription] = Case @ConsiderNull_Frais_AutresAuTransporteurDescription When 0 Then IsNull(@Frais_AutresAuTransporteurDescription, [Frais_AutresAuTransporteurDescription]) When 1 Then @Frais_AutresAuTransporteurDescription End
	,[Frais_CompensationDeDeplacement] = Case @ConsiderNull_Frais_CompensationDeDeplacement When 0 Then IsNull(@Frais_CompensationDeDeplacement, [Frais_CompensationDeDeplacement]) When 1 Then @Frais_CompensationDeDeplacement End
	,[Chargeur_FactureID] = Case @ConsiderNull_Chargeur_FactureID When 0 Then IsNull(@Chargeur_FactureID, [Chargeur_FactureID]) When 1 Then @Chargeur_FactureID End
	,[Commentaires_Producteur] = Case @ConsiderNull_Commentaires_Producteur When 0 Then IsNull(@Commentaires_Producteur, [Commentaires_Producteur]) When 1 Then @Commentaires_Producteur End
	,[Commentaires_Transporteur] = Case @ConsiderNull_Commentaires_Transporteur When 0 Then IsNull(@Commentaires_Transporteur, [Commentaires_Transporteur]) When 1 Then @Commentaires_Transporteur End
	,[Commentaires_Chargeur] = Case @ConsiderNull_Commentaires_Chargeur When 0 Then IsNull(@Commentaires_Chargeur, [Commentaires_Chargeur]) When 1 Then @Commentaires_Chargeur End
	,[TauxChargeurAuProducteur] = Case @ConsiderNull_TauxChargeurAuProducteur When 0 Then IsNull(@TauxChargeurAuProducteur, [TauxChargeurAuProducteur]) When 1 Then @TauxChargeurAuProducteur End
	,[TauxChargeurAuTransporteur] = Case @ConsiderNull_TauxChargeurAuTransporteur When 0 Then IsNull(@TauxChargeurAuTransporteur, [TauxChargeurAuTransporteur]) When 1 Then @TauxChargeurAuTransporteur End
	,[Frais_AutresRevenusTransporteur] = Case @ConsiderNull_Frais_AutresRevenusTransporteur When 0 Then IsNull(@Frais_AutresRevenusTransporteur, [Frais_AutresRevenusTransporteur]) When 1 Then @Frais_AutresRevenusTransporteur End
	,[Frais_AutresRevenusTransporteurDescription] = Case @ConsiderNull_Frais_AutresRevenusTransporteurDescription When 0 Then IsNull(@Frais_AutresRevenusTransporteurDescription, [Frais_AutresRevenusTransporteurDescription]) When 1 Then @Frais_AutresRevenusTransporteurDescription End
	,[Frais_AutresRevenusProducteur] = Case @ConsiderNull_Frais_AutresRevenusProducteur When 0 Then IsNull(@Frais_AutresRevenusProducteur, [Frais_AutresRevenusProducteur]) When 1 Then @Frais_AutresRevenusProducteur End
	,[Frais_AutresRevenusProducteurDescription] = Case @ConsiderNull_Frais_AutresRevenusProducteurDescription When 0 Then IsNull(@Frais_AutresRevenusProducteurDescription, [Frais_AutresRevenusProducteurDescription]) When 1 Then @Frais_AutresRevenusProducteurDescription End
	,[Montant_SurchargeProducteur] = Case @ConsiderNull_Montant_SurchargeProducteur When 0 Then IsNull(@Montant_SurchargeProducteur, [Montant_SurchargeProducteur]) When 1 Then @Montant_SurchargeProducteur End
	,[KgVert_Brut] = Case @ConsiderNull_KgVert_Brut When 0 Then IsNull(@KgVert_Brut, [KgVert_Brut]) When 1 Then @KgVert_Brut End
	,[KgVert_Tare] = Case @ConsiderNull_KgVert_Tare When 0 Then IsNull(@KgVert_Tare, [KgVert_Tare]) When 1 Then @KgVert_Tare End
	,[KgVert_Net] = Case @ConsiderNull_KgVert_Net When 0 Then IsNull(@KgVert_Net, [KgVert_Net]) When 1 Then @KgVert_Net End
	,[KgVert_Rejets] = Case @ConsiderNull_KgVert_Rejets When 0 Then IsNull(@KgVert_Rejets, [KgVert_Rejets]) When 1 Then @KgVert_Rejets End
	,[KgVert_Paye] = Case @ConsiderNull_KgVert_Paye When 0 Then IsNull(@KgVert_Paye, [KgVert_Paye]) When 1 Then @KgVert_Paye End
	,[Pourcent_Sec_Producteur] = Case @ConsiderNull_Pourcent_Sec_Producteur When 0 Then IsNull(@Pourcent_Sec_Producteur, [Pourcent_Sec_Producteur]) When 1 Then @Pourcent_Sec_Producteur End
	,[Pourcent_Sec_Producteur_Override] = Case @ConsiderNull_Pourcent_Sec_Producteur_Override When 0 Then IsNull(@Pourcent_Sec_Producteur_Override, [Pourcent_Sec_Producteur_Override]) When 1 Then @Pourcent_Sec_Producteur_Override End
	,[TMA_Producteur] = Case @ConsiderNull_TMA_Producteur When 0 Then IsNull(@TMA_Producteur, [TMA_Producteur]) When 1 Then @TMA_Producteur End
	,[Pourcent_Sec_Transport] = Case @ConsiderNull_Pourcent_Sec_Transport When 0 Then IsNull(@Pourcent_Sec_Transport, [Pourcent_Sec_Transport]) When 1 Then @Pourcent_Sec_Transport End
	,[Pourcent_Sec_Transport_Override] = Case @ConsiderNull_Pourcent_Sec_Transport_Override When 0 Then IsNull(@Pourcent_Sec_Transport_Override, [Pourcent_Sec_Transport_Override]) When 1 Then @Pourcent_Sec_Transport_Override End
	,[TMA_Transport] = Case @ConsiderNull_TMA_Transport When 0 Then IsNull(@TMA_Transport, [TMA_Transport]) When 1 Then @TMA_Transport End
	,[IsTMA] = Case @ConsiderNull_IsTMA When 0 Then IsNull(@IsTMA, [IsTMA]) When 1 Then @IsTMA End
	,[SuspendrePaiement] = Case @ConsiderNull_SuspendrePaiement When 0 Then IsNull(@SuspendrePaiement, [SuspendrePaiement]) When 1 Then @SuspendrePaiement End
	,[BonCommande] = Case @ConsiderNull_BonCommande When 0 Then IsNull(@BonCommande, [BonCommande]) When 1 Then @BonCommande End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


