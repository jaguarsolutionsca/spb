



CREATE PROCEDURE [dbo].[jag_Rapport_Territoire_LotsParMunicipalite]
	(
	    @MrcID_Debut VARCHAR (6)=null, 
	    @MrcID_Fin VARCHAR (6)=null,	
		@MuniDebut varchar(6)=null,-- = '7602',
		@MuniFin varchar(6)=null,-- = '7602',
		@RangDebut varchar(25)=null,-- = '1',
		@RangFin varchar(25)=null,-- = '2',
		@CantonDebut varchar(6)=null,-- = '01',
		@CantonFin varchar(6)=null,-- = '01'
		@Actif bit = NULL
	)
AS

SET NOCOUNT ON
	declare @Lot table
	(
		CantonID varchar(6) null,
		Rang  varchar(25) null,
		Lot varchar(6) null, 
		Superficie_total float null,
		Superficie_boisee float null,		
		Proprietaire varchar(55) null,
		Municipalite varchar(125) null,	
		MrcID varchar(6) null,
		MRC varchar(50) null,
		Statut varchar(25) null
	)

	insert into @Lot	
	(
		CantonID,
		Rang,
		Lot, 
		Superficie_total,
		Superficie_boisee,		
		Proprietaire,
		Municipalite,	
		MrcID,
		MRC,
		Statut
	)
	
	SELECT
	CantonID,
	Rang,
	Lot,
	Superficie_total AS [Superficie Totale],
	Superficie_boisee AS [Superficie Boisée],
	Fournisseur.[ID] + ' - ' + Fournisseur.[Nom] AS [Proprietaire],
	Municipalite =	Municipalite.[Description] + 
			case when [ZoneID] is null or [ZoneID] = '0' then '' else ' (' + Municipalite_Zone.[Description] + ')' end,
	MrcID,
	MRC = Mrc.[Description],	
	(CASE WHEN ((Lot.Actif IS NULL)OR(Lot.Actif = 1)) THEN 'Actif' ELSE 'Inactif' END) AS [Statut]
	FROM Lot
		left outer JOIN Fournisseur ON Fournisseur.[ID] = Lot.[ProprietaireID]
		left outer JOIN Municipalite ON Municipalite.[ID] = Lot.[MunicipaliteID]
		left outer JOIN Municipalite_Zone ON Lot.[MunicipaliteID] = Municipalite_Zone.[MunicipaliteID] and Lot.[ZoneID] = Municipalite_Zone.[ID]
		left outer JOIN MRC ON Municipalite.MrcID = MRC.ID
	WHERE 
	    ((@MrcID_Debut is null) or (@MrcID_Debut <= Municipalite.MrcID)) AND
		((@MrcID_Fin is null) or (Municipalite.MrcID <= @MrcID_Fin)) AND
		((@MuniDebut 	is null) or (Lot.[MunicipaliteID] 	>= @MuniDebut)) AND
	 	((@MuniFin 	is null) or (Lot.[MunicipaliteID] 	<= @MuniFin)) AND
	 	((@RangDebut 	is null) or (Lot.[Rang] 		>= @RangDebut)) AND
	 	((@RangFin 	is null) or (Lot.[Rang] 		<= @RangFin)) AND
	 	((@CantonDebut 	is null) or (Lot.[CantonID] 		>= @CantonDebut)) AND
	 	((@CantonFin 	is null) or (Lot.[CantonID] 		<= @CantonFin)) AND
	 	((@Actif 	IS NULL) OR (Lot.[Actif] 		= @Actif))
	 	
	 	
	Select 
	CantonID,
	Rang,
	Lot, 
	Superficie_total,
	Superficie_boisee,		
	Proprietaire,
	Municipalite,	
	MRC,
	Statut
	from @lot
	ORDER BY [CantonID], [Rang], [Lot]
	 	
	--------------------------------------------------------------
	-- Tableau Resume #1 Nombre propriétaire par MRC
	--------------------------------------------------------------

	Select 
	MRC,
	count(distinct(Proprietaire))  as [NombreProprietaire] ,
	Round(sum(Superficie_total), 2) as Superficie_total,
	Round(sum(Superficie_boisee), 2) as Superficie_boisee		
	from @lot
	group by MrcID, MRC
	order by MRC


	--------------------------------------------------------------
	-- Tableau Resume #2 Nombre propriétaire 
	--------------------------------------------------------------

	Select 
	count(distinct(Proprietaire))  as [NombreProprietaire] ,
	Round(sum(Superficie_total), 2) as Superficie_total,
	Round(sum(Superficie_boisee), 2) as Superficie_boisee		
	from @lot


Return(@@RowCount)





