CREATE PROCEDURE [app].[Lookup_Search]
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
    [ID] int NOT NULL,
    [CIE] int NULL,
    [CIE_Text] nvarchar(50) NULL,
    [Groupe] nvarchar(12) NOT NULL,
    [Code] nvarchar(9) NULL,
    [Description] nvarchar(50) NOT NULL,
    [Value1] nvarchar(50) NULL,
    [Value2] nvarchar(50) NULL,
    [Value3] varchar(1024) NULL,
    [Started] int NOT NULL,
    [Ended] int NULL,
    [SortOrder] int NULL,
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
    pt.CIE,
    lut1.Name [CIE_Text],
    pt.Groupe,
    pt.Code,
    pt.Description,
    pt.Value1,
    pt.Value2,
    pt.Value3,
    pt.Started,
    pt.Ended,
    pt.SortOrder,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By]
FROM [app].[Lookup] pt
LEFT OUTER JOIN Company lut1 ON lut1.CIE = pt.CIE
INNER JOIN Account a ON a.UID = pt.UpdatedBy
WHERE
(
    (@searchText IS NULL) OR
    (pt.Groupe LIKE '%'+@searchText+'%') OR
    (pt.Code LIKE '%'+@searchText+'%') OR
    (pt.Description LIKE '%'+@searchText+'%') OR
    (pt.Value1 LIKE '%'+@searchText+'%') OR
    (pt.Value2 LIKE '%'+@searchText+'%') OR
    (pt.Value3 LIKE '%'+@searchText+'%')
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'groupe' THEN pt.Groupe END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'code' THEN pt.Code END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'description' THEN pt.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'value1' THEN pt.Value1 END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'value2' THEN pt.Value2 END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'value3' THEN pt.Value3 END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'started' THEN pt.Started END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'ended' THEN pt.Ended END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'groupe' THEN pt.Groupe END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'code' THEN pt.Code END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'description' THEN pt.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'value1' THEN pt.Value1 END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'value2' THEN pt.Value2 END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'value3' THEN pt.Value3 END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'started' THEN pt.Started END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'ended' THEN pt.Ended END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable;
END