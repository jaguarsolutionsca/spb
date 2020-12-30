

CREATE PROCEDURE dbo.jag_GetVolumesLivres
(
	@ProducteurID varchar(16),
	@RegroupementID int,
	@UsineID varchar(6),
	@EssenceID varchar(6),
	@Date datetime
)

AS

	declare @Periode int
	declare @Annee int

	select 
	@Annee = Annee,
	@Periode = PeriodeContingentement
	from Periode 
	where DateDebut <= @Date and DateFin >= @Date

	select 
	sum(CP.Volume_Accorde) as VolumeAccorde,
	sum(dbo.jag_GetVolumeLivrePourContingentementParProducteur (CP.ContingentementID, CP.ProducteurID)) as VolumeLivre,
	sum(CP.Volume_Accorde - dbo.jag_GetVolumeLivrePourContingentementParProducteur (CP.ContingentementID, CP.ProducteurID)) as VolumeRestant
	from 
	Contingentement C inner join 
	Contingentement_Producteur CP on C.ID = CP.ContingentementID
	where 
	CP.ProducteurID = @ProducteurID and
	C.Annee = @Annee and
	C.PeriodeContingentement = @Periode and
	((C.RegroupementID = @RegroupementID) or ((C.UsineID = @UsineID) and (C.EssenceID = @EssenceID)))


