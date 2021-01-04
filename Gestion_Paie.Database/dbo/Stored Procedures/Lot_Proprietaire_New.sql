CREATE PROCEDURE [dbo].[Lot_Proprietaire_New]
(
    @_uid int,
    @ProprietaireID int
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [ProprietaireID] varchar(15) NOT NULL,
    [ProprietaireID_Text] nvarchar(50) NOT NULL,
    [DateDebut] date NOT NULL,
    [DateFin] date NULL,
    [LotID] int NOT NULL,
    [LotID_Text] nvarchar(50) NOT NULL
)
;
INSERT @returnTable
SELECT
    @ProprietaireID [ProprietaireID],
    '' [ProprietaireID_Text],
    GETDATE() [DateDebut],
    NULL [DateFin],
    0 [LotID],
    '' [LotID_Text]
;
SELECT * FROM @returnTable;
;
END