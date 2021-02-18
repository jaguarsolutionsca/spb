CREATE PROCEDURE [dbo].[Job_New]
(
    @_uid int,
    @KindLUID int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    '' [Title],
    @KindLUID [KindLUID],
    '' [KindLUID_Text],
    CAST(0 as bit) [Archive] 
;
END