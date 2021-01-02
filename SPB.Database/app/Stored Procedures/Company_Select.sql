CREATE PROCEDURE [app].[Company_Select]
(
	@_uid int,
	@cie int
)
AS
BEGIN
SET NOCOUNT ON
;


SELECT * FROM app.Company where CIE = @cie;

EXEC [app].[CompanyProfile_Select] @_uid=@_uid, @cie=@cie


END