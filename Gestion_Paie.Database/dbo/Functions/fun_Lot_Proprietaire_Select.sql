CREATE FUNCTION [dbo].[fun_Lot_Proprietaire_Select]
(
    @ID int
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        pt.ID,
        pt.ProprietaireID,
        lut1.Nom [ProprietaireID_Text],
        pt.DateDebut,
        pt.DateFin,
        pt.LotID,
        lut2.CantonID + ' - ' + ISNULL(Rang, '') + ' - ' + ISNULL(Lot, '') [LotID_Text]
    FROM [dbo].[Lot_Proprietaire] pt
    INNER JOIN Fournisseur lut1 ON lut1.ID = pt.ProprietaireID
    INNER JOIN Lot lut2 ON lut2.ID = pt.LotID
    WHERE pt.ID = @ID
)