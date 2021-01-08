CREATE PROCEDURE [app].[Account_List]
(
	@_uid int = NULL,
	@cie int = NULL,
    @Archive bit = NULL,
    @ReadyToArchive bit = NULL
)
AS
BEGIN
SET NOCOUNT ON
;

--DECLARE @IsSupport bit = app.UserIs_Support(@_uid);

SELECT * 
FROM app.Account_Full
WHERE
(
    ((@cie IS NULL) OR (CIE = @cie)) AND
    ((@Archive IS NULL) OR (Archive = @Archive)) AND
    ((@ReadyToArchive IS NULL) OR (ReadyToArchive = @ReadyToArchive))
)
;

END