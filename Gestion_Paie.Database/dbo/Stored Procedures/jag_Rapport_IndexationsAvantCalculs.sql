

CREATE PROCEDURE dbo.jag_Rapport_IndexationsAvantCalculs
	(
		@PeriodeDebut int = NULL,
		@AnneeDebut int = NULL,
		@PeriodeFin int = NULL,
		@AnneeFin int = NULL,
		@FournisseurDebut varchar(15) = NULL,
		@FournisseurFin varchar(15) = NULL,
		@UsineDebut VARCHAR(6) = NULL,
		@UsineFin VARCHAR(6) = NULL,
		@DateIndexationDebut SMALLDATETIME = NULL,
		@DateIndexationFin SMALLDATETIME = NULL,
		@TypeFournisseur char(1) = 'T'
	)
AS

SET NOCOUNT ON

DECLARE @t TABLE
(
	_FournisseurID varchar(15),
	_LivraisonID INT,
	_IndexationID INT,
	_IndexationCalculeID INT,
	Volume FLOAT
)
	
if (@TypeFournisseur = 'T')
BEGIN
	INSERT INTO @t
	SELECT DISTINCT
	IC.TransporteurID,
	L.[ID],
	I.[ID],
	IC.ID,
	NULL
	FROM IndexationCalcule_Transporteur IC
		INNER JOIN Indexation I ON I.[ID] = IC.IndexationID
		INNER JOIN Livraison L ON L.[ID] = IC.LivraisonID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	where ((@DateIndexationDebut IS NULL) OR (@DateIndexationDebut <= I.DateIndexation))
	AND ((@DateIndexationFin IS NULL) OR (@DateIndexationFin >= I.DateIndexation))
	AND	((@FournisseurDebut IS NULL) OR (@FournisseurDebut <= IC.TransporteurID))
	AND ((@FournisseurFin IS NULL) OR (@FournisseurFin >= IC.TransporteurID))
	AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
	AND	((@UsineDebut	is null) or (C.[UsineID] >= @UsineDebut))
	AND ((@UsineFin		is null) or (C.[UsineID] <= @UsineFin))
	AND (I.IndexationTransporteur = 1)
	
	UPDATE @t SET Volume = 
	(
		SELECT L.VolumeTransporte FROM Livraison L WHERE L.[ID] = _LivraisonID AND L.TransporteurID = _FournisseurID
	)
	WHERE Volume IS NULL
END
ELSE
BEGIN
	INSERT INTO @t
	SELECT DISTINCT
	IC.ProducteurID,
	L.[ID],
	I.[ID],
	IC.ID,
	IC.Volume
	FROM IndexationCalcule_Producteur IC
		INNER JOIN Indexation I ON I.[ID] = IC.IndexationID
		INNER JOIN Livraison L ON L.[ID] = IC.LivraisonID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	where ((@DateIndexationDebut IS NULL) OR (@DateIndexationDebut <= I.DateIndexation))
	AND ((@DateIndexationFin IS NULL) OR (@DateIndexationFin >= I.DateIndexation))
	AND	((@FournisseurDebut IS NULL) OR (@FournisseurDebut <= IC.ProducteurID))
	AND ((@FournisseurFin IS NULL) OR (@FournisseurFin >= IC.ProducteurID))
	AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))	
	AND	((@UsineDebut	is null) or (C.[UsineID]	>= @UsineDebut))
	AND ((@UsineFin		is null) or (C.[UsineID]	<= @UsineFin))
	AND (I.IndexationTransporteur = 0)
	
	UPDATE @t SET Volume = 
	(
		SELECT SUM(LD.VolumeNet) FROM Livraison_Detail LD WHERE LD.LivraisonID = _LivraisonID AND LD.ProducteurID = _FournisseurID
	)
	WHERE Volume IS NULL
END
	
SELECT
L.Periode AS [Periode],
U.[Description] AS [Usine],
L.[ID] AS [Livraison],
T._FournisseurID,
F.[Nom] AS [Fournisseur],
M.[Description] AS [Municipalite],
T.Volume AS [Volume],
--(CASE WHEN (I.IndexationTransporteur = 0) THEN (CASE WHEN ICP.TypeIndexation = 'M' THEN (ICP.Volume) ELSE 0 END) ELSE 0 END) AS [Volume],
(CASE WHEN (I.IndexationTransporteur = 1) THEN (CASE WHEN ICT.TypeIndexation = 'P' THEN (ICT.MontantDejaPaye) ELSE 0 END) ELSE (CASE WHEN ICP.TypeIndexation = 'P' THEN (ICP.MontantDejaPaye) ELSE 0 END) END) AS [MontantDejaPaye],
(CASE WHEN (I.IndexationTransporteur = 1) THEN (CASE WHEN ICT.TypeIndexation = 'P' THEN (ICT.PourcentageDuMontant * 100) ELSE 0 END) ELSE (CASE WHEN ICP.TypeIndexation = 'P' THEN (ICP.PourcentageDuMontant * 100) ELSE 0 END) END) AS [PourcentageDuMontant],

(CASE WHEN (I.IndexationTransporteur = 0) THEN (CASE WHEN ICP.TypeIndexation = 'M' THEN (ICP.Taux) ELSE 0 END) ELSE 0 END) AS [Taux],
(CASE WHEN (I.IndexationTransporteur = 1) THEN (ICT.Montant) ELSE (ICP.Montant) END) AS [Montant]
FROM @t T
	INNER JOIN Fournisseur F ON F.[ID] = T._FournisseurID
	INNER JOIN Livraison L ON L.[ID] = T._LivraisonID
	INNER JOIN Indexation I ON I.[ID] = T._IndexationID
	INNER JOIN Contrat C ON C.[ID] = I.ContratID
	INNER JOIN Usine U ON U.[ID] = C.UsineID
	INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
	LEFT OUTER JOIN IndexationCalcule_Transporteur ICT ON (ICT.[IndexationID] = T._IndexationID) AND ICT.TransporteurID = T._FournisseurID AND ICT.LivraisonID = T._LivraisonID and ICT.ID = T._IndexationCalculeID
	LEFT OUTER JOIN IndexationCalcule_Producteur ICP ON (ICP.[IndexationID] = T._IndexationID) AND ICP.ProducteurID = T._FournisseurID AND ICP.LivraisonID = T._LivraisonID and ICP.ID = T._IndexationCalculeID
ORDER BY [Fournisseur], L.[ID] DESC




