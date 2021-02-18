CREATE PROCEDURE [dbo].[Job_Select]
(
    @_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [dbo].[Job_Full] WHERE ID = @ID
;
END