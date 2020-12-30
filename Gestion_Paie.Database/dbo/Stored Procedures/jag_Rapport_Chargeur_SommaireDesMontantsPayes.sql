

CREATE PROCEDURE dbo.jag_Rapport_Chargeur_SommaireDesMontantsPayes
	(		
		@DateDebut datetime = Null,
		@DateFin datetime = Null
	)
AS

SET NOCOUNT ON

select 

Fournisseur.[ID] as Code,
max(Fournisseur.[Nom]) as [Nom],

(
(case when sum(FactureFournisseur.[Montant_Total]) is not null then sum(FactureFournisseur.[Montant_Total]) else 0 end) -
(case when sum(FactureFournisseur.[Montant_TPS]) is not null then sum(FactureFournisseur.[Montant_TPS]) else 0 end) - 
(case when sum(FactureFournisseur.[Montant_TPS]) is not null then sum(FactureFournisseur.[Montant_TVQ]) else 0 end)
)
as MontantBrut,

(case when sum(FactureFournisseur.[Montant_TPS]) is not null then round(sum(FactureFournisseur.[Montant_TPS]), 2) else 0 end) as MontantTPS,

(case when sum(FactureFournisseur.[Montant_TVQ]) is not null then round(sum(FactureFournisseur.[Montant_TVQ]), 2) else 0 end) as MontantTVQ,

(case when sum(FactureFournisseur.[Montant_Total]) is not null then sum(FactureFournisseur.[Montant_Total]) else 0 end) as MontantNet

from 
	FactureFournisseur
		inner join Fournisseur on FactureFournisseur.[FournisseurID] = Fournisseur.[ID]

where 
	(TypeFactureFournisseur = 'C')
	AND ((@DateDebut	is null) or (FactureFournisseur.[DateFacture] >= @DateDebut))
	AND ((@DateFin		is null) or (FactureFournisseur.[DateFacture] <= @DateFin))
		
group by Fournisseur.[ID]
order by [Nom]


Return(@@RowCount)


