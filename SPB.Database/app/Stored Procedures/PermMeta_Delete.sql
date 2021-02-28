CREATE PROCEDURE [app].[PermMeta_Delete]
(
    @_uid int,
    @ID int,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS (SELECT 1 FROM PermMeta WHERE ID = @ID AND Updated > @Updated)
    THROW 50000, 'Concurrency Error', 1


DELETE PermMeta WHERE ID = @ID
;


END