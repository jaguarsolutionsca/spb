CREATE PROCEDURE [app].[AccountProfile_Insert]
(
	@UID int,
    @json nvarchar(MAX)
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


INSERT Gestion_Paie.dbo.jag_Profile
VALUES (@UID, 'UID-'+ CAST(@UID AS nvarchar), '')
;

INSERT Gestion_Paie.dbo.jag_ProfileSettings
SELECT
	@UID [profileID],
	Description [name],
	cte.[value]
FROM app.Lookup lut
LEFT OUTER JOIN @table cte on cte.[key] = lut.Description
WHERE Groupe = 'PROFILE.KEY'
;

END