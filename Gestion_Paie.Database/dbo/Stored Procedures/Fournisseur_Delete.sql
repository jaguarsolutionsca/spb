CREATE PROCEDURE [dbo].[Fournisseur_Delete]
(
	@_uid int,
    @ID varchar(15),
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
    DELETE Fournisseur WHERE ID = @ID
    ;
    

END
