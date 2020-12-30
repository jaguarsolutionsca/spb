CREATE PROCEDURE [dbo].[jag_Rapport_Facture_ControleBoisParUsine]
@UsineDebut VARCHAR (6)=Null, @UsineFin VARCHAR (6)=Null, @Annee INT=Null, @MoisDebut INT=NULL, @MoisFin INT=NULL, @GroupByDate VARCHAR (50)='DateLivraison'
AS
SET NOCOUNT ON

declare @SQLText1 varchar(8000)
declare @SQLText2 varchar(8000)
declare @SQLText3 varchar(8000)
declare @SQLText4 varchar(8000)
declare @SQLText5 varchar(8000)
declare @SQLText6 varchar(8000)
declare @SQLText7 varchar(8000)
declare @SQLText8 varchar(8000)
declare @SQLText9 varchar(8000)

select @SQLText1 = ''
select @SQLText2 = ''
select @SQLText3 = ''
select @SQLText4 = ''
select @SQLText5 = ''
select @SQLText6 = ''
select @SQLText7 = ''
select @SQLText8 = ''
select @SQLText9 = ''

select @SQLText1 = '
declare @Mois table
(
	Mois int,
	UsineID varchar(6) null,
	UniteID varchar(6) null,
	RepartitionID int null,
	UtilisationID int null,
	EssenceID varchar(6) null,
	Code char(4) null,
	Total float null
)

insert into @Mois (Mois, UsineID, UniteID, RepartitionID, EssenceID, Code, Total)
select 
month(Livraison.' + @GroupByDate+ '),
Contrat.UsineID,
Livraison_Detail.UniteMesureID,
max(E.RepartitionID),
Livraison_Detail.EssenceID,
Livraison_Detail.Code,
case when sum(Livraison_Detail.VolumeNet) is not null then sum(Livraison_Detail.VolumeNet) else 0 end

from 
	Livraison
		inner join Livraison_detail on Livraison.ID = Livraison_detail.LivraisonID
			inner join Contrat on Livraison.ContratID = Contrat.ID
			inner join Essence E ON E.ID = Livraison_Detail.EssenceID

where 
	(3 = 3)'

if (@Annee is not null)
Begin
	select @SQLText1 = @SQLText1 + '
and 	(year(Livraison.DateLivraison) = ' + convert(varchar, @Annee) + ')'
End

if (@UsineDebut is not null)
Begin
	select @SQLText1 = @SQLText1 + '
and 	(Contrat.UsineID >= ''' + convert(varchar, @UsineDebut) + ''')'
End

if (@UsineFin is not null)
Begin
	select @SQLText1 = @SQLText1 + '
and 	(Contrat.UsineID <= ''' + convert(varchar, @UsineFin) + ''')'
End


select @SQLText1 = @SQLText1 + '
group by month(Livraison.' + convert(varchar, @GroupByDate) + '), Contrat.UsineID, Livraison_Detail.UniteMesureID, Livraison_Detail.EssenceID, Livraison_Detail.Code

'


select @SQLText2 = '
insert into @Mois (Mois, UsineID, UniteID, RepartitionID, EssenceID, Code, Total)
select 
month(GestionVolume.DateLivraison),
GestionVolume.UsineID,
GestionVolume_Detail.UniteMesureID,
max(E.RepartitionID),
GestionVolume_Detail.EssenceID,
'''', --Code
case when sum(GestionVolume_Detail.VolumeNet) is not null then sum(GestionVolume_Detail.VolumeNet) else 0 end

from 
	GestionVolume
		inner join GestionVolume_Detail on GestionVolume.ID = GestionVolume_Detail.GestionVolumeID
		inner join Essence E ON E.ID = GestionVolume_Detail.EssenceID

where 
	(3 = 3)'

if (@Annee is not null)
Begin
	select @SQLText2 = @SQLText2 + '
and 	(year(GestionVolume.DateLivraison) = ' + convert(varchar, @Annee) + ')'
End

if (@UsineDebut is not null)
Begin
	select @SQLText2 = @SQLText2 + '
and 	(GestionVolume.UsineID >= ''' + convert(varchar, @UsineDebut) + ''')'
End

if (@UsineFin is not null)
Begin
	select @SQLText2 = @SQLText2 + '
and 	(GestionVolume.UsineID <= ''' + convert(varchar, @UsineFin) + ''')'
End
	

select @SQLText2 = @SQLText2 + '
AND 	(GestionVolume_detail.VolumeNet <> 0)

group by month(GestionVolume.DateLivraison), GestionVolume.UsineID, GestionVolume_Detail.UniteMesureID, GestionVolume_Detail.EssenceID


update @Mois SET UtilisationID =
(SELECT UtilisationID FROM Usine WHERE Usine.ID = USineID)

'



select @SQLText3 = '
declare @Result table
(
	_UsineID varchar(6) null,
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
	M3SOL float null
)
'

--Janvier
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 1))AND((@MoisFin IS NULL) OR (@MoisFin >= 1)))
BEGIN
select @SQLText3 = @SQLText3 + '	
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Janvier)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 1
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END

--Fevrier
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 2))AND((@MoisFin IS NULL) OR (@MoisFin >= 2)))
BEGIN
select @SQLText3 = @SQLText3 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Fevrier)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 2
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END




--Mars
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 3))AND((@MoisFin IS NULL) OR (@MoisFin >= 3)))
BEGIN
select @SQLText4 = @SQLText4 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Mars)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 3
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END

--Avril
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 4))AND((@MoisFin IS NULL) OR (@MoisFin >= 4)))
BEGIN
select @SQLText4 = @SQLText4 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Avril)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 4
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END

--Mai
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 5))AND((@MoisFin IS NULL) OR (@MoisFin >= 5)))
BEGIN
select @SQLText4 = @SQLText4 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Mai)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 5
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END




--Juin
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 6))AND((@MoisFin IS NULL) OR (@MoisFin >= 6)))
BEGIN
select @SQLText5 = @SQLText5 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Juin)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 6
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END

--Juillet
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 7))AND((@MoisFin IS NULL) OR (@MoisFin >= 7)))
BEGIN
select @SQLText5 = @SQLText5 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Juillet)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 7
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END

--Aout
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 8))AND((@MoisFin IS NULL) OR (@MoisFin >= 8)))
BEGIN
select @SQLText5 = @SQLText5 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Aout)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 8
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END



--Septembre
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 9))AND((@MoisFin IS NULL) OR (@MoisFin >= 9)))
BEGIN
select @SQLText6 = @SQLText6 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Septembre)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 9
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END

--Octobre
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 10))AND((@MoisFin IS NULL) OR (@MoisFin >= 10)))
BEGIN
select @SQLText6 = @SQLText6 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Octobre)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 10
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END

--Novembre
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 11))AND((@MoisFin IS NULL) OR (@MoisFin >= 11)))
BEGIN
select @SQLText6 = @SQLText6 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Novembre)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 11
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END



--Decembre
IF (((@MoisDebut IS NULL) OR (@MoisDebut <= 12))AND((@MoisFin IS NULL) OR (@MoisFin >= 12)))
BEGIN
select @SQLText7 = @SQLText7 + '
	insert into @Result (_UsineID, _EssenceID, _Code, _RepartitionID, _UtilisationID, _UniteID, Decembre)
	select 
	UsineID,
	EssenceID,
	Code,
	RepartitionID,
	MAX(UtilisationID),
	UniteID,
	sum(Total)
	from @Mois 
	where Mois = 12
	AND Total <> 0
	group by UsineID, EssenceID, Code, RepartitionID, UniteID
'
END

select @SQLText7 = @SQLText7 + '
update @Result SET M3APP =
(SELECT Facteur_M3app FROM Essence_Unite EU WHERE EU.EssenceID = _EssenceID AND EU.UniteID = _UniteID)

update @Result SET M3SOL =
(SELECT Facteur_M3sol FROM Essence_Unite EU WHERE EU.EssenceID = _EssenceID AND EU.UniteID = _UniteID)

update @Result SET M3APP = 0 WHERE M3APP IS NULL
update @Result SET M3SOL = 0 WHERE M3SOL IS NULL

update @Result SET M3APP = ROUND(M3APP,3)
update @Result SET M3SOL = ROUND(M3SOL,3)

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

'

select @SQLText8 = '

update @Result SET Total = Janvier+Fevrier+Mars+Avril+Mai+Juin+Juillet+Aout+Septembre+Octobre+Novembre+Decembre
update @Result SET Total = ROUND(Total,3)

update @Result SET TotM3APP = ROUND((Total*M3APP),2)
update @Result SET TotM3SOL = ROUND((Total*M3SOL),2)

SELECT
U.Description AS [Usine],
E.Description + '' '' + LTRIM(RTRIM(_Code)) AS [Essence],
MAX(case when ER.Description is not null then ER.Description else ''non-défini'' end) as Repartition,
MAX(Ut.Description) AS [Utilisation],
_UniteID AS [Unite],
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
MAX(M3SOL) AS M3SOL
FROM @Result
		inner join Usine U on U.ID = _UsineID
			inner join Essence E  on E.ID = _EssenceID
					left outer join EssenceRepartition ER on ER.ID = _RepartitionID
						left outer join UsineUtilisation Ut on Ut.[ID] = _UtilisationID
group by U.Description, E.Description, _Code, ER.Description, Ut.Description, _UniteID
order by U.Description, [Essence], [Repartition], Ut.Description, _UniteID

SELECT
max(Ut.Description) as [Utilisation],
max(case when ER.Description is not null then ER.Description else ''non-défini'' end) as [Repartition],
ROUND(SUM(Total),3) AS [Total],
ROUND(SUM(TotM3APP),3) AS [TotM3APP],
ROUND(SUM(TotM3SOL),3) AS [TotM3SOL]
FROM @Result
	left outer join UsineUtilisation Ut on Ut.ID = _UtilisationID
	left outer join EssenceRepartition ER on ER.ID = _RepartitionID
GROUP BY _UtilisationID, _RepartitionID
ORDER BY [Utilisation], [Repartition]

'

select @SQLText9 = '
SELECT
max(case when ER.Description is not null then ER.Description else ''non-défini'' end) as [Repartition],
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

--Return(@@RowCount)
'
--print @SQLText1 + @SQLText2 + @SQLText3 + @SQLText4 + @SQLText5 + @SQLText6 + @SQLText7 + @SQLText8 + @SQLText9
exec (@SQLText1 + @SQLText2 + @SQLText3 + @SQLText4 + @SQLText5 + @SQLText6 + @SQLText7 + @SQLText8 + @SQLText9)


