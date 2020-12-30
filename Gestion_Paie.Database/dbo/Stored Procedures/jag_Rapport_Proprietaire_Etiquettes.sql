

CREATE PROCEDURE [dbo].[jag_Rapport_Proprietaire_Etiquettes]
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
		@LivraisonAnnee INT = NULL,
		@Generique bit = Null
	)
AS

SET NOCOUNT ON

declare @Temp table
(
	[ID]                                VARCHAR(15) NULL,
	CleTri                              VARCHAR(15) NULL,
	Nom                                 VARCHAR(40) NULL,
	AuSoinsDe                           VARCHAR(30) NULL,
	Rue                                 VARCHAR(30) NULL,
	Ville                               VARCHAR(30) NULL,
	PaysID                              VARCHAR(2) NULL,
	Pays				    			VARCHAR(50) NULL,
	Code_postal                         VARCHAR(7) NULL,
	Telephone                           VARCHAR(12) NULL,
	Telephone_Poste                     VARCHAR(4) NULL,
	Telecopieur                         VARCHAR(12) NULL,
	Telephone2                          VARCHAR(12) NULL,
	Telephone2_Desc                     VARCHAR(20) NULL,
	Telephone2_Poste                    VARCHAR(4) NULL,
	Telephone3                          VARCHAR(12) NULL,
	Telephone3_Desc                     VARCHAR(20) NULL,
	Telephone3_Poste                    VARCHAR(4) NULL,
	No_membre                           VARCHAR(10) NULL,
	Resident                            CHAR(1) NULL,
	Email                               VARCHAR(80) NULL,
	WWW                                 VARCHAR(80) NULL,
	Commentaires                        VARCHAR(255) NULL,
	AfficherCommentaires                BIT NULL,
	DepotDirect                         BIT NULL,
	InstitutionBanquaireID              VARCHAR(3) NULL,
	Banque_transit                      VARCHAR(5) NULL,
	Banque_folio                        VARCHAR(12) NULL,
	RecoitTPS                           BIT NULL,
	RecoitTVQ                           BIT NULL,
	No_TPS                              VARCHAR(25) NULL,
	No_TVQ                              VARCHAR(25) NULL,
	PayerA                              BIT NULL,
	PayerAID                            VARCHAR(15) NULL,
	Statut                              VARCHAR(50) NULL,
	Rep_Nom                             VARCHAR(30) NULL,
	Rep_Telephone                       VARCHAR(12) NULL,
	Rep_Telephone_Poste                 VARCHAR(4) NULL,
	Rep_Email                           VARCHAR(80) NULL,
	EnAnglais                           BIT NULL,
	Actif                               BIT NULL,
	MRCProducteurID                     INT NULL,
	PaiementManuel                      BIT NULL,
	Journal   			    			Bit NULL,
	IsProducteur 						Bit NULL,
	IsTransporteur 						Bit NULL,
	IsChargeur 							Bit NULL,
	IsAutre 							Bit NULL
)



insert into @Temp
select 
	f.[ID],
	max(f.CleTri) as CleTri,
	max(f.Nom) as Nom,
	max(f.AuSoinsDe) as AuSoinsDe,
	max(f.Rue) as Rue,
	max(f.Ville) as Ville,
	max(f.PaysID) as PaysID,
	max(p.[Nom]) as Pays,
	max(f.Code_postal) as Code_postal,
	max(f.Telephone) as Telephone,
	max(f.Telephone_Poste) as Telephone_Poste,
	max(f.Telecopieur) as Telecopieur,
	max(f.Telephone2) as Telephone2,
	max(f.Telephone2_Desc) as Telephone2_Desc,
	max(f.Telephone2_Poste) as Telephone2_Poste,
	max(f.Telephone3) as Telephone3,
	max(f.Telephone3_Desc) as Telephone3_Desc,
	max(f.Telephone3_Poste) as Telephone3_Poste,
	max(f.No_membre) as No_membre,
	max(f.Resident) as Resident,
	max(f.Email) as Email,
	max(f.WWW) as WWW,
	max(f.Commentaires) as Commentaires,
	f.AfficherCommentaires,
	f.DepotDirect,
	max(f.InstitutionBanquaireID) as InstitutionBanquaireID,
	max(f.Banque_transit) as Banque_transit,
	max(f.Banque_folio) as Banque_folio,
	f.RecoitTPS,
	f.RecoitTVQ,
	max(f.No_TPS) as No_TPS,
	max(f.No_TVQ) as No_TVQ,
	f.PayerA,
	max(f.PayerAID) as PayerAID,
	max(f.Statut) as Statut,
	max(f.Rep_Nom) as Rep_Nom,
	max(f.Rep_Telephone) as Rep_Telephone,
	max(f.Rep_Telephone_Poste) as Rep_Telephone_Poste,
	max(f.Rep_Email) as Rep_Email,
	f.EnAnglais,
	f.Actif,
	max(f.MRCProducteurID) as MRCProducteurID,
	f.PaiementManuel,
	f.Journal,
	f.IsProducteur,
	f.IsTransporteur,
	f.IsChargeur,
	f.IsAutre
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
	AND 	((@Actif 		is null) or (@Actif 			=  f.[Actif]))
	AND 	((@Journal 		is null) or (@Journal 			=  f.[Journal]))
	AND		((@Generique	is null) or (@Generique			=  f.Generique))
	AND		((@Ville is null) or (f.[Ville] LIKE '%'+@Ville+'%'))
	AND		((@MRC is null) or (M.MrcID = @MRC))
	AND ((@LivraisonAnnee IS NULL) OR ((F.[ID] IN (SELECT DISTINCT DroitCoupeID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee))
	     OR (F.[ID] IN (SELECT DISTINCT EntentePaiementID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee))))

group by F.[ID], f.EnAnglais, f.Actif, f.Journal, f.AfficherCommentaires, f.RecoitTPS, f.RecoitTVQ,
			f.PaiementManuel, f.DepotDirect, f.PayerA, f.IsProducteur, f.IsTransporteur, f.IsChargeur, f.IsAutre

update @Temp set Statut = '' where Statut is null

--SELECT F.[ID] FROM Fournisseur F 
--WHERE ((@LivraisonAnnee IS NULL) OR ((F.[ID] IN (SELECT DISTINCT DroitCoupeID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee))
--OR (F.[ID] IN (SELECT DISTINCT EntentePaiementID FROM Livraison L WHERE L.Facture=1 AND L.Annee = @LivraisonAnnee))))

select distinct
	[ID],
	CleTri,
	(CASE WHEN IsProducteur = 1 THEN 'PR ' ELSE '' END) +
	(CASE WHEN IsTransporteur = 1 THEN 'TR ' ELSE '' END) +
	(CASE WHEN IsChargeur= 1 THEN 'CH ' ELSE '' END) +
	(CASE WHEN IsAutre = 1 THEN 'AU ' ELSE '' END) AS [Type],
	Nom,
	AuSoinsDe,
	Rue,
	Ville,
	PaysID,
	Pays,
	(case when len(code_postal) <= 6 then left(code_postal, 3) + ' ' + right(code_postal, 3) else code_postal end) as Code_postal,
	(case 
		when len(ltrim(rtrim(Telephone))) = 10 then '(' + left(ltrim(rtrim(Telephone)), 3) +')' + ' ' + right(left(ltrim(rtrim(Telephone)), 6), 3) + '-' + right(ltrim(rtrim(Telephone)), 4) 
		when len(ltrim(rtrim(Telephone))) = 7 then left(ltrim(rtrim(Telephone)), 3) + '-' + right(ltrim(rtrim(Telephone)), 4) 
		else Telephone 
	end) as Telephone,
	Telephone_Poste,
	Telecopieur,
	Telephone2,
	Telephone2_Desc,
	Telephone2_Poste,
	Telephone3,
	Telephone3_Desc,
	Telephone3_Poste,
	No_membre,
	Resident,
	Email,
	WWW,
	Commentaires,
	AfficherCommentaires,
	DepotDirect,
	InstitutionBanquaireID,
	Banque_transit,
	Banque_folio,
	RecoitTPS,
	RecoitTVQ,
	No_TPS,
	No_TVQ,
	PayerA,
	PayerAID,
	Statut,
	Rep_Nom,
	Rep_Telephone,
	Rep_Telephone_Poste,
	Rep_Email,
	EnAnglais,
	Actif,
	MRCProducteurID,
	PaiementManuel,
	Journal
from 
	@Temp 

where
		((@StatusDebut 		is null) or (@StatusDebut		<= len(Statut)))
	AND 	((@StatusFin 		is null) or (@StatusFin			>= len(Statut)))

order by Nom asc

Return(@@RowCount)


