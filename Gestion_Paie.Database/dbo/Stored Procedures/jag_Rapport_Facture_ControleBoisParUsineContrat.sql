

CREATE PROCEDURE dbo.jag_Rapport_Facture_ControleBoisParUsineContrat
(
	@Annee int = null
)

AS

SET NOCOUNT ON

declare @Results table
(
	_UsineID VARCHAR(6) null,
	_EssenceID VARCHAR(6),
	_Code CHAR(4),
	_UniteMesureID varchar(6) null,
	VolumePrevueContrat float null,
	VolumeLivreContrat float null,
	VolumeALivreContrat float null,
	VolumeAccordeContingentement float null,
	VolumeLivreContingentement float null
)

INSERT INTO @Results (_UsineID, _EssenceID, _Code, _UniteMesureID)
SELECT DISTINCT
UsineID,
EssenceID,
Code,
UniteMesureID
FROM Contingentement C
WHERE 
	(C.Annee = @Annee)
AND C.ContingentUsine = 1
AND C.CalculAccepte = 1

UPDATE @Results SET
VolumePrevueContrat = (
	SELECT
	SUM(Quantite_prevue * (CASE WHEN CU.Facteur IS NOT NULL THEN CU.Facteur ELSE 0 END))
	FROM Contrat_EssenceUnite CEU
		INNER JOIN Contrat C ON C.[ID] = CEU.ContratID
		LEFT OUTER JOIN Contingentement Co ON Co.Annee = @Annee AND Co.UsineID = C.UsineID
		LEFT OUTER JOIN Contingentement_Unite CU ON CU.ContingentementID = Co.ID AND CU.UniteID = Co.UniteMesureID
	WHERE ((@Annee IS NULL)OR(C.Annee = @Annee))
	AND C.UsineID = _UsineID
	AND (CEU.EssenceID = _EssenceID)
	AND (CEU.Code = _Code)
	AND (CEU.UniteID = _UniteMesureID)
	)

UPDATE @Results SET
VolumeLivreContrat = (
	SELECT
	SUM(VolumeNet)
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
	WHERE ((@Annee IS NULL) OR (L.Annee = @Annee))
	AND (L.Facture = 1)
	AND C.UsineID = _UsineID
	AND (LD.EssenceID = _EssenceID)
	AND (LD.Code = _Code)
	AND (LD.UniteMesureID = _UniteMesureID)
	)

UPDATE @Results SET
VolumeLivreContrat = VolumeLivreContrat * dbo.jag_GetContingentementUniteFacteur(_UsineID, @Annee, _EssenceID, _Code, _UniteMesureID)

UPDATE @Results SET
VolumeLivreContrat = 0
WHERE VolumeLivreContrat IS NULL

UPDATE @Results SET
VolumeALivreContrat = VolumePrevueContrat - VolumeLivreContrat

UPDATE @Results SET
VolumeAccordeContingentement = (
	select
	SUM(Volume_Accorde)
	from Contingentement_Producteur CP
		INNER JOIN Contingentement C ON C.[ID] = CP.ContingentementID AND C.[ContingentUsine] = 1
	WHERE C.UsineID = _UsineID
	AND C.Annee = @Annee
	AND C.UsineID = _UsineID
	AND (C.EssenceID = _EssenceID)
	AND (C.Code = _Code)
	AND (C.UniteMesureID = _UniteMesureID)	
)

UPDATE @Results SET
VolumeLivreContingentement = (SELECT
	SUM(VolumeNet * (CASE WHEN CU.Facteur IS NOT NULL THEN CU.Facteur ELSE 0 END))
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
		INNER JOIN Contingentement C ON C.[ID] = LD.ContingentementID AND C.ContingentUsine = 1
		LEFT OUTER JOIN Contingentement_Unite CU ON CU.ContingentementID = C.ID AND CU.UniteID = C.UniteMesureID
	WHERE ((@Annee IS NULL) OR (L.Annee = @Annee))
	AND (L.Facture = 1)
	AND L.UniteMesureID = _UniteMesureID
	AND C.UsineID = _UsineID
	AND (LD.EssenceID = _EssenceID)
	AND (LD.Code = _Code)
	AND (LD.UniteMesureID = _UniteMesureID)
	)

UPDATE @Results SET
VolumeLivreContingentement = 0
WHERE VolumeLivreContingentement IS NULL

SELECT
U.[Description] AS [Usine],
E.[Description] + ' ' + LTRIM(RTRIM(_Code)) AS [Essence],
R._UniteMesureID AS [Unite],
(R.VolumePrevueContrat) AS [VolumePrevueContrat],
(R.VolumeLivreContrat) AS [VolumeLivreContrat],
(R.VolumeALivreContrat) AS [VolumeALivreContrat],
(R.VolumeAccordeContingentement) AS [VolumeAccordeContingentement],
(R.VolumeLivreContingentement) AS [VolumeLivreContingentement]
FROM @Results R
	INNER JOIN Usine U ON U.[ID] = R._UsineID
	INNER JOIN Essence E ON E.[ID] = R._EssenceID
ORDER BY [Usine], [Essence], [Unite]


