CREATE PROCEDURE [app].[PermMeta_Update]
(
    @_uid int,
    @ID int,
    @Groupe nvarchar(12),
    @Code int,
    @Description nvarchar(50),
    @ParentID int NULL,
    @SortOrder int NULL,
    @Key nvarchar(8) NULL,
    @Archive bit,
    @Updated datetime NULL
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS (SELECT 1 FROM PermMeta WHERE ID = @ID AND Updated > @Updated)
    THROW 50000, 'Concurrency Error', 1


UPDATE PermMeta
SET
    Groupe = @Groupe,
    Code = @Code,
    Description = @Description,
    ParentID = @ParentID,
    SortOrder = @SortOrder,
    [Key] = @Key,
    Archive = @Archive,
    Updated = GETDATE(),
    UpdatedBy = @_uid
WHERE ID = @ID
;


END