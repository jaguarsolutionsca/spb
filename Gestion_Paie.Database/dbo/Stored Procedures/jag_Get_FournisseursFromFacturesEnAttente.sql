

CREATE PROCEDURE dbo.jag_Get_FournisseursFromFacturesEnAttente

AS

SET NOCOUNT ON

DECLARE @Fournisseurs TABLE
(
	[ID] VARCHAR(15)
)

INSERT INTO @Fournisseurs ([ID])
SELECT DISTINCT
FF.FournisseurID
FROM FactureFournisseur FF
WHERE FF.FournisseurID IS NOT NULL
AND FF.Status = 'Attente'

INSERT INTO @Fournisseurs ([ID])
SELECT DISTINCT
FF.PayerAID
FROM FactureFournisseur FF
WHERE FF.PayerAID IS NOT NULL
AND FF.PayerAID NOT IN (SELECT [ID] FROM @Fournisseurs)
AND FF.Status = 'Attente'

SELECT
[ID] AS [ID]
FROM @Fournisseurs
ORDER BY [ID]



