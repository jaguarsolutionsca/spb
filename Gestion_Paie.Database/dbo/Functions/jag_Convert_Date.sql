

CREATE FUNCTION dbo.jag_Convert_Date
	(
	
	@datestr varchar(8)
	
	)
RETURNS datetime
AS

BEGIN
	declare @jour varchar(2)
	declare @mois varchar(2)
	declare @annee varchar(4)
	
	set @jour = SUBSTRING(@datestr,0,3)
	set @mois = SUBSTRING(@datestr,4,3)
	set @annee = SUBSTRING(@datestr,7,3)

	declare @date datetime
	
	set @date = @mois + '/' + @jour + '/' + @annee


RETURN @date
END









