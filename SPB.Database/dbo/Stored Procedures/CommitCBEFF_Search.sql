
CREATE PROCEDURE [dbo].[CommitCBEFF_Search]
(
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
    --
    @Year int = NULL,
    @RegionLUID int = NULL,
	@Plus nvarchar(1024) = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [ID] int NOT NULL,
    [Year] int NOT NULL,
    [RegionLUID] int NOT NULL,
    [RegionLUID_Code] nvarchar(8) NOT NULL,
    [RegionLUID_Text] nvarchar(50) NOT NULL,
    [Details] nvarchar(50) NULL,
    [MonthPaid] nvarchar(25) NULL,
    [Paid] bit NOT NULL,
    [Amount] money NOT NULL,
    [Comment] nvarchar(50) NULL,
    [Archive] bit NOT NULL,
    [Created] datetime NOT NULL,
    [Updated] datetime NOT NULL,
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

declare @tplus TABLE (id int);
insert @tplus select * from app.CsvOfString_to_Table(@plus);

INSERT INTO @returnTable
SELECT
    COUNT(*) OVER()[TotalCount],
    pt.ID,
    pt.Year,
    pt.RegionLUID,
    lut1.Code [RegionLUID_Code],
    lut1.Description [RegionLUID_Text],
    pt.Details,
    pt.MonthPaid,
    pt.Paid,
    pt.Amount,
    pt.Comment,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By],
	0 [PlusOrder]
FROM [dbo].[CommitCBEFF] pt
INNER JOIN app.Lookup lut1 ON lut1.ID = pt.RegionLUID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
LEFT OUTER JOIN @tplus tp ON tp.id = pt.ID
WHERE
(
    (@searchText IS NULL) OR
    (lut1.Description LIKE '%'+@searchText+'%') OR
    (pt.Details LIKE '%'+@searchText+'%') OR
    (pt.MonthPaid LIKE '%'+@searchText+'%') OR
    (pt.Paid LIKE '%'+@searchText+'%') OR
    (pt.Comment LIKE '%'+@searchText+'%') OR
    (pt.Archive LIKE '%'+@searchText+'%') OR
    (pt.Created LIKE '%'+@searchText+'%') OR
    (pt.Updated LIKE '%'+@searchText+'%')
) AND (
    ((@Year IS NULL) OR (pt.Year = @Year)) AND
    ((@RegionLUID IS NULL) OR (pt.RegionLUID = @RegionLUID))
) AND (
	tp.id IS NULL
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'year' THEN pt.Year END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'regionluid_text' THEN lut1.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'details' THEN pt.Details END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'monthPaid' THEN pt.MonthPaid END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'paid' THEN pt.Paid END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'amount' THEN pt.Amount END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'createdUtc' THEN pt.Created END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'year' THEN pt.Year END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'regionluid_text' THEN lut1.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'details' THEN pt.Details END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'monthPaid' THEN pt.MonthPaid END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'paid' THEN pt.Paid END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'amount' THEN pt.Amount END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'createdUtc' THEN pt.Created END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable
UNION
SELECT
    0 [TotalCount],
    pt.ID,
    pt.Year,
    pt.RegionLUID,
    lut1.Code [RegionLUID_Code],
    lut1.Description [RegionLUID_Text],
    pt.Details,
    pt.MonthPaid,
    pt.Paid,
    pt.Amount,
    pt.Comment,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By],
	1 [PlusOrder],
	DATEDIFF(SECOND, '1995-01-01', pt.Created) [RN]
FROM [dbo].[CommitCBEFF] pt
INNER JOIN app.Lookup lut1 ON lut1.ID = pt.RegionLUID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
INNER JOIN @tplus tp ON tp.id = pt.ID
WHERE (tp.id NOT IN (select id from @returnTable))
ORDER BY PlusOrder, RN
;

END