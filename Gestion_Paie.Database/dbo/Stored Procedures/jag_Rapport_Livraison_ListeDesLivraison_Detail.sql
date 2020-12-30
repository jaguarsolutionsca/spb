

CREATE PROCEDURE dbo.jag_Rapport_Livraison_ListeDesLivraison_Detail
	(		
		@Periode int = Null,
		@Annee int = Null,
		@Usine varchar(6) = Null
	)
AS

SET NOCOUNT ON


select 
--Contrat.UsineID as Usine,
Livraison.[NumeroFactureUsine] as Facture,
Livraison.[ID] AS [Permit],
Livraison.Periode,
Livraison.DateLivraison,
Transporteur.ID as CodeTrans,
Transporteur.Nom as Trans,
Lot = 	Lot +
	case when L.[Sequence] is not null and L.[Sequence] <> '' then '-' + L.[Sequence] else '' end +
	case when L.[Partie] = 1 then '(P)' else '' end,
L.Rang as Rang,
Canton.Description as Canton,
[Municipalite] = Municipalite.[Description] +
	case when Livraison.[ZoneID] is null or Livraison.[ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end,
Producteur.ID as CodeProd,
Producteur.Nom as Prod,
Chargeur.[ID] as CodeChargeur,
Chargeur.Nom AS [Chargeur],
Livraison_detail.EssenceID + ' ' + LTRIM(RTRIM(Livraison_Detail.Code)) as [EssenceID],
E.[Description] AS [Essence],
Livraison_detail.UniteMesureID as UniteMesure,
Livraison.VolumeAPayer as VolumeBrut,
Livraison_detail.VolumeNet as VolumeNet

from Livraison
	inner join Livraison_detail on Livraison.[ID] = Livraison_detail.[LivraisonID]
	left outer join Lot L on L.[ID] = Livraison.[LotID]
	inner join Contrat on Livraison.[ContratID] = Contrat.[ID]
	inner join Municipalite on Livraison.[MunicipaliteID] = Municipalite.[ID]
	left outer join Canton on L.[CantonID] = Canton.[ID]
	left outer join Fournisseur as Transporteur on Livraison.[TransporteurID] = Transporteur.[ID]
	inner join Fournisseur as Producteur on Livraison_Detail.[ProducteurID] = Producteur.[ID]
	left outer join Fournisseur as Chargeur on Livraison.ChargeurID = Chargeur.[ID]
	inner join Municipalite_Zone MZ on MZ.[ID] = Livraison.ZoneID and MZ.MunicipaliteID = Livraison.MunicipaliteID
	inner join Essence E on E.[ID] = Livraison_Detail.EssenceID
	
where 
		((@Periode	is null) or (Livraison.[Periode]	= @Periode))
	AND 	((@Annee	is null) or (Livraison.[Annee]		= @Annee))
	AND 	((@Usine	is null) or (Contrat.[UsineID]		= @Usine))	

order by Livraison.[NumeroFactureUsine]--Contrat.[UsineID], Livraison.[Lot], Livraison.[Rang], Canton.[Description]


Return(@@RowCount)

