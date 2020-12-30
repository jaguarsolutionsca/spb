
CREATE PROCEDURE [dbo].[jag_DemandeDeContingentementEstrie]
@Annee INT, @ContingentID VARCHAR (15)=null, @DateContingent DATETIME=Null
AS
SET NOCOUNT ON

SELECT
F.[ID],
F.Nom,
F.AuSoinsDe [AS],
F.Rue,
F.Ville,
UPPER(F.Code_Postal) AS [Code_Postal],
dbo.jag_Convert_Phone(F.Telephone) AS [Telephone],
dbo.jag_Convert_Phone(F.Telecopieur) AS [Telecopieur],
F.No_TPS,
F.No_TVQ,
case when F.Email is not null then F.Email Else '' end Courriel
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
	L.Matricule,
	(CASE WHEN L.Superficie_total IS NOT NULL THEN L.Superficie_total ELSE 0 END) AS [Superficie_total],
	LC.SuperficieContingentee AS [Superficie_boisee],
	(case when L.ProprietaireID = L.ContingentID then 0 else 1 end) as [DroitCoupe],
	L.OGC
	
	FROM LotContingente LC
		INNER JOIN Lot L ON L.[ID] = LC.LotID
		INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		left outer join Municipalite_Zone MZ on MZ.ID = L.ZoneID and MZ.MunicipaliteID = L.MunicipaliteID
	WHERE LC.Annee = @Annee 
	AND LC.FournisseurID = @ContingentID and L.Actif=1
	ORDER BY M.[Description],  L.Matricule
END
ELSE
BEGIN
	SELECT
	M.[Description] + (case when L.[ZoneID] is null or L.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end) AS [Municipalite],
	L.Matricule,
	(CASE WHEN L.Superficie_total IS NOT NULL THEN L.Superficie_total ELSE 0 END) AS [Superficie_total],
	dbo.jag_GetLotSuperficieContingentee(L.[ID], @Annee) AS [Superficie_boisee],
	(case when ((Contingent_Date IS NOT NULL) AND (Contingent_Date >= @DateContingent) AND (L.ContingentID <> L.ProprietaireID)) then 1 else 0 end) as [DroitCoupe],
	L.OGC
	
	FROM Lot L
		INNER JOIN Municipalite M ON M.[ID] = L.MunicipaliteID
		left outer join Municipalite_Zone MZ on MZ.ID = L.ZoneID and MZ.MunicipaliteID = L.MunicipaliteID
	WHERE ((Contingent_Date IS NOT NULL) AND (Contingent_Date >= @DateContingent) AND (ContingentID = @ContingentID))
	OR (((Contingent_Date IS NULL) OR (Contingent_Date < @DateContingent)) AND (ProprietaireID = @ContingentID)) and L.Actif=1
	ORDER BY M.[Description],  L.Matricule
END



