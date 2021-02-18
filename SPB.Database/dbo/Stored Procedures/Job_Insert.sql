CREATE PROCEDURE [dbo].[Job_Insert]
(
    @_uid int,
    @Title nvarchar(50),
    @KindLUID int NULL,
    @Archive bit
)
AS
BEGIN
SET NOCOUNT ON
;

INSERT INTO Job
(Title,KindLUID,Archive,Created,Updated,UpdatedBy)
VALUES (
    @Title,
    @KindLUID,
    @Archive,
    GETDATE(),
    GETDATE(),
    @_uid
);
DECLARE @ID int = (SELECT CAST(SCOPE_IDENTITY() as int));
SELECT @ID;


END