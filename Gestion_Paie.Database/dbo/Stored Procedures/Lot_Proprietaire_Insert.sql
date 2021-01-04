CREATE PROCEDURE [dbo].[Lot_Proprietaire_Insert]
(
    @_uid int,
    @ID int OUTPUT,
    @ProprietaireID varchar(15),
    @DateDebut date,
    @DateFin date NULL,
    @LotID int
)
AS
BEGIN
SET NOCOUNT ON
;

    INSERT INTO Lot_Proprietaire
    (ProprietaireID,DateDebut,DateFin,LotID)
    VALUES (
        @ProprietaireID,
        @DateDebut,
        @DateFin,
        @LotID
    )
    ;
    SET @ID = SCOPE_IDENTITY()
    ;


END