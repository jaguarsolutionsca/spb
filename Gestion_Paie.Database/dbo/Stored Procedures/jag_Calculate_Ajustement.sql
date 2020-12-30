


CREATE PROCEDURE [dbo].[jag_Calculate_Ajustement]
	(
		@AjustementID int
	)
AS

SET NOCOUNT ON

declare @Facture bit
select @Facture = Facture FROM Ajustement WHERE [ID] = @AjustementID

IF (@Facture = 1)
BEGIN
	RETURN
END

EXEC jag_EffacerCalculs_Ajustement @AjustementID

declare @UsePeriodes bit
declare @PeriodeDebut int
declare @AnneeDebut int
declare @PeriodeFin int
declare @AnneeFin int
declare @DateDebut smalldatetime
declare @DateFin smalldatetime

SELECT @UsePeriodes = UsePeriodes FROM Ajustement WHERE Ajustement.[ID] = @AjustementID
SET @UsePeriodes = (CASE WHEN @UsePeriodes IS NOT NULL THEN @UsePeriodes ELSE 0 END)

if (@UsePeriodes = 1)
BEGIN
	SELECT
	@PeriodeDebut = Periode_Debut,
	@AnneeDebut = Contrat.Annee,
	@PeriodeFin = Periode_Fin,
	@AnneeFin = Contrat.Annee
	FROM Ajustement
		INNER JOIN Contrat on Contrat.[ID] = ContratID
	WHERE Ajustement.[ID] = @AjustementID
END
ELSE
BEGIN
	SELECT
	@DateDebut = Date_Debut,
	@DateFin = Date_Fin
	FROM Ajustement
	WHERE Ajustement.[ID] = @AjustementID
END

----------------------------------
-- AJUSTEMENTS USINE
----------------------------------
DECLARE @AjustementUsine TABLE
(
	ID int,
	ContratID varchar(10),
	EssenceID varchar(6),
	Code char(4),
	UniteID varchar(6),
	Taux_usine float
)

DECLARE @AjustementUsine_Calculs TABLE
(
	AjustementID int,
	EssenceID varchar(6),
	Code char(4),
	UniteID varchar(6),
	LivraisonDetailID int,
	UsineID varchar(6),
	Volume float,
	Taux float,
	Montant float
)

INSERT INTO @AjustementUsine
SELECT
AjustementID,
ContratID,
EssenceID,
Code,
UniteID,
Taux_usine
FROM Ajustement_EssenceUnite
WHERE AjustementID = @AjustementID
AND ((Taux_usine IS NOT NULL) AND (Taux_usine <> 0))
ORDER BY ContratID, EssenceID, UniteID, Taux_usine

if (@UsePeriodes = 1)
BEGIN
	INSERT INTO @AjustementUsine_Calculs
	SELECT
	@AjustementID AS [AjustementID],
	A.EssenceID AS [EssenceID],
	A.Code AS [Code],
	A.UniteID AS [UniteID],
	LD.[ID] AS [LivraisonDetailID],
	C.UsineID AS [UsineID],
	LD.VolumeNet AS [Volume],
	A.Taux_usine AS [Taux],
	ROUND((LD.VolumeNet * A.Taux_usine),2) AS [Montant]
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
		INNER JOIN @AjustementUsine A ON A.ContratID = LD.ContratID AND A.EssenceID = LD.EssenceID AND A.Code = LD.Code AND A.UniteID = LD.UniteMesureID
INNER JOIN Ajustement Aj on A.ID = Aj.ID 
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	WHERE ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND ((LD.VolumeNet IS NOT NULL) AND (LD.VolumeNet <> 0))
AND ((Aj.ProducteurID IS NULL) OR (LD.ProducteurID = Aj.ProducteurID))
	AND (L.Facture = 1)
	ORDER BY LD.[ID], A.EssenceID, A.UniteID, LD.VolumeNet
END
ELSE
BEGIN
	INSERT INTO @AjustementUsine_Calculs
	SELECT
	@AjustementID AS [AjustementID],
	A.EssenceID AS [EssenceID],
	A.Code AS [Code],
	A.UniteID AS [UniteID],
	LD.[ID] AS [LivraisonDetailID],
	C.UsineID AS [UsineID],
	LD.VolumeNet AS [Volume],
	A.Taux_usine AS [Taux],
	ROUND((LD.VolumeNet * A.Taux_usine),2) AS [Montant]
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
		INNER JOIN @AjustementUsine A ON A.ContratID = LD.ContratID AND A.EssenceID = LD.EssenceID AND A.Code = LD.Code AND A.UniteID = LD.UniteMesureID
INNER JOIN Ajustement Aj on A.ID = Aj.ID 
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	WHERE ((L.DateLivraison >= @datedebut) AND (L.DateLivraison <= @datefin))
	AND ((LD.VolumeNet IS NOT NULL) AND (LD.VolumeNet <> 0))
AND ((Aj.ProducteurID IS NULL) OR (LD.ProducteurID = Aj.ProducteurID))
	AND (L.Facture = 1)
	ORDER BY LD.[ID], A.EssenceID, A.UniteID, LD.VolumeNet
END

INSERT INTO AjustementCalcule_Usine
(DateCalcul, AjustementID, EssenceID, Code, UniteID, LivraisonDetailID, UsineID, Volume, Taux, Montant, Facture)
SELECT
GetDate(),
AjustementID,
EssenceID,
Code,
UniteID,
LivraisonDetailID,
UsineID,
Volume, 
Taux,
Montant, 
0
FROM @AjustementUsine_Calculs

----------------------------------
-- AJUSTEMENTS PRODUCTEUR
----------------------------------
DECLARE @AjustementProducteur TABLE
(
	ContratID varchar(10),
	EssenceID varchar(6),
	Code char(4),
	UniteID varchar(6),
	Taux_producteur float
)

DECLARE @AjustementProducteur_Calculs TABLE
(
	AjustementID int,
	EssenceID varchar(6),
	Code char(4),
	UniteID varchar(6),
	LivraisonDetailID int,
	ProducteurID varchar(15),
	Volume float,
	Taux float,
	Montant float
)

INSERT INTO @AjustementProducteur
SELECT
AEU.ContratID,
AEU.EssenceID,
AEU.Code,
AEU.UniteID,
AEU.Taux_producteur
FROM Ajustement_EssenceUnite AEU
WHERE AEU.AjustementID = @AjustementID
AND ((AEU.Taux_producteur IS NOT NULL) AND (AEU.Taux_producteur <> 0))
ORDER BY AEU.ContratID, AEU.EssenceID, AEU.UniteID, AEU.Taux_producteur

if (@UsePeriodes = 1)
BEGIN
	INSERT INTO @AjustementProducteur_Calculs
	SELECT
	@AjustementID AS [AjustementID],
	A.EssenceID AS [EssenceID],
	A.Code AS [Code],
	A.UniteID AS [UniteID],
	LD.[ID] AS [LivraisonDetailID],
	LD.ProducteurID AS [ProducteurID],
	LD.VolumeNet AS [Volume],
	A.Taux_producteur AS [Taux],
	ROUND((LD.VolumeNet * A.Taux_producteur),2) AS [Montant]
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
		INNER JOIN @AjustementProducteur A ON A.ContratID = LD.ContratID AND A.EssenceID = LD.EssenceID AND A.Code = LD.Code AND A.UniteID = LD.UniteMesureID
		INNER JOIN Ajustement Aj ON Aj.[ID] = @AjustementID
	WHERE ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND ((LD.VolumeNet IS NOT NULL) AND (LD.VolumeNet <> 0))
	AND (L.Facture = 1)
	AND ((Aj.ProducteurID IS NULL) OR (LD.ProducteurID = Aj.ProducteurID))
	ORDER BY LD.[ID], A.EssenceID, A.UniteID, LD.VolumeNet
END
ELSE
BEGIN
	INSERT INTO @AjustementProducteur_Calculs
	SELECT
	@AjustementID AS [AjustementID],
	A.EssenceID AS [EssenceID],
	A.Code AS [Code],
	A.UniteID AS [UniteID],
	LD.[ID] AS [LivraisonDetailID],
	LD.ProducteurID AS [ProducteurID],
	LD.VolumeNet AS [Volume],
	A.Taux_producteur AS [Taux],
	ROUND((LD.VolumeNet * A.Taux_producteur),2) AS [Montant]
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
		INNER JOIN @AjustementProducteur A ON A.ContratID = LD.ContratID AND A.EssenceID = LD.EssenceID AND A.Code = LD.Code AND A.UniteID = LD.UniteMesureID
		INNER JOIN Ajustement Aj ON Aj.[ID] = @AjustementID
	WHERE ((L.DateLivraison >= @datedebut) AND (L.DateLivraison <= @datefin))
	AND ((LD.VolumeNet IS NOT NULL) AND (LD.VolumeNet <> 0))
	AND (L.Facture = 1)
	AND ((Aj.ProducteurID IS NULL) OR (LD.ProducteurID = Aj.ProducteurID))
	ORDER BY LD.[ID], A.EssenceID, A.UniteID, LD.VolumeNet
END

INSERT INTO AjustementCalcule_Producteur
(DateCalcul, AjustementID, EssenceID, Code, UniteID, LivraisonDetailID, ProducteurID, Volume, Taux, Montant, Facture)
SELECT
GetDate(),
AjustementID,
EssenceID,
Code,
UniteID,
LivraisonDetailID,
ProducteurID,
Volume, 
Taux,
Montant, 
0
FROM @AjustementProducteur_Calculs


----------------------------------
-- AJUSTEMENTS TRANSPORTEUR
----------------------------------
DECLARE @AjustementTransporteur TABLE
(
	ContratID varchar(10),
	UniteID varchar(6),
	MunicipaliteID varchar(6),
	ZoneID varchar(2),		
	Taux_transporteur float
)

DECLARE @AjustementTransporteur_Calculs TABLE
(
	AjustementID int,
	UniteID varchar(6),
	MunicipaliteID varchar(6),
	ZoneID varchar(2),
	LivraisonID int,
	TransporteurID varchar(15),
	Volume float,
	Taux float,
	Montant float
)

INSERT INTO @AjustementTransporteur
SELECT
ContratID,
UniteID,
MunicipaliteID,
ZoneID,
Taux_transporteur
FROM Ajustement_Transporteur
WHERE AjustementID = @AjustementID AND ((Taux_transporteur IS NOT NULL) AND (Taux_transporteur <> 0))
ORDER BY ContratID, UniteID, MunicipaliteID, Taux_transporteur

if (@UsePeriodes = 1)
BEGIN
	INSERT INTO @AjustementTransporteur_Calculs
	SELECT
	@AjustementID AS [AjustementID],
	A.UniteID AS [UniteID],
	L.MunicipaliteID AS [MunicipaliteID],
	L.ZoneID AS [ZoneID],
	L.[ID] AS [LivraisonID],
	L.TransporteurID AS [TransporteurID],
	L.VolumeAPayer AS [Volume],
	A.Taux_transporteur AS [Taux],
	ROUND((L.VolumeAPayer * A.Taux_transporteur),2) AS [Montant]
	FROM Livraison L
		--inner join Lot Lo on Lo.ID = L.LotID
		INNER JOIN @AjustementTransporteur A ON A.ContratID = L.ContratID AND A.UniteID = L.UniteMesureID AND A.MunicipaliteID = L.MunicipaliteID AND A.ZoneID = L.ZoneID
		INNER JOIN Ajustement Aj ON Aj.[ID] = @AjustementID
	WHERE ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND ((L.VolumeAPayer IS NOT NULL) AND (L.VolumeAPayer <> 0))
	AND (L.Facture = 1)
	AND (L.TransporteurID IS NOT NULL)
	AND ((Aj.TransporteurID IS NULL) OR (L.TransporteurID = Aj.TransporteurID))
	ORDER BY L.[ID], A.UniteID, L.MunicipaliteID, L.VolumeAPayer
END
ELSE
BEGIN
	INSERT INTO @AjustementTransporteur_Calculs
	SELECT
	@AjustementID AS [AjustementID],
	A.UniteID AS [UniteID],
	L.MunicipaliteID AS [MunicipaliteID],
	L.ZoneID AS [ZoneID],
	L.[ID] AS [LivraisonID],
	L.TransporteurID AS [TransporteurID],
	L.VolumeAPayer AS [Volume],
	A.Taux_transporteur AS [Taux],
	ROUND((L.VolumeAPayer * A.Taux_transporteur),2) AS [Montant]
	FROM Livraison L
		--inner join Lot Lo on Lo.ID = L.LotID
		INNER JOIN @AjustementTransporteur A ON A.ContratID = L.ContratID AND A.UniteID = L.UniteMesureID AND A.MunicipaliteID = L.MunicipaliteID AND A.ZoneID = L.ZoneID
		INNER JOIN Ajustement Aj ON Aj.[ID] = @AjustementID
	WHERE ((L.DateLivraison >= @datedebut) AND (L.DateLivraison <= @datefin))
	AND ((L.VolumeAPayer IS NOT NULL) AND (L.VolumeAPayer <> 0))
	AND (L.Facture = 1)
	AND (L.TransporteurID IS NOT NULL)
	AND ((Aj.TransporteurID IS NULL) OR (L.TransporteurID = Aj.TransporteurID))
	ORDER BY L.[ID], A.UniteID, L.MunicipaliteID, L.VolumeAPayer
END

INSERT INTO AjustementCalcule_Transporteur
(DateCalcul, AjustementID, UniteID, MunicipaliteID, ZoneID, LivraisonID, TransporteurID, Volume, Taux, Montant, Facture)
SELECT
GetDate(),
AjustementID,
UniteID,
MunicipaliteID,
ZoneID,
LivraisonID,
TransporteurID,
Volume, 
Taux,
Montant, 
0
FROM @AjustementTransporteur_Calculs


----------------------------------
-- AJUSTEMENTS Transporteur Essence
----------------------------------
DECLARE @AjustementTransporteurEssence TABLE
(
	ContratID varchar(10),
	EssenceID varchar(6),
	Code char(4),
	UniteID varchar(6),
	Taux_transporteur float
)

DECLARE @AjustementTransporteurEssence_Calculs TABLE
(
	AjustementID int,
	EssenceID varchar(6),
	Code char(4),
	UniteID varchar(6),
	LivraisonDetailID int,
	TransporteurID varchar(15),
	Volume float,
	Taux float,
	Montant float
)

INSERT INTO @AjustementTransporteurEssence
SELECT
AEU.ContratID,
AEU.EssenceID,
AEU.Code,
AEU.UniteID,
AEU.Taux_transporteur
FROM Ajustement_EssenceUnite AEU
WHERE AEU.AjustementID = @AjustementID
AND ((AEU.Taux_transporteur IS NOT NULL) AND (AEU.Taux_transporteur <> 0))
ORDER BY AEU.ContratID, AEU.EssenceID, AEU.UniteID, AEU.Taux_transporteur

if (@UsePeriodes = 1)
BEGIN
	INSERT INTO @AjustementTransporteurEssence_Calculs
	SELECT
	@AjustementID AS [AjustementID],
	A.EssenceID AS [EssenceID],
	A.Code AS [Code],
	A.UniteID AS [UniteID],
	LD.[ID] AS [LivraisonDetailID],
	L.TransporteurID AS [TransporteurID],
	LD.VolumeNet AS [Volume],
	A.Taux_transporteur AS [Taux],
	ROUND((LD.VolumeNet * A.Taux_transporteur),2) AS [Montant]
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
		INNER JOIN @AjustementTransporteurEssence A ON A.ContratID = LD.ContratID AND A.EssenceID = LD.EssenceID AND A.Code = LD.Code AND A.UniteID = LD.UniteMesureID
		INNER JOIN Ajustement Aj ON Aj.[ID] = @AjustementID
	WHERE ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) )
	AND	( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	
	AND ((LD.VolumeNet IS NOT NULL) AND (LD.VolumeNet <> 0))
	AND (L.Facture = 1)
	AND ((Aj.TransporteurID IS NULL) OR (L.TransporteurID = Aj.TransporteurID))
	ORDER BY LD.[ID], A.EssenceID, A.UniteID, LD.VolumeNet
END
ELSE
BEGIN
	INSERT INTO @AjustementTransporteurEssence_Calculs
	SELECT
	@AjustementID AS [AjustementID],
	A.EssenceID AS [EssenceID],
	A.Code AS [Code],
	A.UniteID AS [UniteID],
	LD.[ID] AS [LivraisonDetailID],
	L.TransporteurID AS [TransporteurID],
	LD.VolumeNet AS [Volume],
	A.Taux_transporteur AS [Taux],
	ROUND((LD.VolumeNet * A.Taux_transporteur),2) AS [Montant]
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
		INNER JOIN @AjustementTransporteurEssence A ON A.ContratID = LD.ContratID AND A.EssenceID = LD.EssenceID AND A.Code = LD.Code AND A.UniteID = LD.UniteMesureID
		INNER JOIN Ajustement Aj ON Aj.[ID] = @AjustementID
	WHERE ((L.DateLivraison >= @datedebut) AND (L.DateLivraison <= @datefin))
	AND ((LD.VolumeNet IS NOT NULL) AND (LD.VolumeNet <> 0))
	AND (L.Facture = 1)
	AND ((Aj.TransporteurID IS NULL) OR (L.TransporteurID = Aj.TransporteurID))
	ORDER BY LD.[ID], A.EssenceID, A.UniteID, LD.VolumeNet
END

INSERT INTO AjustementCalcule_TransporteurEssence
(DateCalcul, AjustementID, EssenceID, Code, UniteID, LivraisonDetailID, TransporteurID, Volume, Taux, Montant, Facture)
SELECT
GetDate(),
AjustementID,
EssenceID,
Code,
UniteID,
LivraisonDetailID,
TransporteurID,
Volume, 
Taux,
Montant, 
0
FROM @AjustementTransporteurEssence_Calculs
