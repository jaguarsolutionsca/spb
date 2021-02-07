CREATE PROCEDURE [dbo].[Staff_Update]
(
    @_uid int,
    @ID int,
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
    @OfficeID int NULL,
    @JobID int,
    @Archive bit,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS (SELECT 1 FROM Staff WHERE ID = @ID AND Updated > @Updated)
    THROW 50000, 'Concurrency Error', 1


UPDATE Staff
SET
    FirstName = @FirstName,
    LastName = @LastName,
    OfficeID = @OfficeID,
    JobID = @JobID,
    Archive = @Archive,
    Updated = GETDATE(),
    UpdatedBy = @_uid
WHERE ID = @ID
;


END