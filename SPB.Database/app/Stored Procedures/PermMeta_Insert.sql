CREATE PROCEDURE [app].[PermMeta_Insert]
(
    @_uid int,
    @Groupe nvarchar(12),
    @Code int,
    @Description nvarchar(50),
    @ParentID int NULL,
    @SortOrder int NULL,
    @Key nvarchar(8) NULL,
    @Archive bit
)
AS
BEGIN
SET NOCOUNT ON
;

INSERT INTO PermMeta
(Groupe,Code,Description,ParentID,SortOrder,[Key],Archive,Created,Updated,UpdatedBy)
VALUES (
    @Groupe,
    @Code,
    @Description,
    @ParentID,
    @SortOrder,
    @Key,
    @Archive,
    GETDATE(),
    GETDATE(),
    @_uid
);
DECLARE @ID int = (SELECT CAST(SCOPE_IDENTITY() as int));
SELECT @ID;


END