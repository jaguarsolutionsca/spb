

CREATE FUNCTION dbo.jag_GetCountDroitCoupeLot
	(
		@ProducteurID VARCHAR(15),
		@Date smalldatetime
	)
RETURNS int 
AS

BEGIN

	DECLARE @count int
	SET @count = (SELECT COUNT(*) AS [Count] FROM dbo.jag_GetDroitCoupeLot (@ProducteurID, @Date))

RETURN @count
END








