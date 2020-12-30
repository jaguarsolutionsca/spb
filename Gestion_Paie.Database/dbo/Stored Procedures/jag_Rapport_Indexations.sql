

CREATE PROCEDURE dbo.jag_Rapport_Indexations
	(
		@PeriodeDebut int = NULL,
		@AnneeDebut int = NULL,
		@PeriodeFin int = NULL,
		@AnneeFin int = NULL,
		@FournisseurDebut varchar(15) = NULL,
		@FournisseurFin varchar(15) = NULL,
		@UsineDebut VARCHAR(6) = NULL,
		@UsineFin VARCHAR(6) = NULL,
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
	SELECT 
	FF.FournisseurID,
	L.[ID],
	I.[ID],
	IC.ID,
	NULL
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID AND FF.TypeFactureFournisseur='T' AND TypeFacture='I'
		INNER JOIN Indexation I ON I.[ID] = FFD.RefID
		INNER JOIN IndexationCalcule_Transporteur IC ON IC.IndexationID = I.[ID] AND IC.TransporteurID = FF.FournisseurID
		INNER JOIN Livraison L ON L.[ID] = IC.LivraisonID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	where (FF.DateFacture > '2005/04/10')
	AND (FF.Status <> 'Attente')
	AND ((@FournisseurDebut IS NULL) OR (@FournisseurDebut <= FF.FournisseurID))
	AND ((@FournisseurFin IS NULL) OR (@FournisseurFin >= FF.FournisseurID))
	AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
	AND	((@UsineDebut	is null) or (C.[UsineID]	>= @UsineDebut))
	AND ((@UsineFin		is null) or (C.[UsineID]	<= @UsineFin))
	AND (I.IndexationTransporteur = 1)
	
	INSERT INTO @t
	SELECT DISTINCT
	FF.FournisseurID,
	L.[ID],
	I.[ID],
	IC.ID,
	NULL
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN IndexationCalcule_Transporteur IC ON (IC.[ID] = FFD.RefID) AND IC.TransporteurID = FF.FournisseurID
		INNER JOIN Indexation I ON I.[ID] = IC.IndexationID
		INNER JOIN Livraison L ON L.[ID] = IC.LivraisonID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	where (FF.Status <> 'Attente')
	AND ((@FournisseurDebut IS NULL) OR (@FournisseurDebut <= FF.FournisseurID))
	AND ((@FournisseurFin IS NULL) OR (@FournisseurFin >= FF.FournisseurID))
	AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))
	AND	((@UsineDebut	is null) or (C.[UsineID]	>= @UsineDebut))
	AND ((@UsineFin		is null) or (C.[UsineID]	<= @UsineFin))
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
	FF.FournisseurID,
	L.[ID],
	I.[ID],
	IC.ID,
	IC.Volume
	FROM FactureFournisseur_Details FFD
		INNER JOIN FactureFournisseur FF ON FF.[ID] = FFD.FactureID
		INNER JOIN IndexationCalcule_Producteur IC ON (IC.[ID] = FFD.RefID) AND IC.ProducteurID = FF.FournisseurID
		INNER JOIN Indexation I ON I.[ID] = IC.IndexationID
		INNER JOIN Livraison L ON L.[ID] = IC.LivraisonID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	where (FF.Status <> 'Attente')
	AND ((@FournisseurDebut IS NULL) OR (@FournisseurDebut <= FF.FournisseurID))
	AND ((@FournisseurFin IS NULL) OR (@FournisseurFin >= FF.FournisseurID))
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
T._FournisseurID,
F.[Nom] AS [Fournisseur],
CONVERT(VARCHAR,L.DateLivraison,103) AS [Date],
(L.NumeroFactureUsine) AS [FactureUsine],
L.[ID] AS [Permis],
(C.UsineID) AS [Usine],
L.UniteMesureID AS [Unite],
(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE L.EssenceID + ' ' + RTRIM(LTRIM(L.Code)) END) AS [Essence],
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
	LEFT OUTER JOIN IndexationCalcule_Transporteur ICT ON (ICT.[IndexationID] = T._IndexationID) AND ICT.TransporteurID = T._FournisseurID AND ICT.LivraisonID = T._LivraisonID and ICT.ID = T._IndexationCalculeID
	LEFT OUTER JOIN IndexationCalcule_Producteur ICP ON (ICP.[IndexationID] = T._IndexationID) AND ICP.ProducteurID = T._FournisseurID AND ICP.LivraisonID = T._LivraisonID and ICP.ID = T._IndexationCalculeID
ORDER BY [Fournisseur], L.DateLivraison DESC



