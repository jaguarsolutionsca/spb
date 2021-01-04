CREATE FUNCTION [dbo].[fun_Lot_Select]
(
    @ID int
)
RETURNS TABLE
AS
RETURN
(
    SELECT
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
    LEFT OUTER JOIN Municipalite_Zone lut7 ON lut7.ID = pt.ZoneID
    WHERE pt.ID = @ID
)