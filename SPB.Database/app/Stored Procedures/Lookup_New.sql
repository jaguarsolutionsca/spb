CREATE PROCEDURE [app].[Lookup_New]
(
    @_uid int,
    @Companyid int = NULL,
    @LookupGroupeid nvarchar(12) = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    @Companyid [CIE],
    '' [CIE_Text],
    @LookupGroupeid [Groupe],
    '' [Groupe_Text],
    NULL [ParentGroupe],
    NULL [ParentGroupe_Text],
    NULL [Code],
    'New Lookup' [Description],
    NULL [Value1],
    NULL [Value2],
    NULL [Value3],
    CAST(0 as int) [Started],
    NULL [Ended],
    NULL [SortOrder] 
;
END