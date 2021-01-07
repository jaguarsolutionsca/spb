
CREATE PROCEDURE [dbo].[CommitCBEFF_Select]
(
	@_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [dbo].[CommitCBEFF_Full] WHERE ID = @ID
;
END