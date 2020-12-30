create PROCEDURE [dbo].[jag_Rapport_Contrat_VentillationDesMontants_Excel]
	(
		@DateDebut SMALLDATETIME,
		@DateFin SMALLDATETIME,
		@UsineID VARCHAR(6),
		@UniteMesureID VARCHAR(6)
	)
AS

SET NOCOUNT ON



--Declare	@DateDebut SMALLDATETIME,
--		@DateFin SMALLDATETIME,
--		@UsineID VARCHAR(6),
--		@UniteMesureID VARCHAR(6)


--set		@DateDebut='2018-01-01 00:00:00'
--set		@DateFin='2018-12-31 00:00:00'
--set		@UsineID='ACER'
--set		@UniteMesureID='MPMP'


DECLARE @LivraisonDetails TABLE
(
	[ID] INT,
	ContratID VARCHAR(10)
)

DECLARE @Livraisons TABLE
(
	[ID] INT
)


INSERT INTO @LivraisonDetails
SELECT
LD.[ID],
L.ContratID
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE L.Facture = 1
AND ( C.UsineID = @UsineID)
AND ( L.UniteMesureID = @UniteMesureID )
AND ( DATEDIFF(day, @DateDebut, L.DatePaye) >= 0 AND DATEDIFF(day, @DateFin, L.DatePaye) <= 0)

INSERT INTO @Livraisons
SELECT
L.[ID]
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE L.Facture = 1
AND ( C.UsineID = @UsineID)
AND ( L.UniteMesureID = @UniteMesureID )
AND ( DATEDIFF(day, @DateDebut, L.DatePaye) >= 0 AND DATEDIFF(day, @DateFin, L.DatePaye) <= 0)

DECLARE @Montants TABLE
(
	_EssenceID VARCHAR(6),
	_Code char(4),
	Volume_Usine FLOAT,
	Volume_Reduction FLOAT,
	Volume_M3 FLOAT,
	Montant_Usine FLOAT,
	Montant_Ajustement_Usine FLOAT,
	Montant_Producteur FLOAT,
	Montant_Ajustement_Producteur FLOAT,
	Montant_Preleve_Plan_Conjoint FLOAT,
	Montant_Preleve_Fond_Roulement FLOAT,
	Montant_Preleve_Fond_Forestier FLOAT,
	Montant_Preleve_Divers FLOAT
	, Montant_MEC FLOAT
)

INSERT INTO @Montants (_EssenceID, _Code)
SELECT DISTINCT
LD.EssenceID,
LD.Code
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
AND L.UniteMesureID = @UniteMesureID

UPDATE @Montants SET
Volume_Usine = (
	SELECT
	SUM(VolumeNet)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code AND L.UniteMesureID = @UniteMesureID
	),
Volume_Reduction = (
	SELECT
	SUM(VolumeReduction)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code  AND L.UniteMesureID = @UniteMesureID
	),
Volume_M3 = (
	SELECT
	SUM(VolumeNet) * max(EU.Facteur_M3sol)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
		INNER JOIN Essence_Unite EU on EU.EssenceID = LD.EssenceID and EU.UniteID = LD.UniteMesureID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code AND L.UniteMesureID = @UniteMesureID
	),
Montant_Usine = (
	SELECT
	ROUND(SUM(LD.Montant_Usine),2)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code  AND L.UniteMesureID = @UniteMesureID
	),
Montant_Ajustement_Usine = (
	SELECT
	ROUND(SUM(Montant),2)
	FROM AjustementCalcule_Usine ACU
		INNER JOIN Livraison_Detail LD ON LD.[ID] = ACU.[LivraisonDetailID]
	WHERE ACU.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
	AND ACU.EssenceID = _EssenceID AND LD.Code = _Code  AND ACU.UniteID = @UniteMesureID
	),
Montant_Producteur = (
	SELECT
	ROUND(SUM(Montant_ProducteurNet),2)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code  AND L.UniteMesureID = @UniteMesureID
	),
Montant_Ajustement_Producteur = (
	SELECT
	ROUND(SUM(Montant),2)
	FROM AjustementCalcule_Producteur ACP
		INNER JOIN Livraison_Detail LD ON LD.[ID] = ACP.[LivraisonDetailID]
	WHERE ACP.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
	AND ACP.EssenceID = _EssenceID AND LD.Code = _Code  AND ACP.UniteID = @UniteMesureID
	),
Montant_Preleve_Plan_Conjoint = (
	SELECT
	ROUND(SUM(LD.Montant_Preleve_Plan_Conjoint),2)

	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code  AND L.UniteMesureID = @UniteMesureID
	),
Montant_Preleve_Fond_Roulement = (
	SELECT
	ROUND(SUM(LD.Montant_Preleve_Fond_Roulement),2)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code  AND L.UniteMesureID = @UniteMesureID
	),
Montant_Preleve_Fond_Forestier = (
	SELECT
	ROUND(SUM(LD.Montant_Preleve_Fond_Forestier),2)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code  AND L.UniteMesureID = @UniteMesureID
	),
Montant_Preleve_Divers = (
	SELECT
	ROUND(SUM(LD.Montant_Preleve_Divers),2)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.LivraisonID
	WHERE LD.[ID] IN (SELECT [ID] FROM @LivraisonDetails)
	AND LD.EssenceID = _EssenceID AND LD.Code = _Code  AND L.UniteMesureID = @UniteMesureID
	),
Montant_MEC = (
	SELECT
	ROUND(SUM(L.Montant_MiseEnCommun),2)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	AND L.Sciage = 0
	AND L.EssenceID = _EssenceID AND L.Code = _Code  AND L.UniteMesureID = @UniteMesureID
	)
	
UPDATE @Montants SET Volume_Usine = 0 WHERE Volume_Usine IS NULL
UPDATE @Montants SET Volume_Reduction = 0 WHERE Volume_Reduction IS NULL
UPDATE @Montants SET Volume_M3 = 0 WHERE Volume_M3 IS NULL
UPDATE @Montants SET Montant_Usine = 0 WHERE Montant_Usine IS NULL
UPDATE @Montants SET Montant_Ajustement_Usine = 0 WHERE Montant_Ajustement_Usine IS NULL
UPDATE @Montants SET Montant_Producteur = 0 WHERE Montant_Producteur IS NULL
UPDATE @Montants SET Montant_Ajustement_Producteur = 0 WHERE Montant_Ajustement_Producteur IS NULL
UPDATE @Montants SET Montant_Preleve_Plan_Conjoint = 0 WHERE Montant_Preleve_Plan_Conjoint IS NULL
UPDATE @Montants SET Montant_Preleve_Fond_Roulement = 0 WHERE Montant_Preleve_Fond_Roulement IS NULL
UPDATE @Montants SET Montant_Preleve_Fond_Forestier = 0 WHERE Montant_Preleve_Fond_Forestier IS NULL
UPDATE @Montants SET Montant_Preleve_Divers = 0 WHERE Montant_Preleve_Divers IS NULL
UPDATE @Montants SET Montant_MEC = 0 WHERE Montant_MEC IS NULL


--TOTAUX Livraisons
DELETE @Livraisons
INSERT INTO @Livraisons
SELECT
L.[ID]
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE L.Facture = 1
AND ( C.UsineID = @UsineID )
AND ( DATEDIFF(day, @DateDebut, L.DatePaye) >= 0 AND DATEDIFF(day, @DateFin, L.DatePaye) <= 0)

DELETE @LivraisonDetails
INSERT INTO @LivraisonDetails
SELECT
LD.[ID],
L.ContratID
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE L.[ID] in (SELECT [ID] FROM @Livraisons)



SELECT 
@UsineID AS [UsineID],
(SELECT [Description] FROM Usine WHERE Usine.[ID] = @UsineID) AS [Usine],
@UniteMesureID AS [UniteMesureID],
(SELECT [Description] FROM UniteMesure WHERE [ID] = @UniteMesureID) AS [Unite],
_EssenceID + ' ' + LTRIM(RTRIM(_Code)) AS [EssenceID],
E.[Description] AS [Essence],
Volume_Usine,
Volume_Reduction,
Volume_M3,
Montant_Usine,
Montant_Ajustement_Usine,
Montant_Producteur,
Montant_Ajustement_Producteur,
Montant_Preleve_Plan_Conjoint,
Montant_Preleve_Fond_Roulement,
Montant_Preleve_Fond_Forestier,
Montant_Preleve_Divers
, Montant_MEC
FROM @Montants
	INNER JOIN Essence E ON E.[ID] = _EssenceID
	


