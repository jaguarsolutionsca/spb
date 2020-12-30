
CREATE FUNCTION [dbo].[jag_RemoveComma]
	(
		@string varchar(500)
	)
RETURNS varchar(500)
AS

BEGIN

	declare @pos int
	declare @piece varchar(500)
	declare @NewString varchar(500)
	set @NewString = ''

	-- Need to tack a delimiter onto the end of the input string if one doesn't exist
	if right(rtrim(@string),1) <> ','
	set @string = @string  + ','

	set @pos =  patindex('%,%' , @string)
	while @pos <> 0 
	begin
		set @piece = left(@string, @pos - 1)
	 
		 -- You have a piece of data, so insert it, print it, do whatever you want to with it.
		 set @NewString = @NewString + ' ' + ltrim(rtrim(@piece))

		 set @string = stuff(@string, 1, @pos, '')
		 set @pos =  patindex('%,%' , @string)
	 end


RETURN ltrim(rtrim(@NewString))
END
