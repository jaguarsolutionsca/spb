

CREATE PROCEDURE dbo.jag_ListView_GestionVolume
(
	@DateDebut DATETIME = NULL,
	@DateFin DATETIME = NULL
)

As

SELECT
[GestionVolume].[ID],
DateLivraison AS [Date],
UsineID AS [Usine],
Periode AS [Periode],
F.[Nom] AS [Producteur],
lot.CantonID AS [Canton],
lot.Rang, 
lot.Lot

FROM GestionVolume
		left outer join lot on Lot.ID = GestionVolume.LotID
		inner join Fournisseur F ON F.[ID] = ProducteurID
where 
		((@DateDebut	is null) or (@DateDebut <= DateLivraison))
	AND ((@DateFin		is null) or (@DateFin	>= DateLivraison))


