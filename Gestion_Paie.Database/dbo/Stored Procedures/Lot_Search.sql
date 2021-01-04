CREATE PROCEDURE [dbo].[Lot_Search]
(
    @_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL
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
    (@searchText IS NULL) OR
    (pt.CantonID LIKE '%'+@searchText+'%') OR
    (pt.Rang LIKE '%'+@searchText+'%') OR
    (pt.Lot LIKE '%'+@searchText+'%') OR
    (pt.MunicipaliteID LIKE '%'+@searchText+'%') OR
    (pt.Superficie_total LIKE '%'+@searchText+'%') OR
    (pt.Superficie_boisee LIKE '%'+@searchText+'%') OR
    (pt.ProprietaireID LIKE '%'+@searchText+'%') OR
    (pt.ContingentID LIKE '%'+@searchText+'%') OR
    (pt.Contingent_Date LIKE '%'+@searchText+'%') OR
    (pt.Droit_coupeID LIKE '%'+@searchText+'%') OR
    (pt.Droit_coupe_Date LIKE '%'+@searchText+'%') OR
    (pt.Entente_paiementID LIKE '%'+@searchText+'%') OR
    (pt.Entente_paiement_Date LIKE '%'+@searchText+'%') OR
    (pt.Actif LIKE '%'+@searchText+'%') OR
    (pt.Sequence LIKE '%'+@searchText+'%') OR
    (pt.Partie LIKE '%'+@searchText+'%') OR
    (pt.Matricule LIKE '%'+@searchText+'%') OR
    (pt.ZoneID LIKE '%'+@searchText+'%') OR
    (pt.Secteur LIKE '%'+@searchText+'%') OR
    (pt.Reforme LIKE '%'+@searchText+'%') OR
    (pt.LotsComplementaires LIKE '%'+@searchText+'%') OR
    (pt.Certifie LIKE '%'+@searchText+'%') OR
    (pt.NumeroCertification LIKE '%'+@searchText+'%') OR
    (pt.OGC LIKE '%'+@searchText+'%')
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'cantonid_text' THEN lut1.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rang' THEN pt.Rang END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'lot' THEN pt.Lot END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'municipaliteid_text' THEN lut2.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'superficie_total' THEN pt.Superficie_total END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'superficie_boisee' THEN pt.Superficie_boisee END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'proprietaireid_text' THEN lut3.Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'contingentid_text' THEN lut4.Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'contingent_date' THEN pt.Contingent_Date END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'droit_coupeid_text' THEN lut5.Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'droit_coupe_date' THEN pt.Droit_coupe_Date END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'entente_paiementid_text' THEN lut6.Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'entente_paiement_date' THEN pt.Entente_paiement_Date END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'actif' THEN pt.Actif END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'sequence' THEN pt.Sequence END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'partie' THEN pt.Partie END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'matricule' THEN pt.Matricule END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'zoneid_text' THEN lut7.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'secteur' THEN pt.Secteur END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'cadastre' THEN pt.Cadastre END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'reforme' THEN pt.Reforme END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'lotscomplementaires' THEN pt.LotsComplementaires END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'certifie' THEN pt.Certifie END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'numerocertification' THEN pt.NumeroCertification END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'ogc' THEN pt.OGC END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'cantonid_text' THEN lut1.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rang' THEN pt.Rang END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'lot' THEN pt.Lot END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'municipaliteid_text' THEN lut2.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'superficie_total' THEN pt.Superficie_total END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'superficie_boisee' THEN pt.Superficie_boisee END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'proprietaireid_text' THEN lut3.Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'contingentid_text' THEN lut4.Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'contingent_date' THEN pt.Contingent_Date END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'droit_coupeid_text' THEN lut5.Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'droit_coupe_date' THEN pt.Droit_coupe_Date END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'entente_paiementid_text' THEN lut6.Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'entente_paiement_date' THEN pt.Entente_paiement_Date END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'actif' THEN pt.Actif END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'sequence' THEN pt.Sequence END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'partie' THEN pt.Partie END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'matricule' THEN pt.Matricule END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'zoneid_text' THEN lut7.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'secteur' THEN pt.Secteur END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'cadastre' THEN pt.Cadastre END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'reforme' THEN pt.Reforme END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'lotscomplementaires' THEN pt.LotsComplementaires END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'certifie' THEN pt.Certifie END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'numerocertification' THEN pt.NumeroCertification END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'ogc' THEN pt.OGC END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable;
END