CREATE PROCEDURE [dbo].[Lot_Proprietaire_Update]
(
    @_uid int,
    @ID int,
    @ProprietaireID varchar(15),
    @DateDebut date,
    @DateFin date NULL,
    @LotID int
)
AS
BEGIN
SET NOCOUNT ON
;
    UPDATE Lot_Proprietaire
    SET
        ProprietaireID = @ProprietaireID,
        DateDebut = @DateDebut,
        DateFin = @DateFin,
        LotID = @LotID
    WHERE ID = @ID
    ;


END