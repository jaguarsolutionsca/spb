

CREATE PROCEDURE dbo.jag_Rapport_Contrat_VentillationDesMontants
	(
		@DateDebut SMALLDATETIME,
		@DateFin SMALLDATETIME,
		@UsineID VARCHAR(6),
		@UniteMesureID VARCHAR(6)
	)
AS

SET NOCOUNT ON

DECLARE @LivraisonDetails TABLE
(
	[ID] INT,
	ContratID VARCHAR(10)
)

DECLARE @Livraisons TABLE
(
	[ID] INT
)

DECLARE @Ajustements TABLE
(
	[ID] INT
)

DECLARE @Totaux TABLE
(
	Colonne VARCHAR(15), --1=Usine, 2=Transporteur, 3=Producteur, 4=Chargeur, 5=MiseEnCommun, 6=Preleve, 7=Surcharge
	Montant_Livraison FLOAT,
	Frais_Chargeur FLOAT,
	Frais_Autres FLOAT,
	Frais_CompensationDeplacement FLOAT,
	Frais_AutresRevenus FLOAT,
	Montant_Ajustement FLOAT,
	Montant_Indexation FLOAT,
	Montant_Total FLOAT
)

INSERT INTO @LivraisonDetails
SELECT
LD.[ID],
L.ContratID
FROM Livraison_Detail LD
	INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
--	INNER JOIN FactureFournisseur FF ON FF.[ID] = L.Producteur1_FactureID
WHERE L.Facture = 1
AND ( C.UsineID = @UsineID)
AND ( L.UniteMesureID = @UniteMesureID )
AND ( DATEDIFF(day, @DateDebut, L.DatePaye) >= 0 AND DATEDIFF(day, @DateFin, L.DatePaye) <= 0)
--AND ( DATEDIFF(day, @DateDebut, FF.DateFacture) >= 0 AND DATEDIFF(day, @DateFin, FF.DateFacture) <= 0)

INSERT INTO @Livraisons
SELECT
L.[ID]
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
--	INNER JOIN FactureFournisseur FF ON FF.[ID] = L.Producteur1_FactureID
WHERE L.Facture = 1
AND ( C.UsineID = @UsineID)
AND ( L.UniteMesureID = @UniteMesureID )
AND ( DATEDIFF(day, @DateDebut, L.DatePaye) >= 0 AND DATEDIFF(day, @DateFin, L.DatePaye) <= 0)
--AND ( DATEDIFF(day, @DateDebut, FF.DateFacture) >= 0 AND DATEDIFF(day, @DateFin, FF.DateFacture) <= 0)

DECLARE @Montants TABLE
(
	_EssenceID VARCHAR(6),
	_Code char(4),
	Volume_Usine FLOAT,
	Volume_Reduction FLOAT,
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

DECLARE @MontantsSciage TABLE
(
	Montant_MEC FLOAT
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
UPDATE @Montants SET Montant_Usine = 0 WHERE Montant_Usine IS NULL
UPDATE @Montants SET Montant_Ajustement_Usine = 0 WHERE Montant_Ajustement_Usine IS NULL
UPDATE @Montants SET Montant_Producteur = 0 WHERE Montant_Producteur IS NULL
UPDATE @Montants SET Montant_Ajustement_Producteur = 0 WHERE Montant_Ajustement_Producteur IS NULL
UPDATE @Montants SET Montant_Preleve_Plan_Conjoint = 0 WHERE Montant_Preleve_Plan_Conjoint IS NULL
UPDATE @Montants SET Montant_Preleve_Fond_Roulement = 0 WHERE Montant_Preleve_Fond_Roulement IS NULL
UPDATE @Montants SET Montant_Preleve_Fond_Forestier = 0 WHERE Montant_Preleve_Fond_Forestier IS NULL
UPDATE @Montants SET Montant_Preleve_Divers = 0 WHERE Montant_Preleve_Divers IS NULL
UPDATE @Montants SET Montant_MEC = 0 WHERE Montant_MEC IS NULL

--Montants Sciage
INSERT INTO @MontantsSciage (Montant_MEC)
SELECT 0

UPDATE @MontantsSciage SET
Montant_MEC = (
	SELECT
	ROUND(SUM(L.Montant_MiseEnCommun),2)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	AND L.UniteMesureID = @UniteMesureID
	AND L.Sciage = 1
)

UPDATE @MontantsSciage SET Montant_MEC = 0 WHERE Montant_MEC IS NULL

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

INSERT INTO @Totaux (Colonne) VALUES (1)
INSERT INTO @Totaux (Colonne) VALUES (2)
INSERT INTO @Totaux (Colonne) VALUES (3)
INSERT INTO @Totaux (Colonne) VALUES (4)
INSERT INTO @Totaux (Colonne) VALUES (5)
INSERT INTO @Totaux (Colonne) VALUES (6)
INSERT INTO @Totaux (Colonne) VALUES (7)


UPDATE @Totaux SET
Montant_Livraison = (
	SELECT
	SUM(L.Montant_Transporteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 2

UPDATE @Totaux SET
Montant_Livraison = (
	SELECT
	SUM(L.Montant_Producteur1 + L.Montant_Producteur2)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 3

UPDATE @Totaux SET
Montant_Livraison = (
	SELECT
	SUM(L.Montant_Chargeur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 4

UPDATE @Totaux SET
Montant_Livraison = (
	SELECT
	SUM(L.Montant_Preleve_Plan_Conjoint + L.Montant_Preleve_Fond_Roulement + L.Montant_Preleve_Fond_Forestier + L.Montant_Preleve_Divers)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 6

UPDATE @Totaux SET
Montant_Livraison = (
	SELECT
	SUM(Montant_Surcharge + Montant_SurchargeProducteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 7

UPDATE @Totaux SET
Montant_Livraison = (
	SELECT
	SUM(L.Montant_Usine)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 1

UPDATE @Totaux SET
Montant_Livraison = (
	SELECT
	SUM(L.Montant_MiseEnCommun)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 5


--TOTAUX FRAIS
UPDATE @Totaux SET 
Frais_Autres = (
	SELECT
	-1 * SUM(Frais_AutresAuTransporteur + Frais_AutresAuProducteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 1

UPDATE @Totaux SET 
Frais_AutresRevenus = (
	SELECT
	SUM(Frais_AutresRevenusTransporteur)+SUM(Frais_AutresRevenusProducteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 1

UPDATE @Totaux SET 
Frais_Chargeur = (
	SELECT
	-1 * SUM(Frais_ChargeurAuTransporteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 2

UPDATE @Totaux SET 
Frais_Chargeur = (
	SELECT
	-1 * SUM(Frais_ChargeurAuProducteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 3

UPDATE @Totaux SET 
Frais_Autres = -1 * (
	SELECT
	SUM(Frais_AutresAuTransporteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 2

UPDATE @Totaux SET 
Frais_Autres = (
	SELECT
	-1 * SUM(Frais_AutresAuProducteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 3

UPDATE @Totaux SET 
Frais_CompensationDeplacement = (
	SELECT
	SUM(Frais_CompensationDeDeplacement)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 2

UPDATE @Totaux SET 
Frais_CompensationDeplacement = (
	SELECT
	-1 * SUM(Frais_CompensationDeDeplacement)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 3

UPDATE @Totaux SET 
Frais_AutresRevenus = (
	SELECT
	SUM(Frais_AutresRevenusTransporteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 2

UPDATE @Totaux SET 
Frais_AutresRevenus = (
	SELECT
	SUM(Frais_AutresRevenusProducteur)
	FROM Livraison L
	WHERE L.[ID] IN (SELECT [ID] FROM @Livraisons)
	)
WHERE Colonne = 3

--TOTAUX Ajustements
DELETE @Ajustements
INSERT INTO @Ajustements
SELECT
A.[ID]
FROM Ajustement A
	INNER JOIN Contrat C ON C.[ID] = A.ContratID
WHERE A.Facture = 1
AND ( C.UsineID = @UsineID )
AND ( DATEDIFF(day, @DateDebut, A.DateAjustement) >= 0 AND DATEDIFF(day, @DateFin, A.DateAjustement) <= 0)

UPDATE @Totaux SET
Montant_Ajustement = (
	SELECT
	SUM(Montant)
	FROM AjustementCalcule_Transporteur ACT
	WHERE ACT.LivraisonID IN (SELECT [ID] FROM @Livraisons)
--	WHERE ACT.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 2
UPDATE @Totaux SET Montant_Ajustement = 0 WHERE Montant_Ajustement IS NULL AND Colonne = 2

UPDATE @Totaux SET
Montant_Ajustement = Montant_Ajustement + (
	SELECT
	(CASE WHEN SUM(Montant) IS NOT NULL THEN (SUM(Montant)) ELSE 0 END)
	FROM AjustementCalcule_TransporteurEssence ACTE
	WHERE ACTE.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
--	WHERE ACU.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 2
UPDATE @Totaux SET Montant_Ajustement = 0 WHERE Montant_Ajustement IS NULL AND Colonne = 2


UPDATE @Totaux SET
Montant_Indexation = (
	SELECT
	SUM(Montant)
	FROM IndexationCalcule_Transporteur ICT
	WHERE ICT.LivraisonID IN (SELECT [ID] FROM @Livraisons)
--	WHERE ACT.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 2

UPDATE @Totaux SET
Montant_Ajustement = (
	SELECT
	SUM(Montant)
	FROM AjustementCalcule_Producteur ACP
	WHERE ACP.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
--	WHERE ACP.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 3

UPDATE @Totaux SET
Montant_Indexation = (
	SELECT
	SUM(Montant)
	FROM IndexationCalcule_Producteur ICP
	WHERE ICP.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
--	WHERE ACP.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 3

UPDATE @Totaux SET
Montant_Ajustement = (
	SELECT
	SUM(Montant)
	FROM AjustementCalcule_Usine ACU
	WHERE ACU.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
--	WHERE ACU.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 1

UPDATE @Totaux SET
Montant_Ajustement = (
	SELECT
	(CASE WHEN SUM(Montant) IS NOT NULL THEN (-1 * SUM(Montant)) ELSE 0 END)
	FROM AjustementCalcule_Producteur ACP
	WHERE ACP.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
--	WHERE ACU.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 5
UPDATE @Totaux SET Montant_Ajustement = 0 WHERE Montant_Ajustement IS NULL AND Colonne = 5

UPDATE @Totaux SET
Montant_Ajustement = Montant_Ajustement + (
	SELECT
	(CASE WHEN SUM(Montant) IS NOT NULL THEN (-1 * SUM(Montant)) ELSE 0 END)
	FROM AjustementCalcule_Transporteur ACT
	WHERE ACT.LivraisonID IN (SELECT [ID] FROM @Livraisons)
--	WHERE ACU.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 5
UPDATE @Totaux SET Montant_Ajustement = 0 WHERE Montant_Ajustement IS NULL AND Colonne = 5

UPDATE @Totaux SET
Montant_Ajustement = Montant_Ajustement + (
	SELECT
	(CASE WHEN SUM(Montant) IS NOT NULL THEN (-1 * SUM(Montant)) ELSE 0 END)
	FROM AjustementCalcule_TransporteurEssence ACTE
	WHERE ACTE.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
--	WHERE ACU.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 5
UPDATE @Totaux SET Montant_Ajustement = 0 WHERE Montant_Ajustement IS NULL AND Colonne = 5


UPDATE @Totaux SET
Montant_Ajustement = Montant_Ajustement + (
	SELECT
	(CASE WHEN SUM(Montant) IS NOT NULL THEN SUM(Montant) ELSE 0 END)
	FROM AjustementCalcule_Usine ACU
	WHERE ACU.LivraisonDetailID IN (SELECT [ID] FROM @LivraisonDetails)
--	WHERE ACU.[AjustementID] IN (SELECT [ID] FROM @Ajustements)
	)
WHERE Colonne = 5
UPDATE @Totaux SET Montant_Ajustement = 0 WHERE Montant_Ajustement IS NULL AND Colonne = 5

-- liste des fournisseurs/Usines qui recoivent/paient des taxes
declare @ProducteurRecoitTPS table
(
	ID varchar(16)
)
insert into @ProducteurRecoitTPS 
select ID from Fournisseur where RecoitTPS = 1
   
declare @ProducteurRecoitTVQ table
(
	ID varchar(16)
)
insert into @ProducteurRecoitTVQ 
select ID from Fournisseur where RecoitTVQ = 1

declare @UsinePaieTPS table
(
	ID varchar(16)
)
insert into @UsinePaieTPS 
select ID from Usine where NePaiePasTPS <> 1
   
declare @UsinePaieTVQ table
(
	ID varchar(16)
)
insert into @UsinePaieTVQ 
select ID from Usine where NePaiePasTVQ <> 1

UPDATE @Totaux SET Montant_Livraison = 0 WHERE Montant_Livraison IS NULL
UPDATE @Totaux SET Frais_Chargeur = 0 WHERE Frais_Chargeur IS NULL
UPDATE @Totaux SET Frais_Autres = 0 WHERE Frais_Autres IS NULL
UPDATE @Totaux SET Frais_CompensationDeplacement = 0 WHERE Frais_CompensationDeplacement IS NULL
UPDATE @Totaux SET Frais_AutresRevenus = 0 WHERE Frais_AutresRevenus IS NULL
UPDATE @Totaux SET Montant_Ajustement = 0 WHERE Montant_Ajustement IS NULL
UPDATE @Totaux SET Montant_Indexation = 0 WHERE Montant_Indexation IS NULL

UPDATE @Totaux SET
Montant_Total = ROUND((Montant_Livraison + Montant_Ajustement + Montant_Indexation + Frais_Chargeur + Frais_Autres + Frais_CompensationDeplacement + Frais_AutresRevenus),2)

SELECT 
@UsineID AS [UsineID],
(SELECT [Description] FROM Usine WHERE Usine.[ID] = @UsineID) AS [Usine],
@UniteMesureID AS [UniteMesureID],
(SELECT [Description] FROM UniteMesure WHERE [ID] = @UniteMesureID) AS [Unite],
_EssenceID + ' ' + LTRIM(RTRIM(_Code)) AS [EssenceID],
E.[Description] AS [Essence],
Volume_Usine,
Volume_Reduction,
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
	
SELECT
Montant_MEC
FROM @MontantsSciage

UPDATE @Totaux SET Montant_Livraison = 0 WHERE Montant_Livraison IS NULL
UPDATE @Totaux SET Montant_Ajustement = 0 WHERE Montant_Ajustement IS NULL
UPDATE @Totaux SET Montant_Total = 0 WHERE Montant_Total IS NULL

SELECT 
* 
FROM @Totaux
ORDER BY Colonne
