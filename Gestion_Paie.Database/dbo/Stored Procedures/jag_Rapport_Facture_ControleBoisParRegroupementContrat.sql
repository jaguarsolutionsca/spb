

CREATE PROCEDURE dbo.jag_Rapport_Facture_ControleBoisParRegroupementContrat
(
	@Annee int = null
)

AS

SET NOCOUNT ON

declare @Results table
(
	_RegroupementID VARCHAR(6) null,
	_UniteMesureID varchar(6) null,
	VolumePrevueContrat float null,
	VolumeLivreContrat float null,
	VolumeALivreContrat float null,
	VolumeAccordeContingentement float null,
	VolumeLivreContingentement float null
)

INSERT INTO @Results (_RegroupementID, _UniteMesureID)
SELECT DISTINCT
RegroupementID,
UniteMesureID
FROM Contingentement C
WHERE C.Annee = @Annee
AND C.ContingentUsine = 0
AND C.CalculAccepte = 1

UPDATE @Results SET
VolumePrevueContrat = dbo.jag_GetVolumePrevueContrat (@Annee, _RegroupementID, _UniteMesureID)

UPDATE @Results SET
VolumeLivreContrat = (
	SELECT
	SUM(VolumeNet * (CASE WHEN CU.Facteur IS NOT NULL THEN CU.Facteur ELSE 0 END))
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
		INNER JOIN Contrat C ON C.[ID] = L.ContratID
		LEFT OUTER JOIN Contingentement Co ON Co.Annee = C.Annee-- AND Co.RegroupementID = _RegroupementID
		LEFT OUTER JOIN Contingentement_Unite CU ON CU.ContingentementID = Co.ID AND CU.UniteID = Co.UniteMesureID
	WHERE ((@Annee IS NULL) OR (L.Annee = @Annee))
	AND (L.Facture = 1)
	AND LD.EssenceID IN (SELECT [ID] FROM Essence WHERE RegroupementID = _RegroupementID)
	AND Co.RegroupementID = _RegroupementID
	--AND L.UniteMesureID = _UniteMesureID
	)

UPDATE @Results SET
VolumeLivreContrat = 0
WHERE VolumeLivreContrat IS NULL

UPDATE @Results SET
VolumeALivreContrat = VolumePrevueContrat - VolumeLivreContrat

UPDATE @Results SET
VolumeAccordeContingentement = dbo.jag_GetVolumeAccordeContingentement (@Annee, _RegroupementID)

UPDATE @Results SET
VolumeLivreContingentement = (SELECT
	SUM(VolumeNet * (CASE WHEN CU.Facteur IS NOT NULL THEN CU.Facteur ELSE 0 END))
	FROM Livraison_Detail LD
		INNER JOIN Livraison L ON L.[ID] = LD.[LivraisonID]
		INNER JOIN Contingentement C ON C.[ID] = LD.ContingentementID AND C.ContingentUsine = 0
		LEFT OUTER JOIN Contingentement_Unite CU ON CU.ContingentementID = C.ID AND CU.UniteID = C.UniteMesureID
	WHERE ((@Annee IS NULL) OR (L.Annee = @Annee))
	AND (L.Facture = 1)
	--AND L.UniteMesureID = _UniteMesureID
	AND RegroupementID = _RegroupementID
	)

SELECT
(ER.[Description]) AS [Regroupement],
R._UniteMesureID AS [Unite],
(R.VolumePrevueContrat) AS [VolumePrevueContrat],
(R.VolumeLivreContrat) AS [VolumeLivreContrat],
(R.VolumeALivreContrat) AS [VolumeALivreContrat],
(R.VolumeAccordeContingentement) AS [VolumeAccordeContingentement],
(R.VolumeLivreContingentement) AS [VolumeLivreContingentement]
FROM @Results R
	INNER JOIN EssenceRegroupement ER ON ER.[ID] = R._RegroupementID
ORDER BY [Regroupement], [Unite]








