
CREATE PROCEDURE [dbo].[CommitCBEFF_Delete]
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
    FROM CommitCBEFF
    WHERE ID = @ID AND Updated > @Updated
)
    THROW 50000 , 'Concurrency Error', 1
;

    DELETE CommitCBEFF WHERE ID = @ID
    ;
    

END