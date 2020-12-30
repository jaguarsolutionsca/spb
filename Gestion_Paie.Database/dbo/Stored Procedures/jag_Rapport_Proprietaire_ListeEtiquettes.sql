

CREATE PROCEDURE [dbo].[jag_Rapport_Proprietaire_ListeEtiquettes]
	(		
		@TypeFournisseur varchar(1) = Null,
		@ProducteurDebut varchar(15) = Null,
		@ProducteurFin varchar(15) = Null,		
		@MembreDebut varchar(10) = Null,
		@MembreFin varchar(10) = Null,	
		@MunicipaliteDebut varchar(6) = Null,
		@MunicipaliteFin varchar(6) = Null,	
		@SecteurDebut varchar(2) = Null,
		@SecteurFin varchar(2) = Null,	
		@PeriodeContingentDebut INT = NULL,
		@PeriodeContingentAnneeDebut INT = NULL,
		@PeriodeContingentFin INT = NULL,
		@PeriodeContingentAnneeFin INT = NULL,
		@ContingentDebut int = Null,
		@ContingentFin int = Null,	
		@VolumeAccorde bit = Null,	
		@ResidentDebut char(1) = Null,
		@ResidentFin char(1) = Null,	
		@StatusDebut int = Null,
		@StatusFin int = Null,
		@Actif bit = Null,
		@Journal bit = Null,
		@Ville VARCHAR(30) = Null,
		@MRC varchar(6) = null,
		@LivraisonAnnee INT = NULL
	)
AS

SET NOCOUNT ON

declare @Temp table
(
	[ID]                                VARCHAR(15) NULL,
	Nom                                 VARCHAR(40) NULL,
	AuSoinsDe                           VARCHAR(30) NULL,
	Rue                                 VARCHAR(30) NULL,
	Ville                               VARCHAR(30) NULL,
	PaysID                              VARCHAR(2) NULL,
	Pays								VARCHAR(50) NULL,
	Code_postal                         VARCHAR(7) NULL,
	Telephone                           VARCHAR(12) NULL
)



insert into @Temp
select 
	f.[ID],
	max(f.Nom) as Nom,
	max(f.AuSoinsDe) as AuSoinsDe,
	max(f.Rue) as Rue,
	max(f.Ville) as Ville,
	max(f.PaysID) as PaysID,
	max(p.[Nom]) as Pays,
	max(f.Code_postal) as Code_postal,
	max(f.Telephone) as Telephone
from 
	Fournisseur f
	left outer join Pays p on p.ID = f.PaysID
	left outer join Lot L on L.ProprietaireID = f.[ID]
	left outer join Municipalite M ON M.ID = L.MunicipaliteID
	left outer join Contingentement_Producteur CP on f.[ID] = CP.ProducteurID
	left outer join Contingentement C ON C.[ID] = CP.ContingentementID

where

	((@TypeFournisseur IS NULL) OR 
	((@TypeFournisseur = 'P') and (f.IsProducteur = 1)) OR
	((@TypeFournisseur = 'T') and (f.IsTransporteur = 1)) OR
	((@TypeFournisseur = 'C') and (f.IsChargeur = 1)) OR
	((@TypeFournisseur = 'A') and (f.IsAutre = 1)))
	AND 	((@ProducteurDebut 	is null) or (@ProducteurDebut 		<= f.[ID]))
	AND 	((@ProducteurFin 	is null) or (@ProducteurFin 		>= f.[ID]))	
	AND 	((@MembreDebut 		is null) or (@MembreDebut 		<= f.[No_membre]))
	AND 	((@MembreFin 		is null) or (@MembreFin 		>= f.[No_membre]))	
	AND 	((@MunicipaliteDebut 	is null) or (@MunicipaliteDebut 	<= L.[MunicipaliteID]))
	AND 	((@MunicipaliteFin 	is null) or (@MunicipaliteFin 		>= L.[MunicipaliteID]))	
	AND 	((@SecteurDebut 	is null) or (@SecteurDebut 		<= L.[Secteur]))
	AND 	((@SecteurFin 		is null) or (@SecteurFin 		>= L.[Secteur]))
	AND		((@PeriodeContingentDebut IS NULL) OR (@PeriodeContingentAnneeDebut IS NULL) OR ( ((convert(char(4), C.Annee)) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,C.PeriodeContingentement),2)))) >= ((convert(char(4), @PeriodeContingentAnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeContingentDebut),2)))) ))
	AND		((@PeriodeContingentFin IS NULL) OR (@PeriodeContingentAnneeFin IS NULL) OR ( ((convert(char(4), C.Annee)) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,C.PeriodeContingentement),2)))) <= ((convert(char(4), @PeriodeContingentAnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeContingentFin),2)))) ))	
	AND 	((@PeriodeContingentFin	IS NULL) OR (@PeriodeContingentFin >= C.PeriodeContingentement))
	AND 	((@PeriodeContingentAnneeFin IS NULL) OR (@PeriodeContingentAnneeFin >= C.Annee))
	AND 	((@ContingentDebut	IS NULL) OR (@ContingentDebut		<= CP.[ContingentementID]))
	AND 	((@ContingentFin	IS NULL) OR (@ContingentFin		>= CP.[ContingentementID]))
	AND		((@VolumeAccorde	IS NULL)  or (@VolumeAccorde = 0 ) OR ( @VolumeAccorde = 1 and CP.Volume_Accorde <> 0))
	AND 	((@ResidentDebut 	is null) or (@ResidentDebut 		<= f.[Resident]))
	AND 	((@ResidentFin 		is null) or (@ResidentFin 		>= f.[Resident]))
	AND		((@StatusDebut 		is null) or (@StatusDebut		<= len(CASE WHEN f.[Statut] IS NOT NULL THEN f.[Statut] ELSE '' END)))
	AND 	((@StatusFin 		is null) or (@StatusFin			>= len(CASE WHEN f.[Statut] IS NOT NULL THEN f.[Statut] ELSE '' END)))
	AND 	((@Actif 		is null) or (@Actif 			=  f.[Actif]))
	AND 	((@Journal 		is null) or (@Journal 			=  f.[Journal]))
	AND		((@Ville is null) or (f.[Ville] LIKE '%'+@Ville+'%'))
	AND		((@MRC is null) or (M.MrcID = @MRC))
	AND ((@LivraisonAnnee IS NULL) OR ((F.[ID] IN (SELECT DISTINCT DroitCoupeID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee))
	     OR (F.[ID] IN (SELECT DISTINCT EntentePaiementID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee))))

group by F.[ID]

--SELECT F.[ID] FROM Fournisseur F 
--WHERE ((@LivraisonAnnee IS NULL) OR ((F.[ID] IN (SELECT DISTINCT DroitCoupeID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee))
--OR (F.[ID] IN (SELECT DISTINCT EntentePaiementID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee))))

select distinct
	[ID],
	Nom,
	AuSoinsDe,
	Rue,
	Ville,
	Pays,
	(case when len(code_postal) <= 6 then left(code_postal, 3) + ' ' + right(code_postal, 3) else code_postal end) as Code_postal,
	Telephone
from 
	@Temp 

order by Nom asc

Return(@@RowCount)


