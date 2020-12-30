CREATE PROCEDURE [dbo].[jag_Calculate_Indexation]
	(
		@IndexationID int
	)
--with Recompile 
AS

EXEC('ALTER INDEX ix_Livraison_Contrat_Facture ON dbo.Livraison REBUILD')

declare @Facture bit
select @Facture = Facture FROM Indexation WHERE [ID] = @IndexationID

IF (@Facture = 1)
BEGIN
	RETURN
END

DECLARE @IndexationTransporteur bit 
select @IndexationTransporteur = (select IndexationTransporteur from Indexation where [ID] = @IndexationID)
SET @IndexationTransporteur = (CASE WHEN @IndexationTransporteur IS NOT NULL THEN @IndexationTransporteur ELSE 1 END)

EXEC jag_EffacerCalculs_Indexation @IndexationID

declare @PeriodeDebut int
declare @AnneeDebut int
declare @PeriodeFin int
declare @AnneeFin int

SELECT
@PeriodeDebut = Periode_Debut,
@AnneeDebut = Contrat.Annee,
@PeriodeFin = Periode_Fin,
@AnneeFin = Contrat.Annee
FROM Indexation 
	INNER JOIN Contrat   on Contrat.[ID] = Indexation.ContratID
WHERE Indexation.[ID] = @IndexationID

----------------------------------
-- INDEXATION PAR MONTANT
----------------------------------
DECLARE @IndexationTransporteurMontant TABLE
(
	ContratID varchar(10),
	MunicipaliteID varchar(6),
	ZoneID varchar(2),
	Montant float
)

DECLARE @IndexationProducteurMontant TABLE
(
	ContratID varchar(10),
	EssenceID varchar(6),
	Code char(4),
	UniteID varchar(6),
	Taux float,
	Montant float
)

DECLARE @IndexationCalcule_Transporteur TABLE
(
	TypeIndexation char(1),
	IndexationID int,
	IndexationDetailID int,
	LivraisonID int,
	TransporteurID varchar(15),
	MontantDejaPaye float,
	PourcentageDuMontant float,
	Montant float
)

DECLARE @IndexationCalcule_Producteur TABLE
(
	TypeIndexation char(1),
	IndexationID int,
	IndexationDetailID int,
	LivraisonID int,
	LivraisonDetailID int,
	ProducteurID varchar(15),
	ContratID varchar(10),
	EssenceID varchar(6),
	Code char(4),
	UniteID varchar(6),
	Volume float,
	MontantDejaPaye float,
	PourcentageDuMontant float,
	Taux float,
	Montant float
)

IF (@IndexationTransporteur = 1)
BEGIN
	INSERT INTO @IndexationTransporteurMontant
	SELECT
	ContratID,
	Indexation_Municipalite.MunicipaliteID,
	Indexation_Municipalite.ZoneID,
	Montant
	FROM Indexation_Municipalite 
		INNER JOIN Indexation  ON Indexation.[ID] = @IndexationID AND Indexation.TypeIndexation = 'M'
	WHERE IndexationID = @IndexationID
	AND ((Montant IS NOT NULL) AND (Montant <> 0))
	ORDER BY ContratID, MunicipaliteID, Montant
	
	INSERT INTO @IndexationCalcule_Transporteur
	SELECT
	'M',
	Indexation_Municipalite.IndexationID AS [IndexationID],
	Indexation_Municipalite.[ID] AS [IndexationDetailID],
	L.[ID] AS [LivraisonID],
	L.TransporteurID AS [TransporteurID],
	0 AS [MontantDejaPaye],
	0 AS [PourcentageDuMontant],
	ROUND(I.Montant,2) AS [Montant]
	FROM Livraison L
	--	inner join Lot lo on L.LotID = lo.ID
		INNER JOIN @IndexationTransporteurMontant I ON I.ContratID = L.ContratID AND I.MunicipaliteID = L.MunicipaliteID AND I.ZoneID = L.ZoneID 
		INNER JOIN Indexation_Municipalite ON Indexation_Municipalite.IndexationID = @IndexationID AND Indexation_Municipalite.MunicipaliteID = L.MunicipaliteID AND Indexation_Municipalite.ZoneID = L.ZoneID 
	WHERE
	 ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND (L.Facture = 1)
	AND (L.TransporteurID IS NOT NULL)
	ORDER BY L.[ID], L.TransporteurID, I.Montant

	INSERT INTO IndexationCalcule_Transporteur
	(DateCalcul, TypeIndexation, IndexationID, IndexationDetailID, LivraisonID, TransporteurID, MontantDejaPaye, PourcentageDuMontant, Montant, Facture)
	SELECT
	GetDate(),
	TypeIndexation,
	IndexationID,
	IndexationDetailID,
	LivraisonID,
	TransporteurID,
	MontantDejaPaye, 
	PourcentageDuMontant,
	Montant, 
	0

	FROM @IndexationCalcule_Transporteur
	where 
		right('00000000000000000000000000000000' + convert(varchar, IndexationID), 32) + '-' + 
		right('00000000000000000000000000000000' + convert(varchar, LivraisonID), 32) in
		(select
			right('00000000000000000000000000000000' + convert(varchar, IndexationID), 32) + '-' + 
			right('00000000000000000000000000000000' + convert(varchar, LivraisonID), 32)	
		from Indexation_Livraison)

	DELETE FROM @IndexationCalcule_Transporteur
END
ELSE
BEGIN
	INSERT INTO @IndexationProducteurMontant
	SELECT
	IEU.ContratID,
	IEU.EssenceID,
	IEU.Code,
	IEU.UniteID,
	IEU.Taux,
	0
	FROM Indexation_EssenceUnite  IEU 
		INNER JOIN Indexation  ON Indexation.[ID] = @IndexationID AND Indexation.TypeIndexation = 'M'
	WHERE IndexationID = @IndexationID
	AND ((Taux IS NOT NULL) AND (Taux <> 0))
	ORDER BY IEU.ContratID, IEU.EssenceID, IEU.Code, IEU.UniteID, IEU.Taux
	
	INSERT INTO @IndexationCalcule_Producteur
	SELECT
	'M',
	IEU.IndexationID AS [IndexationID],
	IEU.[ID] AS [IndexationDetailID],
	L.[ID] AS [LivraisonID],
	LD.[ID] AS [LivraisonDetailID],
	LD.ProducteurID AS [ProducteurID],
	LD.ContratID,
	LD.EssenceID,
	LD.Code,
	LD.UniteMesureID,
	LD.VolumeNet AS [Volume],
	0 AS [MontantDejaPaye],
	0 AS [PourcentageDuMontant],
	I.Taux AS [Taux],
	0 AS [Montant]
	FROM Livraison L 
		INNER JOIN Livraison_Detail LD  ON LD.LivraisonID = L.[ID]
		INNER JOIN @IndexationProducteurMontant I ON I.ContratID = L.ContratID AND I.EssenceID = LD.EssenceID AND I.Code = LD.Code AND I.UniteID = LD.UniteMesureID
		INNER JOIN Indexation_EssenceUnite IEU  ON IEU.IndexationID = @IndexationID AND IEU.ContratID = LD.ContratID AND IEU.EssenceID = LD.EssenceID AND IEU.Code = LD.Code AND IEU.UniteID = LD.UniteMesureID
	WHERE
	 ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND (L.Facture = 1)
	AND (LD.ProducteurID IS NOT NULL)
	ORDER BY L.[ID], LD.ProducteurID, I.Montant

	UPDATE @IndexationCalcule_Producteur SET Volume = (CASE WHEN Volume IS NOT NULL THEN Volume ELSE 0 END)
	UPDATE @IndexationCalcule_Producteur SET Taux = (CASE WHEN Taux IS NOT NULL THEN Taux ELSE 0 END)
	UPDATE @IndexationCalcule_Producteur SET Montant = ROUND(Volume * Taux,2)
	
	INSERT INTO IndexationCalcule_Producteur
	(DateCalcul, TypeIndexation, IndexationID, IndexationDetailID, LivraisonID, LivraisonDetailID, ProducteurID, ContratID, EssenceID, Code, UniteID, Volume, MontantDejaPaye, PourcentageDuMontant, Taux, Montant, Facture)
	SELECT
	GetDate(),
	TypeIndexation,
	IndexationID,
	IndexationDetailID,
	LivraisonID,
	LivraisonDetailID,
	ProducteurID,
	ContratID,
	EssenceID,
	Code,
	UniteID,
	Volume,
	MontantDejaPaye,
	PourcentageDuMontant,
	Taux,
	Montant, 
	0
	FROM @IndexationCalcule_Producteur
	where 
		right('00000000000000000000000000000000' + convert(varchar, IndexationID), 32) + '-' + 
		right('00000000000000000000000000000000' + convert(varchar, LivraisonID), 32) in
		(select
			right('00000000000000000000000000000000' + convert(varchar, IndexationID), 32) + '-' + 
			right('00000000000000000000000000000000' + convert(varchar, LivraisonID), 32)	
		from Indexation_Livraison)

	DELETE FROM @IndexationCalcule_Producteur
END

----------------------------------
-- INDEXATION PAR POURCENTAGE
----------------------------------
DECLARE @IndexationPourcentage TABLE
(
	ContratID varchar(10),
	Pourcentage float
)

IF (@IndexationTransporteur = 1)
BEGIN
	DELETE FROM @IndexationCalcule_Transporteur

	INSERT INTO @IndexationPourcentage
	SELECT
	ContratID,
	PourcentageDuMontant
	FROM Indexation 
	WHERE [ID] = @IndexationID

	AND (TypeIndexation = 'P')
	AND ((PourcentageDuMontant IS NOT NULL) AND (PourcentageDuMontant <> 0))
	ORDER BY ContratID, PourcentageDuMontant

	INSERT INTO @IndexationCalcule_Transporteur
	SELECT
	'P',
	@IndexationID AS [IndexationID],
	NULL AS [IndexationDetailID],
	L.[ID] AS [LivraisonID],
	L.TransporteurID AS [TransporteurID],
	L.Montant_Transporteur AS [MontantDejaPaye],
	I.Pourcentage AS [PourcentageDuMontant],
	ROUND((L.Montant_Transporteur * I.Pourcentage),2) AS [Montant]
	FROM Livraison L 
		INNER JOIN @IndexationPourcentage I ON I.ContratID = L.ContratID
		INNER JOIN Indexation  ON Indexation.[ID] = @IndexationID
	WHERE
	 ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND (L.Facture = 1)
	--ORDER BY L.[ID], L.TransporteurID, L.Montant_Transporteur

	INSERT INTO IndexationCalcule_Transporteur
	(DateCalcul, TypeIndexation, IndexationID, IndexationDetailID, LivraisonID, TransporteurID, MontantDejaPaye, PourcentageDuMontant, Montant, Facture)
	SELECT
	GetDate(),
	TypeIndexation,
	IndexationID,
	IndexationDetailID,
	LivraisonID,
	TransporteurID,
	MontantDejaPaye, 
	PourcentageDuMontant,
	Montant, 
	0
	FROM @IndexationCalcule_Transporteur
	where 
		right('00000000000000000000000000000000' + convert(varchar, IndexationID), 32) + '-' + 
		right('00000000000000000000000000000000' + convert(varchar, LivraisonID), 32) in
		(select
			right('00000000000000000000000000000000' + convert(varchar, IndexationID), 32) + '-' + 
			right('00000000000000000000000000000000' + convert(varchar, LivraisonID), 32)	
		from Indexation_Livraison)
END
ELSE
BEGIN
	DELETE FROM @IndexationCalcule_Producteur

	INSERT INTO @IndexationPourcentage
	SELECT
	ContratID,
	PourcentageDuMontant
	FROM Indexation 
	WHERE [ID] = @IndexationID
	AND (TypeIndexation = 'P')
	AND ((PourcentageDuMontant IS NOT NULL) AND (PourcentageDuMontant <> 0))
	ORDER BY ContratID, PourcentageDuMontant

	INSERT INTO @IndexationCalcule_Producteur
	SELECT
	'P',
	@IndexationID AS [IndexationID],
	NULL AS [IndexationDetailID],
	L.[ID] AS [LivraisonID],
	NULL AS [LivraisonDetailID],
	L.DroitCoupeID AS [ProducteurID],
	L.ContratID,
	NULL AS [EssenceID],
	NULL AS [Code],
	NULL AS [UniteID],
	NULL AS [Volume],
	L.Montant_Producteur1 AS [MontantDejaPaye],
	I.Pourcentage AS [PourcentageDuMontant],
	NULL AS [Taux],
	ROUND((L.Montant_Producteur1 * I.Pourcentage),2) AS [Montant]
	FROM Livraison L 
		INNER JOIN @IndexationPourcentage I ON I.ContratID = L.ContratID
		INNER JOIN Indexation  ON Indexation.[ID] = @IndexationID
	WHERE 
	l.id>=161350 and -- livraison apres 2018-04-01
	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND L.DroitCoupeID IS NOT NULL
	AND (L.Facture = 1)
	ORDER BY L.[ID], L.DroitCoupeID, L.Montant_Producteur1
	
	INSERT INTO @IndexationCalcule_Producteur
	SELECT
	'P',
	@IndexationID AS [IndexationID],
	NULL AS [IndexationDetailID],
	L.[ID] AS [LivraisonID],
	NULL AS [LivraisonDetailID],
	L.EntentePaiementID AS [ProducteurID],
	L.ContratID,
	NULL AS [EssenceID],
	NULL AS [Code],
	NULL AS [UniteID],
	NULL AS [Volume],
	L.Montant_Producteur2 AS [MontantDejaPaye],
	I.Pourcentage AS [PourcentageDuMontant],
	NULL AS [Taux],
	ROUND((L.Montant_Producteur2 * I.Pourcentage),2) AS [Montant]
	FROM Livraison L 
		INNER JOIN @IndexationPourcentage I ON I.ContratID = L.ContratID
		INNER JOIN Indexation   ON Indexation.[ID] = @IndexationID
	WHERE ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND L.EntentePaiementID IS NOT NULL
	AND (L.Facture = 1)
	ORDER BY L.[ID], L.EntentePaiementID, L.Montant_Producteur1
	
	INSERT INTO IndexationCalcule_Producteur
	(DateCalcul, TypeIndexation, IndexationID, IndexationDetailID, LivraisonID, LivraisonDetailID, ProducteurID, ContratID, EssenceID, Code, UniteID, Volume, MontantDejaPaye, PourcentageDuMontant, Taux, Montant, Facture)
	SELECT
	GetDate(),
	TypeIndexation,
	IndexationID,
	IndexationDetailID,
	LivraisonID,
	LivraisonDetailID,
	ProducteurID,
	ContratID,
	EssenceID,
	Code,
	UniteID,
	Volume,
	MontantDejaPaye, 
	PourcentageDuMontant,
	Taux,
	Montant, 
	0
	FROM @IndexationCalcule_Producteur
	where 
		right('00000000000000000000000000000000' + convert(varchar, IndexationID), 32) + '-' + 
		right('00000000000000000000000000000000' + convert(varchar, LivraisonID), 32) in
		(select
			right('00000000000000000000000000000000' + convert(varchar, IndexationID), 32) + '-' + 
			right('00000000000000000000000000000000' + convert(varchar, LivraisonID), 32)	
		from Indexation_Livraison)
END

