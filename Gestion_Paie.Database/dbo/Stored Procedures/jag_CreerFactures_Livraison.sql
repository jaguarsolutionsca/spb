CREATE PROCEDURE [dbo].[jag_CreerFactures_Livraison]
@Periode INT, @Annee INT, @Usines VARCHAR (4000)=NULL, @LivraisonID INT=NULL, @DateFactureAcomba SMALLDATETIME, @DatePaiementAcomba_Cheque SMALLDATETIME, @DatePaiementAcomba_Depot SMALLDATETIME
AS
SET NOCOUNT ON

DECLARE @KeepZeroDetails BIT
SET @KeepZeroDetails = 0

Declare @SuspendrePaiement bit
set @SuspendrePaiement = 0

exec jag_Clear_FactureEnAttente

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

DECLARE @TauxTPS FLOAT
DECLARE @TauxTVQ FLOAT
SELECT TOP 1 @TauxTPS = Taux_TPS, @TauxTVQ = Taux_TVQ FROM jag_System

DECLARE @tUsines TABLE
(
	[ID] varchar(6)	
)

DECLARE @Livraisons TABLE
(
	[ID] int
)

DECLARE @Fournisseurs TABLE
(
	[ID] varchar(15),
	[Nom] varchar(40)
)

DECLARE @Surcharges table
(
	ContratID VARCHAR(10),
	Volume float,
	Taux float,
	Montant float
)

DECLARE @Clients TABLE
(
	[ID] varchar(6),
	[Description] varchar(50)
)

DECLARE @FactureFournisseur TABLE
(
	FournisseurID varchar(15),
	_PayerAID varchar(15),
	DepotDirect bit,
	Montant_Total float,
	[Description] varchar(255),
	Status varchar(15), -- Attente, FactureBAD, FactureOK, PaiementBAD, PaiementOK
	StatusDescription varchar(300)	
)

DECLARE @FactureClient TABLE
(
	ClientID varchar(6),
	PayerAID varchar(6),
	Montant_Total float,
	[Description] varchar(255),
	Status varchar(15), -- Attente, FactureBAD, FactureOK, PaiementBAD, PaiementOK
	StatusDescription varchar(300)	
)

DECLARE @Details TABLE
(
	FactureID int,
	Ligne int,
	Compte int,
	Montant float,
	RefID int, -- LivraisonID, AjustementID ou IndexationID 
	UsineID varchar(6)
)

DECLARE @DetailsTemp TABLE
(
	FactureID int,
	Ligne int,
	Compte int,
	Montant float,
	RefID int, -- LivraisonID, AjustementID ou IndexationID 
	UsineID varchar(6)
)

DECLARE @Sommaires TABLE
(
	FactureID int,
	Ligne int,
	Compte int,
	Montant float,
	[Description] varchar(90),
	isTaxe bit
)

DECLARE @SommairesTemp TABLE
(
	FactureID int,
	Ligne int,
	Compte int,
	Montant float,
	[Description] varchar(90),
	isTaxe bit
)

DECLARE @NoFacture varchar(12)
DECLARE @NoFacture1 varchar(12)
DECLARE @NoFacture2 varchar(12)
DECLARE @NoFacture3 varchar(12)
DECLARE @NoFacture4 varchar(12)

DECLARE @Compte_DuAuxProducteurs int

DECLARE @Compte_TPSPayees int
DECLARE @Compte_TVQPayees int
DECLARE @Compte_TPSPercues int
DECLARE @Compte_TVQPercues int

DECLARE @FactureID int
DECLARE @FactureID1 int
DECLARE @FactureID2 int
DECLARE @FactureID3 int
DECLARE @FactureID4 int
DECLARE @FournisseurID varchar(15)
DECLARE @ClientID varchar(6)

DECLARE @Ligne int
DECLARE @LigneCount int

DECLARE @Montant float
DECLARE @Montant2 float
DECLARE @TPS float
DECLARE @TVQ float
DECLARE @Montant_Usine float
DECLARE @TPS_Usine float
DECLARE @TVQ_Usine float
DECLARE @Montant_Transporteur float
DECLARE @TPS_Transporteur float
DECLARE @TVQ_Transporteur float
DECLARE @Montant_ProducteurBrut float
DECLARE @Montant_ProducteurNet float
DECLARE @TPS_Producteur float
DECLARE @TVQ_Producteur float
DECLARE @Montant_Preleve float
DECLARE @TPS_Preleve float
DECLARE @TVQ_Preleve float
DECLARE @Montant_Chargeur float
DECLARE @TPS_Chargeur float
DECLARE @TVQ_Chargeur float
DECLARE @Montant_Surcharge float
DECLARE @TPS_Surcharge float
DECLARE @TVQ_Surcharge float
DECLARE @TPS_Compensation float
DECLARE @TVQ_Compensation float
DECLARE @TPS_AutresFrais float
DECLARE @TVQ_AutresFrais float
DECLARE @TPS_AutresRevenus float
DECLARE @TVQ_AutresRevenus float
DECLARE @Montant_Preleve1 float
DECLARE @Montant_Preleve2 float
DECLARE @Montant_Preleve3 float
DECLARE @Montant_Preleve4 float
DECLARE @Montant_MEC float

DECLARE @Frais_ChargeurAuTransporteur FLOAT
DECLARE @Frais_AutresAuTransporteur FLOAT
DECLARE @Frais_AutresRevenusTransporteur FLOAT
DECLARE @Frais_AutresRevenusProducteur FLOAT
DECLARE @Frais_CompensationDeDeplacement FLOAT
DECLARE @Frais_ChargeurAuProducteur FLOAT
DECLARE @Frais_AutresAuProducteur FLOAT
DECLARE @Frais_AutresAuProducteurTransportSciage FLOAT

SELECT @NoFacture = MAX(NoFacture) FROM FactureFournisseur-- WHERE Annee = @Annee
SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

SELECT @Compte_DuAuxProducteurs = Compte_DuAuxProducteurs FROM jag_System

SELECT @Compte_TPSPayees = Compte_TPSPayees FROM jag_System
SELECT @Compte_TVQPayees = Compte_TVQPayees FROM jag_System
SELECT @Compte_TPSPercues = Compte_TPSPercues FROM jag_System
SELECT @Compte_TVQPercues = Compte_TVQPercues FROM jag_System

IF (@Usines IS NOT NULL)
BEGIN
	INSERT INTO @tUsines ([ID])
	select * from Split(@Usines,';')

	DECLARE @CurrentUsine varchar(6)
	
	DECLARE cursUsine CURSOR FOR
		SELECT [ID] FROM @tUsines
	
	OPEN cursUsine
	
	FETCH NEXT FROM cursUsine INTO @CurrentUsine
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO @Livraisons
		SELECT [ID] FROM dbo.jag_GetLivraisonsNonFacturees (@Periode, @Annee, @CurrentUsine, @LivraisonID, @SuspendrePaiement)
	
		FETCH NEXT FROM cursUsine INTO @CurrentUsine
	END
	
	-- Deallocate resources
	CLOSE cursUsine
	DEALLOCATE cursUsine
END
ELSE
BEGIN
	INSERT INTO @Livraisons
	SELECT [ID] FROM dbo.jag_GetLivraisonsNonFacturees (@Periode, @Annee, NULL, @LivraisonID, @SuspendrePaiement)
END

IF NOT EXISTS (SELECT * FROM @Livraisons)
BEGIN
	RETURN
END

exec jag_Calculate_LivraisonsNonFacturees @Periode, @Annee, @Usines, @LivraisonID, @SuspendrePaiement

-------------------------------------------------------
-------------- CHARGEURS ------------------------------
-------------------------------------------------------

DELETE @FactureFournisseur
DELETE @Details
DELETE @DetailsTemp
DELETE @Sommaires
DELETE @SommairesTemp
DELETE @Fournisseurs

INSERT INTO @Fournisseurs ([ID], [Nom])
SELECT DISTINCT
ChargeurID,
T.[Nom]
FROM Livraison
	INNER JOIN Fournisseur T ON T.ID = Livraison.ChargeurID
WHERE Livraison.[ID] in (SELECT [ID] FROM @Livraisons)
AND ChargeurID IS NOT NULL
AND (((Frais_ChargeurAuProducteur IS NOT NULL) AND (Frais_ChargeurAuProducteur <> 0))
OR ((Frais_ChargeurAuTransporteur IS NOT NULL) AND (Frais_ChargeurAuTransporteur <> 0)))
ORDER BY T.[Nom]

DECLARE cursFournisseurs CURSOR FOR
	select [ID] from @Fournisseurs ORDER BY [Nom]

OPEN cursFournisseurs

FETCH NEXT FROM cursFournisseurs INTO @FournisseurID

WHILE @@FETCH_STATUS = 0
BEGIN
	DELETE @FactureFournisseur
	DELETE @Details
	DELETE @DetailsTemp
	DELETE @Sommaires
	DELETE @SommairesTemp

	SET @Montant = 0
	SET @TPS = 0
	SET @TVQ = 0

	SELECT DISTINCT
	@Montant = ROUND(SUM(dbo.jag_CalculateMontantChargeurNet(L.[ID])),2)
	FROM Livraison L
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND ChargeurID = @FournisseurID

	SET @Montant = (CASE WHEN @Montant IS NOT NULL THEN @Montant ELSE 0 END)
	

	IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND RecoitTPS = 1 AND No_TPS IS NOT NULL)
	BEGIN
		SET @TPS = ROUND((@Montant * @TauxTPS),2)
		SET @TPS = (CASE WHEN @TPS IS NOT NULL THEN @TPS ELSE 0 END)
	END
	
	IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND RecoitTVQ = 1 AND No_TVQ IS NOT NULL)
	BEGIN
		SET @TVQ = ROUND((@Montant * @TauxTVQ),2)
		SET @TVQ = (CASE WHEN @TVQ IS NOT NULL THEN @TVQ ELSE 0 END)
	END

	IF (@Montant < 0)
	BEGIN
		UPDATE Fournisseur SET PaiementManuel = 1 WHERE [ID] = @FournisseurID
	END
	
	INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
	SELECT 
	@FournisseurID, 
	(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurID END),
	'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Chargeur]',
	'Attente'
	FROM Fournisseur F 
	WHERE F.[ID] = @FournisseurID
	
	update @FactureFournisseur 	set DepotDirect = (select DepotDirect from Fournisseur where ID = _PayerAID)

	INSERT INTO FactureFournisseur (NoFacture, DateFacture, DateFactureAcomba, DatePaiementAcomba, Annee, TypeFactureFournisseur, TypeFacture, TypeInvoiceAcomba, FournisseurID, PayerAID, Montant_Total, [Description], Status)
	SELECT 
	@NoFacture,
	GetDate(),
	@DateFactureAcomba,
	(Case when f.DepotDirect = 1 then @DatePaiementAcomba_Depot else @DatePaiementAcomba_Cheque end),
	@Annee,
	'C',
	'L',
	NULL,
	F.FournisseurID,
	F._PayerAID,
	NULL,
	F.[Description],
	F.Status
	FROM @FactureFournisseur F

	SELECT @FactureID = @@IDENTITY
	
	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID)
	SELECT
	@FactureID,
	MAX(U.Compte_chargeur),
	ROUND(SUM(L.Montant_Chargeur),2),
	L.[ID],
	MAX(C.UsineID)
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.ChargeurID = @FournisseurID
	GROUP BY L.ChargeurID, L.[ID]
	
	UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Details WHERE Montant = 0
	END

	DELETE @DetailsTemp
	INSERT INTO @DetailsTemp
	SELECT * FROM @Details ORDER BY Compte

	DELETE @Details

	INSERT INTO @Details
	SELECT * FROM @DetailsTemp ORDER BY Compte

	UPDATE Livraison SET
	Chargeur_FactureID = @FactureID
	WHERE [ID] in (SELECT [ID] FROM @Livraisons)
	AND ChargeurID = @FournisseurID

	SET @Ligne = NULL
	SET @LigneCount = 1

	DECLARE cursDetails CURSOR FOR
	SELECT Ligne
	FROM @Details
	where Ligne IS NULL
	for update of Ligne

	OPEN cursDetails

	FETCH NEXT FROM cursDetails INTO @Ligne

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE @Details
		SET Ligne = @LigneCount
		WHERE CURRENT OF cursDetails
		
		select @LigneCount = @LigneCount + 1
		
		FETCH NEXT FROM cursDetails INTO @Ligne
	END
	
	CLOSE cursDetails
	DEALLOCATE cursDetails

	INSERT INTO FactureFournisseur_Details (FactureID, Ligne, Compte, Montant, RefID)
	SELECT 
	FactureID,
	Ligne,
	Compte,
	Montant,
	RefID
	FROM @Details

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode),
	0
	FROM @Details D
	GROUP BY Compte

	UPDATE @Sommaires SET Montant = 0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Sommaires WHERE Montant = 0
	END
	
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp ORDER BY Compte

	SET @LigneCount = 1

	DECLARE cursSommaires CURSOR FOR
	SELECT Ligne
	FROM @Sommaires
	where Ligne IS NULL
	for update of Ligne

	OPEN cursSommaires

	FETCH NEXT FROM cursSommaires INTO @Ligne

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE @Sommaires
		SET Ligne = @LigneCount
		WHERE CURRENT OF cursSommaires
		
		select @LigneCount = @LigneCount + 1
		
		FETCH NEXT FROM cursSommaires INTO @Ligne
	END

	CLOSE cursSommaires
	DEALLOCATE cursSommaires

	IF ((@TPS IS NOT NULL) AND (@TPS <> 0))
	BEGIN
		INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
		SELECT
		@FactureID,
		@NoLigneTPS,
		@Compte_TPSPayees,
		@TPS,
		'TPS',
		1
	END
	ELSE
	BEGIN
		SET @TPS = 0
	END
	
	IF ((@TVQ IS NOT NULL) AND (@TVQ <> 0))
	BEGIN
		INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
		SELECT
		@FactureID,
		@NoLigneTVQ,
		@Compte_TVQPayees,
		@TVQ,
		'TVQ',
		1
	END
	ELSE
	BEGIN
		SET @TVQ = 0
	END

	INSERT INTO FactureFournisseur_Sommaire (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	FactureID,
	Ligne,
	Compte,
	Montant,
	[Description],
	isTaxe
	FROM @Sommaires
	ORDER BY Ligne

	UPDATE FactureFournisseur SET
	Montant_Total 	= ROUND((@Montant + @TPS + @TVQ),2),
	Montant_TPS 	= ROUND(@TPS, 2),
	Montant_TVQ	= ROUND(@TVQ, 2)		
	WHERE [ID] = @FactureID

	UPDATE FactureFournisseur SET
	TypeInvoiceAcomba = (CASE WHEN Montant_Total >= 0 THEN 2 ELSE 1 END)
	WHERE [ID] = @FactureID
	
	SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

	FETCH NEXT FROM cursFournisseurs INTO @FournisseurID
END

-- Deallocate resources
CLOSE cursFournisseurs
DEALLOCATE cursFournisseurs

-------------------------------------------------------
------------ TRANSPORTEURS ------------------------------
-------------------------------------------------------

DELETE @FactureFournisseur
DELETE @Details
DELETE @DetailsTemp
DELETE @Sommaires
DELETE @SommairesTemp
DELETE @Fournisseurs

INSERT INTO @Fournisseurs ([ID], [Nom])
SELECT DISTINCT
TransporteurID,
T.[Nom]
FROM Livraison
	INNER JOIN Fournisseur T ON T.ID = Livraison.TransporteurID
WHERE Livraison.[ID] in (SELECT [ID] FROM @Livraisons)
AND TransporteurID IS NOT NULL
--AND ((Montant_Transporteur IS NOT NULL) AND (Montant_Transporteur <> 0))
ORDER BY T.[Nom]

DECLARE cursFournisseurs CURSOR FOR
	select [ID] from @Fournisseurs ORDER BY [Nom]

OPEN cursFournisseurs

FETCH NEXT FROM cursFournisseurs INTO @FournisseurID

WHILE @@FETCH_STATUS = 0
BEGIN
	DELETE @FactureFournisseur
	DELETE @Details
	DELETE @DetailsTemp
	DELETE @Sommaires
	DELETE @SommairesTemp

	SET @Montant_Transporteur = 0
	SET @Frais_ChargeurAuTransporteur = 0
	SET @Frais_AutresAuTransporteur = 0
	SET @Frais_AutresRevenusTransporteur = 0
	SET @Frais_AutresRevenusProducteur = 0
	SET @Frais_CompensationDeDeplacement = 0
	SET @Montant = 0
	SET @TPS = 0
	SET @TVQ = 0
	SET @TPS_Chargeur = 0
	SET @TVQ_Chargeur = 0
	SET @TPS_Transporteur = 0
	SET @TVQ_Transporteur = 0
	SET @TPS_AutresFrais = 0
	SET @TVQ_AutresFrais = 0
	SET @TPS_Compensation = 0
	SET @TVQ_Compensation = 0
	SET @TPS_AutresRevenus = 0
	SET @TVQ_AutresRevenus = 0

	SELECT DISTINCT
	@Montant = ROUND(SUM(dbo.jag_CalculateMontantTransporteurNet(L.[ID])),2),
	@Montant_Transporteur = ROUND(SUM(Montant_Transporteur),2),
	@Frais_ChargeurAuTransporteur = ROUND(SUM(Frais_ChargeurAuTransporteur),2),
	@Frais_AutresAuTransporteur = ROUND(SUM(Frais_AutresAuTransporteur),2),
	@Frais_AutresRevenusTransporteur = ROUND(SUM(Frais_AutresRevenusTransporteur),2),
	@Frais_CompensationDeDeplacement = ROUND(SUM(Frais_CompensationDeDeplacement),2)
	FROM Livraison L
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND TransporteurID = @FournisseurID

	SET @Montant = (CASE WHEN @Montant IS NOT NULL THEN @Montant ELSE 0 END)
	SET @Montant_Transporteur = (CASE WHEN @Montant_Transporteur IS NOT NULL THEN @Montant_Transporteur ELSE 0 END)
	SET @Frais_ChargeurAuTransporteur = (CASE WHEN @Frais_ChargeurAuTransporteur IS NOT NULL THEN @Frais_ChargeurAuTransporteur ELSE 0 END)
	SET @Frais_AutresAuTransporteur = (CASE WHEN @Frais_AutresAuTransporteur IS NOT NULL THEN @Frais_AutresAuTransporteur ELSE 0 END)
	SET @Frais_AutresRevenusTransporteur = (CASE WHEN @Frais_AutresRevenusTransporteur IS NOT NULL THEN @Frais_AutresRevenusTransporteur ELSE 0 END)
	SET @Frais_CompensationDeDeplacement = (CASE WHEN @Frais_CompensationDeDeplacement IS NOT NULL THEN @Frais_CompensationDeDeplacement ELSE 0 END)

	SET @TPS_Chargeur = ROUND((@Frais_ChargeurAuTransporteur * @TauxTPS),2)
	SET @TVQ_Chargeur = ROUND((@Frais_ChargeurAuTransporteur * @TauxTVQ),2)
	SET @TPS_Chargeur = (CASE WHEN @TPS_Chargeur IS NOT NULL THEN @TPS_Chargeur ELSE 0 END)
	SET @TVQ_Chargeur = (CASE WHEN @TVQ_Chargeur IS NOT NULL THEN @TVQ_Chargeur ELSE 0 END)
	
	SET @TPS_AutresFrais = ROUND((@Frais_AutresAuTransporteur * @TauxTPS),2)
	SET @TVQ_AutresFrais = ROUND((@Frais_AutresAuTransporteur * @TauxTVQ),2)

	IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND RecoitTPS = 1 AND No_TPS IS NOT NULL)
	BEGIN
		SET @TPS_Transporteur = ROUND((@Montant_Transporteur * @TauxTPS),2)
		SET @TPS_Transporteur = (CASE WHEN @TPS_Transporteur IS NOT NULL THEN @TPS_Transporteur ELSE 0 END)
	
		SET @TPS_Compensation = ROUND((@Frais_CompensationDeDeplacement * @TauxTPS),2)
		SET @TPS_Compensation = (CASE WHEN @TPS_Compensation IS NOT NULL THEN @TPS_Compensation ELSE 0 END)

		SET @TPS_AutresRevenus = ROUND((@Frais_AutresRevenusTransporteur * @TauxTPS),2)
		SET @TPS_AutresRevenus = (CASE WHEN @TPS_AutresRevenus IS NOT NULL THEN @TPS_AutresRevenus ELSE 0 END)
	END
	
	IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND RecoitTVQ = 1 AND No_TVQ IS NOT NULL)
	BEGIN
		SET @TVQ_Transporteur = ROUND((@Montant_Transporteur * @TauxTVQ),2)
		SET @TVQ_Transporteur = (CASE WHEN @TVQ_Transporteur IS NOT NULL THEN @TVQ_Transporteur ELSE 0 END)

		SET @TVQ_Compensation = ROUND((@Frais_CompensationDeDeplacement * @TauxTVQ),2)
		SET @TVQ_Compensation = (CASE WHEN @TVQ_Compensation IS NOT NULL THEN @TVQ_Compensation ELSE 0 END)
		
		SET @TVQ_AutresRevenus = ROUND((@Frais_AutresRevenusTransporteur * @TauxTVQ),2)
		SET @TVQ_AutresRevenus = (CASE WHEN @TVQ_AutresRevenus IS NOT NULL THEN @TVQ_AutresRevenus ELSE 0 END)
	END
	
	SET @TPS = ROUND(@TPS_Transporteur - @TPS_Chargeur - @TPS_AutresFrais + @TPS_Compensation + @TPS_AutresRevenus,2)
	SET @TVQ = ROUND(@TVQ_Transporteur - @TVQ_Chargeur - @TVQ_AutresFrais + @TVQ_Compensation + @TVQ_AutresRevenus,2)
	
	SET @TPS = (CASE WHEN @TPS IS NOT NULL THEN @TPS ELSE 0 END)
	SET @TVQ = (CASE WHEN @TVQ IS NOT NULL THEN @TVQ ELSE 0 END)

	IF (@Montant < 0)
	BEGIN
		UPDATE Fournisseur SET PaiementManuel = 1 WHERE [ID] = @FournisseurID
	END
	
	INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
	SELECT 
	@FournisseurID, 
	(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurID END),
	'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Transporteur]',
	'Attente'
	FROM Fournisseur F 
	WHERE F.[ID] = @FournisseurID
	
	update @FactureFournisseur 	set DepotDirect = (select DepotDirect from Fournisseur where ID = _PayerAID)

	INSERT INTO FactureFournisseur (NoFacture, DateFacture, DateFactureAcomba, DatePaiementAcomba, Annee, TypeFactureFournisseur, TypeFacture, TypeInvoiceAcomba, FournisseurID, PayerAID, Montant_Total, [Description], Status)
	SELECT 
	@NoFacture,
	GetDate(),
	@DateFactureAcomba,
	(case when F.DepotDirect = 1 then @DatePaiementAcomba_Depot else @DatePaiementAcomba_Cheque end),
	@Annee,
	'T',
	'L',
	NULL,
	F.FournisseurID,
	F._PayerAID,
	NULL,
	F.[Description],
	F.Status
	FROM @FactureFournisseur F

	SELECT @FactureID = @@IDENTITY
	
	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID)
	SELECT
	@FactureID,
	MAX(U.Compte_transporteur),
	ROUND(SUM(L.Montant_Transporteur),2),
	L.[ID],
	MAX(C.UsineID)
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.TransporteurID = @FournisseurID
	--AND Montant_Transporteur IS NOT NULL
	--AND Montant_Transporteur <> 0
	GROUP BY L.TransporteurID, L.[ID]
		
	UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
	--NE PAS EFFACER LES LIGNES A ZERO EN CAS QUE LE TRANSPORTEUR RECOIT SEULEMENT DE LA COMPENSATION
	--DELETE @Details WHERE Montant = 0
	
	DELETE @DetailsTemp
	INSERT INTO @DetailsTemp
	SELECT * FROM @Details ORDER BY Compte

	DELETE @Details

	INSERT INTO @Details
	SELECT * FROM @DetailsTemp ORDER BY Compte

	UPDATE Livraison SET
	Transporteur_FactureID = @FactureID
	WHERE [ID] in (SELECT [ID] FROM @Livraisons)
	AND TransporteurID = @FournisseurID

	SET @Ligne = NULL
	SET @LigneCount = 1

	DECLARE cursDetails CURSOR FOR
	SELECT Ligne
	FROM @Details
	where Ligne IS NULL
	for update of Ligne

	OPEN cursDetails

	FETCH NEXT FROM cursDetails INTO @Ligne

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE @Details
		SET Ligne = @LigneCount
		WHERE CURRENT OF cursDetails
		
		select @LigneCount = @LigneCount + 1
		
		FETCH NEXT FROM cursDetails INTO @Ligne
	END
	
	CLOSE cursDetails
	DEALLOCATE cursDetails

	INSERT INTO FactureFournisseur_Details (FactureID, Ligne, Compte, Montant, RefID)
	SELECT 
	FactureID,
	Ligne,
	Compte,
	Montant,
	RefID
	FROM @Details

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode),
	0
	FROM @Details D
	GROUP BY Compte

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_transporteur),
	ROUND(SUM(L.Frais_CompensationDeDeplacement),2),
	'Compensation de déplacement',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.TransporteurID = @FournisseurID
	GROUP BY L.TransporteurID, L.[ID]
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_transporteur),
	ROUND(SUM(L.Frais_AutresRevenusTransporteur),2),
	'Autres revenus',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.TransporteurID = @FournisseurID
	GROUP BY L.TransporteurID, L.[ID]
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_transporteur),
	ROUND(SUM(-1*L.Frais_ChargeurAuTransporteur),2),
	'Frais de chargement',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.TransporteurID = @FournisseurID
	GROUP BY L.TransporteurID, L.[ID]
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_transporteur),
	ROUND(SUM(-1*L.Frais_AutresAuTransporteur),2),
	'Autres frais',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.TransporteurID = @FournisseurID
	GROUP BY L.TransporteurID, L.[ID]

	UPDATE @Sommaires SET Montant = 0 WHERE Montant IS NULL
	--ON PEUT EFFACER LES LIGNES DE SOMMAIRES À ZERO
	--NE PAS EFFACER LES LIGNES A ZERO EN CAS QUE LE TRANSPORTEUR RECOIT SEULEMENT DE LA COMPENSATION
	--DELETE @Sommaires WHERE Montant = 0
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Sommaires WHERE Montant = 0
	END

	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp ORDER BY Compte

	SET @LigneCount = 1

	DECLARE cursSommaires CURSOR FOR
	SELECT Ligne
	FROM @Sommaires
	where Ligne IS NULL
	for update of Ligne

	OPEN cursSommaires

	FETCH NEXT FROM cursSommaires INTO @Ligne

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE @Sommaires
		SET Ligne = @LigneCount
		WHERE CURRENT OF cursSommaires
		
		select @LigneCount = @LigneCount + 1
		
		FETCH NEXT FROM cursSommaires INTO @Ligne
	END

	CLOSE cursSommaires
	DEALLOCATE cursSommaires

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSTransporteur, @TPS_Transporteur, 'Transporteur TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQTransporteur, @TVQ_Transporteur, 'Transporteur TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSChargeur, @TPS_Chargeur, 'Chargeur TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQChargeur, @TVQ_Chargeur, 'Chargeur TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSAutresFrais, @TPS_AutresFrais, 'Autres Frais TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQAutresFrais, @TVQ_AutresFrais, 'Autres Frais TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSCompensation, @TPS_Compensation, 'Compensation TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQCompensation, @TVQ_Compensation, 'Compensation TVQ'

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSAutresRevenus, @TPS_AutresRevenus, 'Autres Revenus TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQAutresRevenus, @TVQ_AutresRevenus, 'Autres Revenus TVQ'	

	IF ((@TPS IS NOT NULL) AND (@TPS <> 0))
	BEGIN
		INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
		SELECT
		@FactureID,
		@NoLigneTPS,
		@Compte_TPSPayees,
		@TPS,
		'TPS',
		1
	END
	ELSE
	BEGIN
		SET @TPS = 0
	END
	
	IF ((@TVQ IS NOT NULL) AND (@TVQ <> 0))
	BEGIN
		INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
		SELECT
		@FactureID,
		@NoLigneTVQ,
		@Compte_TVQPayees,
		@TVQ,
		'TVQ',
		1
	END
	ELSE
	BEGIN
		SET @TVQ = 0
	END

	INSERT INTO FactureFournisseur_Sommaire (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	FactureID,
	Ligne,
	Compte,
	Montant,
	[Description],
	isTaxe
	FROM @Sommaires
	ORDER BY Ligne

	UPDATE FactureFournisseur SET
	Montant_Total 	= ROUND((@Montant + @TPS + @TVQ),2),
	Montant_TPS 	= ROUND(@TPS, 2),
	Montant_TVQ	= ROUND(@TVQ, 2)		
	WHERE [ID] = @FactureID

	UPDATE FactureFournisseur SET
	TypeInvoiceAcomba = (CASE WHEN Montant_Total >= 0 THEN 2 ELSE 1 END)
	WHERE [ID] = @FactureID
	
	SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

	FETCH NEXT FROM cursFournisseurs INTO @FournisseurID
END

-- Deallocate resources
CLOSE cursFournisseurs
DEALLOCATE cursFournisseurs

-------------------------------------------------------
------------ PRODUCTEURS ------------------------------
-------------------------------------------------------

DELETE @FactureFournisseur
DELETE @Details
DELETE @DetailsTemp
DELETE @Sommaires
DELETE @SommairesTemp
DELETE @Fournisseurs

INSERT INTO @Fournisseurs ([ID], [Nom])
SELECT DISTINCT
ProducteurID,
P.[Nom]
FROM Livraison_Detail
	INNER JOIN Fournisseur P ON P.ID = Livraison_Detail.ProducteurID
WHERE Livraison_Detail.[LivraisonID] in (SELECT [ID] FROM @Livraisons)
ORDER BY P.[Nom]

DECLARE cursFournisseurs CURSOR FOR
	select [ID] from @Fournisseurs ORDER BY [Nom]

OPEN cursFournisseurs

FETCH NEXT FROM cursFournisseurs INTO @FournisseurID

WHILE @@FETCH_STATUS = 0
BEGIN
	DELETE @FactureFournisseur
	DELETE @Details
	DELETE @DetailsTemp
	DELETE @Sommaires
	DELETE @SommairesTemp

	SET @Montant_Usine = NULL
	SET @Montant_Transporteur = NULL
	SET @Montant_Preleve = NULL
	SET @Montant_Preleve1 = NULL
	SET @Montant_Preleve2 = NULL
	SET @Montant_Preleve3 = NULL
	SET @Montant_Preleve4 = NULL
	SET @Montant = NULL
	SET @Montant2 = NULL
	SET @Montant_Surcharge = NULL
	SET @TPS_Producteur = 0
	SET @TVQ_Producteur = 0
	SET @TPS_Preleve = 0
	SET @TVQ_Preleve = 0
	SET @TPS_Transporteur = 0
	SET @TVQ_Transporteur = 0
	SET @TPS_Surcharge = 0
	SET @TVQ_Surcharge = 0
	SET @TPS_Chargeur = 0
	SET @TVQ_Chargeur = 0
	SET @TPS_Compensation = 0
	SET @TVQ_Compensation = 0
	SET @TPS_AutresFrais = 0
	SET @TVQ_AutresFrais = 0
	SET @TPS_AutresRevenus = 0
	SET @TVQ_AutresRevenus = 0

	SET @Montant_ProducteurBrut = 0
	SET @Montant_ProducteurNet = 0
	SET @Frais_ChargeurAuProducteur = 0
	SET @Frais_AutresAuProducteur = 0
	SET @Frais_AutresAuProducteurTransportSciage = 0
	SET @Frais_CompensationDeDeplacement = 0
	
	SET @TPS = 0
	SET @TVQ = 0
	
	SELECT
	@Montant_Usine = ROUND(SUM(LD.Montant_Usine),2),
	@Montant_Preleve1 = ROUND(SUM(LD.Montant_Preleve_Plan_Conjoint),2),
	@Montant_Preleve2 = ROUND(SUM(LD.Montant_Preleve_Fond_Roulement),2),
	@Montant_Preleve3 = ROUND(SUM(LD.Montant_Preleve_Fond_Forestier),2),
	@Montant_Preleve4 = ROUND(SUM(LD.Montant_Preleve_Divers),2),
	@Montant_ProducteurBrut = ROUND(SUM(LD.Montant_ProducteurBrut),2),
	@Montant_ProducteurNet = ROUND(SUM(LD.Montant_ProducteurNet),2)
	FROM Livraison_Detail LD
	WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)
	AND ProducteurID = @FournisseurID

	SELECT
	@Montant = ROUND(SUM(dbo.jag_CalculateMontantProducteurNet(L.[ID], L.DroitCoupeID)),2)
	FROM Livraison L
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND DroitCoupeID = @FournisseurID

	SELECT
	@Montant2 = ROUND(SUM(dbo.jag_CalculateMontantProducteurNet(L.[ID], L.EntentePaiementID)),2)
	FROM Livraison L
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND EntentePaiementID = @FournisseurID

	SET @Montant = (CASE WHEN @Montant IS NOT NULL THEN @Montant ELSE 0 END)
	SET @Montant2 = (CASE WHEN @Montant2 IS NOT NULL THEN @Montant2 ELSE 0 END)

	SET @Montant = @Montant + @Montant2

	SET @Montant = (CASE WHEN @Montant IS NOT NULL THEN @Montant ELSE 0 END)
	SET @Montant_Usine = (CASE WHEN @Montant_Usine IS NOT NULL THEN @Montant_Usine ELSE 0 END)
	SET @Montant_ProducteurBrut = (CASE WHEN @Montant_ProducteurBrut IS NOT NULL THEN @Montant_ProducteurBrut ELSE 0 END)
	SET @Montant_ProducteurNet = (CASE WHEN @Montant_ProducteurNet IS NOT NULL THEN @Montant_ProducteurNet ELSE 0 END)
	SET @Montant_Preleve1 = (CASE WHEN @Montant_Preleve1 IS NOT NULL THEN @Montant_Preleve1 ELSE 0 END)
	SET @Montant_Preleve2 = (CASE WHEN @Montant_Preleve2 IS NOT NULL THEN @Montant_Preleve2 ELSE 0 END)
	SET @Montant_Preleve3 = (CASE WHEN @Montant_Preleve3 IS NOT NULL THEN @Montant_Preleve3 ELSE 0 END)
	SET @Montant_Preleve4 = (CASE WHEN @Montant_Preleve4 IS NOT NULL THEN @Montant_Preleve4 ELSE 0 END)

	SET @Montant_Preleve = ROUND(SUM(@Montant_Preleve1 + @Montant_Preleve2 + @Montant_Preleve3 + @Montant_Preleve4),2)
	SET @Montant_Preleve = (CASE WHEN @Montant_Preleve IS NOT NULL THEN @Montant_Preleve ELSE 0 END)
	
	SELECT
	@Frais_ChargeurAuProducteur = ROUND(SUM(L.Frais_ChargeurAuProducteur),2),
	@Frais_AutresAuProducteur = ROUND(SUM(L.Frais_AutresAuProducteur),2),
	@Frais_AutresAuProducteurTransportSciage = ROUND(SUM(L.Frais_AutresAuProducteurTransportSciage),2),
	@Frais_CompensationDeDeplacement = ROUND(SUM(L.Frais_CompensationDeDeplacement),2),
	@Frais_AutresRevenusProducteur = ROUND(SUM(Frais_AutresRevenusProducteur),2)
	FROM Livraison L
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND DroitCoupeID = @FournisseurID
	
	SET @Frais_ChargeurAuProducteur = (CASE WHEN @Frais_ChargeurAuProducteur IS NOT NULL THEN @Frais_ChargeurAuProducteur ELSE 0 END)
	SET @Frais_AutresAuProducteur = (CASE WHEN @Frais_AutresAuProducteur IS NOT NULL THEN @Frais_AutresAuProducteur ELSE 0 END)
	SET @Frais_AutresAuProducteurTransportSciage = (CASE WHEN @Frais_AutresAuProducteurTransportSciage IS NOT NULL THEN @Frais_AutresAuProducteurTransportSciage ELSE 0 END)
	SET @Frais_CompensationDeDeplacement = (CASE WHEN @Frais_CompensationDeDeplacement IS NOT NULL THEN @Frais_CompensationDeDeplacement ELSE 0 END)
	SET @Frais_AutresRevenusProducteur = (CASE WHEN @Frais_AutresRevenusProducteur IS NOT NULL THEN @Frais_AutresRevenusProducteur ELSE 0 END)

	SELECT
	@Montant_Surcharge = ROUND(SUM(dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], @FournisseurID)),2)
	FROM Livraison L
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND DroitCoupeID = @FournisseurID
	
	SET @Montant_Surcharge = (CASE WHEN @Montant_Surcharge IS NOT NULL THEN ROUND(@Montant_Surcharge,2) ELSE 0 END)
	
	delete @Surcharges
		
	insert into @Surcharges (ContratID, Montant)
	SELECT
	C.[ID],
	SUM(dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], LD.ProducteurID))
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)
	AND ProducteurID = @FournisseurID
	GROUP BY C.[ID]

	--deja calcule par la function jag_CalculateMontantProducteurNet
	/*SET @Montant_Surcharge = (SELECT SUM(Montant) FROM @Surcharges)
	SET @Montant_Surcharge = (CASE WHEN @Montant_Surcharge IS NOT NULL THEN ROUND(@Montant_Surcharge,2) ELSE 0 END)
	SET @Montant = ROUND(@Montant - @Montant_Surcharge,2)
	SET @Montant = (CASE WHEN @Montant IS NOT NULL THEN @Montant ELSE 0 END)*/

	SELECT DISTINCT
	@Montant_Transporteur = ROUND(SUM(LD.Montant_TransporteurMoyen),2)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)
	AND ProducteurID = @FournisseurID

	SET @Montant_Transporteur = (CASE WHEN @Montant_Transporteur IS NOT NULL THEN @Montant_Transporteur ELSE 0 END)

	IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND RecoitTPS = 1 AND No_TPS IS NOT NULL)
	BEGIN
		SET @TPS_Producteur = ROUND((@Montant_ProducteurBrut * @TauxTPS),2)
		SET @TPS_Producteur = (CASE WHEN @TPS_Producteur IS NOT NULL THEN @TPS_Producteur ELSE 0 END)

		SET @TPS_AutresRevenus = ROUND((@Frais_AutresRevenusProducteur * @TauxTPS),2)
		SET @TPS_AutresRevenus = (CASE WHEN @TPS_AutresRevenus IS NOT NULL THEN @TPS_AutresRevenus ELSE 0 END)
	END
	
	IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND RecoitTVQ = 1 AND No_TVQ IS NOT NULL)
	BEGIN
		SET @TVQ_Producteur = ROUND((@Montant_ProducteurBrut * @TauxTVQ),2)
		SET @TVQ_Producteur = (CASE WHEN @TVQ_Producteur IS NOT NULL THEN @TVQ_Producteur ELSE 0 END)

		SET @TVQ_AutresRevenus = ROUND((@Frais_AutresRevenusProducteur * @TauxTVQ),2)
		SET @TVQ_AutresRevenus = (CASE WHEN @TVQ_AutresRevenus IS NOT NULL THEN @TVQ_AutresRevenus ELSE 0 END)
	END


	--------------------------------------------------------------------------------------------
	-- elever TPS et TVQ sur le montant de transport uniquement au producteur inscrit aux taxes

	IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND InscritTPS = 1 AND No_TPS IS NOT NULL)
	BEGIN
		SET @TPS_Transporteur = ROUND((@Montant_Transporteur * @TauxTPS),2)
		SET @TPS_Transporteur = (CASE WHEN @TPS_Transporteur IS NOT NULL THEN @TPS_Transporteur ELSE 0 END)
	END

	IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND InscritTVQ = 1 AND No_TVQ IS NOT NULL)
	BEGIN
		SET @TVQ_Transporteur = ROUND((@Montant_Transporteur * @TauxTVQ),2)
		SET @TVQ_Transporteur = (CASE WHEN @TVQ_Transporteur IS NOT NULL THEN @TVQ_Transporteur ELSE 0 END)
	END
	--------------------------------------------------------------------------------------------


	SET @TPS_Chargeur = ROUND((@Frais_ChargeurAuProducteur * @TauxTPS),2)
	SET @TVQ_Chargeur = ROUND((@Frais_ChargeurAuProducteur * @TauxTVQ),2)
	SET @TPS_Preleve = ROUND((@Montant_Preleve * @TauxTPS),2)
	SET @TVQ_Preleve = ROUND((@Montant_Preleve * @TauxTVQ),2)
	SET @TPS_Surcharge = ROUND((@Montant_Surcharge * @TauxTPS),2)
	SET @TVQ_Surcharge = ROUND((@Montant_Surcharge * @TauxTVQ),2)
	SET @TPS_Compensation = ROUND((@Frais_CompensationDeDeplacement * @TauxTPS),2)
	SET @TVQ_Compensation = ROUND((@Frais_CompensationDeDeplacement * @TauxTVQ),2)
	SET @TPS_AutresFrais = ROUND((@Frais_AutresAuProducteur * @TauxTPS),2)
	SET @TVQ_AutresFrais = ROUND((@Frais_AutresAuProducteur * @TauxTVQ),2)

	SET @TPS = ROUND(SUM(@TPS_Producteur - @TPS_Surcharge - @TPS_Preleve - @TPS_Transporteur - @TPS_Chargeur - @TPS_Compensation - @TPS_AutresFrais + @TPS_AutresRevenus),2)
	SET @TVQ = ROUND(SUM(@TVQ_Producteur - @TVQ_Surcharge - @TVQ_Preleve - @TVQ_Transporteur - @TVQ_Chargeur - @TVQ_Compensation - @TVQ_AutresFrais + @TVQ_AutresRevenus),2)
	
	IF (@Montant < 0)
	BEGIN
		UPDATE Fournisseur SET PaiementManuel = 1 WHERE [ID] = @FournisseurID
	END
	
	INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
	SELECT 
	@FournisseurID, 
	(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurID END),
	'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Producteur]',
	'Attente'
	FROM Fournisseur F 
	WHERE F.[ID] = @FournisseurID
	
	update @FactureFournisseur 	set DepotDirect = (select DepotDirect from Fournisseur where ID = _PayerAID)

	INSERT INTO FactureFournisseur (NoFacture, DateFacture, DateFactureAcomba, DatePaiementAcomba, Annee, TypeFactureFournisseur, TypeFacture, TypeInvoiceAcomba, FournisseurID, PayerAID, Montant_Total, [Description], Status)
	SELECT 
	@NoFacture,
	GetDate(),
	@DateFactureAcomba,
	(case when F.DepotDirect = 1 then @DatePaiementAcomba_Depot else @DatePaiementAcomba_Cheque end),
	@Annee,
	'P',
	'L',
	NULL,
	F.FournisseurID,
	F._PayerAID,
	NULL,
	F.[Description],
	F.Status
	FROM @FactureFournisseur F

	SELECT @FactureID = @@IDENTITY
	
	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID)
	SELECT
	@FactureID,
	MAX(U.Compte_producteur),
	ROUND(SUM(LD.Montant_ProducteurNet),2),
	LD.LivraisonID,
	MAX(C.UsineID)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)
	AND ProducteurID = @FournisseurID
	GROUP BY LD.ProducteurID, LD.LivraisonID
	
	UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Details WHERE Montant = 0
	END
	
	DELETE @DetailsTemp
	INSERT INTO @DetailsTemp
	SELECT * FROM @Details ORDER BY Compte

	DELETE @Details

	INSERT INTO @Details
	SELECT * FROM @DetailsTemp ORDER BY Compte

	UPDATE Livraison SET
	Producteur1_FactureID = @FactureID
	WHERE [ID] in (SELECT [ID] FROM @Livraisons)
	AND DroitCoupeID = @FournisseurID

	UPDATE Livraison SET
	Producteur2_FactureID = @FactureID
	WHERE [ID] in (SELECT [ID] FROM @Livraisons)
	AND ((EntentePaiementID IS NOT NULL) AND (EntentePaiementID = @FournisseurID))

	SET @Ligne = NULL
	SET @LigneCount = 1

	DECLARE cursDetails CURSOR FOR
	SELECT Ligne
	FROM @Details
	where Ligne IS NULL
	for update of Ligne

	OPEN cursDetails

	FETCH NEXT FROM cursDetails INTO @Ligne

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE @Details
		SET Ligne = @LigneCount
		WHERE CURRENT OF cursDetails
		
		select @LigneCount = @LigneCount + 1
		
		FETCH NEXT FROM cursDetails INTO @Ligne
	END
	
	CLOSE cursDetails
	DEALLOCATE cursDetails

	INSERT INTO FactureFournisseur_Details (FactureID, Ligne, Compte, Montant, RefID)
	SELECT 
	FactureID,
	Ligne,
	Compte,
	Montant,
	RefID
	FROM @Details

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode),
	0
	FROM @Details D
	GROUP BY Compte
	ORDER BY Compte
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_producteur),
	ROUND(SUM(-1*L.Frais_CompensationDeDeplacement),2),
	'Compensation de déplacement',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.DroitCoupeID = @FournisseurID
	GROUP BY L.DroitCoupeID, L.[ID]	
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_producteur),
	ROUND(SUM(L.Frais_AutresRevenusProducteur),2),
	'Autres revenus',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.DroitCoupeID = @FournisseurID
	GROUP BY L.DroitCoupeID, L.[ID]
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_producteur),
	ROUND(SUM(-1*L.Frais_ChargeurAuProducteur),2),
	'Frais de chargement',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.DroitCoupeID = @FournisseurID
	GROUP BY L.DroitCoupeID, L.[ID]	
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_producteur),
	ROUND(SUM(-1*L.Frais_AutresAuProducteur),2),
	'Autres frais',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.DroitCoupeID = @FournisseurID
	GROUP BY L.DroitCoupeID, L.[ID]	
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_producteur),
	ROUND(SUM(-1*L.Frais_AutresAuProducteurTransportSciage),2),
	'Autres frais transport sciage',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND L.DroitCoupeID = @FournisseurID
	GROUP BY L.DroitCoupeID, L.[ID]		
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT 
	@FactureID,
	NULL,
	U.Compte_producteur,
	ROUND((-1*S.Montant),2),
	'Surcharge',
	0
	FROM @Surcharges S
		INNER JOIN Contrat C ON C.[ID] = S.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	
	UPDATE @Sommaires SET Montant = 0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Sommaires WHERE Montant = 0
	END
		
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp ORDER BY Compte

	SET @LigneCount = 1

	DECLARE cursSommaires CURSOR FOR
	SELECT Ligne
	FROM @Sommaires
	where Ligne IS NULL
	for update of Ligne

	OPEN cursSommaires

	FETCH NEXT FROM cursSommaires INTO @Ligne

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE @Sommaires
		SET Ligne = @LigneCount
		WHERE CURRENT OF cursSommaires
		
		select @LigneCount = @LigneCount + 1
		
		FETCH NEXT FROM cursSommaires INTO @Ligne
	END

	CLOSE cursSommaires
	DEALLOCATE cursSommaires

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSSurcharge, @TPS_Surcharge, 'Surcharge TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQSurcharge, @TVQ_Surcharge, 'Surcharge TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSPreleve, @TPS_Preleve, 'Preleve TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQPreleve, @TVQ_Preleve, 'Preleve TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSProducteur, @TPS_Producteur, 'Producteur TPS'

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQProducteur, @TVQ_Producteur, 'Producteur TVQ'

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSTransporteur, @TPS_Transporteur, 'Transporteur TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQTransporteur, @TVQ_Transporteur, 'Transporteur TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSChargeur, @TPS_Chargeur, 'Chargeur TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQChargeur, @TVQ_Chargeur, 'Chargeur TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSCompensation, @TPS_Compensation, 'Compensation TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQCompensation, @TVQ_Compensation, 'Compensation TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSAutresFrais, @TPS_AutresFrais, 'Autres Frais TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQAutresFrais, @TVQ_AutresFrais, 'Autres Frais TVQ'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTPSAutresRevenus, @TPS_AutresRevenus, 'Autres Revenus TPS'	

	INSERT INTO @Sommaires (FactureID, Ligne, Montant, [Description])
	SELECT @FactureID, @NoLigneTVQAutresRevenus, @TVQ_AutresRevenus, 'Autres Revenus TVQ'	

	SET @TPS = (CASE WHEN @TPS IS NOT NULL THEN @TPS ELSE 0 END)
	SET @TVQ = (CASE WHEN @TVQ IS NOT NULL THEN @TVQ ELSE 0 END)
	
	IF ((@TPS IS NOT NULL) AND (@TPS <> 0))
	BEGIN
		INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
		SELECT
		@FactureID,
		@NoLigneTPS,
		@Compte_TPSPayees,
		@TPS,
		'TPS',
		1
	END
	ELSE
	BEGIN
		SET @TPS = 0
	END
			
	IF ((@TVQ IS NOT NULL) AND (@TVQ <> 0))
	BEGIN
		INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
		SELECT
		@FactureID,
		@NoLigneTVQ,
		@Compte_TVQPayees,
		@TVQ,
		'TVQ',
		1
	END
	ELSE
	BEGIN
		SET @TVQ = 0
	END
	
	INSERT INTO FactureFournisseur_Sommaire (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	FactureID,
	Ligne,
	Compte,
	Montant,
	[Description],
	isTaxe
	FROM @Sommaires
	ORDER BY Ligne

	UPDATE FactureFournisseur SET
	Montant_Total = ROUND((@Montant + @TPS + @TVQ),2),
	Montant_TPS 	= ROUND(@TPS, 2),
	Montant_TVQ	= ROUND(@TVQ, 2)	
	WHERE [ID] = @FactureID

	UPDATE FactureFournisseur SET
	TypeInvoiceAcomba = (CASE WHEN Montant_Total >= 0 THEN 2 ELSE 1 END)
	WHERE [ID] = @FactureID

	SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

	FETCH NEXT FROM cursFournisseurs INTO @FournisseurID
END

-- Deallocate resources
CLOSE cursFournisseurs
DEALLOCATE cursFournisseurs

-------------------------------------------------------
--------------- PRELEVÉS ------------------------------
-------------------------------------------------------

DELETE @FactureFournisseur
DELETE @Details
DELETE @DetailsTemp
DELETE @Sommaires
DELETE @SommairesTemp
DELETE @Fournisseurs


SET @Montant_Preleve1 = 0
SET @Montant_Preleve2 = 0
SET @Montant_Preleve3 = 0
SET @Montant_Preleve4 = 0

SELECT DISTINCT
@Montant_Preleve1 = ROUND(SUM(LD.Montant_Preleve_Plan_Conjoint),2)
FROM Livraison_Detail LD
WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)

SELECT DISTINCT
@Montant_Preleve2 = ROUND(SUM(LD.Montant_Preleve_Fond_Roulement),2)
FROM Livraison_Detail LD
WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)

SELECT DISTINCT
@Montant_Preleve3 = ROUND(SUM(LD.Montant_Preleve_Fond_Forestier),2)
FROM Livraison_Detail LD
WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)

SELECT DISTINCT
@Montant_Preleve4 = ROUND(SUM(LD.Montant_Preleve_Divers),2)
FROM Livraison_Detail LD
WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)

SELECT @Montant_Preleve1 = (CASE WHEN @Montant_Preleve1 IS NOT NULL THEN @Montant_Preleve1 ELSE 0 END)
SELECT @Montant_Preleve2 = (CASE WHEN @Montant_Preleve2 IS NOT NULL THEN @Montant_Preleve2 ELSE 0 END)
SELECT @Montant_Preleve3 = (CASE WHEN @Montant_Preleve3 IS NOT NULL THEN @Montant_Preleve3 ELSE 0 END)
SELECT @Montant_Preleve4 = (CASE WHEN @Montant_Preleve4 IS NOT NULL THEN @Montant_Preleve4 ELSE 0 END)

DECLARE @FournisseurPreleve1 varchar(15)
DECLARE @FournisseurPreleve2 varchar(15)
DECLARE @FournisseurPreleve3 varchar(15)
DECLARE @FournisseurPreleve4 varchar(15)

SELECT @FournisseurPreleve1 = Fournisseur_PlanConjoint FROM jag_System
SELECT @FournisseurPreleve2 = Fournisseur_Fond_Roulement FROM jag_System
SELECT @FournisseurPreleve3 = Fournisseur_Fond_Forestier FROM jag_System
SELECT @FournisseurPreleve4 = Fournisseur_Preleve_Divers FROM jag_System

INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
SELECT 
@FournisseurPreleve1, 
(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurPreleve1 END),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Prélevés plan conjoint]',
'Attente'
FROM Fournisseur F
WHERE F.[ID] = @FournisseurPreleve1

INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
SELECT 
@FournisseurPreleve2, 
(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurPreleve2 END),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Prélevés fond de roulement]',
'Attente'
FROM Fournisseur F
WHERE F.[ID] = @FournisseurPreleve2

INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
SELECT 
@FournisseurPreleve3, 
(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurPreleve3 END),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Prélevés fond forestier]',
'Attente'
FROM Fournisseur F
WHERE F.[ID] = @FournisseurPreleve3

INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
SELECT 
@FournisseurPreleve4, 
(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurPreleve4 END),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Prélevés divers]',
'Attente'
FROM Fournisseur F
WHERE F.[ID] = @FournisseurPreleve4



SELECT @NoFacture1 = MAX(NoFacture) FROM FactureFournisseur
SELECT @NoFacture1 = (CASE WHEN @NoFacture1 IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture1)+1))),6) ELSE '000001' END)

INSERT INTO FactureFournisseur (NoFacture, DateFacture, DateFactureAcomba, DatePaiementAcomba, Annee, TypeFactureFournisseur, TypeFacture, TypeInvoiceAcomba, FournisseurID, PayerAID, Montant_Total, [Description], Status)
SELECT 
@NoFacture1,
GetDate(),
@DateFactureAcomba,
@DatePaiementAcomba_Cheque,
@Annee,
'R',
'L',
NULL,
F.FournisseurID,
F._PayerAID,
NULL,
F.[Description],
F.Status
FROM @FactureFournisseur F
where F.FournisseurID = @FournisseurPreleve1 and F.[Description] like '%plan conjoint%'

SELECT @FactureID1 = @@IDENTITY

INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID)
SELECT
@FactureID1,
MAX(U.Compte_preleve_plan_conjoint),
ROUND(SUM(LD.Montant_Preleve_Plan_Conjoint),2),
L.[ID],
MAX(C.UsineID)
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Usine U ON U.[ID] = C.UsineID
WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
GROUP BY L.[ID]



SELECT @NoFacture2 = MAX(NoFacture) FROM FactureFournisseur
SELECT @NoFacture2 = (CASE WHEN @NoFacture2 IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture2)+1))),6) ELSE '000001' END)

INSERT INTO FactureFournisseur (NoFacture, DateFacture, DateFactureAcomba, DatePaiementAcomba, Annee, TypeFactureFournisseur, TypeFacture, TypeInvoiceAcomba, FournisseurID, PayerAID, Montant_Total, [Description], Status)
SELECT 
@NoFacture2,
GetDate(),
@DateFactureAcomba,
@DatePaiementAcomba_Cheque,
@Annee,
'R',
'L',
NULL,
F.FournisseurID,
F._PayerAID,
NULL,
F.[Description],
F.Status
FROM @FactureFournisseur F
where F.FournisseurID = @FournisseurPreleve2 and F.[Description] like '%fond de roulement%'

SELECT @FactureID2 = @@IDENTITY

INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID)
SELECT
@FactureID2,
MAX(U.Compte_preleve_fond_roulement),
ROUND(SUM(LD.Montant_Preleve_Fond_Roulement),2),
L.[ID],
MAX(C.UsineID)
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Usine U ON U.[ID] = C.UsineID
WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
GROUP BY L.[ID]



SELECT @NoFacture3 = MAX(NoFacture) FROM FactureFournisseur
SELECT @NoFacture3 = (CASE WHEN @NoFacture3 IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture3)+1))),6) ELSE '000001' END)

INSERT INTO FactureFournisseur (NoFacture, DateFacture, DateFactureAcomba, DatePaiementAcomba, Annee, TypeFactureFournisseur, TypeFacture, TypeInvoiceAcomba, FournisseurID, PayerAID, Montant_Total, [Description], Status)
SELECT 
@NoFacture3,
GetDate(),
@DateFactureAcomba,
@DatePaiementAcomba_Cheque,
@Annee,
'R',
'L',
NULL,
F.FournisseurID,
F._PayerAID,
NULL,
F.[Description],
F.Status
FROM @FactureFournisseur F
where F.FournisseurID = @FournisseurPreleve3 and F.[Description] like '%fond forestier%'

SELECT @FactureID3 = @@IDENTITY

INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID)
SELECT
@FactureID3,
MAX(U.Compte_preleve_fond_forestier),
ROUND(SUM(LD.Montant_Preleve_Fond_Forestier),2),
L.[ID],
MAX(C.UsineID)
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Usine U ON U.[ID] = C.UsineID
WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
GROUP BY L.[ID]



SELECT @NoFacture4 = MAX(NoFacture) FROM FactureFournisseur
SELECT @NoFacture4 = (CASE WHEN @NoFacture4 IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture4)+1))),6) ELSE '000001' END)

INSERT INTO FactureFournisseur (NoFacture, DateFacture, DateFactureAcomba, DatePaiementAcomba, Annee, TypeFactureFournisseur, TypeFacture, TypeInvoiceAcomba, FournisseurID, PayerAID, Montant_Total, [Description], Status)
SELECT 
@NoFacture4,
GetDate(),
@DateFactureAcomba,
@DatePaiementAcomba_Cheque,
@Annee,
'R',
'L',
NULL,
F.FournisseurID,
F._PayerAID,
NULL,
F.[Description],
F.Status
FROM @FactureFournisseur F
where F.FournisseurID = @FournisseurPreleve4 and F.[Description] like '%divers%'

SELECT @FactureID4 = @@IDENTITY

INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID)
SELECT
@FactureID4,
MAX(U.Compte_preleve_divers),
ROUND(SUM(LD.Montant_Preleve_Divers),2),
L.[ID],
MAX(C.UsineID)
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Usine U ON U.[ID] = C.UsineID
WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
GROUP BY L.[ID]



UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
IF (@KeepZeroDetails = 0)
BEGIN
	DELETE @Details WHERE Montant = 0
END

DELETE @DetailsTemp
INSERT INTO @DetailsTemp
SELECT * FROM @Details ORDER BY Compte

DELETE @Details

INSERT INTO @Details
SELECT * FROM @DetailsTemp ORDER BY Compte

SET @Ligne = NULL
SET @LigneCount = 1

DECLARE cursDetails CURSOR FOR
SELECT Ligne
FROM @Details
where Ligne IS NULL
for update of Ligne

OPEN cursDetails

FETCH NEXT FROM cursDetails INTO @Ligne

WHILE @@FETCH_STATUS = 0
BEGIN

	UPDATE @Details
	SET Ligne = @LigneCount
	WHERE CURRENT OF cursDetails
	
	select @LigneCount = @LigneCount + 1
	
	FETCH NEXT FROM cursDetails INTO @Ligne
END

CLOSE cursDetails
DEALLOCATE cursDetails

INSERT INTO FactureFournisseur_Details (FactureID, Ligne, Compte, Montant, RefID)
SELECT 
FactureID,
Ligne,
Compte,
Montant,
RefID
FROM @Details



INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
SELECT
@FactureID1,
NULL,
Compte,
ROUND(SUM(Montant),2),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Prélevés plan conjoint]',
0
FROM @Details D
where FactureID = @FactureID1
GROUP BY Compte

INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
SELECT
@FactureID2,
NULL,
Compte,
ROUND(SUM(Montant),2),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Prélevés fond de roulement]',
0
FROM @Details D
where FactureID = @FactureID2
GROUP BY Compte

INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)

SELECT
@FactureID3,
NULL,
Compte,
ROUND(SUM(Montant),2),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Prélevés fond forestier]',
0
FROM @Details D
where FactureID = @FactureID3
GROUP BY Compte

INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
SELECT
@FactureID4,
NULL,
Compte,
ROUND(SUM(Montant),2),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Prélevés divers]',
0
FROM @Details D
where FactureID = @FactureID4
GROUP BY Compte


DELETE @SommairesTemp
INSERT INTO @SommairesTemp
SELECT * FROM @Sommaires ORDER BY Compte

DELETE @Sommaires

INSERT INTO @Sommaires
SELECT * FROM @SommairesTemp ORDER BY Compte

SET @LigneCount = 1

DECLARE cursSommaires CURSOR FOR
SELECT Ligne
FROM @Sommaires
where Ligne IS NULL
for update of Ligne

OPEN cursSommaires

FETCH NEXT FROM cursSommaires INTO @Ligne

WHILE @@FETCH_STATUS = 0
BEGIN

	UPDATE @Sommaires
	SET Ligne = @LigneCount
	WHERE CURRENT OF cursSommaires
	
	select @LigneCount = @LigneCount + 1
	
	FETCH NEXT FROM cursSommaires INTO @Ligne
END

CLOSE cursSommaires
DEALLOCATE cursSommaires

INSERT INTO FactureFournisseur_Sommaire (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
SELECT
FactureID,
Ligne,
Compte,
Montant,
[Description],
isTaxe
FROM @Sommaires
ORDER BY Ligne


UPDATE FactureFournisseur SET
Montant_Total = ROUND((@Montant_Preleve1),2),
Montant_TPS = 0,
Montant_TVQ = 0
WHERE [ID] = @FactureID1

UPDATE FactureFournisseur SET
TypeInvoiceAcomba = (CASE WHEN Montant_Total >= 0 THEN 2 ELSE 1 END)
WHERE [ID] = @FactureID1


UPDATE FactureFournisseur SET
Montant_Total = ROUND((@Montant_Preleve2),2),
Montant_TPS = 0,
Montant_TVQ = 0
WHERE [ID] = @FactureID2

UPDATE FactureFournisseur SET
TypeInvoiceAcomba = (CASE WHEN Montant_Total >= 0 THEN 2 ELSE 1 END)
WHERE [ID] = @FactureID2


UPDATE FactureFournisseur SET
Montant_Total = ROUND((@Montant_Preleve3),2),
Montant_TPS = 0,
Montant_TVQ = 0
WHERE [ID] = @FactureID3

UPDATE FactureFournisseur SET
TypeInvoiceAcomba = (CASE WHEN Montant_Total >= 0 THEN 2 ELSE 1 END)
WHERE [ID] = @FactureID3


UPDATE FactureFournisseur SET
Montant_Total = ROUND((@Montant_Preleve4),2),
Montant_TPS = 0,
Montant_TVQ = 0
WHERE [ID] = @FactureID4

UPDATE FactureFournisseur SET
TypeInvoiceAcomba = (CASE WHEN Montant_Total >= 0 THEN 2 ELSE 1 END)
WHERE [ID] = @FactureID4

SELECT @NoFacture = MAX(NoFacture) FROM FactureFournisseur
SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

-------------------------------------------------------
--------------- SURCHARGE ------------------------------
-------------------------------------------------------

DELETE @FactureFournisseur
DELETE @Details
DELETE @DetailsTemp
DELETE @Sommaires
DELETE @SommairesTemp
DELETE @Fournisseurs

declare @MontantSurchargesTransporteur float
declare @MontantSurchargesProducteur float

delete @Surcharges
		
insert into @Surcharges (ContratID, Montant)
SELECT
C.[ID],
ROUND(SUM(dbo.jag_CalculateMontantSurchargeAuProducteur(L.[ID], L.DroitCoupeID)),2)
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE LD.[LivraisonID] in (SELECT [ID] FROM @Livraisons)
GROUP BY C.[ID]

--update @Surcharges set Volume = 0 WHERE Volume IS NULL
--update @Surcharges set Taux = 0 WHERE Taux IS NULL
--update @Surcharges set Montant = ROUND((Volume*Taux),2)

--delete @Surcharges where Montant = 0

SELECT @MontantSurchargesProducteur = (SELECT SUM(Montant) FROM @Surcharges)
SET @MontantSurchargesProducteur = (CASE WHEN @MontantSurchargesProducteur IS NOT NULL THEN @MontantSurchargesProducteur ELSE 0 END)

SELECT
@MontantSurchargesTransporteur = ROUND(SUM(dbo.jag_CalculateMontantSurchargeAuTransporteur(L.[ID])),2)
FROM Livraison L
WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)

SET @MontantSurchargesTransporteur = (CASE WHEN @MontantSurchargesTransporteur IS NOT NULL THEN @MontantSurchargesTransporteur ELSE 0 END)

DECLARE @FournisseurSurcharge varchar(15)
SELECT @FournisseurSurcharge = Fournisseur_Surcharge FROM jag_System

INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
SELECT 
@FournisseurSurcharge, 
(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurSurcharge END),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Surcharge]',
'Attente'
FROM Fournisseur F
WHERE F.[ID] = @FournisseurSurcharge

INSERT INTO FactureFournisseur (NoFacture, DateFacture, DateFactureAcomba, DatePaiementAcomba, Annee, TypeFactureFournisseur, TypeFacture, TypeInvoiceAcomba, FournisseurID, PayerAID, Montant_Total, [Description], Status)
SELECT 
@NoFacture,
GetDate(),
@DateFactureAcomba,
@DatePaiementAcomba_Cheque,
@Annee,
'S',
'L',
NULL,
F.FournisseurID,
F._PayerAID,
F.Montant_Total,
F.[Description],
F.Status
FROM @FactureFournisseur F

SELECT @FactureID = @@IDENTITY

INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID)
SELECT
@FactureID,
MAX(U.Compte_surcharge),
ROUND(SUM(dbo.jag_CalculateMontantSurchargeAuTransporteur(L.[ID])),2),
L.[ID],
MAX(C.UsineID)
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Usine U ON U.[ID] = C.UsineID
WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
GROUP BY L.[ID]

UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
IF (@KeepZeroDetails = 0)
BEGIN
	DELETE @Details WHERE Montant = 0
END

SET @Ligne = NULL
SET @LigneCount = 1

DECLARE cursDetails CURSOR FOR
SELECT Ligne
FROM @Details
where Ligne IS NULL
for update of Ligne

OPEN cursDetails

FETCH NEXT FROM cursDetails INTO @Ligne

WHILE @@FETCH_STATUS = 0
BEGIN

	UPDATE @Details
	SET Ligne = @LigneCount
	WHERE CURRENT OF cursDetails
	
	select @LigneCount = @LigneCount + 1
	
	FETCH NEXT FROM cursDetails INTO @Ligne
END

CLOSE cursDetails
DEALLOCATE cursDetails


INSERT INTO FactureFournisseur_Details (FactureID, Ligne, Compte, Montant, RefID)
SELECT 
FactureID,
Ligne,
Compte,
Montant,
RefID
FROM @Details

INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
SELECT
@FactureID,
NULL,
Compte,
ROUND(SUM(Montant),2),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Transporteurs]',
0
FROM @Details D
GROUP BY Compte

INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
SELECT
@FactureID,
NULL,
U.Compte_surcharge,
ROUND(SUM(Montant),2),
'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode) + ' [Producteurs]',
0
FROM @Surcharges S
	INNER JOIN Contrat C ON C.[ID] = S.ContratID
	INNER JOIN Usine U ON U.[ID] = C.UsineID
GROUP BY U.Compte_surcharge

UPDATE @Sommaires SET Montant=0 WHERE Montant IS NULL
IF (@KeepZeroDetails = 0)
BEGIN
	DELETE @Sommaires WHERE Montant = 0
END

INSERT INTO @SommairesTemp
SELECT * FROM @Sommaires ORDER BY Compte

DELETE @Sommaires

INSERT INTO @Sommaires
SELECT * FROM @SommairesTemp ORDER BY Compte

SET @LigneCount = 1

DECLARE cursSommaires CURSOR FOR
SELECT Ligne
FROM @Sommaires
where Ligne IS NULL
for update of Ligne

OPEN cursSommaires

FETCH NEXT FROM cursSommaires INTO @Ligne

WHILE @@FETCH_STATUS = 0
BEGIN

	UPDATE @Sommaires
	SET Ligne = @LigneCount
	WHERE CURRENT OF cursSommaires
	
	select @LigneCount = @LigneCount + 1
	
	FETCH NEXT FROM cursSommaires INTO @Ligne
END

CLOSE cursSommaires
DEALLOCATE cursSommaires

INSERT INTO FactureFournisseur_Sommaire (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
SELECT
FactureID,
Ligne,
Compte,
Montant,
[Description],
isTaxe
FROM @Sommaires
ORDER BY Ligne

UPDATE FactureFournisseur SET
Montant_Total = ROUND((@MontantSurchargesProducteur+@MontantSurchargesTransporteur),2),
Montant_TPS = 0,
Montant_TVQ = 0
WHERE [ID] = @FactureID

UPDATE FactureFournisseur SET
TypeInvoiceAcomba = (CASE WHEN Montant_Total >= 0 THEN 2 ELSE 1 END)
WHERE [ID] = @FactureID

SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

-------------------------------------------------------
------------ CLIENTS ------------------------------
-------------------------------------------------------

DELETE @FactureClient
DELETE @Details
DELETE @DetailsTemp
DELETE @Sommaires
DELETE @SommairesTemp
DELETE @Fournisseurs

SET @NoFacture = NULL
SELECT @NoFacture = MAX(NoFacture) FROM FactureClient-- WHERE Annee = @Annee
SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

INSERT INTO @Clients ([ID], [Description])
SELECT DISTINCT
C.UsineID,
U.[Description]
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
	INNER JOIN Usine U ON U.ID = C.UsineID
WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
ORDER BY U.[Description]

DECLARE cursClients CURSOR FOR
	select [ID] from @Clients ORDER BY [Description]

OPEN cursClients

FETCH NEXT FROM cursClients INTO @ClientID

WHILE @@FETCH_STATUS = 0
BEGIN
	DELETE @FactureClient
	DELETE @Details
	DELETE @DetailsTemp
	DELETE @Sommaires
	DELETE @SommairesTemp

	SET @Montant_Usine = 0
	SET @Montant = 0
	SET @TPS = 0
	SET @TVQ = 0
	SET @Frais_AutresAuTransporteur = 0
	SET @Frais_AutresRevenusTransporteur = 0
	SET @Frais_AutresRevenusProducteur = 0
	SET @Frais_AutresAuProducteur = 0
	SET @Frais_AutresAuProducteurTransportSciage = 0

	SELECT DISTINCT
	@Montant_Usine = ROUND(SUM(Montant_Usine),2),
	@Montant_MEC = ROUND(SUM(Montant_MiseEnCommun),2),
	@Frais_AutresAuTransporteur = ROUND(SUM(Frais_AutresAuTransporteur),2),
	@Frais_AutresAuProducteur = ROUND(SUM(L.Frais_AutresAuProducteur),2),
	@Frais_AutresAuProducteurTransportSciage = ROUND(SUM(L.Frais_AutresAuProducteurTransportSciage),2),
	@Frais_AutresRevenusTransporteur = ROUND(SUM(Frais_AutresRevenusTransporteur),2),
	@Frais_AutresRevenusProducteur = ROUND(SUM(Frais_AutresRevenusProducteur),2)
	FROM Livraison L
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND ContratID in (SELECT [ID] FROM Contrat WHERE UsineID = @ClientID /*AND Annee <= @Annee*/)
	
	SET @Montant_Usine = (CASE WHEN @Montant_Usine IS NOT NULL THEN @Montant_Usine ELSE 0 END)
	SET @Montant_MEC = (CASE WHEN @Montant_MEC IS NOT NULL THEN @Montant_MEC ELSE 0 END)
	SET @Frais_AutresAuTransporteur = (CASE WHEN @Frais_AutresAuTransporteur IS NOT NULL THEN @Frais_AutresAuTransporteur ELSE 0 END)
	SET @Frais_AutresAuProducteur = (CASE WHEN @Frais_AutresAuProducteur IS NOT NULL THEN @Frais_AutresAuProducteur ELSE 0 END)
	SET @Frais_AutresAuProducteurTransportSciage = (CASE WHEN @Frais_AutresAuProducteurTransportSciage IS NOT NULL THEN @Frais_AutresAuProducteurTransportSciage ELSE 0 END)
	SET @Frais_AutresRevenusTransporteur = (CASE WHEN @Frais_AutresRevenusTransporteur IS NOT NULL THEN @Frais_AutresRevenusTransporteur ELSE 0 END)
	SET @Frais_AutresRevenusProducteur = (CASE WHEN @Frais_AutresRevenusProducteur IS NOT NULL THEN @Frais_AutresRevenusProducteur ELSE 0 END)

	SET @Montant = ROUND((@Montant_Usine - @Frais_AutresAuTransporteur - @Frais_AutresAuProducteur - @Frais_AutresAuProducteurTransportSciage + @Frais_AutresRevenusTransporteur + @Frais_AutresRevenusProducteur),2)

	SET @TPS = ROUND((@Montant * @TauxTPS),2)
	SET @TVQ = ROUND((@Montant * @TauxTVQ),2)

	-- Mettre les taxes a 0 si l'usine ne paye pas de taxes
	IF EXISTS (SELECT [ID] FROM Usine WHERE [ID] = @ClientID AND NePaiePasTPS = 1)
	BEGIN
		set @TPS = 0
	END

	IF EXISTS (SELECT [ID] FROM Usine WHERE [ID] = @ClientID AND NePaiePasTVQ = 1)
	BEGIN
		set @TVQ = 0
	END

	INSERT INTO @FactureClient (ClientID, PayerAID, [Description], Status)
	SELECT 
	@ClientID, 
	@ClientID,
	'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode),
	'Attente'

	INSERT INTO FactureClient (NoFacture, DateFacture, DateFactureAcomba, Annee, TypeFacture, TypeInvoiceClientAcomba, ClientID, PayerAID, Montant_Total, [Description], Status)
	SELECT 
	@NoFacture,
	GetDate(),
	@DateFactureAcomba,
	@Annee,
	'L',
	NULL,
	F.ClientID,
	F.PayerAID,
	NULL,
	F.[Description],
	F.Status
	FROM @FactureClient F

	SELECT @FactureID = @@IDENTITY
	
	INSERT INTO @Details (FactureID, Compte, Montant, RefID)
	SELECT
	@FactureID,
	MAX(U.Compte_a_recevoir),
	ROUND(SUM(L.Montant_Usine),2),
	L.[ID]
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, L.ID

	INSERT INTO @Details (FactureID, Compte, Montant, RefID)
	SELECT
	@FactureID,
	MAX(U.Compte_mise_en_commun),
	(-1 * ROUND(SUM(L.Montant_MiseEnCommun),2)),
	L.[ID]
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, L.[ID]
	HAVING SUM(L.Montant_MiseEnCommun) <> 0
	
	INSERT INTO @Details (FactureID, Compte, Montant, RefID)
	SELECT
	@FactureID,
	@Compte_DuAuxProducteurs,
	ROUND(SUM(L.Montant_MiseEnCommun),2),
	L.[ID]
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, L.[ID]
	HAVING SUM(L.Montant_MiseEnCommun) <> 0
	
	UPDATE @Details SET Montant=0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Details WHERE Montant = 0
	END
		
	DECLARE @Compte_MEC int
	SELECT 
	@Compte_MEC = U.Compte_mise_en_commun
	FROM Contrat C
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE C.UsineID = @ClientID

	UPDATE Livraison SET
	Usine_FactureID = @FactureID
	WHERE [ID] in (SELECT [ID] FROM @Livraisons)
	AND ContratID in (SELECT [ID] FROM Contrat WHERE UsineID = @ClientID /*AND Annee <= @Annee*/)

	SET @Ligne = NULL
	SET @LigneCount = 1

	DECLARE cursDetails CURSOR FOR
	SELECT Ligne
	FROM @Details
	where Ligne IS NULL
	for update of Ligne

	OPEN cursDetails

	FETCH NEXT FROM cursDetails INTO @Ligne

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE @Details
		SET Ligne = @LigneCount
		WHERE CURRENT OF cursDetails
		
		select @LigneCount = @LigneCount + 1
		
		FETCH NEXT FROM cursDetails INTO @Ligne
	END
	
	CLOSE cursDetails
	DEALLOCATE cursDetails

	INSERT INTO FactureClient_Details (FactureID, Ligne, Compte, Montant, RefID)
	SELECT 
	FactureID,
	Ligne,
	Compte,
	Montant,
	RefID
	FROM @Details

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	'Livraisons pour la période ' + CONVERT(VARCHAR, @Annee) + '-' + CONVERT(VARCHAR, @Periode),
	0
	FROM @Details
	WHERE Compte <> @Compte_MEC AND Compte <> @Compte_DuAuxProducteurs
	GROUP BY Compte

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_a_recevoir),
	ROUND(SUM(L.Frais_AutresRevenusTransporteur),2),
	'Autres revenus transporteur',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, L.[ID]
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_a_recevoir),
	ROUND(SUM(L.Frais_AutresRevenusProducteur),2),
	'Autres revenus producteur',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, L.[ID]
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	NULL,
	MAX(U.Compte_a_recevoir),
	ROUND(SUM(-1*(L.Frais_AutresAuTransporteur + L.Frais_AutresAuProducteur + L.Frais_AutresAuProducteurTransportSciage)),2),
	'Autres frais',
	0
	FROM Livraison L
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, L.[ID]
	
		
	UPDATE @Sommaires SET Montant=0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Sommaires WHERE Montant = 0
	END
		
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> @Compte_MEC AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_MEC ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp

	SET @LigneCount = 1

	DECLARE cursSommaires CURSOR FOR
	SELECT Ligne
	FROM @Sommaires
	where Ligne IS NULL
	for update of Ligne

	OPEN cursSommaires

	FETCH NEXT FROM cursSommaires INTO @Ligne

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE @Sommaires
		SET Ligne = @LigneCount
		WHERE CURRENT OF cursSommaires
		
		select @LigneCount = @LigneCount + 1
		
		FETCH NEXT FROM cursSommaires INTO @Ligne
	END

	CLOSE cursSommaires
	DEALLOCATE cursSommaires

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	@NoLigneMEC,
	Compte,
	ROUND(SUM(Montant),2),
	'Mise en commun pour les livraisons pour la période ' + CONVERT(VARCHAR,@Annee) + '-' + CONVERT(VARCHAR,@Periode),
	0
	FROM @Details
	WHERE Compte = @Compte_MEC
	GROUP BY Compte
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	@FactureID,
	@NoLigneMEC2,
	Compte,
	ROUND(SUM(Montant),2),
	'Transfert dans le compte "Dû aux producteurs"',
	0
	FROM @Details
	WHERE Compte = @Compte_DuAuxProducteurs
	GROUP BY Compte

	IF EXISTS (SELECT [ID] FROM Usine WHERE [ID] = @ClientID AND NePaiePasTPS = 0)
	BEGIN
		INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
		SELECT
		@FactureID,
		@NoLigneTPS,
		@Compte_TPSPercues,
		@TPS,
		'TPS',
		1
	END

	IF EXISTS (SELECT [ID] FROM Usine WHERE [ID] = @ClientID AND NePaiePasTVQ = 0)
	BEGIN
		INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
		SELECT
		@FactureID,
		@NoLigneTVQ,
		@Compte_TVQPercues,
		@TVQ,
		'TVQ',
		1
	END

	UPDATE @Sommaires SET Montant=0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Sommaires WHERE Montant = 0
	END
	
	INSERT INTO FactureClient_Sommaire (FactureID, Ligne, Compte, Montant, [Description], isTaxe)
	SELECT
	FactureID,
	Ligne,
	Compte,
	Montant,
	[Description],
	isTaxe
	FROM @Sommaires
	ORDER BY Ligne

	UPDATE FactureClient SET
	Montant_Total = ROUND((@Montant + @TPS + @TVQ),2),
	Montant_TPS = ROUND(@TPS, 2),
	Montant_TVQ	= ROUND(@TVQ, 2)	
	WHERE [ID] = @FactureID

	UPDATE FactureClient SET
	TypeInvoiceClientAcomba = (CASE WHEN Montant_Total >= 0 THEN 4 ELSE 3 END)
	WHERE [ID] = @FactureID

	SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

	FETCH NEXT FROM cursClients INTO @ClientID
END

-- Deallocate resources
CLOSE cursClients
DEALLOCATE cursClients

UPDATE Livraison SET
Facture = 1
WHERE ((Producteur1_FactureID IS NOT NULL) OR (Producteur2_FactureID IS NOT NULL) OR (Transporteur_FactureID IS NOT NULL) OR (Usine_FactureID IS NOT NULL))
AND [ID] IN (SELECT [ID] FROM @Livraisons)

--Mettre les fournisseurs ayant plusieurs nouvelles factures en paiement manuel
UPDATE Fournisseur SET PaiementManuel = 1
WHERE [ID] IN (SELECT FournisseurID FROM FactureFournisseur WHERE Status='Attente' GROUP BY FournisseurID HAVING COUNT(*) > 1)


