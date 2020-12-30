


CREATE PROCEDURE dbo.jag_Get_FreeFouID
	(
		@ID int output
	)
AS
	
declare @IDTemp int

-- Begin Fetch Last Pointer Used
--------------------------------
if ((select count(*) from jag_SystemEx where Name='FournisseurPointerID') = 0)
BEGIN
	insert into jag_SystemEx (Name, Value) values ('FournisseurPointerID', 1)
END

select @IDTemp = convert(int, Value) from jag_SystemEx where Name='FournisseurPointerID'

if @IDTemp is null
BEGIN
	select @IDTemp = 0
END
-- End Fetch Last Pointer Used
------------------------------
			  
declare @temp table
(
	ID int
)    
insert into @temp
select ID FROM Fournisseur WHERE IsNumeric([ID]) = 1 and convert(int, ID) >= @IDTemp

WHILE (1=1)
BEGIN

	SET @IDTemp = @IDTemp + 1

   	if (not exists(select ID FROM @temp WHERE convert(int, ID) = @IDTemp))
	BEGIN
        select @ID = @IDTemp 
		update jag_SystemEx set Value = convert(varchar, @IDTemp) where Name = 'FournisseurPointerID'
		break
	END
END           


