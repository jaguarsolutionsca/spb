﻿CREATE PROCEDURE [dbo].[Office_Delete]
(
    @_uid int,
    @ID int,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS (SELECT 1 FROM Office WHERE ID = @ID AND Updated > @Updated)
    THROW 50000, 'Concurrency Error', 1


DELETE Office WHERE ID = @ID
;


END