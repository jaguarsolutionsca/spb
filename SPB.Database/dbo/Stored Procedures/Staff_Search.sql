CREATE PROCEDURE [dbo].[Staff_Search]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
    @Plus nvarchar(1024) = NULL,
    --
    @OfficeID int = NULL,
    @JobID int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [ID] int NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [OfficeID] int NULL,
    [OfficeID_Text] nvarchar(50) NULL,
    [JobID] int NULL,
    [JobID_Text] nvarchar(50) NULL,
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

DECLARE @tplus TABLE (id int);
INSERT @tplus SELECT * FROM app.CsvOfString_to_Table(@plus);

INSERT INTO @returnTable
SELECT
    COUNT(*) OVER() [TotalCount],
    pt.ID,
    pt.FirstName,
    pt.LastName,
    pt.OfficeID,
    lut1.Name [OfficeID_Text],
    pt.JobID,
    lut2.Title [JobID_Text],
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By],
    0 [PlusOrder]
FROM [dbo].[Staff] pt
LEFT OUTER JOIN Office lut1 ON lut1.ID = pt.OfficeID
LEFT OUTER JOIN Job lut2 ON lut2.ID = pt.JobID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
WHERE
(
    (@searchText IS NULL) OR
    (pt.FirstName LIKE '%'+@searchText+'%') OR
    (pt.LastName LIKE '%'+@searchText+'%') OR
    (lut1.Name LIKE '%'+@searchText+'%') OR
    (lut2.Title LIKE '%'+@searchText+'%') OR
    (pt.Archive LIKE '%'+@searchText+'%') OR
    (pt.Created LIKE '%'+@searchText+'%') OR
    (pt.Updated LIKE '%'+@searchText+'%')
) AND (
    ((@OfficeID IS NULL) OR (pt.OfficeID = @OfficeID)) AND
    ((@JobID IS NULL) OR (pt.JobID = @JobID))
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'firstname' THEN pt.FirstName END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'lastname' THEN pt.LastName END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'officeid_text' THEN lut1.Name END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'jobid_text' THEN lut2.Title END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'firstname' THEN pt.FirstName END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'lastname' THEN pt.LastName END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'officeid_text' THEN lut1.Name END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'jobid_text' THEN lut2.Title END DESC,
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
    pt.FirstName,
    pt.LastName,
    pt.OfficeID,
    lut1.Name [OfficeID_Text],
    pt.JobID,
    lut2.Title [JobID_Text],
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By],
    1 [PlusOrder],
    DATEDIFF(SECOND, '1995-01-01', pt.Created) [RN]
FROM [dbo].[Staff] pt
LEFT OUTER JOIN Office lut1 ON lut1.ID = pt.OfficeID
LEFT OUTER JOIN Job lut2 ON lut2.ID = pt.JobID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
INNER JOIN @tplus tp ON tp.id = pt.ID
WHERE (tp.id NOT IN (SELECT id FROM @returnTable))
ORDER BY PlusOrder, RN
;

END