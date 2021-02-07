CREATE PROCEDURE [dbo].[Staff_Select]
(
    @_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [dbo].[Staff_Full] WHERE ID = @ID
;
END