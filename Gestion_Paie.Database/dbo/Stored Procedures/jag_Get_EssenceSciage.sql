



CREATE PROCEDURE dbo.jag_Get_EssenceSciage
/*
	(
		@parameter1 datatype = default value,
		@parameter2 datatype OUTPUT
	)
*/
AS
	
SELECT [Description] FROM EssenceSciage ORDER BY [Description]



