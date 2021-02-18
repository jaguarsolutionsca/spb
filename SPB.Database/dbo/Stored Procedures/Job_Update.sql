CREATE PROCEDURE [dbo].[Job_Update]
(
    @_uid int,
    @ID int,
    @Title nvarchar(50),
    @KindLUID int NULL,
    @Archive bit,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS (SELECT 1 FROM Job WHERE ID = @ID AND Updated > @Updated)
    THROW 50000, 'Concurrency Error', 1


UPDATE Job
SET
    Title = @Title,
    KindLUID = @KindLUID,
    Archive = @Archive,
    Updated = GETDATE(),
    UpdatedBy = @_uid
WHERE ID = @ID
;


END