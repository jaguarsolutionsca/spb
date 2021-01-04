CREATE PROCEDURE [dbo].[Lot_New]
(
    @_uid int
    
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [CantonID] varchar(6) NULL,
    [CantonID_Text] nvarchar(50) NULL,
    [Rang] varchar(25) NULL,
    [Lot] varchar(6) NULL,
    [MunicipaliteID] varchar(6) NULL,
    [MunicipaliteID_Text] nvarchar(50) NULL,
    [Superficie_total] real NULL,
    [Superficie_boisee] real NULL,
    [ProprietaireID] varchar(15) NULL,
    [ProprietaireID_Text] nvarchar(50) NULL,
    [ContingentID] varchar(15) NULL,
    [ContingentID_Text] nvarchar(50) NULL,
    [Contingent_Date] smalldatetime NULL,
    [Droit_coupeID] varchar(15) NULL,
    [Droit_coupeID_Text] nvarchar(50) NULL,
    [Droit_coupe_Date] smalldatetime NULL,
    [Entente_paiementID] varchar(15) NULL,
    [Entente_paiementID_Text] nvarchar(50) NULL,
    [Entente_paiement_Date] smalldatetime NULL,
    [Actif] bit NULL,
    [Sequence] varchar(6) NULL,
    [Partie] bit NULL,
    [Matricule] varchar(20) NULL,
    [ZoneID] varchar(2) NULL,
    [ZoneID_Text] nvarchar(50) NULL,
    [Secteur] varchar(2) NULL,
    [Cadastre] int NULL,
    [Reforme] bit NULL,
    [LotsComplementaires] varchar(255) NULL,
    [Certifie] bit NULL,
    [NumeroCertification] varchar(50) NULL,
    [OGC] bit NULL
)
;
INSERT @returnTable
SELECT
    NULL [CantonID],
    '' [CantonID_Text],
    NULL [Rang],
    NULL [Lot],
    NULL [MunicipaliteID],
    '' [MunicipaliteID_Text],
    NULL [Superficie_total],
    NULL [Superficie_boisee],
    NULL [ProprietaireID],
    '' [ProprietaireID_Text],
    NULL [ContingentID],
    '' [ContingentID_Text],
    NULL [Contingent_Date],
    NULL [Droit_coupeID],
    '' [Droit_coupeID_Text],
    NULL [Droit_coupe_Date],
    NULL [Entente_paiementID],
    '' [Entente_paiementID_Text],
    NULL [Entente_paiement_Date],
    NULL [Actif],
    NULL [Sequence],
    NULL [Partie],
    NULL [Matricule],
    NULL [ZoneID],
    '' [ZoneID_Text],
    NULL [Secteur],
    NULL [Cadastre],
    NULL [Reforme],
    NULL [LotsComplementaires],
    NULL [Certifie],
    NULL [NumeroCertification],
    NULL [OGC] 
;
SELECT * FROM @returnTable;
;
END