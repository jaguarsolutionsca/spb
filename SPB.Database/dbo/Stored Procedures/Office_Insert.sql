CREATE PROCEDURE [dbo].[Office_Insert]
(
    @_uid int,
    @Name nvarchar(50),
    @Location nvarchar(50),
    @OpenedOn date NULL,
    @Archive bit
)
AS
BEGIN
SET NOCOUNT ON
;

INSERT INTO Office
(Name,Location,OpenedOn,Archive,Created,Updated,UpdatedBy)
VALUES (
    @Name,
    @Location,
    @OpenedOn,
    @Archive,
    GETDATE(),
    GETDATE(),
    @_uid
);
DECLARE @ID int = (SELECT CAST(SCOPE_IDENTITY() as int));
SELECT @ID;


END