

CREATE PROCEDURE dbo.jag_DemandeDeContingentement
	(
		@Annee int,
		@ContingentID varchar(15) = null,
		@DateContingent datetime = Null
	)

AS

SET NOCOUNT ON

SELECT
F.[ID],
F.Nom,
F.Rue,
F.Ville,
UPPER(F.Code_Postal) AS [Code_Postal],
--dbo.jag_Convert_Phone('8191234567') AS [Telephone],
--dbo.jag_Convert_Phone('8191234567') AS [Telecopieur],
dbo.jag_Convert_Phone(F.Telephone) AS [Telephone],
dbo.jag_Convert_Phone(F.Telecopieur) AS [Telecopieur],
--'123511685' AS [No_TPS],
--'1012684246' AS [No_TVQ]
F.No_TPS,
F.No_TVQ
FROM Fournisseur F
WHERE F.[ID] = @ContingentID

declare @UtiliserLotsContingentes bit
set @UtiliserLotsContingentes = 0

if ((select count(*) from jag_SystemEx WHERE [Name] = 'UtiliserLotsContingentes') > 0)
BEGIN
	if ((SELECT UPPER([Value]) FROM jag_SystemEx WHERE [Name] = 'UtiliserLotsContingentes') = 'TRUE')
	BEGIN
		SET @UtiliserLotsContingentes = 1
	END	
END

IF (@UtiliserLotsContingentes = 1)
BEGIN
	SELECT
	M.[Description] + (case when L.[ZoneID] is null or L.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end) AS [Municipalite],
	C.[Description] AS [Canton],
	L.Rang,
	Lot +
		(case when [Sequence] is not null and [Sequence] <> '' then '-' + [Sequence] else '' end) +
		(case when L.[Partie] = 1 then '(P)' else '' end) AS [Lot],
	(CASE WHEN L.Superficie_total IS NOT NULL THEN L.Superficie_total ELSE 0 END) AS [Superficie_total],
	LC.SuperficieContingentee AS [Superficie_boisee]
	--(CASE WHEN L.Superficie_boisee IS NOT NULL THEN L.Superficie_boisee ELSE 0 END) AS [Superficie_boisee]
	FROM LotContingente LC
		INNER JOIN Lot L ON L.[ID] = LC.LotID
		INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		INNER JOIN Canton C ON C.[ID] = L.CantonID
		left outer join Municipalite_Zone MZ on MZ.ID = L.ZoneID and MZ.MunicipaliteID = L.MunicipaliteID
	WHERE LC.Annee = @Annee 
	AND LC.FournisseurID = @ContingentID and L.Actif=1
	ORDER BY M.[Description], C.[Description], L.Rang, L.Lot
END
ELSE
BEGIN
	SELECT
	[Municipalite] = M.[Description] +
		case when L.[ZoneID] is null or L.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end,
	C.[Description] AS [Canton],
	L.Rang,
	Lot = 	Lot +
		case when [Sequence] is not null and [Sequence] <> '' then '-' + [Sequence] else '' end +
		case when L.[Partie] = 1 then '(P)' else '' end,

	(CASE WHEN L.Superficie_total IS NOT NULL THEN L.Superficie_total ELSE 0 END) AS [Superficie_total],
	dbo.jag_GetLotSuperficieContingentee(L.[ID], @Annee) AS [Superficie_boisee]
	--(CASE WHEN L.Superficie_boisee IS NOT NULL THEN L.Superficie_boisee ELSE 0 END) AS [Superficie_boisee]
	FROM Lot L
		INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		INNER JOIN Canton C ON C.[ID] = L.CantonID
		left outer join Municipalite_Zone MZ on MZ.ID = L.ZoneID and MZ.MunicipaliteID = L.MunicipaliteID
	WHERE ((Contingent_Date IS NOT NULL) AND (Contingent_Date >= @DateContingent) AND (ContingentID = @ContingentID))
	OR (((Contingent_Date IS NULL) OR (Contingent_Date < @DateContingent)) AND (ProprietaireID = @ContingentID)) and L.Actif=1
	ORDER BY M.[Description], C.[Description], L.Rang, L.Lot
END


