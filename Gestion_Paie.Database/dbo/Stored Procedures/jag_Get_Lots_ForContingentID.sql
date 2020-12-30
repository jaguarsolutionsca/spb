﻿


CREATE  PROCEDURE dbo.jag_Get_Lots_ForContingentID
	(
		@ContingentID varchar(15),
		@Date datetime = NULL
	)
AS

IF (@Date IS NULL) SET @Date = CONVERT(datetime, CONVERT(CHAR(15), GetDate(), 111))

Select
 [Lot].[ID]
,[Lot].[CantonID] + ' (' + [Canton].[Description] + ')' AS [Canton]
,[Lot].[CantonID]
,[Lot].[Rang]
,[Lot].[Lot]
,[Lot].[Sequence]
,[Lot].[Partie]
,Municipalite.[ID] as MunicipaliteID
,Municipalite.[Description] AS [Municipalité]
,[Lot].[Secteur] as Secteur
,[Lot].[ZoneID] as [Zone]
,[Zone].[Description] as [ZoneDesc]
,[Lot].[Superficie_total] AS [Superficie Totale]
,[Lot].[Superficie_boisee] AS [Superficie Boisée]
,[Lot].[Actif]
,[Lot].[Reforme]
,[Lot].[Cadastre]
,[Lot].[Matricule]
,[Lot].[Certifie]
,[Lot].[OGC]
From Lot
	INNER JOIN Canton ON Canton.[ID] = Lot.[CantonID]
	left outer JOIN Municipalite ON Municipalite.[ID] = Lot.[MunicipaliteID]
	left outer join Municipalite_Zone Zone on Zone.[ID] = Lot.ZoneID and Zone.MunicipaliteID = Lot.MunicipaliteID
WHERE 
(((ContingentID = @ContingentID AND Contingent_Date >= @Date)
OR
(((ContingentID IS NULL)OR(ContingentID = ProprietaireID)) AND (ProprietaireID = @ContingentID)))
OR
((ProprietaireID = @ContingentID)AND(Contingent_Date < @Date)))
AND ((Lot.Actif = 1) OR (Lot.Actif IS NULL))
ORDER BY CantonID, Rang, LEFT(('00000000'+Lot),6)






