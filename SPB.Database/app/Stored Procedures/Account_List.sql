CREATE PROCEDURE [app].[Account_List]
(
	@cid int = NULL,
    @Archive bit = NULL,
	@uid int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;

DECLARE @IsSupport bit = app.UserIs_Support(@uid);

SELECT * 
FROM app.Account
WHERE
(
    ((@cid IS NULL) OR (CID = @cid)) AND
    ((@Archive IS NULL) OR (Archive = @Archive)) AND
	(@IsSupport = 1)
)
;

END