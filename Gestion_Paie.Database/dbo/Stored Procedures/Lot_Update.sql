CREATE PROCEDURE [dbo].[Lot_Update]
(
    @_uid int,
    @CantonID varchar(6) NULL,
    @Rang varchar(25) NULL,
    @Lot varchar(6) NULL,
    @MunicipaliteID varchar(6) NULL,
    @Superficie_total real NULL,
    @Superficie_boisee real NULL,
    @ProprietaireID varchar(15) NULL,
    @ContingentID varchar(15) NULL,
    @Contingent_Date smalldatetime NULL,
    @Droit_coupeID varchar(15) NULL,
    @Droit_coupe_Date smalldatetime NULL,
    @Entente_paiementID varchar(15) NULL,
    @Entente_paiement_Date smalldatetime NULL,
    @Actif bit NULL,
    @ID int,
    @Sequence varchar(6) NULL,
    @Partie bit NULL,
    @Matricule varchar(20) NULL,
    @ZoneID varchar(2) NULL,
    @Secteur varchar(2) NULL,
    @Cadastre int NULL,
    @Reforme bit NULL,
    @LotsComplementaires varchar(255) NULL,
    @Certifie bit NULL,
    @NumeroCertification varchar(50) NULL,
    @OGC bit NULL
)
AS
BEGIN
SET NOCOUNT ON
;
    UPDATE Lot
    SET
        CantonID = @CantonID,
        Rang = @Rang,
        Lot = @Lot,
        MunicipaliteID = @MunicipaliteID,
        Superficie_total = @Superficie_total,
        Superficie_boisee = @Superficie_boisee,
        ProprietaireID = @ProprietaireID,
        ContingentID = @ContingentID,
        Contingent_Date = @Contingent_Date,
        Droit_coupeID = @Droit_coupeID,
        Droit_coupe_Date = @Droit_coupe_Date,
        Entente_paiementID = @Entente_paiementID,
        Entente_paiement_Date = @Entente_paiement_Date,
        Actif = @Actif,
        Sequence = @Sequence,
        Partie = @Partie,
        Matricule = @Matricule,
        ZoneID = @ZoneID,
        Secteur = @Secteur,
        Cadastre = @Cadastre,
        Reforme = @Reforme,
        LotsComplementaires = @LotsComplementaires,
        Certifie = @Certifie,
        NumeroCertification = @NumeroCertification,
        OGC = @OGC
    WHERE ID = @ID
    ;


END