CREATE PROCEDURE [dbo].[Office_Search]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
    --
    @Location nvarchar(50) = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [ID] int NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Location] nvarchar(50) NOT NULL,
    [OpenedOn] date NULL,
    [Archive] bit NOT NULL,
    [Created] datetime NOT NULL,
    [Updated] datetime NOT NULL,
    [UpdatedBy] int NOT NULL,
    [By] nvarchar(50) NOT NULL
)
;
SELECT @pageNo = CASE WHEN @pageNo > 0 THEN @pageNo ELSE 1 END;
SELECT @pageSize = CASE WHEN @pageSize > 0 THEN @pageSize ELSE 25 END;
DECLARE @rowOffset int = (@pageNo - 1) * @pageSize;
IF(ISNULL(@searchText, '') = '') SET @searchText = NULL;

INSERT INTO @returnTable
SELECT
    COUNT(*) OVER()[TotalCount],
    pt.ID,
    pt.Name,
    pt.Location,
    pt.OpenedOn,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [dbo].[Office] pt
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
WHERE
(
    (@searchText IS NULL) OR
    (pt.Name LIKE '%'+@searchText+'%') OR
    (pt.Location LIKE '%'+@searchText+'%') OR
    (pt.OpenedOn LIKE '%'+@searchText+'%') OR
    (pt.Archive LIKE '%'+@searchText+'%') OR
    (pt.Created LIKE '%'+@searchText+'%') OR
    (pt.Updated LIKE '%'+@searchText+'%')
) AND (
    ((@Location IS NULL) OR (pt.Location = @Location))
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'name' THEN pt.Name END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'location' THEN pt.Location END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'openedon' THEN pt.OpenedOn END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'name' THEN pt.Name END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'location' THEN pt.Location END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'openedon' THEN pt.OpenedOn END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable;
END