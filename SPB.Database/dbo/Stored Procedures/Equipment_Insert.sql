CREATE PROCEDURE [dbo].[Equipment_Insert]
(
    @_uid int,
    @StaffID int,
    @Name nvarchar(50),
    @CatLUID int NULL,
    @Price decimal NULL,
    @Archive bit
)
AS
BEGIN
SET NOCOUNT ON
;

INSERT INTO Equipment
(StaffID,Name,CatLUID,Price,Archive,Created,Updated,UpdatedBy)
VALUES (
    @StaffID,
    @Name,
    @CatLUID,
    @Price,
    @Archive,
    GETDATE(),
    GETDATE(),
    @_uid
);
DECLARE @ID int = (SELECT CAST(SCOPE_IDENTITY() as int));
SELECT @ID;


END