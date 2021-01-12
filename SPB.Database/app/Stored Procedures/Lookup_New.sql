CREATE PROCEDURE [app].[Lookup_New]
(
    @_uid int
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
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
    [SortOrder] int NULL
)
;
INSERT @returnTable
SELECT
    NULL [CIE],
    '' [CIE_Text],
    '' [Groupe],
    NULL [Code],
    'New Lookup' [Description],
    NULL [Value1],
    NULL [Value2],
    NULL [Value3],
    0 [Started],
    NULL [Ended],
    NULL [SortOrder] 
;
SELECT * FROM @returnTable;
;
END