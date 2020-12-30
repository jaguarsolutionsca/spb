


CREATE PROCEDURE dbo.jag_Rapport_Facture_ParFournisseur
(
	@TypeFournisseurID char(1) = null,
	@FournisseurDebut varchar(15) = null,
	@FournisseurFin varchar(15) = null,
	@PeriodeDebut int = null,
	@PeriodeFin int = null,
	@AnneeDebut int = null,
	@AnneeFin int = null,
	@Usine varchar(6) = null,
	@Essence varchar(6) = null,
	@Unite varchar(6) = null
)

AS

SET NOCOUNT ON


declare @AllFactures table
(
	FactureID int,
	LivraisonID int,
	NoFacture varchar(6),
	AnneePeriodeParamDebut real,
	AnneePeriodeParamFin real,
	AnneePeriodeLiv real
)

-- insert factures producteurs
if ((@TypeFournisseurID = 'P') or (@TypeFournisseurID is null))
BEGIN
	insert into @AllFactures
	select 
		Prod.ID, 
		L.ID, 
		Prod.NoFacture,
		(@AnneeDebut/1.0 	+ @PeriodeDebut/100.0), 
		(@AnneeFin/1.0 		+ @PeriodeFin/100.0),
		(L.Annee/1.0 		+ L.Periode/100.0)

	from 
		FactureFournisseur Prod 
		left outer join Livraison L on L.Producteur1_FactureID = Prod.ID
		left outer join Contrat C on L.ContratID = C.ID
		inner join Fournisseur F on F.ID = Prod.FournisseurID
	where 
		(Prod.ID 		is not null) and 
		(L.Facture 		= 1) and
		((@AnneeDebut 		is null or @PeriodeDebut is null) or (@AnneeDebut/1.0 	+ @PeriodeDebut/100.0	<= (L.Annee/1.0 + L.Periode/100.0))) and 
		((@AnneeFin 		is null or @PeriodeFin is null) or (@AnneeFin/1.0	+ @PeriodeFin/100.0	>= (L.Annee/1.0 + L.Periode/100.0))) and
		((@Usine		is null) or (@Usine 		= C.UsineID)) and
		((@Essence		is null) or (@Essence		= L.EssenceID)) and	
		((@Unite		is null) or (@Unite		= L.UniteMesureID)) and
		((@FournisseurDebut 	is null) or (@FournisseurDebut 	<= F.ID)) and
		((@FournisseurFin 	is null) or (@FournisseurFin   	>= F.ID)) and
		((@TypeFournisseurID IS NULL) OR 
		((@TypeFournisseurID = 'P') and (IsProducteur = 1)) OR
		((@TypeFournisseurID = 'T') and (IsTransporteur = 1)) OR
		((@TypeFournisseurID = 'C') and (IsChargeur = 1)) OR
		((@TypeFournisseurID = 'A') and (IsAutre = 1)))
	

	insert into @AllFactures
	select 
		Prod.ID, 
		L.ID, 
		Prod.NoFacture,
		(@AnneeDebut/1.0 	+ @PeriodeDebut/100.0), 
		(@AnneeFin/1.0 		+ @PeriodeFin/100.0),
		(L.Annee/1.0 		+ L.Periode/100.0)
	from 
		FactureFournisseur Prod
		left outer join Livraison L on L.Producteur2_FactureID = Prod.ID
		left outer join Contrat C on L.ContratID = C.ID
		inner join Fournisseur F on F.ID = Prod.FournisseurID
	where 
		(Prod.ID is not null) and 
		(L.Facture 		= 1) and
		((@AnneeDebut 		is null or @PeriodeDebut is null) or (@AnneeDebut/1.0 	+ @PeriodeDebut/100.0	<= (L.Annee/1.0 + L.Periode/100.0))) and 
		((@AnneeFin 		is null or @PeriodeFin is null) or (@AnneeFin/1.0	+ @PeriodeFin/100.0	>= (L.Annee/1.0 + L.Periode/100.0))) and
		((@Usine		is null) or (@Usine 		= C.UsineID)) and
		((@Essence		is null) or (@Essence		= L.EssenceID)) and	
		((@Unite		is null) or (@Unite		= L.UniteMesureID)) and
		((@FournisseurDebut 	is null) or (@FournisseurDebut 	<= F.ID)) and
		((@FournisseurFin 	is null) or (@FournisseurFin   	>= F.ID)) and
		((@TypeFournisseurID IS NULL) OR 
		((@TypeFournisseurID = 'P') and (IsProducteur = 1)) OR
		((@TypeFournisseurID = 'T') and (IsTransporteur = 1)) OR
		((@TypeFournisseurID = 'C') and (IsChargeur = 1)) OR
		((@TypeFournisseurID = 'A') and (IsAutre = 1)))
END


-- insert factures transporteurs
if ((@TypeFournisseurID = 'T') or (@TypeFournisseurID is null))
BEGIN
	insert into @AllFactures
	select 
		Prod.ID, 
		L.ID, 
		Prod.NoFacture,
		(@AnneeDebut/1.0 	+ @PeriodeDebut/100.0), 
		(@AnneeFin/1.0 		+ @PeriodeFin/100.0),
		(L.Annee/1.0 		+ L.Periode/100.0)
	from 
		FactureFournisseur Prod
		left outer join Livraison L on L.Transporteur_FactureID = Prod.ID
		left outer join Contrat C on L.ContratID = C.ID
		inner join Fournisseur F on F.ID = Prod.FournisseurID
	where 
		(Prod.ID 		is not null) and 
		(L.Facture 		= 1) and
		((@AnneeDebut 		is null or @PeriodeDebut is null) or (@AnneeDebut/1.0 	+ @PeriodeDebut/100.0	<= (L.Annee/1.0 + L.Periode/100.0))) and 
		((@AnneeFin 		is null or @PeriodeFin is null) or (@AnneeFin/1.0	+ @PeriodeFin/100.0	>= (L.Annee/1.0 + L.Periode/100.0))) and
		((@Usine		is null) or (@Usine 		= C.UsineID)) and
		((@Essence		is null) or (@Essence		= L.EssenceID)) and	
		((@Unite		is null) or (@Unite		= L.UniteMesureID)) and
		((@FournisseurDebut 	is null) or (@FournisseurDebut 	<= F.ID)) and
		((@FournisseurFin 	is null) or (@FournisseurFin   	>= F.ID)) and
		((@TypeFournisseurID IS NULL) OR 
		((@TypeFournisseurID = 'P') and (IsProducteur = 1)) OR
		((@TypeFournisseurID = 'T') and (IsTransporteur = 1)) OR
		((@TypeFournisseurID = 'C') and (IsChargeur = 1)) OR
		((@TypeFournisseurID = 'A') and (IsAutre = 1)))
END

--select * from @AllFactures order by NoFacture
--select livraisonid, count(*) from @AllFactures group by livraisonid
--select FactureID, count(*) from @AllFactures group by FactureID
--select count(distinct factureid) from @AllFactures




declare @AutresCategories table
(
	FactureID int,
	PreleveTPS float,
	PreleveTVQ float,
	ProducteurTPS float,
	ProducteurTVQ float,
	TransporteurTPS float,
	TransporteurTVQ float, 
	SurchargeTPS float,
	SurchargeTVQ float,
	ChargeurTPS float,
	ChargeurTVQ float,
	CompensationTPS float,
	CompensationTVQ float,
	AutresFraisTPS float,
	AutresFraisTVQ float,
	AutresChargesTPS float,
	AutresChargesTVQ float
)

insert into @AutresCategories (FactureID)
select distinct FactureID from @AllFactures


--------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------
-- Enlever les commentaires pour calculer les Prelevés, Surcharges, Compensations, ...
--------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------
/*
declare @FactureID int
DECLARE curs CURSOR FOR
	SELECT FactureID
	FROM @AutresCategories
OPEN curs
FETCH NEXT FROM curs INTO @FactureID
WHILE @@FETCH_STATUS = 0
BEGIN
	update @AutresCategories set PreleveTPS 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1000 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set PreleveTVQ 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1001 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set ProducteurTPS 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1002 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set ProducteurTVQ 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1003 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set TransporteurTPS 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1004 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set TransporteurTVQ 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1005 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set SurchargeTPS 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1006 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set SurchargeTVQ 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1007 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set ChargeurTPS 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1008 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set ChargeurTVQ 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1009 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set CompensationTPS 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1010 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set CompensationTVQ 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1011 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set AutresFraisTPS 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1012 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set AutresFraisTVQ 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1013 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set AutresChargesTPS 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1014 and FactureID = @FactureID) where FactureID = @FactureID
	update @AutresCategories set AutresChargesTVQ 	= (select top 1 Montant from facturefournisseur_sommaire where ligne = 1015 and FactureID = @FactureID) where FactureID = @FactureID

	FETCH NEXT FROM curs INTO @FactureID
END
CLOSE curs
DEALLOCATE curs
*/

select

NoFacture,
FournisseurID,
F.Nom as Fournisseur,
CONVERT(VARCHAR, DateFacture, 103) AS [DateFacture],
Annee,
A.PreleveTPS,
A.PreleveTVQ,
A.ProducteurTPS,
A.ProducteurTVQ,
A.TransporteurTPS,
A.TransporteurTVQ, 
A.SurchargeTPS,
A.SurchargeTVQ,
A.ChargeurTPS,
A.ChargeurTVQ,
A.CompensationTPS,
A.CompensationTVQ,
A.AutresFraisTPS,
A.AutresFraisTVQ,
A.AutresChargesTPS,
A.AutresChargesTVQ,
Montant_TPS,
Montant_TVQ,
Montant_Total,
case 
	when Status = 'Attente' 	then 'En Attente'
	when Status = 'FactureBad' 	then 'Annulé - Erreur en effectuant le facturant'
	when Status = 'FactureOK' 	then 'Facturée'
	when Status = 'PaiementOK' 	then 'Payée'
	when Status = 'PaiementBad' 	then 'Annullé - Erreur en effectuant le paiement'
	when Status = 'PaiementManuel' 	then 'Payée manuellement'	
	else ''
end as Status,
NumeroCheque,
case when Status <> 'Attente' and Status <> 'FactureBad' then DateFactureAcomba else null end as DateFactureAcomba,
case when Status = 'PaiementOK' then DatePaiementAcomba else null end as DatePaiementAcomba,
Description

from 
	FactureFournisseur FF
	inner join Fournisseur F on F.ID = FF.FournisseurID
	inner join @AutresCategories A on A.FactureID = FF.ID
where 
	((@FournisseurDebut 	is null) or (@FournisseurDebut <= F.ID)) and
	((@FournisseurFin 	is null) or (@FournisseurFin   >= F.ID)) and
	((@TypeFournisseurID IS NULL) OR 
	((@TypeFournisseurID = 'P') and (IsProducteur = 1)) OR
	((@TypeFournisseurID = 'T') and (IsTransporteur = 1)) OR
	((@TypeFournisseurID = 'C') and (IsChargeur = 1)) OR
	((@TypeFournisseurID = 'A') and (IsAutre = 1)))
order by
	NoFacture asc

