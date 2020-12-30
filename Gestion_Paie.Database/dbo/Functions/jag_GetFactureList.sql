

CREATE FUNCTION dbo.jag_GetFactureList
	(
		@Date SMALLDATETIME = NULL,
		@NumeroDebut INT = NULL,
		@NumeroFin INT = NULL,
		@ShowLivraisons BIT,
		@ShowAjustements BIT,
		@ShowIndexations BIT
	)

RETURNS TABLE 

AS

Return
(
	SELECT TOP 100 PERCENT
	--TypeFactureFournisseur,
	FF.[ID]
	FROM FactureFournisseur FF
		INNER JOIN Fournisseur F ON F.[ID] = FF.FournisseurID
	WHERE ((@Date IS NULL) OR (DATEDIFF(day, @Date, DateFacture) = 0))
	AND ((@NumeroDebut IS NULL) OR (NoFacture >= RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NumeroDebut)))),6)))
	AND ((@NumeroFin IS NULL) OR (NoFacture <= RIGHT(('000000'+CONVERT(VARCHAR,(CONVERT(INT,@NumeroFin)))),6)))
	AND ((Status = 'FactureOK') OR (Status = 'PaiementOK') OR (Status = 'PaiementManuel'))
	/*Comment this line for all facture types*/--AND ((TypeFactureFournisseur = 'T') OR (TypeFactureFournisseur = 'P'))
	AND	(((@ShowLivraisons = 1)AND(TypeFacture = 'L'))
	OR	 ((@ShowAjustements = 1)AND(TypeFacture = 'A'))
	OR	 ((@ShowIndexations = 1)AND(TypeFacture = 'I')))
	ORDER BY FF.NumeroCheque asc, TypeFactureFournisseur DESC, F.[Nom]
)














