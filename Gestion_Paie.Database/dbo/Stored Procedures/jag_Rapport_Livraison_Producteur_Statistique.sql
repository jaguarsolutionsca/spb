
Create PROCEDURE [dbo].[jag_Rapport_Livraison_Producteur_Statistique]
@UsineDebut VARCHAR (6)=Null, @UsineFin VARCHAR (6)=Null, @AgenceID_Debut VARCHAR (4)=null, @AgenceID_Fin VARCHAR (4)=null, @MrcID_Debut VARCHAR (6)=null, @MrcID_Fin VARCHAR (6)=null, @MunicipaliteID_Debut VARCHAR (6)=null, @MunicipaliteID_Fin VARCHAR (6)=null, @Secteur_Debut VARCHAR (2)=null, @Secteur_Fin VARCHAR (2)=null, @AnneeDebut INT=null, @AnneeFin INT=null, @PeriodeDebut INT=null, @PeriodeFin INT=null
AS
SET NOCOUNT ON

	declare @Livraison table
	(
		LivraisionID int null,
		Annee int null, 
		Periode int null,
		ProducteurID varchar(15) null,
		VolumeNet float null,
		Montant_ProducteurNet float null,
		Montant_Preleve_Plan_Conjoint float null,
		Montant_Preleve_Fond_Roulement float null,
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
	
	-----------------------------------------------------------------------------------------------
	-- Ajouter LIVRAISON
	-----------------------------------------------------------------------------------------------

	insert into @Livraison	
	(
		LivraisionID,
		Annee, 
		Periode,	
		ProducteurID,
		VolumeNet,
		Montant_ProducteurNet,
		Montant_Preleve_Plan_Conjoint,
		Montant_Preleve_Fond_Roulement,
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
	Livraison.ID,
	Livraison.Annee, 
	Livraison.Periode,
	Livraison_Detail.ProducteurID,
	Livraison_Detail.VolumeNet,
	Livraison_Detail.Montant_ProducteurNet,
	Livraison_Detail.Montant_Preleve_Plan_Conjoint,
	Livraison_Detail.Montant_Preleve_Fond_Roulement,	
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
	    left join Municipalite_Secteur  on Livraison.MunicipaliteID = Municipalite_Secteur.MunicipaliteID
	    left join Essence_Unite on Essence_Unite.EssenceID = Livraison_Detail.EssenceID AND
					Essence_Unite.UniteID = Livraison_Detail.UniteMesureID
	    Where
		((@UsineDebut is null) or (@UsineDebut <= Contrat.UsineID)) AND
		((@UsineFin is null) or (Contrat.UsineID <= @UsineFin)) AND    
		((@AgenceID_Debut is null) or (@AgenceID_Debut <= Municipalite.AgenceID)) AND
		((@AgenceID_Fin is null) or (Municipalite.AgenceID <= @AgenceID_Fin)) AND
		((@MrcID_Debut is null) or (@MrcID_Debut <= Municipalite.MrcID)) AND
		((@MrcID_Fin is null) or (Municipalite.MrcID <= @MrcID_Fin)) AND
		((@MunicipaliteID_Debut is null) or (@MunicipaliteID_Debut <= Livraison.MunicipaliteID)) AND
		((@MunicipaliteID_Fin is null) or (Livraison.MunicipaliteID <= @MunicipaliteID_Fin)) AND
		((@Secteur_Debut is null) or (@Secteur_Debut <= Municipalite_Secteur.Secteur)) AND
		((@Secteur_Fin is null) or (Municipalite_Secteur.Secteur <= @Secteur_Fin)) AND
		((@AnneeDebut is null) or (@AnneeDebut <= Livraison.Annee)) AND
		((@AnneeFin is null) or (Livraison.Annee <= @AnneeFin)) AND
		((@PeriodeDebut is null) or (@PeriodeDebut <= Livraison.Periode)) AND
		((@PeriodeFin is null) or (Livraison.Periode <= @PeriodeFin))     
		
	 
/*	 
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
*/	
	--------------------------------------------------------------
    -- Tableau Resume #6 Details
	--------------------------------------------------------------
	Select 
		F.Nom,
		F.AuSoinsDe,
		F.Rue,
		F.Ville,
		L.LivraisionID,
		L.Annee, 
		L.Periode,		
		L.ProducteurID,
		L.VolumeNet,	
		L.UsineID,
		L.EssenceID ,
		L.UniteMesureID,
		L.PateSciage,
		L.M3APP,
		L.M3SOL,
		L.Montant_ProducteurNet + L.Montant_Preleve_Plan_Conjoint + L.Montant_Preleve_Fond_Roulement Montant_Chemin,
		A.[Description] Agence,
		M.[Description] MRC,
		Mun.[Description] Municipalite,
		L.Secteur
		
	 from @Livraison as L
		left outer join Fournisseur f on f.ID = ProducteurID
		left outer join Agence A on A.ID = AgenceID
		left outer join MRC M on M.ID = MrcID
		left outer join Municipalite Mun on Mun.ID = MunicipaliteID


	--------------------------------------------------------------
    -- Tableau Resume #6 by usine-Agence-mrc-mun
	--------------------------------------------------------------
	Select 
		max (F.Nom) Nom,
		max(F.AuSoinsDe) AuSoinsDe,
		max(F.Rue) Rue,
		max(F.Ville) Ville,
		L.ProducteurID,
		sum(L.VolumeNet) VolumeNet,	
		L.UsineID,
		L.EssenceID ,
		L.UniteMesureID,
		L.PateSciage,
		sum(L.M3APP) M3APP,
		sum(L.M3SOL) M3SOL,
		sum(L.Montant_ProducteurNet + L.Montant_Preleve_Plan_Conjoint + L.Montant_Preleve_Fond_Roulement) Montant_Chemin,
		max(A.[Description]) Agence,
		Max(M.[Description]) MRC,
		Max(Mun.[Description]) Municipalite,
		L.Secteur
		
	 from @Livraison as L
		left outer join Fournisseur f on f.ID = ProducteurID
		left outer join Agence A on A.ID = AgenceID
		left outer join MRC M on M.ID = MrcID
		left outer join Municipalite Mun on Mun.ID = MunicipaliteID

	 GROUP BY 
	 L.UsineID,
	 L.EssenceID,
	 L.UniteMesureID,
	 L.PateSciage,
	 L.ProducteurID,
	 L.AgenceID,
	 L.MrcID,
	 L.MunicipaliteID,
	 L.Secteur
	 


	--------------------------------------------------------------
    -- Tableau Resume #6 by Usine-Producteur
	--------------------------------------------------------------
	Select 
		max (F.Nom) Nom,
		max(F.AuSoinsDe) AuSoinsDe,
		max(F.Rue) Rue,
		max(F.Ville) Ville,
		L.ProducteurID,
		sum(L.VolumeNet) VolumeNet,	
		L.UsineID,
		sum(L.M3APP) M3APP,
		sum(L.M3SOL) M3SOL,
		sum(L.Montant_ProducteurNet + L.Montant_Preleve_Plan_Conjoint + L.Montant_Preleve_Fond_Roulement) Montant_Chemin
		
	 from @Livraison as L
		left outer join Fournisseur f on f.ID = ProducteurID

	 GROUP BY 
	 L.UsineID,
	 L.ProducteurID
	 

	--------------------------------------------------------------
    -- Tableau Resume #6 by Producteur
	--------------------------------------------------------------
	Select 
		max (F.Nom) Nom,
		max(F.AuSoinsDe) AuSoinsDe,
		max(F.Rue) Rue,
		max(F.Ville) Ville,
		L.ProducteurID,
		sum(L.VolumeNet) VolumeNet,	
		sum(L.M3APP) M3APP,
		sum(L.M3SOL) M3SOL,
		sum(L.Montant_ProducteurNet + L.Montant_Preleve_Plan_Conjoint + L.Montant_Preleve_Fond_Roulement) Montant_Chemin
		
	 from @Livraison as L
		left outer join Fournisseur f on f.ID = ProducteurID

	 GROUP BY 
	 L.ProducteurID

