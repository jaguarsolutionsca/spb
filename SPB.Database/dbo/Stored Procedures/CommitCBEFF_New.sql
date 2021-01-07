
CREATE PROCEDURE [dbo].[CommitCBEFF_New]
(
    @_uid int
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [Year] int NOT NULL,
    [RegionLUID] int NULL,
    [RegionLUID_Text] nvarchar(50) NULL,
    [Details] nvarchar(50) NULL,
    [MonthPaid] nvarchar(25) NULL,
    [Paid] bit NOT NULL,
    [Amount] money NOT NULL,
    [Comment] nvarchar(50) NULL,
    [Archive] bit NOT NULL
)


INSERT @returnTable
SELECT
    2021 [Year],
    NULL [RegionLUID],
    '' [RegionLUID_Text],
    NULL [Details],
    NULL [MonthPaid],
    0 [Paid],
    0 [Amount],
    NULL [Comment],
    0 [Archive]
;

SELECT * FROM @returnTable;
;
END