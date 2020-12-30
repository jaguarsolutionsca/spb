

CREATE PROCEDURE dbo.jag_Rapport_Territoire_LotsParSecteur
	(
		@SecteurDebut varchar(6),-- = '0',
		@SecteurFin varchar(6),-- = 'zz',
		@MunicipaliteDebut varchar(6),-- = '0',
		@MunicipaliteFin varchar(6),-- = 'zz',		
		@RangDebut varchar(25),-- = '1',
		@RangFin varchar(25),-- = '2',
		@CantonDebut varchar(6),-- = '0',
		@CantonFin varchar(6),-- = 'zz'
		@Actif bit = NULL
	)
AS

SET NOCOUNT ON

SELECT
Lot.[Secteur] AS [Secteur],
CantonID,
Rang,
Lot = 	Lot +
	case when [Sequence] is not null and [Sequence] <> '' then '-' + [Sequence] else '' end +
	case when Lot.[Partie] = 1 then '(P)' else '' end
,
Superficie_total AS [Superficie Totale],
Superficie_boisee AS [Superficie Boisée],
Fournisseur.[ID] + ' - ' + Fournisseur.[Nom] AS [Proprietaire],
[Municipalite] = Municipalite.[Description] +
	case when [ZoneID] is null or [ZoneID] = '0' then '' else ' (' + Municipalite_Zone.[Description] + ')' end,
(CASE WHEN ((Lot.Actif IS NULL)OR(Lot.Actif = 1)) THEN 'Actif' ELSE 'Inactif' END) AS [Statut]

FROM Lot
	left outer JOIN Fournisseur ON Fournisseur.[ID] = Lot.[ProprietaireID]
	left outer JOIN Municipalite ON Municipalite.[ID] = Lot.[MunicipaliteID]
	left outer JOIN Municipalite_Zone ON Lot.[MunicipaliteID] = Municipalite_Zone.[MunicipaliteID] and Lot.[ZoneID] = Municipalite_Zone.[ID]
	
WHERE 
		((@SecteurDebut IS NULL) 	or (Lot.[Secteur] >= @SecteurDebut))
	AND 	((@SecteurFin IS NULL) 		or (Lot.[Secteur] <= @SecteurFin))
	AND 	((@MunicipaliteDebut IS NULL) 	or (Municipalite.[ID] >= @MunicipaliteDebut))
	AND 	((@MunicipaliteFin IS NULL) 	or (Municipalite.[ID] <= @MunicipaliteFin))
	AND 	((@RangDebut IS NULL) 		or (Lot.[Rang] >= @RangDebut))
	AND 	((@RangFin IS NULL) 		or (Lot.[Rang] <= @RangFin))
	AND 	((@CantonDebut IS NULL) 	or (Lot.[CantonID] >= @CantonDebut))
	AND 	((@CantonFin IS NULL) 		or (Lot.[CantonID] <= @CantonFin))
	AND 	((@Actif IS NULL) 		OR (Lot.[Actif] = @Actif))

ORDER BY Municipalite_Secteur.[Secteur], Lot.[CantonID], Lot.[Rang], Lot.[Lot]


Return(@@RowCount)



