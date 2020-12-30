

CREATE PROCEDURE dbo.jag_GetFactureClient
	(
		@FactureID INT = NULL,
		@TypeFacture CHAR(1) = NULL,
		@Status VARCHAR(15) = NULL
	)
AS

SET NOCOUNT ON

DECLARE @Factures TABLE
(
	[ID] int
)

INSERT INTO @Factures
SELECT
[ID]
FROM FactureClient
WHERE ((@TypeFacture IS NULL) OR (TypeFacture = @TypeFacture))
AND ((@Status IS NULL) OR (Status = @Status))
AND ((@FactureID IS NULL) OR ([ID] = @FactureID))
ORDER BY [ID] DESC

SELECT
FF.[ID],
FF.NoFacture,
FF.DateFacture,
FF.DateFactureAcomba,
TF.[Description] AS [TypeFacture],
FF.TypeInvoiceClientAcomba,
FF.ClientID,
U.[Description] AS [ClientDescription],
--FF.PayerAID,
--U2.[Description] AS [PayerADescription],
FF.Montant_Total,
FF.[Description],
FF.Status,
FF.StatusDescription AS [StatusDescription]
FROM FactureClient FF
	INNER JOIN TypeFacture TF ON TF.[ID] = TypeFacture
	INNER JOIN Usine U ON U.[ID] = FF.ClientID
	INNER JOIN Usine U2 ON U2.[ID] = FF.PayerAID
WHERE FF.[ID] in (SELECT [ID] FROM @Factures)
ORDER BY FF.[ID] DESC

SELECT
FFS.[FactureID],
FFS.Ligne,
FFS.Compte,
FFS.Montant,
FFS.[Description],
FFS.isTaxe
FROM FactureClient_Sommaire FFS
WHERE FactureID in (SELECT [ID] FROM @Factures)
ORDER BY FactureID DESC, Ligne ASC








