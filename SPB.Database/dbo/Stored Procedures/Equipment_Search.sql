CREATE PROCEDURE [dbo].[Equipment_Search]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
    @Plus nvarchar(1024) = NULL,
    --
    @StaffID int = NULL,
    @CatLUID int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [ID] int NOT NULL,
    [StaffID] int NOT NULL,
    [StaffID_Text] nvarchar(50) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [CatLUID] int NULL,
    [CatLUID_Text] nvarchar(50) NULL,
    [Price] decimal NULL,
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
    pt.StaffID,
    lut1.FirstName [StaffID_Text],
    pt.Name,
    pt.CatLUID,
    lut2.Description [CatLUID_Text],
    pt.Price,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By],
    0 [PlusOrder]
FROM [dbo].[Equipment] pt
INNER JOIN Staff lut1 ON lut1.ID = pt.StaffID
LEFT OUTER JOIN app.Lookup lut2 ON lut2.ID = pt.CatLUID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
WHERE
(
    (@searchText IS NULL) OR
    (lut1.FirstName LIKE '%'+@searchText+'%') OR
    (pt.Name LIKE '%'+@searchText+'%') OR
    (lut2.Description LIKE '%'+@searchText+'%') OR
    (pt.Archive LIKE '%'+@searchText+'%') OR
    (pt.Created LIKE '%'+@searchText+'%') OR
    (pt.Updated LIKE '%'+@searchText+'%')
) AND (
    pt.StaffID = @StaffID AND
    ((@CatLUID IS NULL) OR (pt.CatLUID = @CatLUID))
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'staffid_text' THEN lut1.FirstName END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'name' THEN pt.Name END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'catluid_text' THEN lut2.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'price' THEN pt.Price END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'archive' THEN pt.Archive END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'created' THEN pt.Created END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'updated' THEN pt.Updated END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'updatedby' THEN pt.UpdatedBy END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'staffid_text' THEN lut1.FirstName END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'name' THEN pt.Name END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'catluid_text' THEN lut2.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'price' THEN pt.Price END DESC,
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
    pt.StaffID,
    lut1.FirstName [StaffID_Text],
    pt.Name,
    pt.CatLUID,
    lut2.Description [CatLUID_Text],
    pt.Price,
    pt.Archive,
    pt.Created,
    pt.Updated,
    pt.UpdatedBy,
    a.Email [By],
    1 [PlusOrder],
    DATEDIFF(SECOND, '1995-01-01', pt.Created) [RN]
FROM [dbo].[Equipment] pt
INNER JOIN Staff lut1 ON lut1.ID = pt.StaffID
LEFT OUTER JOIN app.Lookup lut2 ON lut2.ID = pt.CatLUID
INNER JOIN app.Account a ON a.UID = pt.UpdatedBy
INNER JOIN @tplus tp ON tp.id = pt.ID
WHERE (tp.id NOT IN (SELECT id FROM @returnTable))
ORDER BY PlusOrder, RN
;

END