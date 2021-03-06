﻿CREATE PROCEDURE [dbo].[Fournisseur_Update]
(
	@_uid int,
    @ID varchar(15),
    @CleTri varchar(15) NULL,
    @Nom varchar(40) NULL,
    @AuSoinsDe varchar(30) NULL,
    @Rue varchar(30) NULL,
    @Ville varchar(30) NULL,
    @PaysID varchar(2) NULL,
    @Code_postal varchar(7) NULL,
    @Telephone varchar(12) NULL,
    @Telephone_Poste varchar(4) NULL,
    @Telecopieur varchar(12) NULL,
    @Telephone2 varchar(12) NULL,
    @Telephone2_Desc varchar(20) NULL,
    @Telephone2_Poste varchar(4) NULL,
    @Telephone3 varchar(12) NULL,
    @Telephone3_Desc varchar(20) NULL,
    @Telephone3_Poste varchar(4) NULL,
    @No_membre varchar(10) NULL,
    @Resident char(1) NULL,
    @Email varchar(80) NULL,
    @WWW varchar(80) NULL,
    @Commentaires varchar(255) NULL,
    @AfficherCommentaires bit NULL,
    @DepotDirect bit NULL,
    @InstitutionBanquaireID varchar(3) NULL,
    @Banque_transit varchar(5) NULL,
    @Banque_folio varchar(12) NULL,
    @No_TPS varchar(25) NULL,
    @No_TVQ varchar(25) NULL,
    @PayerA bit NULL,
    @PayerAID varchar(15) NULL,
    @Statut varchar(50) NULL,
    @Rep_Nom varchar(30) NULL,
    @Rep_Telephone varchar(12) NULL,
    @Rep_Telephone_Poste varchar(4) NULL,
    @Rep_Email varchar(80) NULL,
    @EnAnglais bit NULL,
    @Actif bit NULL,
    @MRCProducteurID int NULL,
    @PaiementManuel bit NULL,
    @Journal bit NULL,
    @RecoitTPS bit NULL,
    @RecoitTVQ bit NULL,
    @ModifierTrigger bit NULL,
    @IsProducteur bit NULL,
    @IsTransporteur bit NULL,
    @IsChargeur bit NULL,
    @IsAutre bit NULL,
    @AfficherCommentairesSurPermit bit,
    @PasEmissionPermis bit NULL,
    @Generique bit NULL,
    @Membre_OGC bit NULL,
    @InscritTPS bit NULL,
    @InscritTVQ bit NULL,
    @IsOGC bit,
    @Rep2_Nom varchar(80) NULL,
    @Rep2_Telephone varchar(12) NULL,
    @Rep2_Telephone_Poste varchar(4) NULL,
    @Rep2_Email varchar(80) NULL,
    @Rep2_Commentaires varchar(255) NULL
)
AS
BEGIN
SET NOCOUNT ON
;
    UPDATE Fournisseur
    SET
        ID = @ID,
        CleTri = @CleTri,
        Nom = @Nom,
        AuSoinsDe = @AuSoinsDe,
        Rue = @Rue,
        Ville = @Ville,
        PaysID = @PaysID,
        Code_postal = @Code_postal,
        Telephone = @Telephone,
        Telephone_Poste = @Telephone_Poste,
        Telecopieur = @Telecopieur,
        Telephone2 = @Telephone2,
        Telephone2_Desc = @Telephone2_Desc,
        Telephone2_Poste = @Telephone2_Poste,
        Telephone3 = @Telephone3,
        Telephone3_Desc = @Telephone3_Desc,
        Telephone3_Poste = @Telephone3_Poste,
        No_membre = @No_membre,
        Resident = @Resident,
        Email = @Email,
        WWW = @WWW,
        Commentaires = @Commentaires,
        AfficherCommentaires = @AfficherCommentaires,
        DepotDirect = @DepotDirect,
        InstitutionBanquaireID = @InstitutionBanquaireID,
        Banque_transit = @Banque_transit,
        Banque_folio = @Banque_folio,
        No_TPS = @No_TPS,
        No_TVQ = @No_TVQ,
        PayerA = @PayerA,
        PayerAID = @PayerAID,
        Statut = @Statut,
        Rep_Nom = @Rep_Nom,
        Rep_Telephone = @Rep_Telephone,
        Rep_Telephone_Poste = @Rep_Telephone_Poste,
        Rep_Email = @Rep_Email,
        EnAnglais = @EnAnglais,
        Actif = @Actif,
        MRCProducteurID = @MRCProducteurID,
        PaiementManuel = @PaiementManuel,
        Journal = @Journal,
        RecoitTPS = @RecoitTPS,
        RecoitTVQ = @RecoitTVQ,
        ModifierTrigger = @ModifierTrigger,
        IsProducteur = @IsProducteur,
        IsTransporteur = @IsTransporteur,
        IsChargeur = @IsChargeur,
        IsAutre = @IsAutre,
        AfficherCommentairesSurPermit = @AfficherCommentairesSurPermit,
        PasEmissionPermis = @PasEmissionPermis,
        Generique = @Generique,
        Membre_OGC = @Membre_OGC,
        InscritTPS = @InscritTPS,
        InscritTVQ = @InscritTVQ,
        IsOGC = @IsOGC,
        Rep2_Nom = @Rep2_Nom,
        Rep2_Telephone = @Rep2_Telephone,
        Rep2_Telephone_Poste = @Rep2_Telephone_Poste,
        Rep2_Email = @Rep2_Email,
        Rep2_Commentaires = @Rep2_Commentaires
    WHERE ID = @ID
    ;


END
