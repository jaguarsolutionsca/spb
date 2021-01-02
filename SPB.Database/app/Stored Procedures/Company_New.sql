CREATE PROCEDURE [app].[Company_New]
(
    @_uid int
)
AS
BEGIN
SET NOCOUNT ON
;

SELECT
	'' [Name],
	NULL [Features],
	CAST(0 as bit) [Archive], 
	GETDATE() [Created], 
	GETDATE() [Updated], 
	CAST(0 as int) [UpdatedBy], 
	'' [By]
;


EXEC app.CompanyProfile_New @_uid=@_uid

END