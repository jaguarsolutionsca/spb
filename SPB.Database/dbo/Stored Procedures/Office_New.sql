CREATE PROCEDURE [dbo].[Office_New]
(
    @_uid int
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [Name] nvarchar(50) NOT NULL,
    [Location] nvarchar(50) NOT NULL,
    [OpenedOn] date NULL,
    [Archive] bit NOT NULL
)
;
INSERT @returnTable
SELECT
    '' [Name],
    '' [Location],
    NULL [OpenedOn],
    0 [Archive] 
;
SELECT * FROM @returnTable;
;
END