

CREATE PROCEDURE dbo.jag_FactureList
	(
		@Date SMALLDATETIME = NULL,
		@NumeroDebut INT = NULL,
		@NumeroFin INT = NULL,
		@ShowLivraisons BIT,
		@ShowAjustements BIT,
		@ShowIndexations BIT,
		@SortType INT = 0
	)
AS

SET NOCOUNT ON

--SortType:
--0: None
--1: [Nom] ASC
--2: NumeroCheque ASC, TypeFactureFournisseur ASC, [Nom] ASC
--3: [ID] ASC
--4: [NoFacture] ASC

DECLARE @IDs TABLE
(
	[ID] INT,
	NoFacture VARCHAR(12),
	[Nom] VARCHAR(40),
	TypeFactureFournisseur CHAR(1),
	NumeroCheque VARCHAR(20)
)

INSERT INTO @IDs ([ID], NoFacture, [Nom], TypeFactureFournisseur, NumeroCheque)
SELECT
FF.[ID],
FF.NoFacture,
F.[Nom],
FF.TypeFactureFournisseur,
FF.NumeroCheque
FROM FactureFournisseur FF
	INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
WHERE ((Status = 'FactureOK') OR (Status = 'PaiementOK') OR (Status = 'PaiementManuel'))
AND ((@Date IS NULL)OR(DATEDIFF(day, @Date, DateFactureAcomba) = 0))
AND ((@NumeroDebut IS NULL)OR((RIGHT(NoFacture, 6)) >= RIGHT(('000000' + CONVERT(VARCHAR,@NumeroDebut)) ,6)))
AND ((@NumeroFin   IS NULL)OR((RIGHT(NoFacture, 6)) <= RIGHT(('000000' + CONVERT(VARCHAR,@NumeroFin  )), 6)))
AND (((@ShowLivraisons = 1)AND(TypeFacture = 'L')) OR ((@ShowAjustements = 1)AND(TypeFacture = 'A')) OR ((@ShowIndexations = 1)AND(TypeFacture = 'I')))
AND (Montant_Total <> 0)

IF (@SortType = 0)
BEGIN
	SELECT [ID] FROM @IDs
END
ELSE IF (@SortType = 1)
BEGIN
	SELECT [ID] FROM @IDs
	ORDER BY [Nom] ASC
END
ELSE IF (@SortType = 2)
BEGIN
	SELECT [ID] FROM @IDs
	ORDER BY LEFT(NumeroCheque,1) + RIGHT(('00000000000000000000' + RIGHT(NumeroCheque,LEN(NumeroCheque)-1)),19) ASC,
	TypeFactureFournisseur ASC,
	[Nom] ASC
END
ELSE IF (@SortType = 3)
BEGIN
	SELECT [ID] FROM @IDs
	ORDER BY [ID] ASC
END
ELSE IF (@SortType = 4)
BEGIN
	SELECT [ID] FROM @IDs
	ORDER BY LEFT(NoFacture,1) + RIGHT(('00000000000000000000' + NoFacture),20) ASC
END

