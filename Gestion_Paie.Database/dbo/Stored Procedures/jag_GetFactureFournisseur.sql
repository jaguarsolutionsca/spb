

CREATE PROCEDURE dbo.jag_GetFactureFournisseur
	(
		@FactureID INT = NULL,
		@TypeFacture CHAR(1) = NULL,
		@TypeFactureFournisseur CHAR(1) = NULL,
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
FROM FactureFournisseur
WHERE ((@TypeFacture IS NULL) OR (TypeFacture = @TypeFacture))
AND ((@TypeFactureFournisseur IS NULL) OR (TypeFactureFournisseur = @TypeFactureFournisseur))
AND ((@Status IS NULL) OR (Status = @Status))
AND ((@FactureID IS NULL) OR ([ID] = @FactureID))
ORDER BY [ID] DESC

SELECT
FF.[ID],
FF.NoFacture,
FF.DateFacture,
FF.DateFactureAcomba,
FF.DatePaiementAcomba,
FF.TypeFactureFournisseur AS [TypeFactureFournisseurID],
TFF.[Description] AS [TypeFactureFournisseur],
TF.[Description] AS [TypeFacture],
FF.TypeInvoiceAcomba,
FF.FournisseurID,
F.Nom AS [FournisseurNom],
FF.PayerAID,
F2.Nom AS [PayerANom],
FF.Montant_Total,
FF.[Description],
FF.Status,
FF.StatusDescription AS [StatusDescription]
FROM FactureFournisseur FF
	INNER JOIN TypeFactureFournisseur TFF ON TFF.[ID] = FF.TypeFactureFournisseur
	INNER JOIN TypeFacture TF ON TF.[ID] = TypeFacture
	INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
	INNER JOIN Fournisseur F2 ON F2.[ID] = FF.PayerAID
WHERE FF.[ID] in (SELECT [ID] FROM @Factures)
ORDER BY FF.[ID] DESC

SELECT
FFS.[FactureID],
FFS.Ligne,
FFS.Compte,
FFS.Montant,
FFS.[Description],
FFS.isTaxe
FROM FactureFournisseur_Sommaire FFS
WHERE FactureID in (SELECT [ID] FROM @Factures)
ORDER BY FactureID DESC, Ligne ASC








