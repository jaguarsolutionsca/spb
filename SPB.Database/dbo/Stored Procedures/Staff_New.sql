CREATE PROCEDURE [dbo].[Staff_New]
(
    @_uid int,
    @OfficeID int = NULL,
    @JobID int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT
    '' [FirstName],
    '' [LastName],
    @OfficeID [OfficeID],
    '' [OfficeID_Text],
    @JobID [JobID],
    '' [JobID_Text],
    CAST(0 as bit) [Archive] 
;
END