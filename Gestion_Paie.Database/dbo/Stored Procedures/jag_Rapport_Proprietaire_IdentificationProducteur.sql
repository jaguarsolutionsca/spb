

CREATE PROCEDURE [dbo].[jag_Rapport_Proprietaire_IdentificationProducteur]
	(		
		@SupBoiseeMin float = Null,
		@SupBoiseeMax float = Null,	
		@ProducteurDebut varchar(15) = Null,
		@ProducteurFin varchar(15) = Null,		
		@MembreDebut varchar(10) = Null,
		@MembreFin varchar(10) = Null,		
		@Actif bit = Null,		
		@ResidentDebut char(1) = Null,
		@ResidentFin char(1) = Null,	
		@ContingentementDebut int = Null,
		@ContingentementFin int = Null,	
		@VolumeAccorde bit = Null,		
		@MunicipaliteDebut varchar(6) = Null,
		@MunicipaliteFin varchar(6) = Null,
		@SecteurDebut varchar(2) = Null,
		@SecteurFin varchar(2) = Null,
		@DateRapport datetime = Null,
		@NePasEmettrePermis bit = Null
	)
AS

SET NOCOUNT ON

DECLARE @tempTable TABLE  
(
	FournisseurID varchar(15) NULL,
	FournisseurNom varchar(40) NULL, 
	FournisseurAuSoinsDe varchar(30) NULL,  	
 	FournisseurRep varchar(30) NULL,  	
 	FournisseurRue varchar(30) NULL,     
	FournisseurVille varchar(30) NULL,  
	FournisseurCodePostal varchar(7) NULL, 
	FournisseurPhone varchar(14) NULL, 
	FournisseurTPS varchar(25) NULL, 
	FournisseurTVQ varchar(25) NULL,  
	FournisseurSupBoisee float NULL,
	FournisseurNoMembre varchar(10) NULL,
	MunicipaliteID varchar(6) NULL,
	Secteur varchar(2) NULL
)

insert into @tempTable
SELECT
Fournisseur.ID,
max(Fournisseur.Nom),
max(Fournisseur.AuSoinsDe),
max(Fournisseur.Rep_Nom),
max(Fournisseur.Rue),
max(Fournisseur.Ville),
max(Fournisseur.Code_postal),
dbo.jag_Convert_Phone(max([Fournisseur].[Telephone])) As Phone,
max(Fournisseur.No_TPS),
max(Fournisseur.No_TVQ),
sum(Lot.Superficie_boisee),
max(Fournisseur.No_membre),
max(Lot.MunicipaliteID),
max(Lot.Secteur)

FROM 
	Fournisseur 
		LEFT OUTER join Contingentement_Producteur on (Contingentement_Producteur.[ProducteurID] = Fournisseur.[ID])
			left outer join Lot on (Lot.[ProprietaireID] = Fournisseur.[ID])


WHERE 
		((@Actif				IS NULL) OR (Fournisseur.[Actif]				= @Actif))
	AND ((@ResidentDebut		IS NULL) OR (Fournisseur.[Resident]				>= @ResidentDebut))
	AND ((@ResidentFin			IS NULL) OR (Fournisseur.[Resident]				<= @ResidentFin))
	AND ((@MembreDebut			IS NULL) OR (Fournisseur.[No_membre]			>= @MembreDebut))
	AND ((@MembreFin			IS NULL) OR (Fournisseur.[No_membre]			<= @MembreFin))	
	AND ((@ProducteurDebut		IS NULL) OR (Fournisseur.[ID]					>= @ProducteurDebut))
	AND ((@ProducteurFin		IS NULL) OR (Fournisseur.[ID]					<= @ProducteurFin))
	AND ((@MunicipaliteDebut	IS NULL) OR (Lot.[MunicipaliteID]				>= @MunicipaliteDebut))
	AND ((@MunicipaliteFin		IS NULL) OR (Lot.[MunicipaliteID]				<= @MunicipaliteFin))
	AND ((@SecteurDebut			IS NULL) OR (Lot.[Secteur]						>= @SecteurDebut))
	AND ((@SecteurFin			IS NULL) OR (Lot.[Secteur]						<= @SecteurFin))
	AND ((@ContingentementDebut	IS NULL) OR (Contingentement_Producteur.[ContingentementID]	>= @ContingentementDebut))
	AND ((@ContingentementFin	IS NULL) OR (Contingentement_Producteur.[ContingentementID]	<= @ContingentementFin))
	AND ((@VolumeAccorde		IS NULL) or (@VolumeAccorde = 0 ) OR (@VolumeAccorde = 1 and Contingentement_Producteur.Volume_Accorde <> 0))
	AND ((@SupBoiseeMin 		is NUll) OR (Lot.[Superficie_boisee]			>= @SupBoiseeMin)) 
	AND ((@SupBoiseeMax 		is NUll) OR (Lot.[Superficie_boisee] 			<= @SupBoiseeMax))	
	AND ((@NePasEmettrePermis	is NULL) OR (Fournisseur.[PasEmissionPermis] 	= @NePasEmettrePermis))
	AND (Fournisseur.IsProducteur = 1)

group by Fournisseur.[ID], Contingentement_Producteur.[ContingentementID]


update @tempTable set FournisseurSupBoisee = dbo.jag_GetSuperficieBoisee(FournisseurID, @DateRapport)

select 

distinct

FournisseurID,
FournisseurNom,
FournisseurAuSoinsDe,
FournisseurRep,      
FournisseurRue,     
FournisseurVille,  
FournisseurCodePostal, 
FournisseurPhone, 
FournisseurTPS, 
FournisseurTVQ,  
FournisseurSupBoisee,
FournisseurNoMembre,
(CASE WHEN MunicipaliteID IS NOT NULL THEN M.[Description] ELSE '' END) AS [Municipalite],
(CASE WHEN Secteur IS NOT NULL THEN Secteur ELSE '' END) AS [Secteur]

from @tempTable 
	left outer join Municipalite M ON M.[ID] = MunicipaliteID
order by fournisseurNom
	
Return(@@RowCount)


