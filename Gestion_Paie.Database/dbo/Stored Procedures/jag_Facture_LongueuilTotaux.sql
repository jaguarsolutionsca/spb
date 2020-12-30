

CREATE PROCEDURE [dbo].[jag_Facture_LongueuilTotaux]
	(
		@FactureID INT
	)
AS

SET NOCOUNT ON

DECLARE @NoLigneTPSPreleve INT
DECLARE @NoLigneTVQPreleve INT
DECLARE @NoLigneTPSProducteur INT
DECLARE @NoLigneTVQProducteur INT
DECLARE @NoLigneTPSTransporteur INT
DECLARE @NoLigneTVQTransporteur INT
DECLARE @NoLigneTPSSurcharge INT
DECLARE @NoLigneTVQSurcharge INT
DECLARE @NoLigneTPSChargeur INT
DECLARE @NoLigneTVQChargeur INT
DECLARE @NoLigneTPSCompensation INT
DECLARE @NoLigneTVQCompensation INT
DECLARE @NoLigneTPSAutresFrais INT
DECLARE @NoLigneTVQAutresFrais INT
DECLARE @NoLigneTPSAutresRevenus INT
DECLARE @NoLigneTVQAutresRevenus INT
DECLARE @NoLigneTPS INT
DECLARE @NoLigneTVQ INT
DECLARE @NoLigneMEC INT
DECLARE @NoLigneMEC2 INT

SET @NoLigneTPSPreleve = 1000
SET @NoLigneTVQPreleve = 1001
SET @NoLigneTPSProducteur = 1002
SET @NoLigneTVQProducteur = 1003
SET @NoLigneTPSTransporteur = 1004
SET @NoLigneTVQTransporteur = 1005
SET @NoLigneTPSSurcharge = 1006
SET @NoLigneTVQSurcharge = 1007
SET @NoLigneTPSChargeur = 1008
SET @NoLigneTVQChargeur = 1009
SET @NoLigneTPSCompensation = 1010
SET @NoLigneTVQCompensation = 1011
SET @NoLigneTPSAutresFrais = 1012
SET @NoLigneTVQAutresFrais = 1013
SET @NoLigneTPSAutresRevenus = 1014
SET @NoLigneTVQAutresRevenus = 1015
SET @NoLigneTPS = 500
SET @NoLigneTVQ = 501
SET @NoLigneMEC = 450
SET @NoLigneMEC2 = 451

DECLARE @Surcharges table
(
	ContratID VARCHAR(10),
	Volume float,
	Taux float,
	Montant float
)

DECLARE @TypeFactureFournisseur CHAR(1)
SELECT @TypeFactureFournisseur = TypeFactureFournisseur FROM FactureFournisseur WHERE [ID] = @FactureID

IF (@TypeFactureFournisseur IS NULL)
BEGIN
	RETURN
END

IF ((@TypeFactureFournisseur <> 'P') AND (@TypeFactureFournisseur <> 'T') AND (@TypeFactureFournisseur <> 'C'))
BEGIN
	RETURN
END

DECLARE @TypeFacture CHAR(1)
SELECT @TypeFacture = TypeFacture FROM FactureFournisseur WHERE [ID] = @FactureID

IF (@TypeFacture <> 'L')
BEGIN
	RETURN
END

DECLARE @Compte_DuAuxProducteurs int
SELECT @Compte_DuAuxProducteurs = Compte_DuAuxProducteurs FROM jag_System

DECLARE @Syndicat_NoTPS VARCHAR(20)
SELECT @Syndicat_NoTPS = [Value] FROM jag_SystemEx WHERE [Name] = 'Syndicat_NoTPS'

DECLARE @Syndicat_NoTVQ VARCHAR(20)
SELECT @Syndicat_NoTVQ = [Value] FROM jag_SystemEx WHERE [Name] = 'Syndicat_NoTVQ'

SELECT
TypeFactureFournisseur,
NoFacture AS [Facture],
DateFacture AS [Date],
DateFactureAcomba,
DatePaiementAcomba,
TF.[Description] + 's' AS [TypeFacture],
FournisseurID,
F.Nom,
F.AuSoinsDe [AS],
F.Rue,
F.Ville,
UPPER(F.Code_Postal) AS [Code_Postal],
Montant_Total AS [Montant],
NumeroCheque,
F.No_TPS,
F.No_TVQ,
@Syndicat_NoTPS AS [Syndicat_No_TPS],
@Syndicat_NoTVQ AS [Syndicat_No_TVQ]
FROM FactureFournisseur FF
	INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
	INNER JOIN TypeFacture TF ON TF.[ID] = FF.TypeFacture
WHERE FF.[ID] = @FactureID

DECLARE @MontantSousTotal FLOAT
DECLARE @MontantPaye FLOAT

DECLARE @MontantChargeur FLOAT
DECLARE @MontantNet FLOAT
DECLARE @MontantTransporteur FLOAT
DECLARE @MontantUsine FLOAT
DECLARE @MontantProducteurBrut FLOAT
DECLARE @MontantTransport FLOAT
DECLARE @MontantPreleve FLOAT
DECLARE @MontantSurcharge FLOAT
DECLARE @MontantTransportSciage FLOAT
DECLARE @MontantFrais FLOAT
DECLARE @Frais_Chargeur FLOAT
DECLARE @Frais_Autres FLOAT
DECLARE @Frais_CompensationDeDeplacement FLOAT
DECLARE @Frais_AutresRevenus FLOAT

DECLARE @TPS FLOAT
DECLARE @TVQ FLOAT
DECLARE @PreleveTPS FLOAT
DECLARE @PreleveTVQ FLOAT
DECLARE @ProducteurTPS FLOAT
DECLARE @ProducteurTVQ FLOAT
DECLARE @SurchargeTPS FLOAT
DECLARE @SurchargeTVQ FLOAT
DECLARE @TransportTPS FLOAT
DECLARE @TransportTVQ FLOAT
DECLARE @TransporteurTPS FLOAT
DECLARE @TransporteurTVQ FLOAT
DECLARE @ChargeurTPS FLOAT
DECLARE @ChargeurTVQ FLOAT
DECLARE @CompensationTPS FLOAT
DECLARE @CompensationTVQ FLOAT
DECLARE @AutresFraisTPS FLOAT
DECLARE @AutresFraisTVQ FLOAT
DECLARE @AutresRevenusTPS FLOAT
DECLARE @AutresRevenusTVQ FLOAT

--PRODUCTEUR
IF (@TypeFactureFournisseur = 'P')
BEGIN
	-----------------------------------------------------------
	---------------------- TOTAUX SCIAGE
	-----------------------------------------------------------
	/*SELECT
	@MontantUsine = ROUND(SUM(LD.Montant_Usine),2),
	@MontantProducteurBrut = ROUND(SUM(LD.Montant_ProducteurBrut),2),
	@MontantTransport = ROUND(SUM(LD.Montant_TransporteurMoyen),2),
	@MontantPreleve = ROUND(SUM(LD.Montant_Preleve_Plan_Conjoint + LD.Montant_Preleve_Fond_Roulement + LD.Montant_Preleve_Fond_Forestier + LD.Montant_Preleve_Divers),2)
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
	WHERE FFD.FactureID = @FactureID
	AND L.Sciage = 1

	SELECT
	@Frais_Chargeur = ROUND(SUM(Frais_ChargeurAuProducteur),2),
	@Frais_Autres = ROUND(SUM(Frais_AutresAuProducteur),2),
	@Frais_CompensationDeDeplacement = ROUND(SUM(Frais_CompensationDeDeplacement),2),
	@Frais_AutresRevenus = ROUND(SUM(Frais_AutresRevenusProducteur),2)
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
	WHERE FFD.FactureID = @FactureID
	AND L.Sciage = 1
*/

	SELECT
	@MontantUsine = ROUND(SUM(LD.Montant_Usine),2),
	@MontantProducteurBrut = ROUND(SUM(LD.Montant_ProducteurBrut),2),
	@MontantTransport = ROUND(SUM(LD.Montant_TransporteurMoyen),2),
	@MontantPreleve = ROUND(SUM(LD.Montant_Preleve_Plan_Conjoint + LD.Montant_Preleve_Fond_Roulement + LD.Montant_Preleve_Fond_Forestier + LD.Montant_Preleve_Divers),2)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]	
		INNER JOIN FactureFournisseur FF on (L.Producteur1_FactureID = FF.[ID] or L.Producteur2_FactureID = FF.[ID])
	WHERE FF.[ID] = @FactureID
	AND L.Sciage = 1

	SELECT
	@Frais_Chargeur = ROUND(SUM(Frais_ChargeurAuProducteur),2),
	@Frais_Autres = ROUND(SUM(Frais_AutresAuProducteur),2),
	@Frais_CompensationDeDeplacement = ROUND(SUM(Frais_CompensationDeDeplacement),2),
	@Frais_AutresRevenus = ROUND(SUM(Frais_AutresRevenusProducteur),2),
	@MontantTransportSciage = ROUND(SUM(Frais_AutresAuProducteurTransportSciage),2)
	FROM Livraison L
		INNER JOIN FactureFournisseur FF on (L.Producteur1_FactureID = FF.[ID] or L.Producteur2_FactureID = FF.[ID])
	WHERE FF.[ID] = @FactureID
	AND L.Sciage = 1

	SET @MontantProducteurBrut = (CASE WHEN @MontantProducteurBrut IS NOT NULL THEN @MontantProducteurBrut ELSE 0 END)
	SET @MontantTransport = (CASE WHEN @MontantTransport IS NOT NULL THEN @MontantTransport ELSE 0 END)
	SET @MontantPreleve = (CASE WHEN @MontantPreleve IS NOT NULL THEN @MontantPreleve ELSE 0 END)
	SET @Frais_Chargeur = (CASE WHEN @Frais_Chargeur IS NOT NULL THEN @Frais_Chargeur ELSE 0 END)
	SET @Frais_Autres = (CASE WHEN @Frais_Autres IS NOT NULL THEN @Frais_Autres ELSE 0 END)
	SET @Frais_CompensationDeDeplacement = (CASE WHEN @Frais_CompensationDeDeplacement IS NOT NULL THEN @Frais_CompensationDeDeplacement ELSE 0 END)
	SET @Frais_AutresRevenus = (CASE WHEN @Frais_AutresRevenus IS NOT NULL THEN @Frais_AutresRevenus ELSE 0 END)
	SET @MontantTransportSciage = (CASE WHEN @MontantTransportSciage IS NOT NULL THEN @MontantTransportSciage ELSE 0 END) 

	SELECT 
	@MontantSurcharge = SUM(dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], LD.ProducteurID))
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]	
		INNER JOIN FactureFournisseur FF on (L.producteur1_factureid = FF.[ID] or L.producteur2_factureid = FF.[ID])
	WHERE FF.[ID] = @FactureID
	AND L.Sciage = 1
	
	SET @MontantSurcharge = (CASE WHEN @MontantSurcharge IS NOT NULL THEN ROUND(@MontantSurcharge,2) ELSE 0 END)
	SET @MontantFrais = ROUND((@MontantTransport + @MontantPreleve + @Frais_Chargeur + @Frais_Autres + @Frais_CompensationDeDeplacement + @MontantSurcharge  + @MontantTransportSciage - @Frais_AutresRevenus),2)
	SET @MontantFrais = (CASE WHEN @MontantFrais IS NOT NULL THEN @MontantFrais ELSE 0 END)

	SET @MontantSousTotal = ROUND(@MontantProducteurBrut - @MontantFrais,2)
	SET @MontantSousTotal = (CASE WHEN @MontantSousTotal IS NOT NULL THEN @MontantSousTotal ELSE 0 END)

	SELECT 
	@MontantProducteurBrut AS [SciageBrut],
	@MontantTransport AS [SciageTransport],
	@MontantTransportSciage as [SciageTransportSciage],
	@MontantSurcharge AS [SciageSurcharge],
	@MontantPreleve AS [SciagePreleves],
	@Frais_Chargeur AS [SciageChargeur],
	@Frais_Autres AS [SciageAutres],
	@Frais_CompensationDeDeplacement AS [SciageCompensation],
	@Frais_AutresRevenus AS [SciageAutresRevenus],
	@MontantProducteurBrut - @MontantFrais AS [SciageNet]

	-----------------------------------------------------------
	------------ TOTAUX ESSENCES
	-----------------------------------------------------------
	SET @MontantProducteurBrut = 0
	SET @MontantTransport = 0
	SET @MontantPreleve = 0
	SET @MontantFrais = 0
	SET @MontantSurcharge = 0
	SET @Frais_Chargeur = 0
	SET @Frais_Autres = 0
	SET @Frais_CompensationDeDeplacement = 0
	SET @Frais_AutresRevenus = 0

/*
	SELECT
	@MontantUsine = ROUND(SUM(LD.Montant_Usine),2),
	@MontantProducteurBrut = ROUND(SUM(LD.Montant_ProducteurBrut),2),
	@MontantTransport = ROUND(SUM(LD.Montant_TransporteurMoyen),2),
	@MontantPreleve = ROUND(SUM(LD.Montant_Preleve_Plan_Conjoint + LD.Montant_Preleve_Fond_Roulement + LD.Montant_Preleve_Fond_Forestier + LD.Montant_Preleve_Divers),2)
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
	WHERE FFD.FactureID = @FactureID
	AND L.Sciage = 0

	SELECT
	@Frais_Chargeur = ROUND(SUM(Frais_ChargeurAuProducteur),2),
	@Frais_Autres = ROUND(SUM(Frais_AutresAuProducteur),2),
	@Frais_CompensationDeDeplacement = ROUND(SUM(Frais_CompensationDeDeplacement),2),
	@Frais_AutresRevenus = ROUND(SUM(Frais_AutresRevenusProducteur),2)
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
	WHERE FFD.FactureID = @FactureID
	AND L.Sciage = 0
*/

	SELECT
	@MontantUsine = ROUND(SUM(LD.Montant_Usine),2),
	@MontantProducteurBrut = ROUND(SUM(LD.Montant_ProducteurBrut),2),
	@MontantTransport = ROUND(SUM(LD.Montant_TransporteurMoyen),2),
	@MontantPreleve = ROUND(SUM(LD.Montant_Preleve_Plan_Conjoint + LD.Montant_Preleve_Fond_Roulement + LD.Montant_Preleve_Fond_Forestier + LD.Montant_Preleve_Divers),2)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]	
		INNER JOIN FactureFournisseur FF on (L.Producteur1_FactureID = FF.[ID] or L.Producteur2_FactureID = FF.[ID])
	WHERE FF.[ID] = @FactureID
	AND L.Sciage = 0

	SELECT
	@Frais_Chargeur = ROUND(SUM(Frais_ChargeurAuProducteur),2),
	@Frais_Autres = ROUND(SUM(Frais_AutresAuProducteur),2),
	@Frais_CompensationDeDeplacement = ROUND(SUM(Frais_CompensationDeDeplacement),2),
	@Frais_AutresRevenus = ROUND(SUM(Frais_AutresRevenusProducteur),2)
	FROM Livraison L
		INNER JOIN FactureFournisseur FF on (L.Producteur1_FactureID = FF.[ID] or L.Producteur2_FactureID = FF.[ID])
	WHERE FF.[ID] = @FactureID
	AND L.Sciage = 0

	SET @MontantProducteurBrut = (CASE WHEN @MontantProducteurBrut IS NOT NULL THEN @MontantProducteurBrut ELSE 0 END)
	SET @MontantTransport = (CASE WHEN @MontantTransport IS NOT NULL THEN @MontantTransport ELSE 0 END)
	SET @MontantPreleve = (CASE WHEN @MontantPreleve IS NOT NULL THEN @MontantPreleve ELSE 0 END)
	SET @Frais_Chargeur = (CASE WHEN @Frais_Chargeur IS NOT NULL THEN @Frais_Chargeur ELSE 0 END)
	SET @Frais_Autres = (CASE WHEN @Frais_Autres IS NOT NULL THEN @Frais_Autres ELSE 0 END)
	SET @Frais_CompensationDeDeplacement = (CASE WHEN @Frais_CompensationDeDeplacement IS NOT NULL THEN @Frais_CompensationDeDeplacement ELSE 0 END)
	SET @Frais_AutresRevenus = (CASE WHEN @Frais_AutresRevenus IS NOT NULL THEN @Frais_AutresRevenus ELSE 0 END)

	/*delete @Surcharges

	insert into @Surcharges (ContratID, Volume, Taux)
	SELECT
	C.[ID],
	SUM(CASE WHEN (L.PaieTransporteur=0) THEN L.VolumeSurcharge ELSE 0 END),
	MAX(C.Taux_Surcharge)
	FROM FactureFournisseur_Details FFD
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
	WHERE FFD.FactureID = @FactureID
	AND L.Sciage = 0
	GROUP BY C.[ID]

	update @Surcharges set Volume = 0 WHERE Volume IS NULL
	update @Surcharges set Taux = 0 WHERE Taux IS NULL
	update @Surcharges set Montant = ROUND((Volume*Taux),2)

	UPDATE @Surcharges SET Montant=0 WHERE Montant IS NULL
	delete @Surcharges where Montant <= 0

	SET @MontantSurcharge = (SELECT SUM(Montant) FROM @Surcharges)*/
	
/*
	SELECT 
	@MontantSurcharge = SUM(dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], LD.ProducteurID))
	FROM FactureFournisseur_Details FFD
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
	WHERE FFD.FactureID = @FactureID
	AND L.Sciage = 0*/

	SELECT 
	@MontantSurcharge = SUM(dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], LD.ProducteurID))
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]	
		INNER JOIN FactureFournisseur FF on (L.producteur1_factureid = FF.[ID] or L.producteur2_factureid = FF.[ID])
	WHERE FF.[ID] = @FactureID
	AND L.Sciage = 0
	
	SET @MontantSurcharge = (CASE WHEN @MontantSurcharge IS NOT NULL THEN ROUND(@MontantSurcharge,2) ELSE 0 END)

	SET @MontantFrais = ROUND((@MontantTransport + @MontantPreleve + @Frais_Chargeur + @Frais_Autres + @Frais_CompensationDeDeplacement + @MontantSurcharge - @Frais_AutresRevenus),2)
	SET @MontantFrais = (CASE WHEN @MontantFrais IS NOT NULL THEN @MontantFrais ELSE 0 END)

	SET @MontantSousTotal = ROUND(@MontantSousTotal + @MontantProducteurBrut - @MontantFrais,2)
	SET @MontantSousTotal = (CASE WHEN @MontantSousTotal IS NOT NULL THEN @MontantSousTotal ELSE 0 END)

	--Totaux ESSENCES
	SELECT 
	@MontantProducteurBrut AS [EssenceBrut],
	@MontantTransport AS [EssenceTransport],
	@MontantSurcharge AS [EssenceSurcharge],
	@MontantPreleve AS [EssencePreleves],
	@Frais_Chargeur AS [EssenceChargeur],
	@Frais_Autres AS [EssenceAutres],
	@Frais_CompensationDeDeplacement AS [EssenceCompensation],
	@Frais_AutresRevenus AS [EssenceAutresRevenus],
	@MontantProducteurBrut - @MontantFrais AS [EssenceNet]




	-----------------------------------------------------------
	---------- TOTAUX
	-----------------------------------------------------------
	SELECT
	@TPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPS

	SET @TPS = (CASE WHEN @TPS IS NOT NULL THEN @TPS ELSE 0 END)

	SELECT
	@TVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQ

	SET @TVQ = (CASE WHEN @TVQ IS NOT NULL THEN @TVQ ELSE 0 END)

	SELECT
	@PreleveTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSPreleve

	SET @PreleveTPS = (CASE WHEN @PreleveTPS IS NOT NULL THEN @PreleveTPS ELSE 0 END)

	SELECT
	@PreleveTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQPreleve

	SET @PreleveTVQ = (CASE WHEN @PreleveTVQ IS NOT NULL THEN @PreleveTVQ ELSE 0 END)

	SELECT
	@ProducteurTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSProducteur

	SET @ProducteurTPS = (CASE WHEN @ProducteurTPS IS NOT NULL THEN @ProducteurTPS ELSE 0 END)

	SELECT
	@ProducteurTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQProducteur

	SET @ProducteurTVQ = (CASE WHEN @ProducteurTVQ IS NOT NULL THEN @ProducteurTVQ ELSE 0 END)

	SELECT
	@TransportTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSTransporteur

	SET @TransportTPS = (CASE WHEN @TransportTPS IS NOT NULL THEN @TransportTPS ELSE 0 END)

	SELECT
	@TransportTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQTransporteur

	SET @TransportTVQ = (CASE WHEN @TransportTVQ IS NOT NULL THEN @TransportTVQ ELSE 0 END)

	SELECT
	@SurchargeTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSSurcharge

	SET @SurchargeTPS = (CASE WHEN @SurchargeTPS IS NOT NULL THEN @SurchargeTPS ELSE 0 END)

	SELECT
	@SurchargeTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQSurcharge

	SET @SurchargeTVQ = (CASE WHEN @SurchargeTVQ IS NOT NULL THEN @SurchargeTVQ ELSE 0 END)

	SELECT
	@ChargeurTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSChargeur

	SET @ChargeurTPS = (CASE WHEN @ChargeurTPS IS NOT NULL THEN @ChargeurTPS ELSE 0 END)

	SELECT
	@ChargeurTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQChargeur

	SET @ChargeurTVQ = (CASE WHEN @ChargeurTVQ IS NOT NULL THEN @ChargeurTVQ ELSE 0 END)

	SELECT
	@CompensationTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSCompensation

	SET @CompensationTPS = (CASE WHEN @CompensationTPS IS NOT NULL THEN @CompensationTPS ELSE 0 END)

	SELECT
	@CompensationTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQCompensation

	SET @CompensationTVQ = (CASE WHEN @CompensationTVQ IS NOT NULL THEN @CompensationTVQ ELSE 0 END)
	
	SELECT
	@AutresFraisTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSAutresFrais

	SET @AutresFraisTPS = (CASE WHEN @AutresFraisTPS IS NOT NULL THEN @AutresFraisTPS ELSE 0 END)

	SELECT
	@AutresFraisTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQAutresFrais

	SET @AutresFraisTVQ = (CASE WHEN @AutresFraisTVQ IS NOT NULL THEN @AutresFraisTVQ ELSE 0 END)

	SELECT
	@AutresRevenusTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSAutresRevenus

	SET @AutresRevenusTPS = (CASE WHEN @AutresRevenusTPS IS NOT NULL THEN @AutresRevenusTPS ELSE 0 END)

	SELECT
	@AutresRevenusTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQAutresRevenus

	SET @AutresRevenusTVQ = (CASE WHEN @AutresRevenusTVQ IS NOT NULL THEN @AutresRevenusTVQ ELSE 0 END)	

	SET @MontantPaye = ROUND(@MontantSousTotal + @TPS + @TVQ,2)

	SELECT 
	@MontantSousTotal AS [MontantSousTotal],
	@ProducteurTPS AS [ProducteurTPS],
	@ProducteurTVQ AS [ProducteurTVQ],
	@SurchargeTPS AS [SurchargeTPS],
	@SurchargeTVQ AS [SurchargeTVQ],
	@PreleveTPS AS [PreleveTPS],
	@PreleveTVQ AS [PreleveTVQ],
	@TransportTPS AS [TransportTPS],
	@TransportTVQ AS [TransportTVQ],
	@ChargeurTPS AS [ChargeurTPS],
	@ChargeurTVQ AS [ChargeurTVQ],
	@CompensationTPS AS [CompensationTPS],
	@CompensationTVQ AS [CompensationTVQ],
	@AutresFraisTPS AS [AutresFraisTPS],
	@AutresFraisTVQ AS [AutresFraisTVQ],
	@AutresRevenusTPS AS [AutresRevenusTPS],
	@AutresRevenusTVQ AS [AutresRevenusTVQ],
	@TPS AS [TPS],
	@TVQ AS [TVQ],
	@MontantPaye AS [MontantPaye]
END
--TRANSPORTEUR
ELSE IF (@TypeFactureFournisseur = 'T')
BEGIN
	-----------------------------------------------------------
	------------ TOTAUX TRANSPORTEUR
	-----------------------------------------------------------
	SET @MontantTransporteur = 0
	SET @MontantNet = 0
	SET @Frais_Chargeur = 0
	SET @Frais_Autres = 0
	SET @Frais_CompensationDeDeplacement = 0
	SET @Frais_AutresRevenus = 0

	SELECT
	@MontantSousTotal = ROUND(SUM(dbo.jag_CalculateMontantTransporteurNet(L.[ID])),2),
	@MontantTransporteur = ROUND(SUM(L.Montant_Transporteur),2),
	@Frais_Chargeur = ROUND(SUM(Frais_ChargeurAuTransporteur),2),
	@Frais_Autres = ROUND(SUM(Frais_AutresAuTransporteur),2),
	@Frais_CompensationDeDeplacement = ROUND(SUM(Frais_CompensationDeDeplacement),2),
	@Frais_AutresRevenus = ROUND(SUM(Frais_AutresRevenusTransporteur),2)
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
	WHERE FFD.FactureID = @FactureID

	SET @MontantTransporteur = (CASE WHEN @MontantTransporteur IS NOT NULL THEN @MontantTransporteur ELSE 0 END)
	SET @Frais_Chargeur = (CASE WHEN @Frais_Chargeur IS NOT NULL THEN @Frais_Chargeur ELSE 0 END)
	SET @Frais_Autres = (CASE WHEN @Frais_Autres IS NOT NULL THEN @Frais_Autres ELSE 0 END)
	SET @Frais_CompensationDeDeplacement = (CASE WHEN @Frais_CompensationDeDeplacement IS NOT NULL THEN @Frais_CompensationDeDeplacement ELSE 0 END)
	SET @Frais_AutresRevenus = (CASE WHEN @Frais_AutresRevenus IS NOT NULL THEN @Frais_AutresRevenus ELSE 0 END)

	--SET @MontantSousTotal = ROUND((@MontantTransporteur - @Frais_Chargeur - @Frais_Autres + @Frais_CompensationDeDeplacement + @Frais_AutresRevenues),2)
	SET @MontantSousTotal = (CASE WHEN @MontantSousTotal IS NOT NULL THEN @MontantSousTotal ELSE 0 END)

	SELECT 
	@MontantTransporteur AS [MontantBrut],
	@Frais_Chargeur AS [FraisChargeur],
	@Frais_Autres AS [FraisAutres],
	@Frais_CompensationDeDeplacement AS [FraisCompensation],
	@Frais_AutresRevenus AS [FraisAutresRevenus],
	@MontantSousTotal AS [MontantNet]


	-----------------------------------------------------------
	---------- TOTAUX
	-----------------------------------------------------------
	SELECT
	@TPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPS

	SET @TPS = (CASE WHEN @TPS IS NOT NULL THEN @TPS ELSE 0 END)

	SELECT
	@TVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQ

	SET @TVQ = (CASE WHEN @TVQ IS NOT NULL THEN @TVQ ELSE 0 END)

	SELECT
	@TransporteurTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSTransporteur

	SET @TransporteurTPS = (CASE WHEN @TransporteurTPS IS NOT NULL THEN @TransporteurTPS ELSE 0 END)

	SELECT
	@TransporteurTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQTransporteur

	SET @TransporteurTVQ = (CASE WHEN @TransporteurTVQ IS NOT NULL THEN @TransporteurTVQ ELSE 0 END)

	SELECT
	@ChargeurTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSChargeur

	SET @ChargeurTPS = (CASE WHEN @ChargeurTPS IS NOT NULL THEN @ChargeurTPS ELSE 0 END)

	SELECT
	@ChargeurTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQChargeur

	SET @ChargeurTVQ = (CASE WHEN @ChargeurTVQ IS NOT NULL THEN @ChargeurTVQ ELSE 0 END)

	SELECT
	@CompensationTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSCompensation

	SET @CompensationTPS = (CASE WHEN @CompensationTPS IS NOT NULL THEN @CompensationTPS ELSE 0 END)

	SELECT
	@CompensationTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQCompensation

	SET @CompensationTVQ = (CASE WHEN @CompensationTVQ IS NOT NULL THEN @CompensationTVQ ELSE 0 END)
	
	SELECT
	@AutresFraisTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSAutresFrais

	SET @AutresFraisTPS = (CASE WHEN @AutresFraisTPS IS NOT NULL THEN @AutresFraisTPS ELSE 0 END)

	SELECT
	@AutresFraisTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQAutresFrais

	SET @AutresFraisTVQ = (CASE WHEN @AutresFraisTVQ IS NOT NULL THEN @AutresFraisTVQ ELSE 0 END)	
	
	SELECT
	@AutresRevenusTPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPSAutresRevenus

	SET @AutresRevenusTPS = (CASE WHEN @AutresRevenusTPS IS NOT NULL THEN @AutresRevenusTPS ELSE 0 END)

	SELECT
	@AutresRevenusTVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQAutresRevenus

	SET @AutresRevenusTVQ = (CASE WHEN @AutresRevenusTVQ IS NOT NULL THEN @AutresRevenusTVQ ELSE 0 END)	

	SET @MontantPaye = @MontantSousTotal + @TPS + @TVQ

	SELECT 
	@MontantSousTotal AS [MontantSousTotal],
	@TransporteurTPS AS [TransporteurTPS],
	@TransporteurTVQ AS [TransporteurTVQ],
	@ChargeurTPS AS [ChargeurTPS],
	@ChargeurTVQ AS [ChargeurTVQ],
	@CompensationTPS AS [CompensationTPS],
	@CompensationTVQ AS [CompensationTVQ],
	@AutresFraisTPS AS [AutresFraisTPS],
	@AutresFraisTVQ AS [AutresFraisTVQ],
	@AutresRevenusTPS AS [AutresRevenusTPS],
	@AutresRevenusTVQ AS [AutresRevenusTVQ],
	@TPS AS [TPS],
	@TVQ AS [TVQ],
	@MontantPaye AS [MontantPaye]
END
-- CHARGEUR
ELSE IF (@TypeFactureFournisseur = 'C')
BEGIN
	-----------------------------------------------------------
	------------ TOTAUX CHARGEUR
	-----------------------------------------------------------
	SET @MontantChargeur = 0

	SELECT
	@MontantChargeur = ROUND(SUM(L.Montant_Chargeur),2)
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
	WHERE FFD.FactureID = @FactureID
	AND FFD.Montant IS NOT NULL
	AND FFD.Montant <> 0

	SET @MontantChargeur = (CASE WHEN @MontantChargeur IS NOT NULL THEN @MontantChargeur ELSE 0 END)

	SELECT 
	@MontantChargeur AS [Montant]

	-----------------------------------------------------------
	---------- TOTAUX
	-----------------------------------------------------------
	SELECT
	@TPS = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTPS

	SET @TPS = (CASE WHEN @TPS IS NOT NULL THEN @TPS ELSE 0 END)

	SELECT
	@TVQ = FFS.Montant
	FROM FactureFournisseur_Sommaire FFS
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
	WHERE FFS.FactureID = @FactureID
	AND Ligne = @NoLigneTVQ

	SET @TVQ = (CASE WHEN @TVQ IS NOT NULL THEN @TVQ ELSE 0 END)

	SET @MontantPaye = ROUND(@MontantChargeur + @TPS + @TVQ,2)

	SELECT 
	@TPS AS [TPS],
	@TVQ AS [TVQ],
	@MontantPaye AS [MontantPaye]
END

