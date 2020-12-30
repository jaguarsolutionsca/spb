CREATE PROCEDURE [dbo].[jag_CreerFactures_Ajustement]
@Annee INT, @UsineID VARCHAR (6)=Null, @AjustementID INT=Null, @DateFactureAcomba SMALLDATETIME, @DatePaiementAcomba_Cheque SMALLDATETIME, @DatePaiementAcomba_Depot SMALLDATETIME
AS
SET NOCOUNT ON

DECLARE @KeepZeroDetails BIT
SET @KeepZeroDetails = 0

exec jag_Clear_FactureEnAttente

--DECLARE @NoLigneMEC INT
--DECLARE @NoLigneMEC2 INT
--SET @NoLigneMEC = 450
--SET @NoLigneMEC2 = 451

DECLARE @TauxTPS FLOAT
DECLARE @TauxTVQ FLOAT
SELECT TOP 1 @TauxTPS = Taux_TPS, @TauxTVQ = Taux_TVQ FROM jag_System

DECLARE @Ajustements TABLE
(
	[ID] int,
	ContratID VARCHAR(10)
)

DECLARE @Fournisseurs TABLE
(
	[ID] varchar(15),
	[Nom] varchar(40)
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
	UsineID varchar(6),
	isCompteMEC BIT
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
	isTaxe bit,
	UsineID VARCHAR(6)
)

DECLARE @SommairesTemp TABLE
(
	FactureID int,
	Ligne int,
	Compte int,
	Montant float,
	[Description] varchar(90),
	isTaxe bit,
	UsineID VARCHAR(6)
)

DECLARE @NoFacture varchar(12)

DECLARE @Compte_DuAuxProducteurs int
DECLARE @Compte_TPSPayees int
DECLARE @Compte_TVQPayees int
DECLARE @Compte_TPSPercues int
DECLARE @Compte_TVQPercues int

SELECT @Compte_TPSPayees = Compte_TPSPayees FROM jag_System
SELECT @Compte_TVQPayees = Compte_TVQPayees FROM jag_System
SELECT @Compte_TPSPercues = Compte_TPSPercues FROM jag_System
SELECT @Compte_TVQPercues = Compte_TVQPercues FROM jag_System

DECLARE @FactureID int
DECLARE @FournisseurID varchar(15)
DECLARE @ClientID varchar(6)

DECLARE @Ligne int
DECLARE @LigneCount int

DECLARE @NoLigneTPS INT
DECLARE @NoLigneTVQ INT
SET @NoLigneTPS = 500
SET @NoLigneTVQ = 501

DECLARE @Montant float
DECLARE @TPS float
DECLARE @TVQ float

SELECT @NoFacture = MAX(NoFacture) FROM FactureFournisseur-- WHERE Annee = @Annee
SET @NoFacture = (CASE WHEN @NoFacture IS NOT NULL THEN RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NoFacture)+1))),6) ELSE '000001' END)

SELECT @Compte_DuAuxProducteurs = Compte_DuAuxProducteurs FROM jag_System

INSERT INTO @Ajustements
SELECT [ID], [ContratID] FROM dbo.jag_GetAjustementsNonFactures (@UsineID, @AjustementID)

IF NOT EXISTS (SELECT * FROM @Ajustements)
BEGIN
	RETURN
END


-----------------------------------------------
-- Regarde s'il y a des ajustements RISTOURNE
Declare @AjustementRistourne int
set @AjustementRistourne =
	(SELECT count(*) FROM 
		dbo.jag_GetAjustementsNonFactures (@UsineID, @AjustementID) as f
		left join ajustement as a on a.ID = f.id
		where a.IsRistourne = 1
	)


exec jag_Calculate_AjustementsNonFactures


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
FROM AjustementCalcule_Transporteur ACT
	INNER JOIN Fournisseur T ON T.ID = ACT.TransporteurID
WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
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

	SET @Montant = NULL
	SET @TPS = 0
	SET @TVQ = 0

	SELECT
	@Montant = SUM(Montant)
	FROM AjustementCalcule_Transporteur ACT
	WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND TransporteurID = @FournisseurID
	
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

	INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
	SELECT 
	@FournisseurID, 
	(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurID END),
	--dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, NULL),
	'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) + ' [Transporteur]',
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
	'A',
	NULL,
	F.FournisseurID,
	F._PayerAID,
	NULL,
	F.[Description],
	F.Status
	FROM @FactureFournisseur F

	SELECT @FactureID = @@IDENTITY

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	MAX(U.Compte_transporteur),
	ROUND(SUM(ACT.Montant),2),
	ACT.[ID],
	MAX(C.UsineID),
	0
	FROM AjustementCalcule_Transporteur ACT
		INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACT.TransporteurID = @FournisseurID
	GROUP BY ACT.TransporteurID, ACT.[ID]

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	MAX(U.Compte_mise_en_commun),
	(-1)*ROUND(SUM(ACT.Montant),2),
	ACT.[ID],
	MAX(C.UsineID),
	1
	FROM AjustementCalcule_Transporteur ACT
		INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACT.TransporteurID = @FournisseurID
	GROUP BY ACT.TransporteurID, ACT.[ID]

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	@Compte_DuAuxProducteurs,
	ROUND(SUM(ACT.Montant),2),
	ACT.[ID],
	MAX(C.UsineID),
	0
	FROM AjustementCalcule_Transporteur ACT
		INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACT.TransporteurID = @FournisseurID
	GROUP BY ACT.TransporteurID, ACT.[ID]
	
	UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Details WHERE Montant = 0
	END

	UPDATE AjustementCalcule_Transporteur SET
	FactureID = @FactureID
	WHERE [AjustementID] in (SELECT [ID] FROM @Ajustements)
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

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	SUM(Montant),
	--(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ' + dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, MAX(D.UsineID)) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, MAX(D.UsineID)) END),
	(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE 'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) END),
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE isCompteMEC = 0 AND Compte <> @Compte_DuAuxProducteurs
	GROUP BY Compte
	
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> dbo.jag_GetCompteMEC (UsineID) AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = dbo.jag_GetCompteMEC (UsineID) ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp-- ORDER BY Compte

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

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	SUM(Montant),
	--(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ' + dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, MAX(D.UsineID)) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, MAX(D.UsineID)) END),
	(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE 'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) END),
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE isCompteMEC = 1 OR Compte = @Compte_DuAuxProducteurs
	GROUP BY Compte
	
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> dbo.jag_GetCompteMEC (UsineID) AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = dbo.jag_GetCompteMEC (UsineID) ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp-- ORDER BY Compte
	
	--SET @LigneCount = 500

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
------------ TRANSPORTEURS ESSENCE --------------------
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
FROM AjustementCalcule_TransporteurEssence ACT
	INNER JOIN Fournisseur T ON T.ID = ACT.TransporteurID
WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
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

	SET @Montant = NULL
	SET @TPS = 0
	SET @TVQ = 0

	SELECT
	@Montant = SUM(Montant)
	FROM AjustementCalcule_TransporteurEssence ACT
	WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND TransporteurID = @FournisseurID
	
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

	INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
	SELECT 
	@FournisseurID, 
	(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurID END),
	--dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, NULL),
	'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) + ' [Transporteur]',
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
	'A',
	NULL,
	F.FournisseurID,
	F._PayerAID,
	NULL,
	F.[Description],
	F.Status
	FROM @FactureFournisseur F

	SELECT @FactureID = @@IDENTITY

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	MAX(U.Compte_transporteur),
	ROUND(SUM(ACT.Montant),2),
	ACT.[ID],
	MAX(C.UsineID),
	0
	FROM AjustementCalcule_TransporteurEssence ACT
		INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACT.TransporteurID = @FournisseurID
	GROUP BY ACT.TransporteurID, ACT.[ID]

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	MAX(U.Compte_mise_en_commun),
	(-1)*ROUND(SUM(ACT.Montant),2),
	ACT.[ID],
	MAX(C.UsineID),
	1
	FROM AjustementCalcule_TransporteurEssence ACT
		INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACT.TransporteurID = @FournisseurID
	GROUP BY ACT.TransporteurID, ACT.[ID]

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	@Compte_DuAuxProducteurs,
	ROUND(SUM(ACT.Montant),2),
	ACT.[ID],
	MAX(C.UsineID),
	0
	FROM AjustementCalcule_TransporteurEssence ACT
		INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACT.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACT.TransporteurID = @FournisseurID
	GROUP BY ACT.TransporteurID, ACT.[ID]
	
	UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Details WHERE Montant = 0
	END

	UPDATE AjustementCalcule_TransporteurEssence SET
	FactureID = @FactureID
	WHERE [AjustementID] in (SELECT [ID] FROM @Ajustements)
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

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	SUM(Montant),
	--(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ' + dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, MAX(D.UsineID)) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, MAX(D.UsineID)) END),
	(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE 'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) END),
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE isCompteMEC = 0 AND Compte <> @Compte_DuAuxProducteurs
	GROUP BY Compte
	
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> dbo.jag_GetCompteMEC (UsineID) AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = dbo.jag_GetCompteMEC (UsineID) ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp-- ORDER BY Compte

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

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	SUM(Montant),
	--(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ' + dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, MAX(D.UsineID)) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE dbo.jag_GetAjustementsListForTransporteur (@FournisseurID, MAX(D.UsineID)) END),
	(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE 'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) END),
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE isCompteMEC = 1 OR Compte = @Compte_DuAuxProducteurs
	GROUP BY Compte
	
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> dbo.jag_GetCompteMEC (UsineID) AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = dbo.jag_GetCompteMEC (UsineID) ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp-- ORDER BY Compte
	
	--SET @LigneCount = 500

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
FROM AjustementCalcule_Producteur ACP
	INNER JOIN Fournisseur P ON P.ID = ACP.ProducteurID
WHERE ACP.[AjustementID] in (SELECT [ID] FROM @Ajustements)
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

	SET @Montant = NULL
	SET @TPS = 0
	SET @TVQ = 0

	SELECT
	@Montant = ROUND(SUM(ACP.Montant),2)
	FROM AjustementCalcule_Producteur ACP
	WHERE ACP.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ProducteurID = @FournisseurID

	SET @Montant = (CASE WHEN @Montant IS NOT NULL THEN @Montant ELSE 0 END)
	
	----------------------------------------------------------------------------------
	-- si c'est pour une ristourne, retourne les taxes seulement au producteur inscrit
	----------------------------------------------------------------------------------
	IF @AjustementRistourne > 0
	Begin
		IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND InscritTPS = 1 AND No_TPS IS NOT NULL)
		BEGIN
			SET @TPS = ROUND((@Montant * @TauxTPS),2)
			SET @TPS = (CASE WHEN @TPS IS NOT NULL THEN @TPS ELSE 0 END)
		END
		
		IF EXISTS (SELECT [ID] FROM Fournisseur WHERE [ID] = @FournisseurID AND InscritTVQ = 1 AND No_TVQ IS NOT NULL)
		BEGIN
			SET @TVQ = ROUND((@Montant * @TauxTVQ),2)
			SET @TVQ = (CASE WHEN @TVQ IS NOT NULL THEN @TVQ ELSE 0 END)
		END
	End
	Else
	Begin
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
	end	

	INSERT INTO @FactureFournisseur (FournisseurID, _PayerAID, [Description], Status)
	SELECT 
	@FournisseurID, 
	(CASE WHEN F.PayerA = 1 THEN F.PayerAID ELSE @FournisseurID END),
	--dbo.jag_GetAjustementsListForFournisseur (@FournisseurID, NULL),
	'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) + ' [Producteur]',
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
	'A',
	NULL,
	F.FournisseurID,
	F._PayerAID,
	NULL,
	F.[Description],
	F.Status
	FROM @FactureFournisseur F

	SELECT @FactureID = @@IDENTITY

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	MAX(U.Compte_producteur),
	ROUND(SUM(ACP.Montant),2),
	ACP.[ID],
	MAX(C.UsineID),
	0
	FROM AjustementCalcule_Producteur ACP
		INNER JOIN Ajustement A ON A.[ID] = ACP.[AjustementID]
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACP.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACP.ProducteurID = @FournisseurID
	GROUP BY ACP.ProducteurID, ACP.[ID]

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	MAX(U.Compte_mise_en_commun),
	(-1)*ROUND(SUM(ACP.Montant),2),
	ACP.[ID],
	MAX(C.UsineID),
	1
	FROM AjustementCalcule_Producteur ACP
		INNER JOIN Ajustement A ON A.[ID] = ACP.[AjustementID]
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACP.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACP.ProducteurID = @FournisseurID
	GROUP BY ACP.ProducteurID, ACP.[ID]

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	@Compte_DuAuxProducteurs,
	ROUND(SUM(ACP.Montant),2),
	A.[ID],
	MAX(C.UsineID),
	0
	FROM AjustementCalcule_Producteur ACP
		INNER JOIN Ajustement A ON A.[ID] = ACP.[AjustementID]
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE ACP.[AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ACP.ProducteurID = @FournisseurID
	GROUP BY ACP.ProducteurID, A.[ID]

	UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Details WHERE Montant = 0
	END

	UPDATE AjustementCalcule_Producteur SET
	FactureID = @FactureID
	WHERE [AjustementID] in (SELECT [ID] FROM @Ajustements)
	AND ProducteurID = @FournisseurID

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

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	--(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ' + dbo.jag_GetAjustementsListForFournisseur (@FournisseurID, NULL) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE dbo.jag_GetAjustementsListForFournisseur (@FournisseurID, MAX(D.UsineID)) END),
	(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE 'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) END),
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE isCompteMEC = 0 AND Compte <> @Compte_DuAuxProducteurs
	GROUP BY Compte
	ORDER BY Compte

	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> dbo.jag_GetCompteMEC (UsineID) AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = dbo.jag_GetCompteMEC (UsineID) ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp-- ORDER BY Compte

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
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	--(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ' + dbo.jag_GetAjustementsListForFournisseur (@FournisseurID, NULL) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE dbo.jag_GetAjustementsListForFournisseur (@FournisseurID, MAX(D.UsineID)) END),
	(CASE WHEN Compte = dbo.jag_GetCompteMEC (MAX(D.UsineID)) THEN 'Mise en commun pour les ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) WHEN Compte = @Compte_DuAuxProducteurs THEN 'Transfert dans le compte "Dû aux producteurs"' ELSE 'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee) END),
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE isCompteMEC = 1 OR Compte = @Compte_DuAuxProducteurs
	GROUP BY Compte
	ORDER BY Compte
	
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> dbo.jag_GetCompteMEC (UsineID) AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = dbo.jag_GetCompteMEC (UsineID) ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp-- ORDER BY Compte
	
	--SET @LigneCount = 500

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
FROM AjustementCalcule_Usine ACU
	INNER JOIN Ajustement A ON A.[ID] = ACU.AjustementID
	INNER JOIN Contrat C ON C.[ID] = A.ContratID
	INNER JOIN Usine U ON U.ID = ACU.UsineID
WHERE ACU.[AjustementID] in (SELECT [ID] FROM @Ajustements)
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

	SET @Montant = NULL
	SET @TPS = NULL
	SET @TVQ = NULL
	
	SELECT
	@Montant = ROUND(SUM(Montant),2)
	FROM AjustementCalcule_Usine ACU
		INNER JOIN Ajustement A ON A.[ID] = ACU.AjustementID
	WHERE A.[ID] in (SELECT [ID] FROM @Ajustements)
	AND A.ContratID in (SELECT [ID] FROM Contrat WHERE UsineID = @ClientID AND Annee = @Annee)


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
	--dbo.jag_GetAjustementsListForUsine (@ClientID),
	'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee),
	'Attente'

	INSERT INTO FactureClient (NoFacture, DateFacture, DateFactureAcomba, Annee, TypeFacture, TypeInvoiceClientAcomba, ClientID, PayerAID, Montant_Total, [Description], Status)
	SELECT 
	@NoFacture,
	GetDate(),
	@DateFactureAcomba,
	@Annee,
	'A',
	NULL,
	F.ClientID,
	F.PayerAID,
	NULL,
	F.[Description],
	F.Status
	FROM @FactureClient F

	SELECT @FactureID = @@IDENTITY

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	MAX(U.Compte_a_recevoir),
	ROUND(SUM(ACU.Montant),2),
	ACU.[ID],
	C.UsineID,
	0
	FROM AjustementCalcule_Usine ACU
		INNER JOIN Ajustement A ON A.[ID] = ACU.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE A.[ID] in (SELECT [ID] FROM @Ajustements)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, ACU.[ID]

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	MAX(U.Compte_mise_en_commun),
	(-1 * ROUND(SUM(ACU.Montant),2)),
	ACU.[ID],
	C.UsineID, 
	1
	FROM AjustementCalcule_Usine ACU
		INNER JOIN Ajustement A ON A.[ID] = ACU.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE A.[ID] in (SELECT [ID] FROM @Ajustements)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, ACU.[ID]
	HAVING SUM(ACU.Montant) <> 0

	INSERT INTO @Details (FactureID, Compte, Montant, RefID, UsineID, isCompteMEC)
	SELECT
	@FactureID,
	@Compte_DuAuxProducteurs,
	ROUND(SUM(ACU.Montant),2),
	A.[ID],
	C.UsineID, 
	0

	FROM AjustementCalcule_Usine ACU
		INNER JOIN Ajustement A ON A.[ID] = ACU.AjustementID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		INNER JOIN Usine U ON U.[ID] = C.UsineID
	WHERE A.[ID] in (SELECT [ID] FROM @Ajustements)
	AND C.UsineID = @ClientID
	GROUP BY C.UsineID, A.[ID]
	HAVING SUM(ACU.Montant) <> 0
	
	UPDATE @Details SET Montant = 0 WHERE Montant IS NULL
	IF (@KeepZeroDetails = 0)
	BEGIN
		DELETE @Details WHERE Montant = 0
	END

	UPDATE AjustementCalcule_Usine SET
	FactureID = @FactureID
	WHERE AjustementID IN (SELECT [ID] FROM @Ajustements WHERE ContratID in (SELECT [ID] FROM Contrat WHERE UsineID = @ClientID AND Annee = @Annee))
	
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

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	--dbo.jag_GetAjustementsListForUsine (@ClientID),
	'Ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee),
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE isCompteMEC = 0 AND Compte <> @Compte_DuAuxProducteurs
	GROUP BY Compte

	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> dbo.jag_GetCompteMEC (UsineID) AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = dbo.jag_GetCompteMEC (UsineID) ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp-- ORDER BY Compte

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

	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	--'Mise en commun pour les ' + dbo.jag_GetAjustementsListForUsine (@ClientID),
	'Mise en commun pour les ajustements pour l''annee ' + CONVERT(VARCHAR, @Annee),
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE isCompteMEC = 1
	GROUP BY Compte
	
	INSERT INTO @Sommaires (FactureID, Ligne, Compte, Montant, [Description], isTaxe, UsineID)
	SELECT
	@FactureID,
	NULL,
	Compte,
	ROUND(SUM(Montant),2),
	'Transfert dans le compte "Dû aux producteurs"',
	0,
	MAX(D.UsineID)
	FROM @Details D
	WHERE Compte = @Compte_DuAuxProducteurs
	GROUP BY Compte
	
	DELETE @SommairesTemp
	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte <> dbo.jag_GetCompteMEC (UsineID) AND Compte <> @Compte_DuAuxProducteurs ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = dbo.jag_GetCompteMEC (UsineID) ORDER BY Compte

	INSERT INTO @SommairesTemp
	SELECT * FROM @Sommaires WHERE Compte = @Compte_DuAuxProducteurs ORDER BY Compte

	DELETE @Sommaires

	INSERT INTO @Sommaires
	SELECT * FROM @SommairesTemp-- ORDER BY Compte

	--SET @LigneCount = 500

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
	Montant_TPS 	= ROUND(@TPS, 2),
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

UPDATE AjustementCalcule_Transporteur SET
Facture = 1
WHERE (FactureID IS NOT NULL)
AND [AjustementID] IN (SELECT [ID] FROM @Ajustements)

UPDATE AjustementCalcule_TransporteurEssence SET
Facture = 1
WHERE (FactureID IS NOT NULL)
AND [AjustementID] IN (SELECT [ID] FROM @Ajustements)

UPDATE AjustementCalcule_Producteur SET
Facture = 1
WHERE (FactureID IS NOT NULL)
AND [AjustementID] IN (SELECT [ID] FROM @Ajustements)

UPDATE AjustementCalcule_Usine SET
Facture = 1
WHERE (FactureID IS NOT NULL)
AND [AjustementID] IN (SELECT [ID] FROM @Ajustements)

UPDATE Ajustement SET
Facture = 1
WHERE [ID] IN (SELECT [ID] FROM @Ajustements)

--Mettre les fournisseurs ayant plusieurs nouvelles factures en paiement manuel
UPDATE Fournisseur SET PaiementManuel = 1
WHERE [ID] IN (SELECT FournisseurID FROM FactureFournisseur WHERE Status='Attente' GROUP BY FournisseurID HAVING COUNT(*) > 1)
