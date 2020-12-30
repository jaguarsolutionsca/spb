

CREATE PROCEDURE dbo.jag_Get_LotsContingentes
	(
		@Annee int,
		@ProducteurID varchar(15)
	)
AS

SELECT 
LC.LotID AS [ID]
,L.[CantonID] + ' (' + C.[Description] + ')' AS [Canton]
--,L.[CantonID]
,L.[Rang]
--,L.[Lot]
,L.Lot + (CASE WHEN ((L.[Sequence] IS NOT NULL)AND(LEN(LTRIM(RTRIM(L.[Sequence]))) > 0)) THEN '-'+L.[Sequence] ELSE '' END) 
       + (CASE WHEN ((L.[Partie] IS NOT NULL)AND(L.[Partie] = 1)) THEN '(P)' ELSE '' END) 
AS [Lot]
--,L.[Sequence]
--,L.[Partie]
--,M.[ID] as MunicipaliteID
,M.[Description] + (CASE WHEN ((L.ZoneID IS NULL)OR(L.ZoneID = '0')) THEN '' WHEN ((Z.[Description] IS NOT NULL)AND(LEN(LTRIM(RTRIM(Z.[Description]))) > 0)) THEN ' (' + Z.[Description] + ')' ELSE ' (' + L.ZoneID + ')' END) AS [Municipalite]
,(CASE WHEN L.[Superficie_boisee] IS NOT NULL THEN L.[Superficie_boisee] ELSE 0 END) AS [Superficie_boisee]
,(CASE WHEN LC.SuperficieContingentee IS NOT NULL THEN LC.SuperficieContingentee ELSE 0 END) AS [SuperficieContingentee]
,LC.Override
--,L.Actif
FROM LotContingente LC
	INNER JOIN Lot L ON L.[ID] = LC.LotID
	INNER JOIN Canton C ON C.[ID] = L.[CantonID]
	left outer JOIN Municipalite M ON M.[ID] = L.[MunicipaliteID]
	left outer join Municipalite_Zone Z on Z.[ID] = L.ZoneID and Z.MunicipaliteID = L.MunicipaliteID
WHERE (LC.Annee = @Annee)
AND (LC.FournisseurID = @ProducteurID)
--AND (LC.LotID in (select [ID] from dbo.jag_GetLotsForContingentID(@ContingentID, @DateContingent)))


