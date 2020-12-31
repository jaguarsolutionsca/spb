CREATE PROCEDURE [app].[AccountProfile_Insert]
(
	@UID int,
    @json nvarchar(MAX) -- '{"AcrobatPath":"123","AutresRapportsPrinterMarginBottom":"3","AutresRapportsPrinterMarginLeft":"40"}'
)
AS
BEGIN
SET NOCOUNT ON
;

declare @table TABLE ([uid] int, [key] nvarchar(50), [value] nvarchar(500));

INSERT @table
SELECT
	@uid [uid],
	[key],
	[value]
FROM openjson(@json)
;

INSERT Gestion_Paie.dbo.jag_ProfileSettings
SELECT
	@UID [uid],
	Description [key],
	cte.[value]
FROM app.Lookup lut
LEFT OUTER JOIN @table cte on cte.[key] = lut.Description
WHERE Groupe = 'PROFILE.KEY'
;

END