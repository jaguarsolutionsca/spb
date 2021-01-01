CREATE PROCEDURE [app].[Company_New]
(
    @_uid int
)
AS
BEGIN
SET NOCOUNT ON
;
/*
declare @profile TABLE ([profileJson] nvarchar(MAX));
insert @profile
exec app.CompanyProfile_New @cie = @cie
;


with cte as
(
	SELECT
		'' [Name],
		NULL [Features],
		CAST(0 as bit) [Archive], 
		GETDATE() [Created], 
		GETDATE() [Updated], 
		CAST(0 as int) [UpdatedBy], 
		'' [By]
)
SELECT
	*
FROM cte
INNER JOIN @profile pro ON 1=1
;

exec app.CompanyProfile_New @cie = @cie
*/
END