CREATE PROCEDURE [app].[Lookup_Select]
(
    @_uid int,
    @ID int
)
AS
BEGIN
SET NOCOUNT ON
;
SELECT * FROM [app].[Lookup_Full] WHERE ID=@id
;
END