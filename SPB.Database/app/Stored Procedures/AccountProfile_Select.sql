CREATE PROCEDURE [app].[AccountProfile_Select]
(
	@uid int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
	[Name] [key],
	[value]
FROM
	dbo.jag_ProfileSettings
WHERE
	ProfileID = @uid
;
END