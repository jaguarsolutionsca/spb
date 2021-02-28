CREATE PROCEDURE [app].[PermMeta_Select]
(
    @_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [app].[PermMeta_Full] WHERE ID = @ID
;
END