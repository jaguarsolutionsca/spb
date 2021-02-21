CREATE PROCEDURE [dbo].[Equipment_Select]
(
    @_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [dbo].[Equipment_Full] WHERE ID = @ID
;
END