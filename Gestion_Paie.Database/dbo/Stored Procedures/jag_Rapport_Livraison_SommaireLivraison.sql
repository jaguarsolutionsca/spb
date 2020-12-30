

CREATE PROCEDURE dbo.jag_Rapport_Livraison_SommaireLivraison
	(		
		@Periode int = Null,
		@Annee int = Null
	)
AS

SET NOCOUNT ON

DECLARE @tempTable TABLE(
	TypeLigne char(1) Null,
	_ContratID varchar(10),
	_UsineID varchar(6) NULL,
	Usine varchar(50) NULL,
	_EssenceID varchar(6),
	_Code char(4),
	Essence varchar(50) NULL,
	_UniteMesureID varchar(6) NULL,
	VolumeNet float NULL,
	NombreFacture int NULL,
	MontantUsine float NULL
)

insert into @tempTable
select 
'D' as TypeLigne,
Livraison.ContratID,
Usine.[ID] as _UsineID,
max(Usine.[Description]) as Usine,
Livraison_Detail.[EssenceID],
Livraison_Detail.[Code],
Livraison_Detail.[EssenceID] + ' ' + RTRIM(LTRIM(Livraison_detail.Code)) as [Essence],
Livraison_Detail.[UniteMesureID] as _UniteMesureID,
sum(Livraison_Detail.[VolumeNet]) as VolumeNet,
count(*) as NombreFacture,
sum(Livraison_Detail.Montant_Usine) as MontantUsine

from 
	Livraison
		inner join Livraison_detail on Livraison.[ID] = Livraison_detail.[LivraisonID]
			inner join Contrat on Livraison.[ContratID] = Contrat.[ID]
				inner join Usine on Contrat.[UsineID] = Usine.[ID]

where 
		((@Periode	is null) or (Livraison.[Periode]	= @Periode))
	AND ((@Annee	is null) or (Livraison.[Annee]		= @Annee))

group by Livraison.ContratID, Usine.[ID], Livraison_Detail.[EssenceID], Livraison_detail.Code, Livraison_Detail.[UniteMesureID]

update @tempTable set NombreFacture = (
SELECT 
COUNT(*) 
FROM Livraison L
	INNER JOIN Contrat C ON C.[ID] = L.ContratID
WHERE ((@Periode is null) or (L.[Periode] = @Periode))
AND ((@Annee is null) or (L.[Annee] = @Annee))
AND L.UniteMesureID = _UniteMesureID
AND C.UsineID = _UsineID
AND L.[ID] in (SELECT LivraisonID FROM Livraison_Detail LD where LD.ContratID = _ContratID AND LD.EssenceID = _EssenceID AND LD.Code = _Code AND LD.UniteMesureID = _UniteMesureID)
)

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
	RTRIM(LTRIM(Essence)) AS [Essence],
	_UniteMesureID AS [UniteMesure],
	VolumeNet,
	NombreFacture,
	MontantUsine

from @tempTable

order by _UsineID, _UniteMesureID, [Essence], TypeLigne









