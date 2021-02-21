CREATE PROCEDURE [dbo].[Equipment_New]
(
    @_uid int,
    @StaffID int = NULL,
    @CatLUID int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    @StaffID [StaffID],
    '' [StaffID_Text],
    '' [Name],
    @CatLUID [CatLUID],
    '' [CatLUID_Text],
    NULL [Price],
    CAST(0 as bit) [Archive] 
;
END