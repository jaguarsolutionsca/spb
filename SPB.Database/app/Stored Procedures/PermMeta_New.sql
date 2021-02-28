CREATE PROCEDURE [app].[PermMeta_New]
(
    @_uid int,
    @Meta1id nvarchar(12) = NULL,
    @Meta2id int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    @Meta1id [Groupe],
    '' [Groupe_Text],
    CAST(0 as int) [Code],
    'New PermMeta' [Description],
    @Meta2id [ParentID],
    '' [ParentID_Text],
    NULL [SortOrder],
    NULL [Key],
    CAST(0 as bit) [Archive] 
;
END