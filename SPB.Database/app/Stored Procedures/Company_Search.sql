CREATE PROCEDURE [app].[Company_Search]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [CIE] int NOT NULL,
    [Name] nvarchar(64) NOT NULL,
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
    pt.CIE,
    pt.Name,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
	acc.Email
FROM [app].[Company] pt
INNER JOIN [app].[Account] acc ON acc.UID = pt.UpdatedBy
WHERE
(
    (@searchText IS NULL) OR
    (pt.Name LIKE '%'+@searchText+'%') OR
    (pt.Archive LIKE '%'+@searchText+'%') OR
    (pt.Created LIKE '%'+@searchText+'%') OR
    (pt.Updated LIKE '%'+@searchText+'%')
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'cie' THEN pt.CIE END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'name' THEN pt.Name END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'features' THEN pt.Features END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'cie' THEN pt.CIE END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'name' THEN pt.Name END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'features' THEN pt.Features END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable;
END