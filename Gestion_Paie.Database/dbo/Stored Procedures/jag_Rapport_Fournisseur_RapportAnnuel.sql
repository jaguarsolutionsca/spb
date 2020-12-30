CREATE PROCEDURE [dbo].[jag_Rapport_Fournisseur_RapportAnnuel]
@Annee INT=NULL, @FouDebut VARCHAR (15)=NULL, @FouFin VARCHAR (15)=NULL, @TypeFou CHAR (1)
AS
SET NOCOUNT ON

DECLARE @Factures TABLE
(
	[ID] INT,
	FournisseurID VARCHAR(15),
	NumeroCheque VARCHAR(20)
)

DECLARE @Resume TABLE
(
	_Type INT --1=Livraisons 2=Ajustements 3=Indexations
	, FournisseurID VARCHAR(15)
	, UniteID VARCHAR(6)
	, Sciage BIT
	, EssenceID VARCHAR(6)
	, Code CHAR(4)
	, Volume FLOAT
	, Montant FLOAT
)

INSERT INTO @Factures
SELECT [ID], FournisseurID, NumeroCheque FROM FactureFournisseur FF 
WHERE ((@Annee IS NULL) OR (FF.Annee = @Annee)) 
AND ((@FouDebut IS NULL) OR (FF.FournisseurID >= @FouDebut))
AND ((@FouFin IS NULL) OR (FF.FournisseurID <= @FouFin))
AND FF.TypeFactureFournisseur = @TypeFou

SELECT
F.[ID]
, F.Nom
, F.AuSoinsDe
, F.Rue
, F.Ville
, UPPER(F.Code_Postal) AS [Code_Postal]
, F.No_TPS
, F.No_TVQ
FROM Fournisseur F
WHERE ((@FouDebut IS NULL) OR (F.[ID] >= @FouDebut))
AND ((@FouFin IS NULL) OR (F.[ID] <= @FouFin))
AND F.[ID] IN (SELECT FournisseurID FROM @Factures)

SELECT
FF.[FournisseurID],
SUM(Montant_TPS) AS [Montant_TPS],
SUM(Montant_TVQ) AS [Montant_TVQ],
SUM(Montant_Total) AS [Montant_Total]
FROM FactureFournisseur FF
WHERE FF.[ID] IN (SELECT [ID] FROM @Factures)
GROUP BY FF.FournisseurID

IF (@TypeFou = 'P') --PRODUCTEUR
BEGIN
	--LIVRAISONS
	SELECT
	FF.FournisseurID,
	L.DateLivraison AS [Date],
	L.Periode AS [Periode],
	L.[ID] AS [Permis],
	L.NumeroFactureUsine AS [FactureUsine],
	C.UsineID AS [Usine],
	M.[Description] + (CASE WHEN ((L.[ZoneID] IS NULL) OR (L.[ZoneID] = '0')) THEN '' ELSE ' (' + MZ.[Description] + ')' END) AS [Municipalite],
	L.UniteMesureID AS [Unite],
	E.[Description] + ' ' + LTRIM(RTRIM(LD.Code)) AS [Essence],
	LD.VolumeNet AS [Volume],
	LD.Taux_Usine,
	LD.Montant_Usine AS [Montant_Usine],
	ROUND((LD.Taux_Usine - LD.Taux_TransporteurMoyen - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Plan_Conjoint ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Fond_Roulement ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Fond_Forestier ELSE 0 END) - (CASE WHEN LD.UsePreleveMontant = 1 THEN LD.Taux_Preleve_Divers ELSE 0 END)),2) AS [Taux_Producteur_Net],
	ROUND((L.Frais_AutresRevenusProducteur - L.Frais_AutresAuProducteur) * (case when (L.VolumeBrut - L.VolumeTare) > 0 then LD.VolumeNet / (L.VolumeBrut - L.VolumeTare) else 1 end),2)[Autres_Montant],
	LD.Montant_ProducteurNet + 
	ROUND((L.Frais_AutresRevenusProducteur - L.Frais_AutresAuProducteur) * (case when (L.VolumeBrut - L.VolumeTare) > 0 then LD.VolumeNet / (L.VolumeBrut - L.VolumeTare) else 1 end),2)
	AS [Montant_Net],
	FF.NumeroCheque
	FROM Livraison L
		INNER JOIN @Factures FF ON ((FF.[ID] = L.Producteur1_FactureID)OR(FF.[ID] = L.Producteur2_FactureID))
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
		LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		LEFT OUTER JOIN Municipalite_Zone MZ ON MZ.[ID] = L.ZoneID and MZ.MunicipaliteID=L.MunicipaliteID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		LEFT OUTER JOIN Essence E ON E.[ID] = LD.EssenceID
	WHERE L.Facture = 1
	ORDER BY FF.FournisseurID, L.DateLivraison DESC

	--SOMMAIRE DES LIVRAISONS
	INSERT INTO @Resume
	SELECT
	1, --Livraisons
	FF.FournisseurID,
	--C.UsineID AS [Usine],
	L.UniteMesureID AS [Unite],
	--E.[Description] + ' ' + LTRIM(RTRIM(LD.Code)) AS [Essence],
	0,
	LD.EssenceID,
	LD.Code,
	SUM(LD.VolumeNet) AS [Volume],
	SUM(LD.Montant_ProducteurNet) AS [Montant_Livraison]
	FROM Livraison L
		INNER JOIN @Factures FF ON ((FF.[ID] = L.Producteur1_FactureID)OR(FF.[ID] = L.Producteur2_FactureID))
		INNER JOIN Livraison_Detail LD ON LD.[LivraisonID] = L.[ID] AND LD.ProducteurID = FF.FournisseurID
		--INNER JOIN Contrat C ON C.[ID] = L.ContratID
		--LEFT OUTER JOIN Essence E ON E.[ID] = LD.EssenceID
	WHERE L.Facture = 1
	GROUP BY FF.FournisseurID, L.UniteMesureID, LD.EssenceID, LD.Code
	ORDER BY FF.FournisseurID, L.UniteMesureID, LD.EssenceID, LD.Code

	--AJUSTEMENTS
	SELECT
	FF.FournisseurID,
	(L.DateLivraison) AS [Date],
	L.Periode AS [Periode],
	L.[ID] AS [Permis],
	(L.NumeroFactureUsine) AS [FactureUsine],
	(C.UsineID) AS [Usine],

	M.[Description] + (CASE WHEN ((L.[ZoneID] IS NULL) OR (L.[ZoneID] = '0')) THEN '' ELSE ' (' + MZ.[Description] + ')' END) AS [Municipalite],
	L.UniteMesureID AS [Unite],
	E.[Description] + ' ' + LTRIM(RTRIM(LD.Code)) AS [Essence],
	A.[ID] AS [Ajustement],
	ACP.Volume,
	ACP.Taux,
	ACP.Montant,
	FF.NumeroCheque
	FROM AjustementCalcule_Producteur ACP
		INNER JOIN @Factures FF ON FF.[ID] = ACP.FactureID
		INNER JOIN Ajustement A ON A.[ID] = ACP.AjustementID
		INNER JOIN Livraison_Detail LD ON LD.[ID] = ACP.LivraisonDetailID
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
		LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		LEFT OUTER JOIN Municipalite_Zone MZ ON MZ.[ID] = L.ZoneID and MZ.MunicipaliteID=L.MunicipaliteID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		LEFT OUTER JOIN Essence E ON E.[ID] = LD.EssenceID
	WHERE ACP.Facture = 1
	ORDER BY FF.FournisseurID, L.DateLivraison DESC

	--SOMMAIRE DES AJUSTEMENTS
	INSERT INTO @Resume
	SELECT
	2, --Ajustements
	FF.FournisseurID,
	--(C.UsineID) AS [Usine],
	L.UniteMesureID AS [Unite],
	0,
	LD.EssenceID,
	LD.Code,
	SUM(ACP.Volume) AS [Volume],
	SUM(ACP.Montant) AS [Montant_Ajustement]
	FROM AjustementCalcule_Producteur ACP
		INNER JOIN @Factures FF ON FF.[ID] = ACP.FactureID
		INNER JOIN Ajustement A ON A.[ID] = ACP.AjustementID
		INNER JOIN Livraison_Detail LD ON LD.[ID] = ACP.LivraisonDetailID
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
	WHERE ACP.Facture = 1
	GROUP BY FF.FournisseurID, L.UniteMesureID, L.Sciage, LD.EssenceID, LD.Code
	ORDER BY FF.FournisseurID, L.UniteMesureID, L.Sciage, LD.EssenceID, LD.Code

	--INDEXATIONS
	SELECT
	FF.FournisseurID,
	(L.DateLivraison) AS [Date],
	L.Periode AS [Periode],
	L.[ID] AS [Permis],
	(L.NumeroFactureUsine) AS [FactureUsine],
	(C.UsineID) AS [Usine],
	M.[Description] + (CASE WHEN ((L.[ZoneID] IS NULL) OR (L.[ZoneID] = '0')) THEN '' ELSE ' (' + MZ.[Description] + ')' END) AS [Municipalite],
	L.UniteMesureID AS [Unite],
	(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
	I.[ID] AS [Indexation],
	(CASE WHEN ICP.TypeIndexation = 'M' THEN ICP.Volume ELSE 0 END) AS [Volume],
	(CASE WHEN ICP.TypeIndexation = 'P' THEN (ICP.MontantDejaPaye) ELSE 0 END) AS [MontantDejaPaye],
	(CASE WHEN ICP.TypeIndexation = 'P' THEN (ICP.PourcentageDuMontant * 100) ELSE 0 END) AS [PourcentageDuMontant],
	(CASE WHEN ICP.TypeIndexation = 'M' THEN ICP.Taux ELSE 0 END) AS [Taux],
	ICP.Montant	,
	FF.NumeroCheque
	FROM IndexationCalcule_Producteur ICP
		INNER JOIN @Factures FF ON FF.[ID] = ICP.FactureID
		LEFT OUTER JOIN Indexation_EssenceUnite [IEU] ON [IEU].[ID] = ICP.IndexationDetailID
		INNER JOIN Indexation I ON ((I.[ID] = ICP.IndexationID) OR (I.[ID] = [IEU].IndexationID))
		INNER JOIN Livraison L ON L.[ID] = ICP.LivraisonID
		LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		LEFT OUTER JOIN Municipalite_Zone MZ ON MZ.[ID] = L.ZoneID and MZ.MunicipaliteID=L.MunicipaliteID
		INNER JOIN Contrat C ON C.[ID] = I.ContratID
		LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	WHERE ICP.Facture = 1
	ORDER BY FF.FournisseurID, L.DateLivraison DESC

	--SOMMAIRE DES INDEXATIONS
	INSERT INTO @Resume
	SELECT
	3, --Indexations
	FF.FournisseurID,
	--(C.UsineID) AS [Usine],
	L.UniteMesureID AS [Unite],
	L.Sciage, 
	L.EssenceID,
	L.Code,
	SUM(CASE WHEN ICP.TypeIndexation = 'M' THEN ICP.Volume ELSE 0 END) AS [Volume],
	SUM(ICP.Montant) AS [Montant_Indexation]
	FROM IndexationCalcule_Producteur ICP
		INNER JOIN @Factures FF ON FF.[ID] = ICP.FactureID
		LEFT OUTER JOIN Indexation_EssenceUnite [IEU] ON [IEU].[ID] = ICP.IndexationDetailID
		INNER JOIN Indexation I ON ((I.[ID] = ICP.IndexationID) OR (I.[ID] = [IEU].IndexationID))
		INNER JOIN Livraison L ON L.[ID] = ICP.LivraisonID
	WHERE ICP.Facture = 1
	GROUP BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
	ORDER BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
END
ELSE IF (@TypeFou = 'T') --TRANSPORTEUR
BEGIN
	--LIVRAISONS
	SELECT
	FF.FournisseurID,
	L.DateLivraison AS [Date],
	L.Periode AS [Periode],
	L.[ID] AS [Permis],
	L.NumeroFactureUsine AS [FactureUsine],
	C.UsineID AS [Usine],
	M.[Description] + (CASE WHEN ((L.[ZoneID] IS NULL) OR (L.[ZoneID] = '0')) THEN '' ELSE ' (' + MZ.[Description] + ')' END) AS [Municipalite],
	L.UniteMesureID AS [Unite],
	(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
	L.VolumeAPayer AS [Volume],
	L.Taux_Transporteur,
	L.Montant_Transporteur AS [Montant],
	FF.NumeroCheque
	FROM Livraison L
		INNER JOIN @Factures FF ON (FF.[ID] = L.Transporteur_FactureID)
		LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		LEFT OUTER JOIN Municipalite_Zone MZ ON MZ.[ID] = L.ZoneID and MZ.MunicipaliteID=L.MunicipaliteID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	WHERE L.Facture = 1
	ORDER BY FF.FournisseurID, L.DateLivraison DESC

	--SOMMAIRE DES LIVRAISONS
	INSERT INTO @Resume
	SELECT
	1, --Livraisons
	FF.FournisseurID,
	--C.UsineID AS [Usine],
	L.UniteMesureID AS [Unite],
	L.Sciage,
	L.EssenceID,
	L.Code,
	SUM(L.VolumeAPayer) AS [Volume],
	SUM(L.Montant_Transporteur) AS [Montant_Livraison]
	FROM Livraison L
		INNER JOIN @Factures FF ON (FF.[ID] = L.Transporteur_FactureID)
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	WHERE L.Facture = 1
	GROUP BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
	ORDER BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
	
	--AJUSTEMENTS
	SELECT
	FF.FournisseurID,
	(L.DateLivraison) AS [Date],
	L.Periode AS [Periode],
	L.[ID] AS [Permis],
	(L.NumeroFactureUsine) AS [FactureUsine],
	(C.UsineID) AS [Usine],
	M.[Description] + (CASE WHEN ((L.[ZoneID] IS NULL) OR (L.[ZoneID] = '0')) THEN '' ELSE ' (' + MZ.[Description] + ')' END) AS [Municipalite],
	L.UniteMesureID AS [Unite],
	(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
	A.[ID] AS [Ajustement],
	ACT.Volume,
	ACT.Taux,
	ACT.Montant,
	FF.NumeroCheque	
	FROM AjustementCalcule_Transporteur ACT
		INNER JOIN @Factures FF ON FF.[ID] = ACT.FactureID
		INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
		INNER JOIN Livraison L ON L.[ID] = ACT.[LivraisonID]
		LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		LEFT OUTER JOIN Municipalite_Zone MZ ON MZ.[ID] = L.ZoneID and MZ.MunicipaliteID=L.MunicipaliteID
		INNER JOIN Contrat C ON C.[ID] = A.ContratID
		LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	WHERE ACT.Facture = 1
	ORDER BY FF.FournisseurID, L.DateLivraison DESC

	--SOMMAIRE DES AJUSTEMENTS
	INSERT INTO @Resume
	SELECT
	2, --Ajustements
	FF.FournisseurID,
	--(C.UsineID) AS [Usine],
	L.UniteMesureID AS [Unite],
	L.Sciage,
	L.EssenceID,
	L.Code,
	SUM(ACT.Volume) AS [Volume],
	SUM(ACT.Montant) AS [Montant_Ajustement]
	FROM AjustementCalcule_Transporteur ACT
		INNER JOIN @Factures FF ON FF.[ID] = ACT.FactureID
		INNER JOIN Ajustement A ON A.[ID] = ACT.AjustementID
		INNER JOIN Livraison L ON L.[ID] = ACT.[LivraisonID]
	WHERE ACT.Facture = 1
	GROUP BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
	ORDER BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
	
	--INDEXATIONS
	SELECT
	FF.FournisseurID,
	(L.DateLivraison) AS [Date],
	L.Periode AS [Periode],
	L.[ID] AS [Permis],
	(L.NumeroFactureUsine) AS [FactureUsine],
	(C.UsineID) AS [Usine],
	M.[Description] + (CASE WHEN ((L.[ZoneID] IS NULL) OR (L.[ZoneID] = '0')) THEN '' ELSE ' (' + MZ.[Description] + ')' END) AS [Municipalite],
	L.UniteMesureID AS [Unite],
	(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
	I.[ID] AS [Indexation],
	(CASE WHEN ICT.TypeIndexation = 'P' THEN (ICT.MontantDejaPaye) ELSE 0 END) AS [MontantDejaPaye],
	(CASE WHEN ICT.TypeIndexation = 'P' THEN (ICT.PourcentageDuMontant * 100) ELSE 0 END) AS [PourcentageDuMontant],
	ICT.Montant,
	FF.NumeroCheque
	FROM IndexationCalcule_Transporteur ICT
		INNER JOIN @Factures FF ON FF.[ID] = ICT.FactureID
		LEFT OUTER JOIN Indexation_Municipalite [IM] ON [IM].[ID] = ICT.IndexationDetailID
		INNER JOIN Indexation I ON ((I.[ID] = ICT.IndexationID) OR (I.[ID] = [IM].IndexationID))
		INNER JOIN Livraison L ON L.[ID] = ICT.LivraisonID
		LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		LEFT OUTER JOIN Municipalite_Zone MZ ON MZ.[ID] = L.ZoneID and MZ.MunicipaliteID=L.MunicipaliteID
		INNER JOIN Contrat C ON C.[ID] = I.ContratID
		LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	WHERE ICT.Facture = 1
	ORDER BY FF.FournisseurID, L.DateLivraison DESC
	
	--SOMMAIRE DES INDEXATIONS
	INSERT INTO @Resume
	SELECT
	3, --Indexations
	FF.FournisseurID,
	--(C.UsineID) AS [Usine],
	L.UniteMesureID AS [Unite],
	L.Sciage,
	L.EssenceID,
	L.Code,
	0,
	SUM(ICT.Montant) AS [Montant_Indexation]
	FROM IndexationCalcule_Transporteur ICT
		INNER JOIN @Factures FF ON FF.[ID] = ICT.FactureID
		LEFT OUTER JOIN Indexation_Municipalite [IM] ON [IM].[ID] = ICT.IndexationDetailID
		INNER JOIN Indexation I ON ((I.[ID] = ICT.IndexationID) OR (I.[ID] = [IM].IndexationID))
		INNER JOIN Livraison L ON L.[ID] = ICT.LivraisonID
	WHERE ICT.Facture = 1
	GROUP BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
	ORDER BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
END
ELSE IF (@TypeFou = 'C') --CHARGEUR
BEGIN
	--LIVRAISONS
	SELECT
	FF.FournisseurID,
	L.DateLivraison AS [Date],
	L.Periode AS [Periode],
	L.[ID] AS [Permis],
	L.NumeroFactureUsine AS [FactureUsine],
	C.UsineID AS [Usine],
	M.[Description] + (CASE WHEN ((L.[ZoneID] IS NULL) OR (L.[ZoneID] = '0')) THEN '' ELSE ' (' + MZ.[Description] + ')' END) AS [Municipalite],
	L.UniteMesureID AS [Unite],
	(CASE WHEN L.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(L.Code)) END) AS [Essence],
	L.VolumeTransporte AS [Volume],
	L.TauxChargeurAuProducteur,	
	L.Frais_ChargeurAuProducteur AS [MontantPayeParProducteur],
	L.TauxChargeurAuTransporteur,	
	L.Frais_ChargeurAuTransporteur AS [MontantPayeParTransporteur],
	L.Montant_Chargeur AS [Montant_Chargeur],
	FF.NumeroCheque
	FROM Livraison L
		INNER JOIN @Factures FF ON (FF.[ID] = L.Chargeur_FactureID)
		LEFT OUTER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		LEFT OUTER JOIN Municipalite_Zone MZ ON MZ.[ID] = L.ZoneID and MZ.MunicipaliteID=L.MunicipaliteID
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		LEFT OUTER JOIN Essence E ON E.[ID] = L.EssenceID
	WHERE L.Facture = 1
	ORDER BY FF.FournisseurID, L.DateLivraison DESC
	
	--SOMMAIRE DES LIVRAISONS
	INSERT INTO @Resume
	SELECT
	1, --Livraisons
	FF.FournisseurID,
	--C.UsineID AS [Usine],
	L.UniteMesureID AS [Unite],
	L.Sciage,
	L.EssenceID,
	L.Code,
	SUM(L.VolumeTransporte) AS [Volume],
	SUM(L.Montant_Chargeur) AS [Montant_Livraison]
	FROM Livraison L
		INNER JOIN @Factures FF ON (FF.[ID] = L.Chargeur_FactureID)
	WHERE L.Facture = 1
	GROUP BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
	ORDER BY FF.FournisseurID, L.UniteMesureID, L.Sciage, L.EssenceID, L.Code
END

--UPDATE @Resume SET Volume = NULL WHERE Volume = 0 AND _Type = 3

--RESUME UNITE-ESSENCE
SELECT
R.FournisseurID
, (CASE WHEN (R._Type = 1) THEN 'Livraisons' WHEN (R._Type = 2) THEN 'Ajustements' WHEN (R._Type = 3) THEN 'Indexations' END) AS [Type]
, R.UniteID AS [Unite]
, (CASE WHEN R.Sciage = 1 THEN 'Sciage' ELSE E.[Description] + ' ' + LTRIM(RTRIM(R.Code)) END) AS [Essence]
, SUM(R.Volume) AS [Volume]
, SUM(R.Montant) AS [Montant]
FROM @Resume R
	LEFT OUTER JOIN Essence E ON E.[ID] = R.EssenceID
GROUP BY R.FournisseurID, R._Type, R.UniteID, R.Sciage, E.[Description], R.Code
ORDER BY R.FournisseurID, R._Type, R.UniteID, R.Sciage, E.[Description], R.Code

--RESUME UNITE
SELECT
R.FournisseurID
, (CASE WHEN (R._Type = 1) THEN 'Livraisons' WHEN (R._Type = 2) THEN 'Ajustements' WHEN (R._Type = 3) THEN 'Indexations' END) AS [Type]
, R.UniteID AS [Unite]
, SUM(R.Volume) AS [Volume]
, SUM(R.Montant) AS [Montant]
FROM @Resume R
GROUP BY R.FournisseurID, R._Type, R.UniteID
ORDER BY R.FournisseurID, R._Type, R.UniteID


