CREATE FUNCTION [dbo].[jag_IsBonneProvenance]
(@Annee INT=Null, @PeriodeContingentement INT=Null, @ContingentID VARCHAR (15)=Null, @MunicipaliteID VARCHAR (6)=Null)
RETURNS BIT
AS
Begin
	declare @valide bit
	declare @DateDebut smalldatetime
	declare @nbLots int
	
	
	set @DateDebut = dbo.jag_GetDateDebutContingentement(@Annee, @PeriodeContingentement)
	
	select
	@nbLots = count(*)
	from Lot L
	where 
	L.MunicipaliteID = @MunicipaliteID
	AND ((L.Actif = 1) OR (L.Actif IS NULL))
	AND ((L.OGC = 0) OR (L.OGC IS NULL))	
	AND (L.ID in (select [ID] from jag_GetLotsForContingentID(@ContingentID, @DateDebut)))


	set @valide = (select case when @nbLots > 0 then 1 else 0 end			)
		
	return @valide

End


