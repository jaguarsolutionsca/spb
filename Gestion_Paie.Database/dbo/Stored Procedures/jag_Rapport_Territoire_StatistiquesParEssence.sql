

CREATE PROCEDURE dbo.jag_Rapport_Territoire_StatistiquesParEssence
	(			
		@MunicipaliteDebut varchar(6) = Null,
		@MunicipaliteFin varchar(6) = Null,
		@EssenceDebut varchar(6) = Null,
		@EssenceFin varchar(6) = Null,
		@UniteMesure varchar(6) = Null,
		@PeriodeDebut int = Null,
		@PeriodeFin int = Null,
		@AnneeDebut int = Null,
		@AnneeFin int = Null,
		@UsineID varchar(6) = Null
	)
AS

SET NOCOUNT ON

--CREATE TABLE #tempTableMuniContingent
DECLARE @tempTableMuniContingent TABLE 
(
     tempTableMuniID varchar(6) NULL,
     tempTableMuniNombre int NULL,
     tempTableMuniUniteMesure varchar(6) NULL
)

insert into @tempTableMuniContingent
select MuniCode, sum(MuniContingent), UniteMesure from
(
SELECT

Livraison.[MunicipaliteID]				As MuniCode,
Livraison_Detail.[VolumeBrut]	As MuniContingent,
Livraison.UniteMesureID			As UniteMesure

FROM 
	Livraison 
	inner join Livraison_detail on (Livraison.[ID] = Livraison_detail.[LivraisonID])
	--inner join Lot L on Livraison.LotID = L.ID
	inner join Contrat C on Livraison.ContratID = C.ID

WHERE 

		((@MunicipaliteDebut	IS NULL) OR (Livraison.[MunicipaliteID]			>= @MunicipaliteDebut))
	AND	((@MunicipaliteFin	IS NULL) OR (Livraison.[MunicipaliteID]			<= @MunicipaliteFin))
	AND	((@EssenceDebut		IS NULL) OR (Livraison_detail.[EssenceID]	>= @EssenceDebut))	
	AND	((@EssenceFin		IS NULL) OR (Livraison_detail.[EssenceID]	<= @EssenceFin))
	AND	((@UniteMesure		IS NULL) OR (Livraison_detail.[UniteMesureID] 	= @UniteMesure))
	AND (Livraison_Detail.[ContingentementID] is not null)
	AND	((@UsineID 		is null) or (C.UsineID 				= @UsineID))
	AND ((@PeriodeDebut is null and @AnneeDebut is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND	((@PeriodeFin is null and @AnneeFin is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	)
	
) as temp1
group by MuniCode, UniteMesure




SELECT

Municipalite.[ID]				As CodeMunicipalite,
max(Municipalite.[Description])			As Municipalite,
max(tempTableMuniNombre)			As VolumeContingentMunicipalite,
sum(Livraison_detail.VolumeNet)			As VolumeNetLivre,
PourcentNetLivre = 
    CASE 
        WHEN sum(Livraison_detail.VolumeNet) = 0	THEN 0
        ELSE (	100*(sum(Livraison_detail.VolumeNet)
					/
				(count(*)*(select (convert(float,[Value])*1000) from jag_SystemEx where jag_SystemEx.[Name] = 'MasseContingentVoyageDefaut')))
			 )
    END
,Livraison.UniteMesureID + ' - ' + UM.[Description] AS [UniteMesure]

FROM 
	Municipalite
	--inner join Lot L on L.MunicipaliteID = Municipalite.ID
	inner join Livraison on (Livraison.[MunicipaliteID] = Municipalite.[ID])
	inner join Livraison_detail on (Livraison.[ID] = Livraison_detail.[LivraisonID])
	inner join Contrat C on Livraison.ContratID = C.ID
	inner join UniteMesure UM ON UM.[ID] = Livraison.UniteMesureID
	left outer join @tempTableMuniContingent on (tempTableMuniID = Municipalite.[ID]) and tempTableMuniUniteMesure = Livraison.UniteMesureID


WHERE 
		((@MunicipaliteDebut	IS NULL) OR (Municipalite.[ID]			>= @MunicipaliteDebut))
	AND	((@MunicipaliteFin		IS NULL) OR (Municipalite.[ID]			<= @MunicipaliteFin))
	AND	((@EssenceDebut			IS NULL) OR (Livraison_detail.[EssenceID]	>= @EssenceDebut))	
	AND	((@EssenceFin			IS NULL) OR (Livraison_detail.[EssenceID]	<= @EssenceFin))
	AND	((@UniteMesure			IS NULL) OR (Livraison_detail.[UniteMesureID] 	= @UniteMesure))
	AND	((@UsineID 				is null) or (C.UsineID 				= @UsineID))
	AND ((@PeriodeDebut			is null and @AnneeDebut is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) >= ((convert(char(4), @AnneeDebut)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeDebut),2)))) ))
	AND	((@PeriodeFin			is null and @AnneeFin is null) or ( ((convert(char(4), Livraison.[Annee])) + (convert(char(2), RIGHT('00'+CONVERT(VARCHAR,Livraison.[Periode]),2)))) <= ((convert(char(4), @AnneeFin)) + (convert(char(2),RIGHT('00'+CONVERT(VARCHAR,@PeriodeFin),2)))) )	)
	
group BY Municipalite.[AgenceID], Municipalite.[MrcID], Municipalite.[ID], Livraison.UniteMesureID, UM.[Description], Municipalite.Actif


Return(@@RowCount)



