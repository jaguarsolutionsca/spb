CREATE PROCEDURE [app].[PermMeta_Search]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
    @Plus nvarchar(1024) = NULL,
    --
    @Groupe nvarchar(12) = NULL,
    @ParentID int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [ID] int NOT NULL,
    [Groupe] nvarchar(12) NOT NULL,
    [Groupe_Text] nvarchar(50) NOT NULL,
    [Code] int NOT NULL,
    [Description] nvarchar(50) NOT NULL,
    [ParentID] int NULL,
    [ParentID_Text] nvarchar(50) NULL,
    [SortOrder] int NULL,
    [Key] nvarchar(8) NULL,
    [Archive] bit NOT NULL,
    [Created] datetime NOT NULL,
    [Updated] datetime NULL,
    [UpdatedBy] int NOT NULL,
    [By] nvarchar(50) NOT NULL,
    [PlusOrder] int NULL,
    [RN] int NOT NULL IDENTITY(1,1)
)
;
SELECT @pageNo = CASE WHEN @pageNo > 0 THEN @pageNo ELSE 1 END;
SELECT @pageSize = CASE WHEN @pageSize > 0 THEN @pageSize ELSE 25 END;
DECLARE @rowOffset int = (@pageNo - 1) * @pageSize;
IF(ISNULL(@searchText, '') = '') SET @searchText = NULL;

DECLARE @tplus TABLE (id int);
INSERT @tplus SELECT * FROM app.CsvOfString_to_Table(@plus);

INSERT INTO @returnTable
SELECT
    COUNT(*) OVER() [TotalCount],
    pt.ID,
    pt.Groupe,
    pt.Groupe [Groupe_Text],
    pt.Code,
    pt.Description,
    pt.ParentID,
    lut2.Description [ParentID_Text],
    pt.SortOrder,
    pt.[Key],
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By],
    0 [PlusOrder]
FROM [app].[PermMeta] pt
LEFT OUTER JOIN app.PermMeta lut2 ON lut2.ID = pt.ParentID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
WHERE
(
    (@searchText IS NULL) OR
    (pt.Groupe LIKE '%'+@searchText+'%') OR
    (pt.Description LIKE '%'+@searchText+'%')
) AND (
    ((@Groupe IS NULL) OR (pt.Groupe = @Groupe)) AND
    ((@ParentID IS NULL) OR (pt.ParentID = @ParentID))
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'groupe_text' THEN pt.Groupe END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'code' THEN pt.Code END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'description' THEN pt.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'parentid_text' THEN lut2.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'sortorder' THEN pt.SortOrder END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'key' THEN pt.[Key] END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'groupe_text' THEN pt.Groupe END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'code' THEN pt.Code END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'description' THEN pt.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'parentid_text' THEN lut2.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'sortorder' THEN pt.SortOrder END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'key' THEN pt.[Key] END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;


SELECT * FROM @returnTable
UNION
SELECT
    0 [TotalCount],
    pt.ID,
    pt.Groupe,
    pt.Groupe [Groupe_Text],
    pt.Code,
    pt.Description,
    pt.ParentID,
    lut2.Description [ParentID_Text],
    pt.SortOrder,
    pt.[Key],
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By],
    1 [PlusOrder],
    DATEDIFF(SECOND, '1995-01-01', pt.Created) [RN]
FROM [app].[PermMeta] pt
LEFT OUTER JOIN app.PermMeta lut2 ON lut2.ID = pt.ParentID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
INNER JOIN @tplus tp ON tp.id = pt.ID
WHERE (tp.id NOT IN (SELECT id FROM @returnTable))
ORDER BY PlusOrder, RN
;

END