CREATE PROCEDURE [app].[Account_SelectBy_Credential]
(
    @email nvarchar(128),
	@password nvarchar(128),
	@cie int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
	*
FROM app.Account_Full
WHERE
	EMail = @email AND
	Password = @password AND
	Archive = 0 AND
	(
		( @cie is not null and CIE = @cie ) OR
		( IsSupport = 1 )
	)
;
END