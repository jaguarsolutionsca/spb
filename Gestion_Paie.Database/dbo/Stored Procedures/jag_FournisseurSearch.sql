CREATE PROCEDURE [dbo].[jag_FournisseurSearch]
@SearchString VARCHAR (255), @Delimeter CHAR (1)
AS
SET NOCOUNT ON


	if right(rtrim(@SearchString),1)<> ' '
		set @SearchString = @SearchString + ' '


	Declare @pos int, @count int
	Declare @piece varchar(255)
	declare @sql nvarchar(500)


	set @pos = patindex('%' + @Delimeter +  '%', @SearchString)
	set @count = 0
	set @sql = ''

	while @pos <> 0
	begin
		set @piece = left(@SearchString, @pos - 1)
		
		if len(ltrim(rtrim(@piece)))>0
		begin
			if @count = 0 
				set @sql =  'where TextSearch like ''%' + @piece + '%'''
			else
				set @sql = @sql + ' and TextSearch like ''%' + @piece + '%'''
				
			set @count = @count + 1
		end
		
		set @SearchString = stuff(@SearchString, 1, @pos, '')
		set @pos = patindex('%' + @Delimeter +  '%', @SearchString)
	end


	set @sql = 'Select FournisseurID, Nom, AuSoinsDe, Rue, Ville from FournisseurSearch ' + @sql
	print @sql


	execute sp_executesql @sql


