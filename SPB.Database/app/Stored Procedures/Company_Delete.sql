
CREATE PROCEDURE [app].[Company_Delete]
(
    @_uid int,
    @CIE int,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS(
    SELECT *
    FROM Company
    WHERE CIE = @CIE AND Updated > @Updated
)
    THROW 50000 , 'Concurrency Error', 1
;

DELETE Company WHERE CIE = @CIE
;

END