

CREATE PROCEDURE [dbo].[jag_Search_Livraisons]
	(
		@UsineID VARCHAR(6) = NULL,
		@ShowEssence BIT = NULL,
		@EssenceID VARCHAR(6) = NULL,
		@Code CHAR(4) = NULL,
		@ShowSciage BIT = NULL,
		@EssenceSciage VARCHAR(25) = NULL,
		@PeriodeDebut INT = NULL,
		@PeriodeFin INT = NULL,
		@AnneeDebut INT = NULL,
		@AnneeFin INT = NULL,
		@ProducteurNom VARCHAR(40) = NULL,
		@ProducteurID VARCHAR(15) = NULL,
		@TransporteurNom VARCHAR(40) = NULL,
		@TransporteurID VARCHAR(15) = NULL,
		@NoFactureUsine VARCHAR(25) = NULL
	)

AS
	
SELECT
L.[ID],
L.DateLivraison AS [Date],
L.Annee,
L.Periode,
L.NumeroFactureUsine,
C.UsineID AS [Usine],
(CASE WHEN L.Sciage<>1 THEN (L.EssenceID + ' ' + LTRIM(RTRIM(P.Code))) ELSE (CASE WHEN ((P.EssenceSciage IS NOT NULL)AND(LEN(RTRIM(LTRIM(P.EssenceSciage)))>0)) THEN P.EssenceSciage ELSE 'Sciage' END) END) as [Essence],
L.DroitCoupeID AS [ProducteurID],
F.Nom AS [Producteur],
L.TransporteurID AS [TransporteurID],
T.Nom AS [Transporteur],
M.[Description] AS [Municipalite],
Ca.[ID] + '-' + Lot.Rang + '-' + Lot.Lot as Lot,
Lot.Cadastre,
L.VolumeBrut,
(CASE WHEN ((L.Facture IS NOT NULL)AND(L.Facture = 1)) THEN 'Facturé' ELSE '' END) AS [Facture]
--(CASE WHEN L.Facture IS NOT NULL THEN L.Facture ELSE CONVERT(BIT,0) END) AS [Facture]
FROM Livraison L
	LEFT OUTER JOIN Contrat C ON C.[ID] = L.ContratID
	LEFT OUTER JOIN Fournisseur F ON F.[ID] = L.DroitCoupeID
	LEFT OUTER JOIN Fournisseur T ON T.[ID] = L.TransporteurID
	LEFT OUTER JOIN Usine U ON U.[ID] = C.UsineID
	LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	LEFT OUTER JOIN Permit P on P.ID = L.ID
	LEFT OUTER JOIN Municipalite M on P.MunicipaliteID = M.ID
	LEFT OUTER JOIN Lot on Lot.ID = L.LotID
	LEFT OUTER JOIN Canton Ca on Ca.ID = Lot.CantonID

WHERE 
	((@UsineID IS NULL) OR (C.UsineID = @UsineID))
AND (((@ShowEssence IS NULL) OR ((@ShowEssence = 1) AND (L.Sciage = 0) AND ((@EssenceID IS NULL) OR (L.EssenceID = @EssenceID)) AND ((@Code IS NULL) OR (P.Code = @Code))))
OR 	((@ShowSciage IS NULL) OR ((@ShowSciage = 1) AND (L.Sciage = 1) AND ((@EssenceSciage IS NULL) OR (dbo.jag_StripAccents(P.EssenceSciage) LIKE '%'+dbo.jag_StripAccents(@EssenceSciage)+'%')))))
AND ((@ProducteurNom IS NULL) OR (dbo.jag_StripAccents(F.Nom) LIKE '%'+dbo.jag_StripAccents(@ProducteurNom)+'%'))
AND ((@ProducteurID IS NULL) OR (L.DroitCoupeID = @ProducteurID))
AND ((@TransporteurNom IS NULL) OR (dbo.jag_StripAccents(T.Nom) LIKE '%'+dbo.jag_StripAccents(@TransporteurNom)+'%'))
AND ((@TransporteurID IS NULL) OR (L.TransporteurID = @TransporteurID))
AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
AND ((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
AND ((@NoFactureUsine IS NULL) OR (L.NumeroFactureUsine = @NoFactureUsine))

ORDER BY L.[ID] DESC

