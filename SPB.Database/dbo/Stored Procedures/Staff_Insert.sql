CREATE PROCEDURE [dbo].[Staff_Insert]
(
    @_uid int,
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
    @OfficeID int NULL,
    @JobID int,
    @Archive bit
)
AS
BEGIN
SET NOCOUNT ON
;

INSERT INTO Staff
(FirstName,LastName,OfficeID,JobID,Archive,Created,Updated,UpdatedBy)
VALUES (
    @FirstName,
    @LastName,
    @OfficeID,
    @JobID,
    @Archive,
    GETDATE(),
    GETDATE(),
    @_uid
);
DECLARE @ID int = (SELECT CAST(SCOPE_IDENTITY() as int));
SELECT @ID;


END