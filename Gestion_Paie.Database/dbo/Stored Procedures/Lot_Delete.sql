CREATE PROCEDURE [dbo].[Lot_Delete]
(
    @_uid int,
    @ID int,
    @Updated datetime
)
AS
BEGIN
SET NOCOUNT ON
;
    DELETE Lot WHERE ID = @ID
    ;
    

END