CREATE PROCEDURE [app].[Lookup_ListBy_Groupe]
(
	@_uid int,
	@groupe nvarchar(50),
    @year int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;

IF NOT EXISTS (SELECT * FROM app.Lookup WHERE Groupe = @groupe)
	EXEC dbo.Lookup_ListBy_Groupe @_uid = @_uid, @groupe=@groupe, @year=@year

ELSE
	SELECT * 
	FROM app.Lookup
	WHERE 
		(Groupe = @groupe) AND
		(@year IS NULL OR ((Started <= @year) AND (Ended IS NULL OR Ended >= @year)))
	ORDER BY SortOrder, Description
;

END