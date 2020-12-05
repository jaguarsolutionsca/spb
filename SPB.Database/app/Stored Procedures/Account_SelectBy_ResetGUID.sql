CREATE PROCEDURE [app].[Account_SelectBy_ResetGUID]
(
    @guid uniqueidentifier
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
	*
FROM app.Account_Full
WHERE
	ResetGuid = @guid
;
END