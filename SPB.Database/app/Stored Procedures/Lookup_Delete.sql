CREATE PROCEDURE [app].[Lookup_Delete]
(
    @_uid int,
    @ID int,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS(
    SELECT *
    FROM Lookup
    WHERE ID = @ID AND Updated > @Updated
)
    THROW 50000 , 'Concurrency Error', 1
;

    DELETE Lookup WHERE ID = @ID
    ;
    

END