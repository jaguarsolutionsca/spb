

CREATE PROCEDURE dbo.jag_Rapport_Livraison_SommaireLivraisonAvecDeductions
	(		
		@Periode int = Null,
		@Annee int = Null
	)
AS

SET NOCOUNT ON

DECLARE @tempTable TABLE(
	TypeLigne char(1) Null,
	_UsineID varchar(6) NULL,
	Usine varchar(50) NULL,
	_UniteMesureID varchar(6) NULL,
	VolumeNet float NULL,
	NombreFacture int NULL,
	MontantUsine float NULL,
	Frais_AutresAuProducteur float,
	Frais_AutresAuTransporteur float,
	Frais_AutresRevenusProducteur float,
	Frais_AutresRevenusTransporteur float,
	MontantUsineNet float
)

insert into @tempTable
select 
'D' as TypeLigne,
Usine.[ID] as _UsineID,
max(Usine.[Description]) as Usine,
Livraison_Detail.[UniteMesureID] as _UniteMesureID,
sum(Livraison_Detail.[VolumeNet]) as VolumeNet,
0 as NombreFacture,
sum(Livraison_Detail.Montant_Usine) as MontantUsine,
0 as Frais_AutresAuProducteur,
0 as Frais_AutresAuTransporteur,
0 as Frais_AutresRevenusProducteur,
0 as Frais_AutresRevenusTransporteur,
0 as MontantUsineNet
from 
	Livraison
		inner join Livraison_detail on Livraison.[ID] = Livraison_detail.[LivraisonID]
			inner join Contrat on Livraison.[ContratID] = Contrat.[ID]
				inner join Usine on Contrat.[UsineID] = Usine.[ID]

where 
		((@Periode	is null) or (Livraison.[Periode]	= @Periode))
	AND ((@Annee	is null) or (Livraison.[Annee]		= @Annee))

group by Usine.[ID], Livraison_Detail.[UniteMesureID]

update @tempTable set NombreFacture = (
SELECT 
COUNT(*) 
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE ((@Periode is null) or (L.[Periode] = @Periode))
AND ((@Annee is null) or (L.[Annee] = @Annee))
AND L.UniteMesureID = _UniteMesureID
AND C.UsineID = _UsineID
)

update @tempTable set Frais_AutresAuProducteur = (
SELECT 
SUM(Frais_AutresAuProducteur) 
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE ((@Periode is null) or (L.[Periode] = @Periode))
AND ((@Annee is null) or (L.[Annee] = @Annee))
AND L.UniteMesureID = _UniteMesureID
AND C.UsineID = _UsineID
)

update @tempTable set Frais_AutresAuTransporteur = (
SELECT 
SUM(Frais_AutresAuTransporteur) 
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE ((@Periode is null) or (L.[Periode] = @Periode))
AND ((@Annee is null) or (L.[Annee] = @Annee))
AND L.UniteMesureID = _UniteMesureID
AND C.UsineID = _UsineID
)

update @tempTable set Frais_AutresRevenusProducteur = (
SELECT 
SUM(Frais_AutresRevenusProducteur) 
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE ((@Periode is null) or (L.[Periode] = @Periode))
AND ((@Annee is null) or (L.[Annee] = @Annee))
AND L.UniteMesureID = _UniteMesureID
AND C.UsineID = _UsineID
)

update @tempTable set Frais_AutresRevenusTransporteur = (
SELECT 
SUM(Frais_AutresRevenusTransporteur) 
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE ((@Periode is null) or (L.[Periode] = @Periode))
AND ((@Annee is null) or (L.[Annee] = @Annee))
AND L.UniteMesureID = _UniteMesureID
AND C.UsineID = _UsineID
)

update @tempTable set MontantUsine = 0 WHERE MontantUsine IS NULL
update @tempTable set Frais_AutresAuProducteur = 0 WHERE Frais_AutresAuProducteur IS NULL
update @tempTable set Frais_AutresAuTransporteur = 0 WHERE Frais_AutresAuTransporteur IS NULL
update @tempTable set Frais_AutresRevenusProducteur = 0 WHERE Frais_AutresRevenusProducteur IS NULL
update @tempTable set Frais_AutresRevenusTransporteur = 0 WHERE Frais_AutresRevenusTransporteur IS NULL

update @tempTable set 
MontantUsineNet = MontantUsine - Frais_AutresAuProducteur - Frais_AutresAuTransporteur + Frais_AutresRevenusProducteur + Frais_AutresRevenusTransporteur

update @tempTable set MontantUsineNet = 0 WHERE MontantUsineNet IS NULL

/*
insert into @tempTable
select 
'T',
UsineID,
'Total pour '+max(Usine)+' ('+UniteMesure+')',
max(Essence),
UniteMesure,
sum(VolumeNet),
sum(NombreFacture),
sum(MontantUsine)

from @tempTable

where TypeLigne = 'D'

group by UsineID, UniteMesure
*/
select 

	Usine,
	_UniteMesureID AS [UniteMesure],
	VolumeNet,
	NombreFacture,
	MontantUsine,
	Frais_AutresAuProducteur,
	Frais_AutresAuTransporteur,
	Frais_AutresRevenusProducteur,
	Frais_AutresRevenusTransporteur,
	MontantUSineNet
from @tempTable

order by _UsineID, UniteMesure, TypeLigne

