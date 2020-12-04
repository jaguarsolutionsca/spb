CREATE PROCEDURE [app].[Account_AutoArchive]
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @autoArchiveMonths int = 4;
--SELECT @autoArchiveMonths = Number1 FROM ConfigConstant WHERE Name = 'AA-MONTH';

UPDATE app.Account
SET
	Archive = 1
WHERE 
	AutoArchive = 1 AND 
	Archive = 0 AND 
	DATEDIFF(MONTH, ISNULL(LastActivity, Created), GETDATE()) >= @autoArchiveMonths
;
END