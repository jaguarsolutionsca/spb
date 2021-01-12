CREATE PROCEDURE [app].[Lookup_New]
(
    @_uid int,
	@groupe nvarchar(12)
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
    [Code] nvarchar(12) NULL,
    [Description] nvarchar(50) NOT NULL,
    [Value1] nvarchar(50) NULL,
    [Value2] nvarchar(50) NULL,
    [Value3] varchar(1024) NULL,
    [Started] int NOT NULL,
    [Ended] int NULL,
    [SortOrder] int NULL
)
;

declare @cie int = (select CIE from app.Account where UID = @_uid);
declare @cie_Text nvarchar(50) = (select Name from app.Company where CIE = @cie);

INSERT @returnTable
SELECT
    @cie [CIE],
    @cie_Text [CIE_Text],
    @groupe [Groupe],
    NULL [Code],
    '' [Description],
    NULL [Value1],
    NULL [Value2],
    NULL [Value3],
    2000 [Started],
    NULL [Ended],
    NULL [SortOrder]
;
SELECT * FROM @returnTable;
;
END