CREATE FUNCTION [dbo].[jag_GetDateDebutContingentement]
(@Annee INT=Null, @PeriodeContingentement INT=Null)
RETURNS SMALLDATETIME
AS
Begin
	declare @DateDebut smalldatetime
	
	set @DateDebut = (select top 1 DateDebut from Periode
		where Annee = @Annee and PeriodeContingentement = @PeriodeContingentement
		order by Annee, SemaineNo)
		
	return @DateDebut

End


