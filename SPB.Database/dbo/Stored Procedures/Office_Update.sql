CREATE PROCEDURE [dbo].[Office_Update]
(
    @_uid int,
    @ID int,
    @Name nvarchar(50),
    @Location nvarchar(50),
    @OpenedOn date NULL,
    @Archive bit,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS (SELECT 1 FROM Office WHERE ID = @ID AND Updated > @Updated)
    THROW 50000, 'Concurrency Error', 1


UPDATE Office
SET
    Name = @Name,
    Location = @Location,
    OpenedOn = @OpenedOn,
    Archive = @Archive,
    Updated = GETDATE(),
    UpdatedBy = @_uid
WHERE ID = @ID
;


END