CREATE PROCEDURE [app].[Lookup_ListBy_Groupe]
(
	@groupe nvarchar(50),
    @year int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;

IF NOT EXISTS (SELECT * FROM app.Lookup WHERE Groupe = @groupe)
	EXEC dbo.Lookup_ListBy_Groupe @groupe=@groupe, @year=@year

ELSE
	SELECT * 
	FROM app.Lookup
	WHERE 
		(Groupe = @groupe) AND
		(@year IS NULL OR ((Started <= @year) AND (Ended IS NULL OR Ended >= @year)))
	ORDER BY SortOrder, Description
;

END