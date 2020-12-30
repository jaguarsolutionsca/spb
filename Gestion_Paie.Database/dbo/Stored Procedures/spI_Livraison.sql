CREATE PROCEDURE [dbo].[spI_Livraison]
@ID INT, @DateLivraison SMALLDATETIME=Null, @DatePaye SMALLDATETIME=Null, @ContratID VARCHAR (10)=Null, @UniteMesureID VARCHAR (6)=Null, @EssenceID VARCHAR (6)=Null, @Sciage BIT=Null, @NumeroFactureUsine VARCHAR (25)=Null, @DroitCoupeID VARCHAR (15)=Null, @EntentePaiementID VARCHAR (15)=Null, @TransporteurID VARCHAR (15)=Null, @VR VARCHAR (10)=Null, @MasseLimite FLOAT=Null, @VolumeBrut FLOAT=Null, @VolumeTare FLOAT=Null, @VolumeTransporte FLOAT=Null, @VolumeSurcharge FLOAT=Null, @VolumeAPayer FLOAT=Null, @Annee INT=Null, @Periode INT=Null, @DateCalcul DATETIME=Null, @Taux_Transporteur FLOAT=Null, @Montant_Transporteur FLOAT=Null, @Montant_Usine FLOAT=Null, @Montant_Producteur1 FLOAT=Null, @Montant_Producteur2 FLOAT=Null, @Montant_Preleve_Plan_Conjoint FLOAT=Null, @Montant_Preleve_Fond_Roulement FLOAT=Null, @Montant_Preleve_Fond_Forestier FLOAT=Null, @Montant_Preleve_Divers FLOAT=Null, @Montant_Surcharge FLOAT=Null, @Montant_MiseEnCommun REAL=Null, @Facture BIT=Null, @Producteur1_FactureID INT=Null, @Producteur2_FactureID INT=Null, @Transporteur_FactureID INT=Null, @Usine_FactureID INT=Null, @ErreurCalcul BIT=Null, @ErreurDescription VARCHAR (4000)=Null, @LotID INT=Null, @Taux_Transporteur_Override BIT=Null, @PaieTransporteur BIT=Null, @VolumeSurcharge_Override BIT=Null, @SurchargeManuel BIT=Null, @Code CHAR (4)=Null, @NombrePermis INT=Null, @ZoneID VARCHAR (2)=Null, @MunicipaliteID VARCHAR (6)=Null, @ChargeurID VARCHAR (15)=Null, @Montant_Chargeur FLOAT=Null, @Frais_ChargeurAuProducteur FLOAT=Null, @Frais_ChargeurAuTransporteur FLOAT=Null, @Frais_AutresAuProducteur FLOAT=Null, @Frais_AutresAuProducteurDescription VARCHAR (50)=Null, @Frais_AutresAuProducteurTransportSciage FLOAT=Null, @Frais_AutresAuTransporteur FLOAT=Null, @Frais_AutresAuTransporteurDescription VARCHAR (50)=Null, @Frais_CompensationDeDeplacement FLOAT=Null, @Chargeur_FactureID INT=Null, @Commentaires_Producteur VARCHAR (500)=Null, @Commentaires_Transporteur VARCHAR (500)=Null, @Commentaires_Chargeur VARCHAR (500)=Null, @TauxChargeurAuProducteur FLOAT=Null, @TauxChargeurAuTransporteur FLOAT=Null, @Frais_AutresRevenusTransporteur FLOAT=Null, @Frais_AutresRevenusTransporteurDescription VARCHAR (50)=Null, @Frais_AutresRevenusProducteur FLOAT=Null, @Frais_AutresRevenusProducteurDescription VARCHAR (50)=Null, @Montant_SurchargeProducteur FLOAT=Null, @KgVert_Brut INT=Null, @KgVert_Tare INT=Null, @KgVert_Net INT=Null, @KgVert_Rejets INT=Null, @KgVert_Paye INT=Null, @Pourcent_Sec_Producteur FLOAT=Null, @Pourcent_Sec_Producteur_Override BIT=Null, @TMA_Producteur FLOAT=Null, @Pourcent_Sec_Transport FLOAT=Null, @Pourcent_Sec_Transport_Override BIT=Null, @TMA_Transport FLOAT=Null, @IsTMA BIT=Null, @SuspendrePaiement BIT=Null, @BonCommande VARCHAR (25)=Null
AS
Set NoCount On

If @SuspendrePaiement Is Null
	Set @SuspendrePaiement = (0)

Insert Into [dbo].[Livraison]
(
	  [ID]
	, [DateLivraison]
	, [DatePaye]
	, [ContratID]
	, [UniteMesureID]
	, [EssenceID]
	, [Sciage]
	, [NumeroFactureUsine]
	, [DroitCoupeID]
	, [EntentePaiementID]
	, [TransporteurID]
	, [VR]
	, [MasseLimite]
	, [VolumeBrut]
	, [VolumeTare]
	, [VolumeTransporte]
	, [VolumeSurcharge]
	, [VolumeAPayer]
	, [Annee]
	, [Periode]
	, [DateCalcul]
	, [Taux_Transporteur]
	, [Montant_Transporteur]
	, [Montant_Usine]
	, [Montant_Producteur1]
	, [Montant_Producteur2]
	, [Montant_Preleve_Plan_Conjoint]
	, [Montant_Preleve_Fond_Roulement]
	, [Montant_Preleve_Fond_Forestier]
	, [Montant_Preleve_Divers]
	, [Montant_Surcharge]
	, [Montant_MiseEnCommun]
	, [Facture]
	, [Producteur1_FactureID]
	, [Producteur2_FactureID]
	, [Transporteur_FactureID]
	, [Usine_FactureID]
	, [ErreurCalcul]
	, [ErreurDescription]
	, [LotID]
	, [Taux_Transporteur_Override]
	, [PaieTransporteur]
	, [VolumeSurcharge_Override]
	, [SurchargeManuel]
	, [Code]
	, [NombrePermis]
	, [ZoneID]
	, [MunicipaliteID]
	, [ChargeurID]
	, [Montant_Chargeur]
	, [Frais_ChargeurAuProducteur]
	, [Frais_ChargeurAuTransporteur]
	, [Frais_AutresAuProducteur]
	, [Frais_AutresAuProducteurDescription]
	, [Frais_AutresAuProducteurTransportSciage]
	, [Frais_AutresAuTransporteur]
	, [Frais_AutresAuTransporteurDescription]
	, [Frais_CompensationDeDeplacement]
	, [Chargeur_FactureID]
	, [Commentaires_Producteur]
	, [Commentaires_Transporteur]
	, [Commentaires_Chargeur]
	, [TauxChargeurAuProducteur]
	, [TauxChargeurAuTransporteur]
	, [Frais_AutresRevenusTransporteur]
	, [Frais_AutresRevenusTransporteurDescription]
	, [Frais_AutresRevenusProducteur]
	, [Frais_AutresRevenusProducteurDescription]
	, [Montant_SurchargeProducteur]
	, [KgVert_Brut]
	, [KgVert_Tare]
	, [KgVert_Net]
	, [KgVert_Rejets]
	, [KgVert_Paye]
	, [Pourcent_Sec_Producteur]
	, [Pourcent_Sec_Producteur_Override]
	, [TMA_Producteur]
	, [Pourcent_Sec_Transport]
	, [Pourcent_Sec_Transport_Override]
	, [TMA_Transport]
	, [IsTMA]
	, [SuspendrePaiement]
	, [BonCommande]
)

Values
(
	  @ID
	, @DateLivraison
	, @DatePaye
	, @ContratID
	, @UniteMesureID
	, @EssenceID
	, @Sciage
	, @NumeroFactureUsine
	, @DroitCoupeID
	, @EntentePaiementID
	, @TransporteurID
	, @VR
	, @MasseLimite
	, @VolumeBrut
	, @VolumeTare
	, @VolumeTransporte
	, @VolumeSurcharge
	, @VolumeAPayer
	, @Annee
	, @Periode
	, @DateCalcul
	, @Taux_Transporteur
	, @Montant_Transporteur
	, @Montant_Usine
	, @Montant_Producteur1
	, @Montant_Producteur2
	, @Montant_Preleve_Plan_Conjoint
	, @Montant_Preleve_Fond_Roulement
	, @Montant_Preleve_Fond_Forestier
	, @Montant_Preleve_Divers
	, @Montant_Surcharge
	, @Montant_MiseEnCommun
	, @Facture
	, @Producteur1_FactureID
	, @Producteur2_FactureID
	, @Transporteur_FactureID
	, @Usine_FactureID
	, @ErreurCalcul
	, @ErreurDescription
	, @LotID
	, @Taux_Transporteur_Override
	, @PaieTransporteur
	, @VolumeSurcharge_Override
	, @SurchargeManuel
	, @Code
	, @NombrePermis
	, @ZoneID
	, @MunicipaliteID
	, @ChargeurID
	, @Montant_Chargeur
	, @Frais_ChargeurAuProducteur
	, @Frais_ChargeurAuTransporteur
	, @Frais_AutresAuProducteur
	, @Frais_AutresAuProducteurDescription
	, @Frais_AutresAuProducteurTransportSciage
	, @Frais_AutresAuTransporteur
	, @Frais_AutresAuTransporteurDescription
	, @Frais_CompensationDeDeplacement
	, @Chargeur_FactureID
	, @Commentaires_Producteur
	, @Commentaires_Transporteur
	, @Commentaires_Chargeur
	, @TauxChargeurAuProducteur
	, @TauxChargeurAuTransporteur
	, @Frais_AutresRevenusTransporteur
	, @Frais_AutresRevenusTransporteurDescription
	, @Frais_AutresRevenusProducteur
	, @Frais_AutresRevenusProducteurDescription
	, @Montant_SurchargeProducteur
	, @KgVert_Brut
	, @KgVert_Tare
	, @KgVert_Net
	, @KgVert_Rejets
	, @KgVert_Paye
	, @Pourcent_Sec_Producteur
	, @Pourcent_Sec_Producteur_Override
	, @TMA_Producteur
	, @Pourcent_Sec_Transport
	, @Pourcent_Sec_Transport_Override
	, @TMA_Transport
	, @IsTMA
	, @SuspendrePaiement
	, @BonCommande
)

Set NoCount Off

Return(0)


