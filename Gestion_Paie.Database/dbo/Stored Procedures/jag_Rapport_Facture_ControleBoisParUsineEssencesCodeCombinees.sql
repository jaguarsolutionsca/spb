CREATE PROCEDURE [dbo].[jag_Rapport_Facture_ControleBoisParUsineEssencesCodeCombinees]
	@UsineDebut VARCHAR (6)=Null, 
	@UsineFin VARCHAR (6)=Null, 
	@Annee INT=Null, 
	@MoisDebut INT=NULL, 
	@MoisFin INT=NULL
AS
SET NOCOUNT ON

declare		@_UsineDebut varchar(6)
declare		@_UsineFin varchar(6)
declare		@_Annee int
declare		@_MoisDebut int
declare		@_MoisFin int 

set		@_Annee = @Annee
set		@_MoisDebut = @MoisDebut
set		@_MoisFin = @MoisFin
set		@_UsineDebut = @UsineDebut
set		@_UsineFin =  @UsineFin

declare @Mois table
(
	Mois int,
	UsineID varchar(6) null,
	PaieTransporteur bit not null default 0,
	UniteID varchar(6) null,
	RepartitionID int null,
	UtilisationID int null,
	EssenceID varchar(6) null,
	Code char(4) null,
	Total float null,
	Montant_Usine FLOAT,
	Montant_Producteur FLOAT
)

insert into @Mois (Mois, UsineID, PaieTransporteur, UniteID, RepartitionID, EssenceID, Code,  Total, Montant_Usine, Montant_Producteur)
select 
month(Livraison.DateLivraison),
Contrat.UsineID,
Contrat.PaieTransporteur,
Livraison_Detail.UniteMesureID,
max(E.RepartitionID),
Livraison_Detail.EssenceID,
Livraison_Detail.Code,
case when sum(Livraison_Detail.VolumeNet) is not null then sum(Livraison_Detail.VolumeNet) else 0 end,
ROUND(SUM(Livraison_Detail.Montant_Usine),2),
ROUND(SUM(Livraison_Detail.Montant_ProducteurNet),2)

from 
	Livraison
		inner join Livraison_detail on Livraison.ID = Livraison_detail.LivraisonID
			inner join Contrat on Livraison.ContratID = Contrat.ID
			inner join Essence E ON E.ID = Livraison_Detail.EssenceID

where 
	((@_Annee 		is null) or (year(Livraison.DateLivraison) = @_Annee))
	AND ((@_UsineDebut	is null) or (Contrat.UsineID >= @_UsineDebut))
	AND ((@_UsineFin		is null) or (Contrat.UsineID <= @_UsineFin))
	
group by month(Livraison.DateLivraison), Contrat.UsineID, Contrat.PaieTransporteur, Livraison_Detail.UniteMesureID, Livraison_Detail.EssenceID, Livraison_Detail.Code

insert into @Mois (Mois, UsineID, UniteID, RepartitionID, EssenceID, Total)
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
	((@_Annee 		is null) or (year(GestionVolume.DateLivraison) = @_Annee))
	AND ((@_UsineDebut	is null) or (GestionVolume.UsineID >= @_UsineDebut))
	AND ((@_UsineFin		is null) or (GestionVolume.UsineID <= @_UsineFin))
	AND (GestionVolume_detail.VolumeNet <> 0)
	
group by month(GestionVolume.DateLivraison), GestionVolume.UsineID, GestionVolume_Detail.UniteMesureID, GestionVolume_Detail.EssenceID

update @Mois SET UtilisationID =
(SELECT UtilisationID FROM Usine WHERE Usine.ID = USineID)

declare @Result table
(
	_UsineID varchar(6) null,
	_PaieTransporteur bit not null default 0,
	_EssenceID varchar(6) null,
	_Code char(4) null,
	_RepartitionID int null,
	_UtilisationID int null,
	_UniteID varchar(6) null,
	Janvier float null,
	Fevrier float null,
	Mars float null,
	Avril float null,
	Mai float null,
	Juin float null,
	Juillet float null,
	Aout float null,
	Septembre float null,
	Octobre float null,
	Novembre float null,
	Decembre float null,
	Total float null,
	TotM3APP float null,
	TotM3SOL float null,
	M3APP float null,
	M3SOL float null,
	Montant_Usine FLOAT,
	Montant_Producteur FLOAT	
)

--Janvier
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 1))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 1)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Janvier, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)		
	from @Mois 
	where Mois = 1
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code,  RepartitionID, UniteID
END

--Fevrier
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 2))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 2)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Fevrier, Montant_Usine, Montant_Producteur)

	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)		
	from @Mois 
	where Mois = 2
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code, RepartitionID, UniteID
END

--Mars
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 3))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 3)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Mars, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)		
	from @Mois 
	where Mois = 3
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code, RepartitionID, UniteID
END

--Avril
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 4))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 4)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Avril, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code, 
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)		
	from @Mois 
	where Mois = 4
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code, RepartitionID, UniteID
END

--Mai
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 5))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 5)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Mai, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code, 
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)		
	from @Mois 
	where Mois = 5
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code,  RepartitionID, UniteID
END

--Juin
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 6))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 6)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Juin, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur, 
	EssenceID,
	Code, 
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)	
	from @Mois 
	where Mois = 6
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code, RepartitionID, UniteID
END

--Juillet
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 7))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 7)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Juillet, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code, 
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)	
	from @Mois 
	where Mois = 7
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code,  RepartitionID, UniteID
END

--Aout
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 8))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 8)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Aout, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)
	from @Mois 
	where Mois = 8
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code, RepartitionID, UniteID
END

--Septembre
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 9))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 9)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Septembre, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),	
	sum(Montant_Usine),
	sum(Montant_Producteur)
	from @Mois 
	where Mois = 9
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code, RepartitionID, UniteID
END

--Octobre
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 10))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 10)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Octobre, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)
	from @Mois 
	where Mois = 10
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code, RepartitionID, UniteID
END

--Novembre
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 11))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 11)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Novembre, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur, 
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)
	from @Mois 
	where Mois = 11
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code,RepartitionID, UniteID
END

--Decembre
IF (((@_MoisDebut IS NULL) OR (@_MoisDebut <= 12))AND((@_MoisFin IS NULL) OR (@_MoisFin >= 12)))
BEGIN
	insert into @Result (_UsineID, _PaieTransporteur, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Decembre, Montant_Usine, Montant_Producteur)
	select 
	UsineID,
	PaieTransporteur,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total),
	sum(Montant_Usine),
	sum(Montant_Producteur)
	from @Mois 
	where Mois = 12
	AND Total <> 0
	group by UsineID, PaieTransporteur, EssenceID, Code, RepartitionID, UniteID
END


update @Result SET M3APP =
(SELECT Facteur_M3app FROM Essence_Unite EU WHERE EU.EssenceID = _EssenceID AND EU.UniteID = _UniteID)

update @Result SET M3SOL =
(SELECT Facteur_M3sol FROM Essence_Unite EU WHERE EU.EssenceID = _EssenceID AND EU.UniteID = _UniteID)

update @Result SET M3APP = 0 WHERE M3APP IS NULL
update @Result SET M3SOL = 0 WHERE M3SOL IS NULL

update @Result SET M3APP = ROUND(M3APP,2)
update @Result SET M3SOL = ROUND(M3SOL,2)

update @Result SET Janvier = 0 WHERE Janvier IS NULL
update @Result SET Fevrier = 0 WHERE Fevrier IS NULL
update @Result SET Mars = 0 WHERE Mars IS NULL
update @Result SET Avril = 0 WHERE Avril IS NULL
update @Result SET Mai = 0 WHERE Mai IS NULL
update @Result SET Juin = 0 WHERE Juin IS NULL
update @Result SET Juillet = 0 WHERE Juillet IS NULL
update @Result SET Aout = 0 WHERE Aout IS NULL
update @Result SET Septembre = 0 WHERE Septembre IS NULL
update @Result SET Octobre = 0 WHERE Octobre IS NULL
update @Result SET Novembre = 0 WHERE Novembre IS NULL
update @Result SET Decembre = 0 WHERE Decembre IS NULL

update @Result SET Total = Janvier+Fevrier+Mars+Avril+Mai+Juin+Juillet+Aout+Septembre+Octobre+Novembre+Decembre
update @Result SET Total = ROUND(Total,2)

update @Result SET TotM3APP = ROUND((Total*M3APP),2)
update @Result SET TotM3SOL = ROUND((Total*M3SOL),2)



SELECT
U.Description AS [Usine],
E.Description AS [Essence],
 _Code [EssenceCode],
MAX(case when ER.Description is not null then ER.Description else 'non-défini' end) as Repartition,
MAX(Ut.Description) AS [Utilisation],
_UniteID AS [Unite],

--(case when _PaieTransporteur = 1 then 'Chemin' else 'Usine' end) Prix,
(case when _UsineID > 99 then 
	(case when right(_UsineID,1)= 1 then 'Chemin' else 'Usine' end) 
	else 
	(case when _PaieTransporteur = 1 then 'Chemin' else 'Usine' end)
 end) Prix,

SUM(Janvier) AS [Janvier],
SUM(Fevrier) AS Fevrier,
SUM(Mars) AS Mars,
SUM(Avril) AS Avril,
SUM(Mai) AS Mai,
SUM(Juin) AS Juin,
SUM(Juillet) AS Juillet, 
SUM(Aout) AS Aout,
SUM(Septembre) AS Septembre,
SUM(Octobre) AS Octobre,
SUM(Novembre) AS Novembre,
SUM(Decembre) AS Decembre,
SUM(Total) AS Total,
SUM(TotM3APP) AS TotM3APP,
SUM(TotM3SOL) AS TotM3SOL,
MAX(M3APP) AS M3APP,
MAX(M3SOL) AS M3SOL,
sum(Montant_Usine),
sum(Montant_Producteur)	

FROM @Result
		inner join Usine U on U.ID = _UsineID
			inner join Essence E  on E.ID = _EssenceID
					left outer join EssenceRepartition ER on ER.ID = _RepartitionID
						left outer join UsineUtilisation Ut on Ut.[ID] = _UtilisationID
group by U.Description, _UsineID , E.Description, _Code, ER.Description, Ut.Description, _UniteID, _PaieTransporteur
order by U.Description, _UsineID,[Essence], [EssenceCode], [Repartition], Ut.Description, _UniteID, _PaieTransporteur

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

SELECT
max(case when ER.Description is not null then ER.Description else 'non-défini' end) as [Repartition],
ROUND(SUM(Total),3) AS [Total],
ROUND(SUM(TotM3APP),3) AS [TotM3APP],
ROUND(SUM(TotM3SOL),3) AS [TotM3SOL]
FROM @Result
	left outer join EssenceRepartition ER on ER.ID = _RepartitionID
GROUP BY _RepartitionID
ORDER BY [Repartition]

SELECT
max(Ut.Description) as [Utilisation],
ROUND(SUM(Total),3) AS [Total],
ROUND(SUM(TotM3APP),3) AS [TotM3APP],
ROUND(SUM(TotM3SOL),3) AS [TotM3SOL]
FROM @Result
	left outer join UsineUtilisation Ut on Ut.ID = _UtilisationID
GROUP BY _UtilisationID
ORDER BY [Utilisation]

Return(@@RowCount)


