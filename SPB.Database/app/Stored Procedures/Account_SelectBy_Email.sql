CREATE PROCEDURE [app].[Account_SelectBy_Email]
(
    @email nvarchar(128),
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
	Archive = 0 AND
	(
		( @cie is not null and CIE = @cie ) OR
		( IsSupport = 1 )
	)
;
END