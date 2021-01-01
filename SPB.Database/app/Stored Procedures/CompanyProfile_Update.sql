CREATE PROCEDURE [app].[CompanyProfile_Update]
(
	@cie int,
    @json nvarchar(MAX)
)
AS
BEGIN
SET NOCOUNT ON
;

declare @table TABLE ([key] nvarchar(50), [value] nvarchar(500));

INSERT @table
SELECT
	[key],
	[value]
FROM openjson(@json)
;

UPDATE
	Gestion_Paie.dbo.jag_SystemEx
SET
	Gestion_Paie.dbo.jag_SystemEx.Value = cte.[value]
FROM
	Gestion_Paie.dbo.jag_SystemEx ps
INNER JOIN
	@table cte on 1=1
WHERE
	cte.[key] COLLATE DATABASE_DEFAULT = ps.Name COLLATE DATABASE_DEFAULT
;

END