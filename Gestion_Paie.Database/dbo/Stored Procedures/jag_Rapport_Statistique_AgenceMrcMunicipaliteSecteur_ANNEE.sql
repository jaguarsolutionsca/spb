CREATE PROCEDURE [dbo].[jag_Rapport_Statistique_AgenceMrcMunicipaliteSecteur_ANNEE]
@Annee INT=null
AS
SET NOCOUNT ON

	declare @Livraison table
	(
		LivraisonType varchar(2) null,
		LivraisionID int null,
		Annee int null, 
		Periode int null,
		ProducteurID varchar(15) null,
		VolumeNet float null,
		UniteMesureID varchar(6) null,
		EssenceID varchar(6) null,
		MunicipaliteID varchar(6),
		AgenceID varchar(4) null,
		MrcID varchar(6) null,
		Secteur varchar(2) null,
		UsineID varchar(6) null,
		RepartitionID int null,
		UtilisationID int null,
		PateSciage varchar(6) null,
		M3APP float null,
		M3SOL float null
	)
	
	
		insert into @Livraison	
	(
		LivraisonType,
		LivraisionID,
		Annee, 
		Periode,	
		ProducteurID,
		VolumeNet,
		UniteMesureID,
		EssenceID ,
		MunicipaliteID,
		AgenceID,
		MrcID,
		Secteur,
		UsineID,
		RepartitionID,
		UtilisationID,
		PateSciage,
		M3APP,
		M3SOL
	)
		
		
	Select
	'L',
	Livraison.ID,
	Livraison.Annee, 
	Livraison.Periode,
	Livraison_Detail.ProducteurID,
	Livraison_Detail.VolumeNet,
	Livraison_Detail.UniteMesureID,	
	Livraison_Detail.EssenceID,
	Livraison.MunicipaliteID,
	Municipalite.AgenceID,
	Municipalite.MrcID,
	Municipalite_Secteur.Secteur,
	Contrat.UsineID,
	Essence.RepartitionID,
	Usine.UtilisationID,
	case when UsineUtilisation.isPate = 1 then 'Pâte' else 'Sciage' end,
	ROUND((Essence_Unite.Facteur_M3app * Livraison_Detail.VolumeNet),2) M3APP ,
	ROUND((Essence_Unite.Facteur_M3sol * Livraison_Detail.VolumeNet),2) M3SOL 

	
	From
	Livraison_detail 
		left join Livraison on  Livraison.ID = Livraison_detail.LivraisonID
		left join Contrat on Livraison.ContratID = Contrat.ID
		left join Usine on Contrat.UsineID = Usine.ID
		left join UsineUtilisation on UsineUtilisation.ID = Usine.UtilisationID
	    left join Essence  ON Essence.ID = Livraison_Detail.EssenceID
	    left join Municipalite on Livraison.MunicipaliteID = Municipalite.ID
	    left join Municipalite_Secteur  on Livraison.MunicipaliteID = Municipalite_Secteur.MunicipaliteID  and Municipalite_Secteur.Actif=1
	    left join Essence_Unite on Essence_Unite.EssenceID = Livraison_Detail.EssenceID AND
					Essence_Unite.UniteID = Livraison_Detail.UniteMesureID	
	where 
		((@Annee 		is null) or (year(Livraison.DateLivraison) = @Annee))
		

		insert into @Livraison	
		(
			LivraisonType,
			LivraisionID,
			Annee, 
			Periode,	
			ProducteurID,
			VolumeNet,
			UniteMesureID,
			EssenceID ,
			UsineID,
			RepartitionID,
			UtilisationID,
			PateSciage,
			M3APP,
			M3SOL
		)
	
		Select
		'GV',
		GestionVolume.ID,
		GestionVolume.Annee,
		GestionVolume.Periode,
		GestionVolume.ProducteurID,
		GestionVolume_Detail.VolumeNet,
		GestionVolume_Detail.UniteMesureID,	
		GestionVolume_Detail.EssenceID,
		GestionVolume.UsineID,
		Essence.RepartitionID,
		Usine.UtilisationID,
		case when UsineUtilisation.isPate = 1 then 'Pâte' else 'Sciage' end,
		ROUND((Essence_Unite.Facteur_M3app * GestionVolume_Detail.VolumeNet),2) M3APP ,
		ROUND((Essence_Unite.Facteur_M3sol * GestionVolume_Detail.VolumeNet),2) M3SOL 
		
		From
		GestionVolume_Detail 
			left join GestionVolume on  GestionVolume.ID = GestionVolume_Detail.GestionVolumeID
			left join Usine on GestionVolume.UsineID = Usine.ID
			left join UsineUtilisation on UsineUtilisation.ID = Usine.UtilisationID
			left join Essence  ON Essence.ID = GestionVolume_Detail.EssenceID
		    left join Essence_Unite on Essence_Unite.EssenceID = GestionVolume_Detail.EssenceID AND
					Essence_Unite.UniteID = GestionVolume_Detail.UniteMesureID
		where 
			((@Annee 		is null) or (year(GestionVolume.DateLivraison) = @Annee))


	 
	--------------------------------------------------------------
	-- Tableau Resume #1 Repartion Utilisation
	--------------------------------------------------------------
	SELECT	
	max(Ut.Description) as [Utilisation],
	max(case when ER.Description is not null then ER.Description else 'non-défini' end) as [Repartition],
	ROUND(SUM(M3APP),3) AS [TotM3APP],
	ROUND(SUM(M3SOL),3) AS [TotM3SOL],
	Count(distinct(ProducteurID)) as [NombreProducteur]
	FROM @Livraison
	 	left outer join UsineUtilisation Ut on Ut.ID = UtilisationID
		left outer join EssenceRepartition ER on ER.ID = RepartitionID
	GROUP BY UtilisationID, RepartitionID
	ORDER BY [Utilisation], [Repartition]
	
    --------------------------------------------------------------
    -- Tableau Resume #2 Repartion
	--------------------------------------------------------------
	SELECT
	max(case when ER.Description is not null then ER.Description else 'non-défini' end) as [Repartition],
	ROUND(SUM(M3APP),3) AS [TotM3APP],
	ROUND(SUM(M3SOL),3) AS [TotM3SOL],
	Count(distinct(ProducteurID)) as [NombreProducteur]
	FROM @Livraison
		left outer join EssenceRepartition ER on ER.ID = RepartitionID
	GROUP BY RepartitionID
	ORDER BY [Repartition]	
	
    --------------------------------------------------------------
    -- Tableau Resume #3 Utilisation
	--------------------------------------------------------------
	SELECT
	max(Ut.Description) as [Utilisation],
	ROUND(SUM(M3APP),3) AS [TotM3APP],
	ROUND(SUM(M3SOL),3) AS [TotM3SOL],
	Count(distinct(ProducteurID)) as [NombreProducteur]
	FROM @Livraison
		left outer join UsineUtilisation Ut on Ut.ID = UtilisationID
	GROUP BY UtilisationID
	ORDER BY [Utilisation]	
	

    --------------------------------------------------------------
    -- Tableau Resume #4 Pate ou Sciage
	--------------------------------------------------------------
	SELECT
	PateSciage as [PateSciage],
	ROUND(SUM(M3APP),3) AS [TotM3APP],
	ROUND(SUM(M3SOL),3) AS [TotM3SOL],
	Count(distinct(ProducteurID)) as [NombreProducteur]
	FROM @Livraison
	GROUP BY PateSciage
	ORDER BY [PateSciage]	


    --------------------------------------------------------------
    -- Tableau Resume #5 Total
	--------------------------------------------------------------
	SELECT
	'Total',
	ROUND(SUM(M3APP),3) AS [TotM3APP],
	ROUND(SUM(M3SOL),3) AS [TotM3SOL],
	Count(distinct(ProducteurID)) as [NombreProducteur]
	FROM @Livraison
	
	--------------------------------------------------------------
    -- Tableau Resume #6 Details
	--------------------------------------------------------------
	Select 
		(Ut.Description) as [Utilisation],
		(case when ER.Description is not null then ER.Description else 'non-défini' end) as [Repartition],	
		L.LivraisonType,
		L.LivraisionID,
		L.Annee, 
		L.Periode,		
		L.ProducteurID,
		L.VolumeNet,
		L.UniteMesureID,
		L.EssenceID ,
		L.MunicipaliteID,
		L.AgenceID,
		L.MrcID,
		L.Secteur,
		L.UsineID,
		L.RepartitionID,
		L.UtilisationID,
		L.PateSciage,
		L.M3APP,
		L.M3SOL
	 from @Livraison as L
		left outer join UsineUtilisation Ut on Ut.ID = UtilisationID
		left outer join EssenceRepartition ER on ER.ID = RepartitionID


