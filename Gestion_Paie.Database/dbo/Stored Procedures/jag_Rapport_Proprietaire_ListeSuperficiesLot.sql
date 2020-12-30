

CREATE PROCEDURE dbo.jag_Rapport_Proprietaire_ListeSuperficiesLot
	(			
		@ProducteurDebut varchar(15) = Null,
		@ProducteurFin varchar(15) = Null,
		@MunicipaliteDebut varchar(6) = Null,
		@MunicipaliteFin varchar(6) = Null,
		@SuperficieTotalMin float = Null,
		@SuperficieTotalMax float = Null
	)
AS

SET NOCOUNT ON


SELECT
Fournisseur.ID as Code,
Fournisseur.Nom as Nom,
[Municipalite] = Municipalite.[Description] +
	case when Lot.[ZoneID] is null or Lot.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end,
Canton.Description as Canton,
Lot.Rang,
Lot = 	Lot +
	case when [Sequence] is not null and [Sequence] <> '' then '-' + [Sequence] else '' end +
	case when Lot.[Partie] = 1 then '(P)' else '' end,
Lot.Superficie_total as SupTotal,
Lot.Superficie_boisee as SupBoisee

FROM 
	Lot
		inner join Fournisseur on Lot.ProprietaireID = Fournisseur.[ID]
			inner join Canton on Lot.CantonID = Canton.ID
				inner join Municipalite on Lot.MunicipaliteID = Municipalite.ID
					inner join Municipalite_Zone MZ on MZ.ID = Lot.ZoneID and Lot.MunicipaliteID = MZ.MunicipaliteID

WHERE 

		((@ProducteurDebut		IS NULL) OR (Fournisseur.[ID]		>= @ProducteurDebut))
	AND	((@ProducteurFin		IS NULL) OR (Fournisseur.[ID]		<= @ProducteurFin))

	AND	((@MunicipaliteDebut	IS NULL) OR (Lot.[MunicipaliteID]	>= @MunicipaliteDebut))
	AND	((@MunicipaliteFin		IS NULL) OR (Lot.[MunicipaliteID]	<= @MunicipaliteFin))

	AND	((@SuperficieTotalMin	IS NULL) OR (Lot.[Superficie_total]	>= @SuperficieTotalMin))
	AND	((@SuperficieTotalMax	IS NULL) OR (Lot.[Superficie_total]	<= @SuperficieTotalMax))	
	
order by Fournisseur.Nom



Return(@@RowCount)



