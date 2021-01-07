CREATE PROCEDURE [dbo].[Lot_Search_ForProprietaire]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
	--
	@ProprietaireID varchar(15)
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
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
    [ID] int NOT NULL,
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
SELECT @pageNo = CASE WHEN @pageNo > 0 THEN @pageNo ELSE 1 END;
SELECT @pageSize = CASE WHEN @pageSize > 0 THEN @pageSize ELSE 25 END;
DECLARE @rowOffset int = (@pageNo - 1) * @pageSize;
IF(ISNULL(@searchText, '') = '') SET @searchText = NULL;

INSERT INTO @returnTable
SELECT
    COUNT(*) OVER()[TotalCount],
    pt.CantonID,
    lut1.Description [CantonID_Text],
    pt.Rang,
    pt.Lot,
    pt.MunicipaliteID,
    lut2.Description [MunicipaliteID_Text],
    pt.Superficie_total,
    pt.Superficie_boisee,
    pt.ProprietaireID,
    lut3.Nom [ProprietaireID_Text],
    pt.ContingentID,
    lut4.Nom [ContingentID_Text],
    pt.Contingent_Date,
    pt.Droit_coupeID,
    lut5.Nom [Droit_coupeID_Text],
    pt.Droit_coupe_Date,
    pt.Entente_paiementID,
    lut6.Nom [Entente_paiementID_Text],
    pt.Entente_paiement_Date,
    pt.Actif,
    pt.ID,
    pt.Sequence,
    pt.Partie,
    pt.Matricule,
    pt.ZoneID,
    lut7.Description [ZoneID_Text],
    pt.Secteur,
    pt.Cadastre,
    pt.Reforme,
    pt.LotsComplementaires,
    pt.Certifie,
    pt.NumeroCertification,
    pt.OGC
FROM [dbo].[Lot] pt
LEFT OUTER JOIN Canton lut1 ON lut1.ID = pt.CantonID
LEFT OUTER JOIN Municipalite_Zone lut2 ON lut2.ID = pt.MunicipaliteID
LEFT OUTER JOIN Fournisseur lut3 ON lut3.ID = pt.ProprietaireID
LEFT OUTER JOIN Fournisseur lut4 ON lut4.ID = pt.ContingentID
LEFT OUTER JOIN Fournisseur lut5 ON lut5.ID = pt.Droit_coupeID
LEFT OUTER JOIN Fournisseur lut6 ON lut6.ID = pt.Entente_paiementID
LEFT OUTER JOIN Municipalite_Zone lut7 ON lut7.ID = pt.ZoneID AND lut7.MunicipaliteID = pt.MunicipaliteID
WHERE
(
	(ProprietaireID = @ProprietaireID)
	AND ((pt.Actif = 1) OR (pt.Actif IS NULL))
)
ORDER BY CantonID, Rang, LEFT(('00000000'+Lot),6)
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable;
END