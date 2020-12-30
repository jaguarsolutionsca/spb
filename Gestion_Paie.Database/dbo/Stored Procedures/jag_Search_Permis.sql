

CREATE PROCEDURE dbo.jag_Search_Permis
	(
		@UsineID VARCHAR(6) = NULL,
		@ShowEssence BIT = NULL,
		@EssenceID VARCHAR(6) = NULL,
		@Code CHAR(4) = NULL,
		@ShowSciage BIT = NULL,
		@EssenceSciage VARCHAR(25) = NULL,
		@ProducteurNom VARCHAR(40) = NULL,
		@ProducteurID VARCHAR(15) = NULL,
		@MunicipaliteID VARCHAR(6) = NULL,
		@CantonID VARCHAR(6) = NULL,
		@Rang VARCHAR(25) = NULL,
		@Lot VARCHAR(6) = NULL,
		@SecteurDebut VARCHAR(6) = NULL,
		@SecteurFin VARCHAR(6) = NULL,
		@PeriodeDebut INT = NULL,
		@PeriodeFin INT = NULL,
		@AnneeDebut INT = NULL,
		@AnneeFin INT = NULL,
		@Livre BIT = NULL,
		@NonLivre BIT = NULL,
		@Annule BIT = NULL,
		@NonAnnule BIT = NULL
	)

AS
	
SELECT
P.[ID],
P.DatePermit AS [Date],
P.Annee,
P.Periode,
C.UsineID AS [Usine],
(CASE WHEN PermitSciage<>1 THEN (P.EssenceID + ' ' + LTRIM(RTRIM(Code))) ELSE (CASE WHEN ((P.EssenceSciage IS NOT NULL)AND(LEN(RTRIM(LTRIM(P.EssenceSciage)))>0)) THEN P.EssenceSciage ELSE 'Sciage' END) END) as [Essence],
P.ProducteurDroitCoupeID AS [ProducteurID],
F.Nom AS [Producteur],
M.[Description] AS [Municipalite],
Ca.[ID] + '-' + Lot.Rang + '-' + Lot.Lot as Lot,
Lot.Secteur,
(CASE WHEN ((P.PermitLivre IS NOT NULL)AND(P.PermitLivre = 1)) THEN convert(bit, 1) ELSE convert(bit, 0) END) AS [Livre],
(CASE WHEN ((P.PermitAnnule IS NOT NULL)AND(P.PermitAnnule = 1)) THEN convert(bit, 1) ELSE convert(bit, 0) END) AS [Annule]
--(CASE WHEN P.PermitLivre IS NOT NULL THEN P.PermitLivre ELSE CONVERT(BIT,0) END) AS [Livre],
--(CASE WHEN P.PermitAnnule IS NOT NULL THEN P.PermitAnnule ELSE CONVERT(BIT,0) END) AS [Annule]
FROM Permit P
	LEFT OUTER JOIN Contrat C ON C.[ID] = P.ContratID
	LEFT OUTER JOIN Fournisseur F ON F.[ID] = P.ProducteurDroitCoupeID
	LEFT OUTER JOIN Usine U ON U.[ID] = C.UsineID
	LEFT OUTER JOIN Essence E ON E.[ID] = P.EssenceID
	LEFT OUTER JOIN Lot Lot ON Lot.[ID] = P.LotID
	LEFT OUTER JOIN Canton Ca ON Ca.[ID] = Lot.CantonID
	LEFT OUTER JOIN Municipalite M ON M.[ID] = P.MunicipaliteID


WHERE ((@UsineID IS NULL) OR (C.UsineID = @UsineID))
AND (((@ShowEssence IS NULL) OR ((@ShowEssence = 1) AND (P.PermitSciage = 0) AND ((@EssenceID IS NULL) OR (P.EssenceID = @EssenceID)) AND ((@Code IS NULL) OR (P.Code = @Code))))
OR ((@ShowSciage IS NULL) OR ((@ShowSciage = 1) AND (P.PermitSciage = 1) AND ((@EssenceSciage IS NULL) OR (dbo.jag_StripAccents(P.EssenceSciage) LIKE '%'+dbo.jag_StripAccents(@EssenceSciage)+'%')))))
AND ((@ProducteurNom IS NULL) OR (dbo.jag_StripAccents(F.Nom) LIKE '%'+dbo.jag_StripAccents(@ProducteurNom)+'%'))
AND ((@ProducteurID IS NULL) OR (P.ProducteurDroitCoupeID = @ProducteurID))
AND ((@MunicipaliteID IS NULL) OR (P.MunicipaliteID = @MunicipaliteID))
AND ((@CantonID IS NULL) OR (Lot.CantonID = @CantonID))
AND ((@Rang IS NULL) OR (Lot.Rang LIKE '%'+@Rang+'%'))
AND ((@Lot IS NULL) OR (Lot.Lot = @Lot))
AND ((@SecteurDebut IS NULL) or (Lot.[Secteur] >= @SecteurDebut))
AND ((@SecteurFin IS NULL) or (Lot.[Secteur] <= @SecteurFin))
AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), P.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,P.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2))

)) ))
AND ((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), P.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,P.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	)
AND (((@Livre IS NULL) OR ((@Livre = 1) AND (P.PermitLivre = 1)))
OR ((@NonLivre IS NULL) OR ((@NonLivre = 1) AND (P.PermitLivre = 0))))
AND (((@Annule IS NULL) OR ((@Annule = 1) AND (P.PermitAnnule = 1)))
OR ((@NonAnnule IS NULL) OR ((@NonAnnule = 1) AND (P.PermitAnnule = 0))))
ORDER BY P.[ID] DESC

