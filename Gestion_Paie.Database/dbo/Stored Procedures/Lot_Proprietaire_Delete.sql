CREATE PROCEDURE [dbo].[Lot_Proprietaire_Delete]
(
    @_uid int,
    @ID int,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
    DELETE Lot_Proprietaire WHERE ID = @ID
    ;
    

END