CREATE PROCEDURE [dbo].[Lot_Proprietaire_Search]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
    --
    @ProprietaireID varchar(15)
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [ID] int NOT NULL,
    [ProprietaireID] varchar(15) NOT NULL,
    [ProprietaireID_Text] nvarchar(50) NOT NULL,
    [DateDebut] date NOT NULL,
    [DateFin] date NULL,
    [LotID] int NOT NULL,
    [LotID_Text] nvarchar(50) NOT NULL
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
    pt.ProprietaireID,
    lut1.Nom [ProprietaireID_Text],
    pt.DateDebut,
    pt.DateFin,
    pt.LotID,
    lut2.CantonID + ' - ' + ISNULL(Rang, '') + ' - ' + ISNULL(Lot, '') [LotID_Text]
FROM [dbo].[Lot_Proprietaire] pt
INNER JOIN Fournisseur lut1 ON lut1.ID = pt.ProprietaireID
INNER JOIN Lot lut2 ON lut2.ID = pt.LotID
WHERE
(
    (@searchText IS NULL) OR
    (pt.ProprietaireID LIKE '%'+@searchText+'%') OR
    (pt.DateDebut LIKE '%'+@searchText+'%') OR
    (pt.DateFin LIKE '%'+@searchText+'%') OR
    (lut1.Nom LIKE '%'+@searchText+'%')
) AND (
    pt.ProprietaireID = @ProprietaireID
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'proprietaireid_text' THEN lut1.Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'datedebut' THEN pt.DateDebut END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'datefin' THEN pt.DateFin END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'lotid_text' THEN lut2.CantonID END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'proprietaireid_text' THEN lut1.Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'datedebut' THEN pt.DateDebut END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'datefin' THEN pt.DateFin END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'lotid_text' THEN lut2.CantonID END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable;
END