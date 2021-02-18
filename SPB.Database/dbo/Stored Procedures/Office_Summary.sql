CREATE PROCEDURE [dbo].[Office_Summary]
(
    @Officeid int = NULL,
    @Roomid int = NULL,
    @Staffid int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
IF (@Roomid IS NOT NULL)
    SELECT @Officeid = OfficeID FROM Room WHERE ID = @Roomid;

IF (@Staffid IS NOT NULL)
    SELECT @Officeid = OfficeID FROM Staff WHERE ID = @Staffid;

SELECT
    (SELECT Name FROM Office WHERE ID = @Officeid) [title],
    (SELECT COUNT(*) FROM Room WHERE OfficeID = @Officeid) [RoomCount],
    (SELECT COUNT(*) FROM Staff WHERE OfficeID = @Officeid) [StaffCount],
    --(SELECT COUNT(*) FROM dbo.DataFile WHERE TableName = 'office' AND TableID = @Officeid AND Archive = 0) [fileCount]
    CAST(0 as int) [fileCount]
;
END