CREATE FUNCTION [dbo].[fun_Fournisseur_Select]
(
    @ID varchar(15)
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        pt.ID,
        pt.CleTri,
        pt.Nom,
        pt.AuSoinsDe,
        pt.Rue,
        pt.Ville,
        pt.PaysID,
        lut1.Nom [PaysID_Text],
        pt.Code_postal,
        pt.Telephone,
        pt.Telephone_Poste,
        pt.Telecopieur,
        pt.Telephone2,
        pt.Telephone2_Desc,
        pt.Telephone2_Poste,
        pt.Telephone3,
        pt.Telephone3_Desc,
        pt.Telephone3_Poste,
        pt.No_membre,
        pt.Resident,
        pt.Email,
        pt.WWW,
        pt.Commentaires,
        pt.AfficherCommentaires,
        pt.DepotDirect,
        pt.InstitutionBanquaireID,
        lut2.Description [InstitutionBanquaireID_Text],
        pt.Banque_transit,
        pt.Banque_folio,
        pt.No_TPS,
        pt.No_TVQ,
        pt.PayerA,
        pt.PayerAID,
        pt.Statut,
        pt.Rep_Nom,
        pt.Rep_Telephone,
        pt.Rep_Telephone_Poste,
        pt.Rep_Email,
        pt.EnAnglais,
        pt.Actif,
        pt.MRCProducteurID,
        pt.PaiementManuel,
        pt.Journal,
        pt.RecoitTPS,
        pt.RecoitTVQ,
        pt.ModifierTrigger,
        pt.IsProducteur,
        pt.IsTransporteur,
        pt.IsChargeur,
        pt.IsAutre,
        pt.AfficherCommentairesSurPermit,
        pt.PasEmissionPermis,
        pt.Generique,
        pt.Membre_OGC,
        pt.InscritTPS,
        pt.InscritTVQ,
        pt.IsOGC,
        pt.Rep2_Nom,
        pt.Rep2_Telephone,
        pt.Rep2_Telephone_Poste,
        pt.Rep2_Email,
        pt.Rep2_Commentaires
    FROM [dbo].[Fournisseur] pt
    LEFT OUTER JOIN Pays lut1 ON lut1.ID = pt.PaysID
    LEFT OUTER JOIN InstitutionBanquaire lut2 ON lut2.ID = pt.InstitutionBanquaireID
    WHERE pt.ID = @ID
)
