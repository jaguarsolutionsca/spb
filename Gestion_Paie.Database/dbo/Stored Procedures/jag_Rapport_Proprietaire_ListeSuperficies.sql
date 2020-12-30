

CREATE PROCEDURE dbo.jag_Rapport_Proprietaire_ListeSuperficies
	(		
		@ProprietaireDebut varchar(15) = Null,
		@ProprietaireFin varchar(15) = Null,
		@MunicipaliteDebut varchar(6) = Null,
		@MunicipaliteFin varchar(6) = Null,
		@DateRapport datetime = Null
	)
AS

SET NOCOUNT ON


--CREATE TABLE #tempTableSup 
DECLARE @tempTableSup TABLE
(
	ProprietaireID varchar(15) NULL,     
	SupTotale float NULL, 
	SupBoisee float NULL,
	Muni varchar(6) NULL  	
)

insert into @tempTableSup
select 
	ProprietaireID,
	sum(Superficie_Total) as SupTotale,
	sum(Superficie_boisee) as SupBoisee,
	MunicipaliteID

from(
	select 
	ProprietaireID =CASE 
						WHEN (Lot.Droit_coupe_Date	>=  @DateRapport)	THEN Lot.Droit_coupeID
						WHEN (Lot.Droit_coupe_Date	is Null)			THEN Lot.ProprietaireID						
						ELSE Lot.ProprietaireID
					END,
	Superficie_Total,
	Superficie_boisee,
	MunicipaliteID
	
	from Lot
	
	where 
	
		((@MunicipaliteDebut	IS NULL) OR (Lot.[MunicipaliteID]	>= @MunicipaliteDebut))
	AND	((@MunicipaliteFin		IS NULL) OR (Lot.[MunicipaliteID]	<= @MunicipaliteFin))
	
	) as t1
	
	group by ProprietaireID, MunicipaliteID

SELECT

Fournisseur.ID as CodeProprietaire,
Fournisseur.Nom as Proprietaire, 
--Municipalite.[ID] as CodeMunicipalite,
Municipalite.[Description] as Municipalite,
SupTotale, 
SupBoisee 

FROM 
	@tempTableSup
		inner join Fournisseur on (ProprietaireID = Fournisseur.ID)
			inner join Municipalite on (Muni = Municipalite.[ID])

WHERE 

		((@ProprietaireDebut	IS NULL) OR (ProprietaireID	>= @ProprietaireDebut))
	AND	((@ProprietaireFin		IS NULL) OR (ProprietaireID	<= @ProprietaireFin))

order by Fournisseur.[Nom], Municipalite.[Description]


Return(@@RowCount)









