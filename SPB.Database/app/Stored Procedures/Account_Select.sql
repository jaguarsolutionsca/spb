CREATE PROCEDURE [app].[Account_Select]
(
	@uid int
)
AS
BEGIN
SET NOCOUNT ON
;

declare @profile TABLE ([profileJson] nvarchar(MAX));
insert @profile
exec app.AccountProfile_Select @uid = @uid
;

SELECT
	*
FROM app.Account_Full acc
INNER JOIN @profile pro ON 1=1
WHERE
	UID = @uid
;

END