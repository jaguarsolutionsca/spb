

CREATE PROCEDURE dbo.jag_Rapport_Contrat_TablePrixTransporteur
	(		
		@Date datetime = null,
		@Usine varchar(6) = Null,
		@Unite varchar(6) = Null
	)
AS

SET NOCOUNT ON


declare @temp table
(
	MunicipaliteID varchar(6),
	Municipalite varchar(200),
	Zone varchar(100),
	TauxTransporteur real
)

insert into @temp
select 
Municipalite.[ID],
[Municipalite] = Municipalite.[Description] + 
		case when [ZoneID] is null or [ZoneID] = '0' then '' else ' (' + MZ.[Description] + ')' end,
Zone = (case when [ZoneID] is null or [ZoneID] = '0' then '' else [ZoneID] end),
Contrat_Transporteur.[Taux_transporteur] as TauxTransporteur

from 
	Contrat
		inner join Contrat_Transporteur on Contrat.[ID] = Contrat_Transporteur.[ContratID]	
			inner join Municipalite on Municipalite.[ID] = Contrat_Transporteur.[MunicipaliteID]
				inner join Municipalite_Zone MZ on Contrat_Transporteur.MunicipaliteID = MZ.MunicipaliteID and Contrat_Transporteur.ZoneID = MZ.[ID]
			
where 

	    ((@Usine		is null) or (Contrat.[UsineID]			= @Usine))
	AND ((@Unite		is null) or (Contrat_Transporteur.[UniteID]	= @Unite))
	AND ((@Date		is null) or ((Contrat.[date_debut] <= @Date) and (Contrat.[date_fin] >= @Date)))
	
order by Municipalite.[Description]




declare @MuniID varchar(6)
declare @Count int

DECLARE CUR CURSOR FOR
	select [ID] from Municipalite
OPEN CUR

	FETCH CUR
		INTO @MuniID		
			
	WHILE @@FETCH_STATUS = 0
	BEGIN	

		select @Count = count(*) from @temp where MunicipaliteID = @MuniID

		if @Count > 1
		BEGIN
			delete from @temp where MunicipaliteID = @MuniID and (Zone = '' or Zone is null)
		END

		FETCH CUR
			INTO @MuniID
	END
CLOSE CUR
DEALLOCATE CUR


select Municipalite, TauxTransporteur from @temp order by Municipalite, Zone

Return(@@RowCount)




