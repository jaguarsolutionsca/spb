CREATE PROCEDURE [dbo].[Job_Summary]
(
    @Jobid int = NULL,
    @Staffid int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
IF (@Staffid IS NOT NULL)
    SELECT @Jobid = JobID FROM Staff WHERE ID = @Staffid;

SELECT
    (SELECT Title FROM Job WHERE ID = @Jobid) [title],
    (SELECT COUNT(*) FROM Staff WHERE JobID = @Jobid) [StaffCount],
    --(SELECT COUNT(*) FROM dbo.DataFile WHERE TableName = 'job' AND TableID = @Jobid AND Archive = 0) [fileCount]
    CAST(0 as int) [fileCount]
;
END