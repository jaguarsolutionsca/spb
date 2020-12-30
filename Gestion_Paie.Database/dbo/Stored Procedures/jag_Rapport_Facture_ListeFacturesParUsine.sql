

CREATE PROCEDURE dbo.jag_Rapport_Facture_ListeFacturesParUsine
	(		
		@DateDebut datetime = Null,
		@DateFin datetime = Null
	)
AS

SET NOCOUNT ON

declare @Cumul Table
(
	UsineID varchar(6),
	Usine float,
	Transporteur float,
	Producteur float
)

--Usine
insert into @Cumul
select 
C.UsineID [UsineID],
sum(dbo.jag_CalculateMontantUsineNet(L.[ID])) [Usine],
0 [Transporteur],
0 [Producteur]

from Livraison L
	inner join FactureClient FC on FC.[ID] = L.Usine_FactureID
	inner join Contrat C on L.ContratID = C.ID
		
where ((@DateDebut is null) or (FC.DateFacture >= @DateDebut))
AND	((@DateFin is null) or (FC.DateFacture <= @DateFin))
group by C.UsineID

--Transporteur
insert into @Cumul
select 
C.UsineID [UsineID],
0 [Usine],
sum(dbo.jag_CalculateMontantTransporteurNet(L.[ID])) [Transporteur],
0 [Producteur]

from Livraison L
	inner join FactureFournisseur FF on FF.[ID] = L.Transporteur_FactureID
	inner join Contrat C on L.ContratID = C.ID
		
where ((@DateDebut is null) or (FF.DateFacture >= @DateDebut))
AND	((@DateFin is null) or (FF.DateFacture <= @DateFin))
group by C.UsineID

--Producteur1
insert into @Cumul
select 
C.UsineID [UsineID],
0 [Usine],
0 [Transporteur],
round(sum(dbo.jag_CalculateMontantProducteurNet(L.[ID], L.DroitCoupeID)),2) [Producteur]

from Livraison L
	inner join FactureFournisseur FF on FF.[ID] = L.Producteur1_FactureID
	inner join Contrat C on L.ContratID = C.ID
		
where ((@DateDebut is null) or (FF.DateFacture >= @DateDebut))
AND	((@DateFin is null) or (FF.DateFacture <= @DateFin))
group by C.UsineID

--Producteur2
insert into @Cumul
select 
C.UsineID [UsineID],
0 [Usine],
0 [Transporteur],
round(sum(dbo.jag_CalculateMontantProducteurNet(L.[ID], L.EntentePaiementID)),2) [Producteur]

from Livraison L
	inner join FactureFournisseur FF on FF.[ID] = L.Producteur2_FactureID
	inner join Contrat C on L.ContratID = C.ID
		
where (L.EntentePaiementID IS NOT NULL)
AND ((@DateDebut is null) or (FF.DateFacture >= @DateDebut))
AND	((@DateFin is null) or (FF.DateFacture <= @DateFin))
group by C.UsineID

UPDATE @Cumul SET Transporteur = 0 WHERE Transporteur IS NULL
UPDATE @Cumul SET Producteur = 0 WHERE Producteur IS NULL

select 
U.[Description] [Usine],
sum(Usine) [Usine],
sum(Transporteur) [Transporteur],
sum(Producteur) [Producteur]
from @Cumul C
	inner join Usine U on U.[ID] = C.UsineID
group by U.[Description]
order by U.[Description]


Return(@@RowCount)


