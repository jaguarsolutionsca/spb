CREATE PROCEDURE [dbo].[Office_Summary]
(
    @id int = NULL,
	@staffid int = NULL,
	@roomid int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
IF (@staffid IS NOT NULL)
	SELECT @id = OfficeID FROM Staff WHERE ID = @staffid;

IF (@roomid IS NOT NULL)
	SELECT @id = OfficeID FROM ROOM WHERE ID = @roomid;

SELECT
    (SELECT Name FROM Office WHERE ID = @id) [title],
	(SELECT COUNT(*) FROM Room WHERE OfficeID = @id) [roomCount],
	(SELECT COUNT(*) FROM Staff WHERE OfficeID = @id) [staffCount],
    --(SELECT COUNT(*) FROM dbo.DataFile WHERE TableName = 'office' AND TableID = @id AND Archive = 0) [fileCount]
    CAST(0 as int) [fileCount]
;
END