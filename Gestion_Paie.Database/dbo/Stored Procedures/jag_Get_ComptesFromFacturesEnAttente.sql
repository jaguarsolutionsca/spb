

CREATE PROCEDURE dbo.jag_Get_ComptesFromFacturesEnAttente

AS

SET NOCOUNT ON

DECLARE @Comptes TABLE
(
	[ID] int
)

INSERT INTO @Comptes ([ID])
SELECT DISTINCT
FFS.Compte
FROM FactureFournisseur_Sommaire FFS
	INNER JOIN FactureFournisseur FF ON FF.[ID] = FFS.FactureID
WHERE FFS.Compte IS NOT NULL
AND FF.Status = 'Attente'

INSERT INTO @Comptes ([ID])
SELECT DISTINCT
FCS.Compte
FROM FactureClient_Sommaire FCS
	INNER JOIN FactureClient FC ON FC.[ID] = FCS.FactureID
WHERE FCS.Compte IS NOT NULL
AND FCS.Compte NOT IN (SELECT [ID] FROM @Comptes)
AND FC.Status = 'Attente'

INSERT INTO @Comptes ([ID])
SELECT Compte_Paiements FROM jag_System
WHERE Compte_Paiements NOT IN (SELECT [ID] FROM @Comptes)

INSERT INTO @Comptes ([ID])
SELECT Compte_ARecevoir FROM jag_System
WHERE Compte_ARecevoir NOT IN (SELECT [ID] FROM @Comptes)

INSERT INTO @Comptes ([ID])
SELECT Compte_APayer FROM jag_System
WHERE Compte_APayer NOT IN (SELECT [ID] FROM @Comptes)

INSERT INTO @Comptes ([ID])
SELECT Compte_DuAuxProducteurs FROM jag_System
WHERE Compte_DuAuxProducteurs NOT IN (SELECT [ID] FROM @Comptes)

INSERT INTO @Comptes ([ID])
SELECT Compte_TPSpercues FROM jag_System
WHERE Compte_TPSpercues NOT IN (SELECT [ID] FROM @Comptes)

INSERT INTO @Comptes ([ID])
SELECT Compte_TPSpayees FROM jag_System
WHERE Compte_TPSpayees NOT IN (SELECT [ID] FROM @Comptes)

INSERT INTO @Comptes ([ID])
SELECT Compte_TVQpercues FROM jag_System
WHERE Compte_TVQpercues NOT IN (SELECT [ID] FROM @Comptes)

INSERT INTO @Comptes ([ID])
SELECT Compte_TVQpayees FROM jag_System
WHERE Compte_TVQpayees NOT IN (SELECT [ID] FROM @Comptes)

SELECT
[ID] AS [ID]
FROM @Comptes
ORDER BY [ID]



