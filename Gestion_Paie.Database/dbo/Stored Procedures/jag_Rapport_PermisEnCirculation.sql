

CREATE PROCEDURE [dbo].[jag_Rapport_PermisEnCirculation]
	(
		@ProprietaireDebut varchar(15) = NULL,
		@ProprietaireFin varchar(15) = NULL,
		@UsineDebut varchar(6) = Null,
		@UsineFin varchar(6) = Null,
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null

	)
AS

SET NOCOUNT ON

SELECT
P.[ID] AS [Permis],
CONVERT(VARCHAR,P.DatePermit,103) AS [Date],
Pr.[ID],
Pr.[Nom] AS [Nom],
CONVERT(VARCHAR,P.DateDebut,103) AS [DateDebut],
CONVERT(VARCHAR,P.DateFin,103) AS [DateFin],
U.[Description] AS [Usine],
(CASE WHEN P.EssenceID IS NOT NULL THEN E.[Description] + ' ' + LTRIM(RTRIM(P.Code)) ELSE 'Sciage' END) AS [Essence],
L.CantonID + ' (' + Ca.[Description] + ')' AS [Canton],
L.Rang,
Lot = 	Lot +
	case when L.[Sequence] is not null and L.[Sequence] <> '' then '-' + L.[Sequence] else '' end +
	case when L.[Partie] = 1 then '(P)' else '' end,
L.Cadastre
FROM Permit P
	INNER JOIN Contrat C ON C.[ID] = P.ContratID
	INNER JOIN Usine U ON U.[ID] = C.UsineID
	LEFT OUTER JOIN Essence E ON E.[ID] = P.EssenceID
	left outer JOIN Lot L ON L.[ID] = P.LotID
	left outer JOIN Canton Ca ON Ca.[ID] = L.CantonID
	INNER JOIN Fournisseur Pr ON Pr.[ID] = P.ProducteurDroitCoupeID
WHERE PermitLivre = 0 and PermitAnnule = 0
AND ((@ProprietaireDebut IS NULL) OR (@ProprietaireDebut <= P.ProducteurDroitCoupeID))
AND ((@ProprietaireFin IS NULL) OR (@ProprietaireFin >= P.ProducteurDroitCoupeID))
AND ((@UsineDebut	IS NULL) OR (C.UsineID	>= @UsineDebut))
AND	((@UsineFin	IS NULL) OR (C.UsineID	<= @UsineFin))
AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), P.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,P.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
AND ((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), P.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,P.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	)
order by [Nom], [Permis]




