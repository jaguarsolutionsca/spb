CREATE PROCEDURE [dbo].[Office_Select]
(
    @_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [dbo].[Office_Full] WHERE ID = @ID
;
END