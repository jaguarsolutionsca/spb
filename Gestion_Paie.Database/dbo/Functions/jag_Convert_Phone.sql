

CREATE FUNCTION dbo.jag_Convert_Phone
	(
	@phone varchar(15)
	)
RETURNS varchar(15)
AS

BEGIN

	declare @partie1 varchar(1)
	declare @partie2 varchar(3)
	declare @partie3 varchar(3)
	declare @partie4 varchar(4)

	set @partie4 = REVERSE(SUBSTRING(REVERSE(@phone),0,5))
	set @partie3 = REVERSE(SUBSTRING(REVERSE(@phone),5,3))
	set @partie2 = REVERSE(SUBSTRING(REVERSE(@phone),8,3))
	set @partie1 = REVERSE(SUBSTRING(REVERSE(@phone),11,1))

	set @phone = ''

	if (len(@partie2)>0)
	begin
--		set @phone = @phone + '(' + @partie2 + ') '
		set @phone = @phone + '' + @partie2 + '-'
	end

	set @phone = @phone + @partie3 + '-' + @partie4

RETURN @phone
END









