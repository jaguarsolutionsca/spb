CREATE PROCEDURE [app].[Lookup_Select]
(
    @_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [app].[fun_Lookup_Select] (@ID)
;
END