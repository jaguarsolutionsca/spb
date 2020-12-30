

CREATE PROCEDURE dbo.jag_Rapport_Facture_RepartitionDesVolumes
	(		
		@DateDebut SMALLDATETIME,
		@DateFin SMALLDATETIME
	)
AS

SET NOCOUNT ON

DECLARE @Factures TABLE
(
	[ID] INT
)

INSERT INTO @Factures
SELECT DISTINCT
[ID]
FROM FactureFournisseur FF
WHERE FF.Status = 'PaiementOK'
AND FF.TypeFactureFournisseur = 'P'
AND FF.TypeFacture = 'L'
AND ((@DateDebut is null) or (DATEDIFF(day, @DateDebut, FF.DateFacture) >= 0))
AND ((@DateFin is null) or (DATEDIFF(day, @DateFin, FF.DateFacture) <= 0))
ORDER BY [ID]

DECLARE @Volumes TABLE
(
	_FactureID INT,
	_ProducteurID VARCHAR(15),
	Volume FLOAT,
	Volume_M3APP FLOAT,
	Volume_M3SOL FLOAT,
	Montant FLOAT
)

INSERT INTO @Volumes (_FactureID, _ProducteurID, Montant)
SELECT
FF.[ID],
FF.FournisseurID,
FF.Montant_Total
FROM FactureFournisseur FF
WHERE FF.[ID] IN (SELECT [ID] FROM @Factures)

UPDATE @Volumes SET
Volume = (
	SELECT
	SUM(LD.VolumeNet)
	FROM FactureFournisseur_Details FFD
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID]
	WHERE FFD.FactureID = _FactureID
	AND LD.ProducteurID = _ProducteurID
	)

UPDATE @Volumes SET
Volume_M3APP = (
	SELECT
	SUM(LD.VolumeNet * EU.Facteur_M3app)
	FROM FactureFournisseur_Details FFD
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID]
		INNER JOIN Essence_Unite EU ON EU.EssenceID = LD.EssenceID AND EU.UniteID = LD.UniteMesureID
	WHERE FFD.FactureID = _FactureID
	AND LD.ProducteurID = _ProducteurID
	)

UPDATE @Volumes SET
Volume_M3SOL = (
	SELECT
	SUM(LD.VolumeNet * EU.Facteur_M3sol)
	FROM FactureFournisseur_Details FFD
		INNER JOIN Livraison L ON L.[ID] = FFD.RefID
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID]
		INNER JOIN Essence_Unite EU ON EU.EssenceID = LD.EssenceID AND EU.UniteID = LD.UniteMesureID
	WHERE FFD.FactureID = _FactureID
	AND LD.ProducteurID = _ProducteurID
	)

SELECT
_ProducteurID AS [ProducteurID],
F.Nom AS [Producteur],
SUM(Volume) AS [Volume],
SUM(Volume_M3APP) AS [Volume_M3APP],
SUM(Volume_M3SOL) AS [Volume_M3SOL],
SUM(Montant) AS [Montant]
FROM @Volumes
	INNER JOIN Fournisseur F ON F.[ID] = _ProducteurID
GROUP BY _ProducteurID, F.Nom
ORDER BY [Producteur]



