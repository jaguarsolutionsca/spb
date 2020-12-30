
CREATE PROCEDURE [dbo].[jag_Rapport_Statistique_AgenceMrcSecteur]
	(
	    @AgenceID_Debut varchar(4) = null,
	    @AgenceID_Fin varchar(4)  = null,
		@MrcID_Debut varchar(6) = null,
		@MrcID_Fin varchar(6) = null,
		@Secteur_Debut varchar(2) = null,
		@Secteur_Fin varchar(2) = null,
		@Annee int = null,
		@MoisDebut int = null,
		@MoisFin int = null
	)
AS


SET NOCOUNT ON

declare @Mois table
(
	Mois int,
	MunicipaliteID varchar(6),
	AgenceID varchar(4) null,
	MrcID varchar(6) null,
	Secteur varchar(2) null,
	UsineID varchar(6) null,
	_UniteID varchar(6) null,
	RepartitionID int null,
	UtilisationID int null,
	_EssenceID varchar(6) null,
	Total float null
)


-------------------------------------------------------------------------------------------------------
-- Importation des livraisons
-------------------------------------------------------------------------------------------------------

insert into @Mois (Mois, MunicipaliteID, Secteur, UsineID, _UniteID, RepartitionID, _EssenceID, Total)
select 
month(Livraison.DateLivraison),
Livraison.MunicipaliteID,
Secteur,
Contrat.UsineID,
Livraison_Detail.UniteMesureID,
max(E.RepartitionID),
Livraison_Detail.EssenceID,
case when sum(Livraison_Detail.VolumeNet) is not null then sum(Livraison_Detail.VolumeNet) else 0 end

from 
	Livraison
		inner join Livraison_detail on Livraison.ID = Livraison_detail.LivraisonID
			inner join Contrat on Livraison.ContratID = Contrat.ID
			inner join Essence E ON E.ID = Livraison_Detail.EssenceID
			inner join Municipalite_Secteur  on Livraison.MunicipaliteID = Municipalite_Secteur.MunicipaliteID and Municipalite_Secteur.Actif=1

where 
	((@Annee 		is null) or (year(Livraison.DateLivraison) = @Annee))
	AND ((@MoisDebut    is null) or (month(Livraison.DateLivraison) >=@MoisDebut))
	AND ((@MoisFin    is null) or (month(Livraison.DateLivraison) <=@MoisFin))
	
group by month(Livraison.DateLivraison), Livraison.MunicipaliteID, Municipalite_Secteur.Secteur, Contrat.UsineID, Livraison_Detail.UniteMesureID, Livraison_Detail.EssenceID

update @Mois SET AgenceID =
(SELECT AgenceID FROM Municipalite m WHERE m.ID = MunicipaliteID)

update @Mois SET MrcID =
(SELECT MrcID FROM Municipalite m WHERE m.ID = MunicipaliteID)


-------------------------------------------------------------------------------------------------------
-- Importation des gestions de volume
-------------------------------------------------------------------------------------------------------

insert into @Mois (Mois, UsineID, _UniteID, RepartitionID, _EssenceID, Total)
select 
month(GestionVolume.DateLivraison),
GestionVolume.UsineID,
GestionVolume_Detail.UniteMesureID,
max(E.RepartitionID),
GestionVolume_Detail.EssenceID,
case when sum(GestionVolume_Detail.VolumeNet) is not null then sum(GestionVolume_Detail.VolumeNet) else 0 end

from 
	GestionVolume
		inner join GestionVolume_Detail on GestionVolume.ID = GestionVolume_Detail.GestionVolumeID
		inner join Essence E ON E.ID = GestionVolume_Detail.EssenceID

where 
	((@Annee 		is null) or (year(GestionVolume.DateLivraison) = @Annee))
	AND ((@MoisDebut    is null) or (month(GestionVolume.DateLivraison) >=@MoisDebut))
	AND ((@MoisFin    is null) or (month(GestionVolume.DateLivraison) <=@MoisFin))
	AND (GestionVolume_detail.VolumeNet <> 0)
	
group by month(GestionVolume.DateLivraison), GestionVolume.UsineID, GestionVolume_Detail.UniteMesureID, GestionVolume_Detail.EssenceID



update @Mois SET UtilisationID =
(SELECT UtilisationID FROM Usine WHERE Usine.ID = USineID)


-------------------------------------------------------------------------------------------------------
-- Calculer les résultats
-------------------------------------------------------------------------------------------------------	

declare @Result table
(
	_UsineID varchar(6) null,
	_AgenceID varchar(4) null,
	_MrcID varchar(6) null,
	Secteur varchar(2) null,
	_UtilisationID int null,
	_RepartitionID int null,
	_EssenceID varchar(6) null,
	_UniteID varchar(6) null,
	Total float null,
	M3APP float null,
	M3SOL float null,
	TotM3APP float null,
	TotM3SOL float null
)


insert into @Result (_UsineID,_AgenceID,_MrcID, Secteur, _UtilisationID, _RepartitionID, _EssenceID, _UniteID, Total)
select UsineID, AgenceID, MrcID, Secteur, UtilisationID, RepartitionID, _EssenceID, _UniteID, sum(Total)
from @Mois
group by  UsineID, AgenceID, MrcID, Secteur, UtilisationID, RepartitionID, _EssenceID, _UniteID
	
update @Result SET M3APP =
(SELECT Facteur_M3app FROM Essence_Unite EU WHERE EU.EssenceID = _EssenceID AND EU.UniteID = _UniteID)

update @Result SET M3SOL =
(SELECT Facteur_M3sol FROM Essence_Unite EU WHERE EU.EssenceID = _EssenceID AND EU.UniteID = _UniteID)
	
update @Result SET M3APP = 0 WHERE M3APP IS NULL
update @Result SET M3SOL = 0 WHERE M3SOL IS NULL
update @Result SET Secteur = ' ' WHERE Secteur IS NULL

update @Result SET M3APP = ROUND(M3APP,2)
update @Result SET M3SOL = ROUND(M3SOL,2)

update @Result SET Total = ROUND(Total,2)

update @Result SET TotM3APP = ROUND((Total*M3APP),2)
update @Result SET TotM3SOL = ROUND((Total*M3SOL),2)


/*
select _AgenceID, _MRCID, Resident, _UtilisationID, _RepartitionID from @Result

SELECT
max(Ut.Description) as [Utilisation],
max(case when ER.Description is not null then ER.Description else 'non-défini' end) as [Repartition],
ROUND(SUM(Total),3) AS [Total],
ROUND(SUM(TotM3APP),3) AS [TotM3APP],
ROUND(SUM(TotM3SOL),3) AS [TotM3SOL]
FROM @Result
	left outer join UsineUtilisation Ut on Ut.ID = _UtilisationID
	left outer join EssenceRepartition ER on ER.ID = _RepartitionID
GROUP BY _UtilisationID, _RepartitionID
ORDER BY [Utilisation], [Repartition]
	
	
	select ROUND(SUM(Total),3) AS [Total]
	from @Result
	

*/

	
SELECT

max(case when A.Description  is not null then A.Description else 'Gestion de volume' end) as [Agence],
max(case when M.Description is not null then M.Description else ' ' end) as [MRC],
Secteur,
max(Ut.Description) as [Utilisation],
max(case when ER.Description is not null then ER.Description else 'non-défini' end) as [Repartition],
--ROUND(SUM(Total),3) AS [Total],
ROUND(SUM(TotM3APP),3) AS [TotM3APP],
ROUND(SUM(TotM3SOL),3) AS [TotM3SOL]
FROM @Result
	left outer join Agence A on A.ID = _AgenceID
	left outer join MRC M on M.ID = _MrcID
	left outer join UsineUtilisation Ut on Ut.ID = _UtilisationID
	left outer join EssenceRepartition ER on ER.ID = _RepartitionID
where
((@AgenceID_Debut is null) or (@AgenceID_Debut <= _AgenceID)) AND
((@AgenceID_Fin is null) or (_AgenceID <= @AgenceID_Fin)) AND
((@MrcID_Debut is null) or (@MrcID_Debut <= _MRCID)) AND
((@MrcID_Fin is null) or (_MRCID <= @MrcID_Fin)) AND
((@Secteur_Debut is null) or (@Secteur_Debut <= Secteur)) AND
((@Secteur_Fin is null) or (Secteur <= @Secteur_Fin)) 
GROUP BY _AgenceID, _MRCID, Secteur, _UtilisationID, _RepartitionID
ORDER BY [Agence],[MRC],Secteur, [Utilisation], [Repartition]	
