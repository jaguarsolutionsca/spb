CREATE PROCEDURE [app].[Account_SelectBy_Credential]
(
    @email nvarchar(128),
	@password nvarchar(128),
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
	Password = @password AND
	Archive = 0 AND
	(
		( @cid is not null and CID = @cid ) OR
		( IsSupport = 1 )
	)
;
END