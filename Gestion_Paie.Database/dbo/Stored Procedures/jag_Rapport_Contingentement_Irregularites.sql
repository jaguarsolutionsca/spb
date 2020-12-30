CREATE PROCEDURE [dbo].[jag_Rapport_Contingentement_Irregularites]
@PeriodeDebut INT=Null, @PeriodeFin INT=Null, @AnneeDebut INT=Null, @AnneeFin INT=Null, @FouDebut VARCHAR (15)=Null, @FouFin VARCHAR (15)=Null
AS
SET NOCOUNT ON

Begin

	declare @LivraisonDetail table
	(
		ID int,
		ProducteurID varchar(15),
		ContingentementID int,
		Volume_Accorde real,
		Volume_Livre real,
		PasDeContingent bit,
		MauvaiseProvenance bit,
		MauvaisTransporteur bit,
		ContingentDepasse bit
	)


	----------------------------------------------------------------------------------
	-- Irrégularité ==> Pas de contingent
	-- Irrégularité ==> Mauvaise provenance par municipalité
	-- Irrégularité ==> Mauvais Transporteur
	----------------------------------------------------------------------------------
	insert into @LivraisonDetail (ID, ProducteurID, ContingentementID, Volume_Accorde, PasDeContingent, MauvaiseProvenance, MauvaisTransporteur, ContingentDepasse)
	Select
	LD.ID, LD.ProducteurID, LD.ContingentementID, 
	(case when  CP.Volume_Accorde is null then 0 else CP.Volume_Accorde end) Volume_Accorde,
	(case when  CP.Volume_Accorde is null then 1 else 0 end) PasDeContingent,
	(case when (dbo.jag_IsBonneProvenance(C.Annee, C.PeriodeContingentement, LD.ProducteurID, L.MunicipaliteID) = 0) then 1 else 0 end) MauvaiseProvenance, 
	(case when ((CD.TransporteurID <> L.TransporteurID ) or CD.TransporteurID is null) then 1 else 0 end) MauvaisTransporteur, 
	0
	from Livraison_Detail LD
		left Join Livraison L on LD.LivraisonID = L.ID
		left Join Contingentement C on LD.ContingentementID = C.ID
		left join Contingentement_Producteur CP on LD.ContingentementID=CP.ContingentementID and LD.ProducteurID = CP.ProducteurID
		left join Contingentement_Demande CD on CD.Annee = C.Annee and CD.ProducteurID = LD.ProducteurID
	where 
		
		((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(varchar,RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
		and	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), L.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,L.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(varchar,RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )) 			
		and ((@FouDebut	is null) or (LD.ProducteurID	>= @FouDebut))
		and ((@FouFin		is null) or (LD.ProducteurID	<= @FouFin))
		
		AND LD.contingentementID is not null 	
		
		
		
	----------------------------------------------------------------------------------
	-- Irrégularité ==> Contingent dépassé
	----------------------------------------------------------------------------------	


	-- Calcul volume livre pour chaque comobinaision de PRODUCTEUR-CONTINGENTEMENT
	declare @ProducteurVolume table
	(
		_ContingentementID int,
		_ProducteurID varchar(15),
		Volume_Livre real
	)
	

	insert into @ProducteurVolume (_ContingentementID, _ProducteurID)
	select distinct
	ContingentementID,
	ProducteurID
	from @LivraisonDetail
		
		
	update  @ProducteurVolume
	set Volume_Livre= dbo.jag_GetVolumeLivrePourContingentementParProducteurPeriode(_ContingentementID, _ProducteurID, @PeriodeFin)
	
	-- Applique le volume livré pour chaque liraison détai
	update @LivraisonDetail
	set Volume_Livre = (select Volume_Livre from @ProducteurVolume where _ProducteurID=ProducteurID and _ContingentementID = ContingentementID)

	update @LivraisonDetail set Volume_Livre = 0 where Volume_Livre is null
	update @LivraisonDetail	set ContingentDepasse = 1 where Volume_Livre > Volume_Accorde	
	
	----------------------------------------------------------------------------------
	-- Retourne toutes les irrégularités
	----------------------------------------------------------------------------------
	
	select
	L.ID Livraison,
	L.Annee LivraisonAnnee,
	L.Periode LivraisonPeriode,
	L.MunicipaliteID,
	M.[Description] Municipalite,	
	(case when C.ContingentUsine = 1 then U.[Description] + ' ' + E.[Description] else R.[Description] end) Contingentement,
	C.PeriodeContingentement ContingentPeriode,
	C.UniteMesureID UniteMesure,
	LD.ProducteurID Producteur,
	F.Nom,
	L.TransporteurID,
	(select case when CD.TransporteurID is null then 'Aucun' else CD.TransporteurID end) Transporteur ,
	LD.VolumeContingente * CU.Facteur Volume,
	temp.Volume_Accorde,
	temp.Volume_Livre,	
	PasDeContingent,
	MauvaiseProvenance,
	MauvaisTransporteur,
	ContingentDepasse

	from @LivraisonDetail temp
		left JOIN Livraison_Detail LD on LD.ID = temp.ID
		left JOIN Contingentement_Unite CU ON CU.ContingentementID = LD.ContingentementID AND CU.UniteID = LD.UniteMesureID
		left Join Livraison L on LD.LivraisonID = L.ID
		left Join Contingentement C on LD.ContingentementID = C.ID
		left join Contingentement_Producteur CP on LD.ContingentementID=CP.ContingentementID and LD.ProducteurID = CP.ProducteurID
		left join Fournisseur F on F.ID = LD.ProducteurID
		left join EssenceRegroupement R on R.ID=C.RegroupementID
		left join Usine U on U.ID = C.UsineID
		left join Essence E on E.ID = C.EssenceID
		left join Municipalite M on M.ID = L.MunicipaliteID
		left join Contingentement_Demande CD on CD.Annee = C.Annee and CD.ProducteurID = LD.ProducteurID
	where 	
		PasDeContingent = 1 OR
		MauvaiseProvenance = 1 OR
		MauvaisTransporteur = 1 OR
		ContingentDepasse = 1
	order by 
	L.Annee, L.Periode, LD.ProducteurID, LD.ContingentementID

end


