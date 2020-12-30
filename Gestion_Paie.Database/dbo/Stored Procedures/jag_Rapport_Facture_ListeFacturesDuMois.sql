

CREATE PROCEDURE dbo.jag_Rapport_Facture_ListeFacturesDuMois
	(		
		@DateDebut datetime = Null,
		@DateFin datetime = Null
	)
AS

SET NOCOUNT ON


select 
FF.NoFacture as Facture,
F.ID as Code,
F.Nom as Fournisseur,
--FF.DateFacture as [Date],
CONVERT(VARCHAR,FF.DateFacture,103) AS [Date],
FF.NumeroCheque AS [Cheque],
(case when FF.Montant_Total	is not null then round(FF.Montant_Total, 2)	else 0 end) as [MontantNet]
from 
	FactureFournisseur FF
		inner join fournisseur F on F.ID = FF.PayerAID
		
where 
		((@DateDebut	is null) or (@DateDebut	<= FF.DateFacture))
	AND	((@DateFin	is null) or (@DateFin	>= FF.DateFacture))




Return(@@RowCount)

