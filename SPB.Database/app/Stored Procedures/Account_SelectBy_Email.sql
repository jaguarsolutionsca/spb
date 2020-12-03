CREATE PROCEDURE [app].[Account_SelectBy_Email]
(
    @email nvarchar(128),
	@cid int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
	*
FROM app.Account_Select
WHERE
	EMail = @email AND
	Archive = 0 AND
	(
		( @cid is not null and CID = @cid ) OR
		( IsSupport = 1 )
	)
;
END