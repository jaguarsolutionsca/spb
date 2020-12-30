

CREATE PROCEDURE dbo.jag_Rapport_Livraison_RepartitionDesLivraisons
	(		
		@UsineDebut varchar(6),
		@UsineFin varchar(6),
		@PeriodeDebut int,
		@AnneeDebut int,
		@PeriodeFin int,
		@AnneeFin int,
		@MunicipaliteID varchar(6),
		@AgenceDebut varchar(4),
		@AgenceFin varchar(4),
		@MRCDebut varchar(6),
		@MRCFin varchar(6)
	)
AS

declare @volumetotal float

select 
@volumetotal = sum(VolumeNet)
FROM Livraison_Detail
	inner join Livraison on Livraison.[ID] = Livraison_Detail.LivraisonID
	inner join Contrat on Livraison.[ContratID] = Contrat.[ID]
	left outer join Municipalite on Municipalite.ID = Livraison.MunicipaliteID
	--left outer join Lot on Lot.ID = Livraison.LotID
WHERE ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))	
AND 	((@UsineDebut is null) or (Contrat.UsineID >= @UsineDebut))
AND 	((@UsineFin is null) or (Contrat.UsineID <= @UsineFin))
AND 	((@MunicipaliteID is null) or (Livraison.MunicipaliteID = @MunicipaliteID))
AND 	((@AgenceDebut is null) or (Municipalite.AgenceID >= @AgenceDebut))
AND 	((@AgenceFin is null) or (Municipalite.AgenceID <= @AgenceFin))
AND 	((@MRCDebut is null) or (Municipalite.MrcID >= @MRCDebut))
AND 	((@MRCFin is null) or (Municipalite.MrcID <= @MRCFin))

DECLARE @livraisons TABLE
(
	LivraisonID int,
	EssenceID varchar(6),
	Code char(4),
	UniteMesureID varchar(6),
	VolumeNet float
)

insert into @livraisons
select 
Livraison_Detail.LivraisonID,
Livraison_Detail.EssenceID,
Livraison_Detail.Code,
Livraison_Detail.UniteMesureID,
sum(Livraison_Detail.VolumeNet)
FROM Livraison_Detail
	inner join Livraison on Livraison.[ID] = Livraison_Detail.LivraisonID
	inner join Contrat on Livraison.[ContratID] = Contrat.[ID]
	left outer join Municipalite on Municipalite.ID = Livraison.MunicipaliteID
WHERE ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) ))	
AND 	((@UsineDebut is null) or (Contrat.UsineID >= @UsineDebut))
AND 	((@UsineFin is null) or (Contrat.UsineID <= @UsineFin))
AND 	((@MunicipaliteID is null) or (Livraison.MunicipaliteID = @MunicipaliteID))
AND 	((@AgenceDebut is null) or (Municipalite.AgenceID >= @AgenceDebut))
AND 	((@AgenceFin is null) or (Municipalite.AgenceID <= @AgenceFin))
AND 	((@MRCDebut is null) or (Municipalite.MrcID >= @MRCDebut))
AND 	((@MRCFin is null) or (Municipalite.MrcID <= @MRCFin))
group by Livraison_Detail.LivraisonID, Livraison_Detail.EssenceID, Livraison_Detail.Code, Livraison_Detail.UniteMesureID

SELECT 
(Usine.[Description]) AS [Usine],
l.UniteMesureID AS [UniteMesure],
Essence.[Description] + ' ' + RTRIM(LTRIM(l.Code)) AS [Essence],
Ca.[Description] AS [Canton],
Agence.Description as Agence,
MRC.Description as MRC,
[Municipalite] = Livraison.MunicipaliteID + ' - ' + Municipalite.[Description] +
	(case when Livraison.[ZoneID] is null or Livraison.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end),
Lo.Rang AS [Rang],
Lo.Lot AS [Lot],
1 AS [Nombre],
(l.VolumeNet) AS [VolumeNet],
(CASE WHEN @volumetotal IS NOT NULL THEN ((l.VolumeNet) / @volumetotal) ELSE 0 END) AS [Pourcentage]
from @livraisons l
	INNER JOIN Livraison ON Livraison.[ID] = l.LivraisonID
	INNER JOIN Contrat ON Contrat.[ID] = Livraison.ContratID
	INNER JOIN Usine ON Usine.[ID] = Contrat.UsineID
	INNER JOIN UniteMesure ON UniteMesure.[ID] = l.UniteMesureID
	INNER JOIN Essence ON Essence.[ID] = l.EssenceID
	left outer JOIN Lot Lo ON Livraison.[LotID] = Lo.ID
	left outer join Canton Ca ON Ca.[ID] = Lo.CantonID
	INNER JOIN Municipalite ON Municipalite.[ID] = Livraison.MunicipaliteID
	left outer join Municipalite_Zone MZ on MZ.[ID] = Livraison.ZoneID and MZ.MunicipaliteID = Livraison.MunicipaliteID
	left outer join Agence on Agence.ID = Municipalite.AgenceID
	left outer join MRC on MRC.ID = Municipalite.MrcID

ORDER BY [Usine] ASC, [UniteMesure] ASC, [Essence] ASC, [Municipalite] ASC

