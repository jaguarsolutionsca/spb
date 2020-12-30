


CREATE PROCEDURE dbo.jag_Rapport_Livraison_ListeDesLivraison_Master
	(		
		@Periode int = Null,
		@Annee int = Null,
		@Usine varchar(6) = Null
	)
AS

SET NOCOUNT ON


select 
--Contrat.UsineID as Usine,
MAX(Livraison.[NumeroFactureUsine]) as [Facture],
Livraison.[ID] AS [Permit],
MAX(Livraison.Periode) AS [Periode],
MAX(Transporteur.[ID]) as CodeTrans,
MAX(Transporteur.Nom) as Trans,
Lot = 	MAX(Lot) +
	case when MAX(L.[Sequence]) is not null and MAX(L.[Sequence]) <> '' then '-' + MAX(L.[Sequence]) else '' end +
	case when max(convert(int, L.[Partie])) = 1 then '(P)' else '' end,
MAX(L.Rang) as Rang,
MAX(Canton.[Description]) as Canton,
[Municipalite] = max(Municipalite.[Description]) +
	case when max(Livraison.[ZoneID]) is null or max(Livraison.[ZoneID]) = '0' then '' else ' (' + max(MZ.[Description]) + ')' end,
MAX(Producteur.[ID]) as CodeProd,
MAX(Producteur.Nom) as Prod,
MAX(Chargeur.[ID]) as CodeChargeur,
MAX(Chargeur.Nom) AS [Chargeur],
MAX(CASE WHEN (Livraison.Sciage = 1) THEN 'Sciage' ELSE Livraison.EssenceID + ' ' + RTRIM(LTRIM(Livraison.Code)) END) AS [Essence],
MAX(Livraison.UniteMesureID) as UniteMesure,
MAX(Livraison.VolumeAPayer) as VolumeTrans,
SUM(LD.VolumeNet) as VolumeProducteur

from Livraison
	left outer join Lot L on Livraison.LotID = L.ID
	inner join Livraison_Detail LD ON LD.[LivraisonID] = Livraison.[ID]
	inner join Contrat on Livraison.[ContratID] = Contrat.[ID]
	inner join Municipalite on Livraison.[MunicipaliteID] = Municipalite.[ID]
	left outer join Canton on L.[CantonID] = Canton.[ID]
	left outer join Fournisseur Transporteur on Livraison.[TransporteurID] = Transporteur.[ID]
	inner join Fournisseur Producteur on Livraison.[DroitCoupeID] = Producteur.[ID]
	left outer join Fournisseur as Chargeur on Livraison.ChargeurID = Chargeur.[ID]
	inner join Municipalite_Zone MZ on MZ.[ID] = Livraison.ZoneID and MZ.MunicipaliteID = Livraison.MunicipaliteID

where 
		((@Periode	is null) or (Livraison.[Periode]	= @Periode))
	AND ((@Annee	is null) or (Livraison.[Annee]		= @Annee))
	AND ((@Usine	is null) or (Contrat.[UsineID]		= @Usine))	

group by Livraison.[ID]
order by [Facture]--Contrat.[UsineID], Livraison.[Lot], Livraison.[Rang], Canton.[Description]



Return(@@RowCount)

