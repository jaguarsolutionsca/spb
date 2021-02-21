CREATE PROCEDURE [dbo].[Equipment_Update]
(
    @_uid int,
    @ID int,
    @StaffID int,
    @Name nvarchar(50),
    @CatLUID int NULL,
    @Price decimal NULL,
    @Archive bit,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS (SELECT 1 FROM Equipment WHERE ID = @ID AND Updated > @Updated)
    THROW 50000, 'Concurrency Error', 1


UPDATE Equipment
SET
    StaffID = @StaffID,
    Name = @Name,
    CatLUID = @CatLUID,
    Price = @Price,
    Archive = @Archive,
    Updated = GETDATE(),
    UpdatedBy = @_uid
WHERE ID = @ID
;


END