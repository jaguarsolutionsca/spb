CREATE PROCEDURE [dbo].[jag_Facture_LongueuilUsine]
@FactureID INT, @UsineID VARCHAR (6)
AS
SET NOCOUNT ON

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

DECLARE @LivraisonsProducteurSciage table
(
	[ID] INT,
	ProducteurID VARCHAR(15),
	VolumeNet FLOAT,
	MontantProducteurBrut FLOAT,
	MontantTransport FLOAT,
	MontantChargeur FLOAT,
	MontantAutres FLOAT,
	MontantAutresRevenus FLOAT,
	MontantCompensationDeplacement FLOAT,
	MontantSurcharge FLOAT,
	MontantPreleve FLOAT,
	MontantProducteurNet FLOAT
)

DECLARE @LivraisonsTransporteur table
(
	[ID] INT,
	VolumeBrut FLOAT,
	SecMoyen FLOAT,
	VolumeSurcharge FLOAT,
	VolumeNet FLOAT,
	TauxTransporteur FLOAT,
	MontantTransporteurBrut FLOAT,
	MontantChargeur FLOAT,
	MontantAutres FLOAT,
	MontantCompensation FLOAT,
	MontantAutresRevenus FLOAT,
	MontantTransporteurNet FLOAT
)

--PRODUCTEUR
IF (@TypeFactureFournisseur = 'P')
BEGIN
	----------------------------------
	------- LIVRAISON SCIAGE
	----------------------------------
	INSERT INTO @LivraisonsProducteurSciage
	SELECT
	L.[ID] AS [Permis],
	MAX(LD.[ProducteurID]) AS [ProducteurID],
	SUM(LD.VolumeNet) AS [VolumeNet],
	ROUND((SUM(LD.Montant_ProducteurBrut)),2) AS [MontantProducteurBrut],
	ROUND((SUM(LD.Montant_TransporteurMoyen)),2) + MAX(Round(L.Frais_AutresAuProducteurTransportSciage,2)) AS [MontantTransport],
	ROUND((MAX(CASE WHEN (FF.FournisseurID = L.DroitCoupeID) THEN L.Frais_ChargeurAuProducteur ELSE 0 END)),2) AS [MontantChargeur],
	ROUND((MAX(CASE WHEN (FF.FournisseurID = L.DroitCoupeID) THEN L.Frais_AutresAuProducteur ELSE 0 END)),2) AS [MontantAutres],
	ROUND((MAX(CASE WHEN (FF.FournisseurID = L.DroitCoupeID) THEN L.Frais_AutresRevenusProducteur ELSE 0 END)),2) AS [MontantAutresRevenus],
	ROUND((MAX(CASE WHEN (FF.FournisseurID = L.DroitCoupeID) THEN L.Frais_CompensationDeDeplacement ELSE 0 END)),2) AS [MontantCompensationDeplacement],
	ROUND((MAX(CASE WHEN ((FF.FournisseurID = L.DroitCoupeID)AND(L.PaieTransporteur = 0)) THEN L.Montant_Surcharge ELSE 0 END)),2) AS [MontantSurcharge],
	ROUND((SUM(LD.Montant_Preleve_Plan_Conjoint + LD.Montant_Preleve_Fond_Roulement + LD.Montant_Preleve_Fond_Forestier + LD.Montant_Preleve_Divers)),2) AS [MontantPreleve],
	0
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID 
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.[ProducteurID] = FF.FournisseurID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Essence E ON E.[ID] = LD.EssenceID
	WHERE FFD.FactureID = @FactureID
	AND C.UsineID = @UsineID
	AND L.Sciage = 1
	GROUP BY L.[ID]

	UPDATE @LivraisonsProducteurSciage SET MontantProducteurNet = MontantProducteurBrut - MontantTransport - MontantChargeur - MontantAutres - MontantCompensationDeplacement - MontantSurcharge - MontantPreleve + MontantAutresRevenus
	UPDATE @LivraisonsProducteurSciage SET MontantProducteurNet = 0 WHERE MontantProducteurNet IS NULL

	SELECT
	L.DateLivraison AS [Date],
	L.NumeroFactureUsine AS [FactureUsine],
	L.MunicipaliteID,
	LS.[ID] AS [Permis],
	(C.UsineID) AS [Usine],
	(L.UniteMesureID) AS [Unite],
	LS.VolumeNet,
	LS.MontantProducteurBrut,
	LS.MontantTransport,
	LS.MontantChargeur,
	LS.MontantAutres,
	LS.MontantAutresRevenus,
	LS.MontantCompensationDeplacement,
	LS.MontantSurcharge,
	LS.MontantPreleve,
	LS.MontantProducteurNet,
	L.Commentaires_Producteur AS [Commentaires]
	FROM @LivraisonsProducteurSciage LS
		INNER JOIN Livraison L ON L.[ID] = LS.[ID]
		--INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = LS.ProducteurID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	ORDER BY L.DateLivraison DESC, LS.[ID] DESC

	----------------------------------
	------- LIVRAISON ESSENCE
	----------------------------------
	SELECT
	L.DateLivraison AS [Date],
	L.NumeroFactureUsine AS [FactureUsine],
	L.MunicipaliteID,
	L.[ID] AS [Permis],
	L.UniteMesureID AS [Unite],
	E.[Description] + ' ' + LTRIM(RTRIM(LD.Code)) AS [Essence],
	LD.VolumeBrut AS [VolumeBrut],
	LD.VolumeReduction AS [VolumeReduction],
	LD.VolumeNet AS [VolumeNet],
	LD.Taux_Producteur AS [TauxProducteur],
	LD.Montant_ProducteurBrut AS [MontantProducteurBrut],
	LD.Taux_TransporteurMoyen AS [TauxTransport],
	LD.Montant_TransporteurMoyen AS [MontantTransport],
	(ROUND((LD.Taux_Preleve_Plan_Conjoint + LD.Taux_Preleve_Fond_Roulement + LD.Taux_Preleve_Fond_Forestier + LD.Taux_Preleve_Divers),2) /** (CASE WHEN LD.UsePreleveMontant = 1 THEN 100 ELSE 1 END)*/) AS [TauxPreleves],
	ROUND((LD.Montant_Preleve_Plan_Conjoint + LD.Montant_Preleve_Fond_Roulement + LD.Montant_Preleve_Fond_Forestier + LD.Montant_Preleve_Divers),2) AS [MontantPreleves],
--	ROUND((LD.Taux_Usine - LD.Taux_TransporteurMoyen - LD.Taux_Preleve_Plan_Conjoint - LD.Taux_Preleve_Fond_Roulement - LD.Taux_Preleve_Fond_Forestier - LD.Taux_Preleve_Divers),2) AS [TauxProducteurNet],
	ROUND((LD.Taux_Producteur - LD.Taux_TransporteurMoyen - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Plan_Conjoint ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Fond_Roulement ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Fond_Forestier ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Divers ELSE 0 END)),2) AS [TauxProducteurNet],
	LD.Montant_ProducteurNet AS [MontantProducteurNet],
	L.Commentaires_Producteur AS [Commentaires]
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Essence E ON E.[ID] = LD.EssenceID
	WHERE FFD.FactureID = @FactureID
	AND C.UsineID = @UsineID
	AND L.Sciage = 0
	ORDER BY L.DateLivraison DESC, L.[ID] DESC
END
--TRANSPORTEUR
ELSE IF (@TypeFactureFournisseur = 'T')
BEGIN
	INSERT INTO @LivraisonsTransporteur
	SELECT
	L.[ID] AS [Permis],
	L.VolumeTransporte AS [VolumeBrut],
	L.Pourcent_Sec_Transport as [SecMoyen],
	(CASE WHEN (L.PaieTransporteur = 1) THEN L.VolumeSurcharge ELSE 0 END) AS [VolumeSurcharge],
	L.VolumeAPayer AS [VolumeNet],
	(L.Taux_Transporteur) AS [TauxTransporteur],
	(L.Montant_Transporteur) AS [MontantTransporteur],
	L.Frais_ChargeurAuTransporteur AS [MontantChargeur],
	L.Frais_AutresAuTransporteur AS [MontantAutres],
	L.Frais_CompensationDeDeplacement AS [MontantCompensation],
	L.Frais_AutresRevenusTransporteur AS [MontantAutresRevenus],
	0
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	WHERE FFD.FactureID = @FactureID
	AND C.UsineID = @UsineID
	
	UPDATE @LivraisonsTransporteur SET MontantTransporteurNet = MontantTransporteurBrut - MontantChargeur - MontantAutres + MontantCompensation + MontantAutresRevenus
	UPDATE @LivraisonsTransporteur SET MontantTransporteurNet = 0 WHERE MontantTransporteurNet IS NULL

	SELECT
	(L.DateLivraison) AS [Date],
	(L.NumeroFactureUsine) AS [FactureUsine],
	L.[ID] AS [Permis],
	L.UniteMesureID AS [Unite],
	(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE (E.[Description] + ' ' + (case when l.Code is null then '' else LTRIM(RTRIM(L.Code)) end)) END) AS [Essence],
	LT.VolumeBrut AS [VolumeBrut],
	LT.SecMoyen as [SecMoyen],
	LT.VolumeSurcharge AS [VolumeSurcharge],
	LT.VolumeNet AS [VolumeNet],
	LT.TauxTransporteur AS [TauxTransporteur],
	LT.MontantTransporteurBrut AS [MontantTransporteurBrut],
	LT.MontantChargeur AS [MontantChargeur],
	LT.[MontantAutres] AS [MontantAutres],
	LT.[MontantCompensation] AS [MontantCompensation],
	LT.[MontantAutresRevenus] AS [MontantAutresRevenus],
	LT.MontantTransporteurNet AS [MontantTransporteurNet],
	L.Commentaires_Transporteur AS [Commentaires]
	FROM @LivraisonsTransporteur LT
		INNER JOIN Livraison L ON L.[ID] = LT.[ID]
		LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	ORDER BY L.DateLivraison DESC, L.[ID] DESC
END
--CHARGEUR
ELSE IF (@TypeFactureFournisseur = 'C')
BEGIN
	SELECT
	(L.DateLivraison) AS [Date],
	(L.NumeroFactureUsine) AS [FactureUsine],
	L.[ID] AS [Permis],
	L.UniteMesureID AS [Unite],
	(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE (E.[Description] + ' ' + (case when l.Code is null then '' else LTRIM(RTRIM(L.Code)) end)) END) AS [Essence],
	L.Frais_ChargeurAuProducteur AS [MontantParProducteur],
	L.Frais_ChargeurAuTransporteur AS [MontantParTransporteur],
	L.Montant_Chargeur AS [Montant],
	L.Commentaires_Chargeur AS [Commentaires]
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	WHERE FFD.FactureID = @FactureID
	AND C.UsineID = @UsineID
	ORDER BY L.DateLivraison DESC, L.[ID] DESC
END


