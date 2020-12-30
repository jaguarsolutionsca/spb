

CREATE FUNCTION dbo.jag_StripAccents
	(
	@s varchar(100)
	)
RETURNS varchar(100)
AS

BEGIN
	set @s = replace(@s, 'à', 'a')
	set @s = replace(@s, 'À', 'A')
	set @s = replace(@s, 'â', 'a')
	set @s = replace(@s, 'Â', 'A')
	set @s = replace(@s, 'ä', 'a')
	set @s = replace(@s, 'Ä', 'A')
	set @s = replace(@s, 'é', 'e')
	set @s = replace(@s, 'É', 'E')
	set @s = replace(@s, 'è', 'e')
	set @s = replace(@s, 'È', 'E')
	set @s = replace(@s, 'ê', 'e')
	set @s = replace(@s, 'Ê', 'E')
	set @s = replace(@s, 'ë', 'e')
	set @s = replace(@s, 'Ë', 'E')
	set @s = replace(@s, 'ç', 'c')
	set @s = replace(@s, 'Ç', 'C')
	set @s = replace(@s, 'ô', 'o')
	set @s = replace(@s, 'Ô', 'O')
	set @s = replace(@s, 'ö', 'o')
	set @s = replace(@s, 'Ö', 'O')
	set @s = replace(@s, 'ù', 'u')
	set @s = replace(@s, 'Ù', 'U')

RETURN @s
END




