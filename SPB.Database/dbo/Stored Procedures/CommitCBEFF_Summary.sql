
CREATE PROCEDURE [dbo].[CommitCBEFF_Summary]
(
    @id int
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @out TABLE (title nvarchar(255), fileCount int not null);
INSERT @out
SELECT
    '' [title],
    0 [fileCount]
;
SELECT * FROM @out;
END