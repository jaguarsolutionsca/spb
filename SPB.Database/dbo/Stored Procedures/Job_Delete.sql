CREATE PROCEDURE [dbo].[Job_Delete]
(
    @_uid int,
    @ID int,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS (SELECT 1 FROM Job WHERE ID = @ID AND Updated > @Updated)
    THROW 50000, 'Concurrency Error', 1


DELETE Job WHERE ID = @ID
;


END