CREATE PROCEDURE [dbo].[Job_Search]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
    --
    @KindLUID int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [ID] int NOT NULL,
    [Title] nvarchar(50) NOT NULL,
    [KindLUID] int NULL,
    [KindLUID_Text] nvarchar(50) NULL,
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
    pt.Title,
    pt.KindLUID,
    lut1.Description [KindLUID_Text],
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [dbo].[Job] pt
LEFT OUTER JOIN app.Lookup lut1 ON lut1.ID = pt.KindLUID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
WHERE
(
    (@searchText IS NULL) OR
    (pt.Title LIKE '%'+@searchText+'%') OR
    (lut1.Description LIKE '%'+@searchText+'%') OR
    (pt.Archive LIKE '%'+@searchText+'%') OR
    (pt.Created LIKE '%'+@searchText+'%') OR
    (pt.Updated LIKE '%'+@searchText+'%')
) AND (
    ((@KindLUID IS NULL) OR (pt.KindLUID = @KindLUID))
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'title' THEN pt.Title END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'kindluid_text' THEN lut1.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'title' THEN pt.Title END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'kindluid_text' THEN lut1.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable;
END