CREATE PROCEDURE [dbo].[Fournisseur_Search]
(
	@_uid int,
    @pageNo int = 1,
    @pageSize int = 25,
    @sortColumn nvarchar(32) = NULL,
    @sortDirection nvarchar(4) = NULL,
    @searchText nvarchar(32) = NULL,
    --
    @Nom varchar(40) = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
DECLARE @returnTable TABLE
(
    [TotalCount] int NOT NULL,
    [ID] varchar(15) NOT NULL,
    [CleTri] varchar(15) NULL,
    [Nom] varchar(40) NULL,
    [AuSoinsDe] varchar(30) NULL,
    [Rue] varchar(30) NULL,
    [Ville] varchar(30) NULL,
    [PaysID] varchar(2) NULL,
    [PaysID_Text] nvarchar(50) NULL,
    [Code_postal] varchar(7) NULL,
    [Telephone] varchar(12) NULL,
    [Telephone_Poste] varchar(4) NULL,
    [Telecopieur] varchar(12) NULL,
    [Telephone2] varchar(12) NULL,
    [Telephone2_Desc] varchar(20) NULL,
    [Telephone2_Poste] varchar(4) NULL,
    [Telephone3] varchar(12) NULL,
    [Telephone3_Desc] varchar(20) NULL,
    [Telephone3_Poste] varchar(4) NULL,
    [No_membre] varchar(10) NULL,
    [Resident] char(1) NULL,
    [Email] varchar(80) NULL,
    [WWW] varchar(80) NULL,
    [Commentaires] varchar(255) NULL,
    [AfficherCommentaires] bit NULL,
    [DepotDirect] bit NULL,
    [InstitutionBanquaireID] varchar(3) NULL,
    [InstitutionBanquaireID_Text] nvarchar(50) NULL,
    [Banque_transit] varchar(5) NULL,
    [Banque_folio] varchar(12) NULL,
    [No_TPS] varchar(25) NULL,
    [No_TVQ] varchar(25) NULL,
    [PayerA] bit NULL,
    [PayerAID] varchar(15) NULL,
    [Statut] varchar(50) NULL,
    [Rep_Nom] varchar(30) NULL,
    [Rep_Telephone] varchar(12) NULL,
    [Rep_Telephone_Poste] varchar(4) NULL,
    [Rep_Email] varchar(80) NULL,
    [EnAnglais] bit NULL,
    [Actif] bit NULL,
    [MRCProducteurID] int NULL,
    [PaiementManuel] bit NULL,
    [Journal] bit NULL,
    [RecoitTPS] bit NULL,
    [RecoitTVQ] bit NULL,
    [ModifierTrigger] bit NULL,
    [IsProducteur] bit NULL,
    [IsTransporteur] bit NULL,
    [IsChargeur] bit NULL,
    [IsAutre] bit NULL,
    [AfficherCommentairesSurPermit] bit NOT NULL,
    [PasEmissionPermis] bit NULL,
    [Generique] bit NULL,
    [Membre_OGC] bit NULL,
    [InscritTPS] bit NULL,
    [InscritTVQ] bit NULL,
    [IsOGC] bit NOT NULL,
    [Rep2_Nom] varchar(80) NULL,
    [Rep2_Telephone] varchar(12) NULL,
    [Rep2_Telephone_Poste] varchar(4) NULL,
    [Rep2_Email] varchar(80) NULL,
    [Rep2_Commentaires] varchar(255) NULL
)
;
SELECT @pageNo = CASE WHEN @pageNo > 0 THEN @pageNo ELSE 1 END;
SELECT @pageSize = CASE WHEN @pageSize > 0 THEN @pageSize ELSE 25 END;
DECLARE @rowOffset int = (@pageNo - 1) * @pageSize;
IF(ISNULL(@searchText, '') = '') SET @searchText = NULL;

INSERT INTO @returnTable
SELECT
    COUNT(*) OVER()[TotalCount],
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
WHERE
(
    (@searchText IS NULL) OR
    (pt.ID LIKE '%'+@searchText+'%') OR
    (pt.CleTri LIKE '%'+@searchText+'%') OR
    (pt.Nom LIKE '%'+@searchText+'%') OR
    (pt.AuSoinsDe LIKE '%'+@searchText+'%') OR
    (pt.Rue LIKE '%'+@searchText+'%') OR
    (pt.Ville LIKE '%'+@searchText+'%') OR
    (pt.PaysID LIKE '%'+@searchText+'%') OR
    (pt.Code_postal LIKE '%'+@searchText+'%') OR
    (pt.Telephone LIKE '%'+@searchText+'%') OR
    (pt.Telephone_Poste LIKE '%'+@searchText+'%') OR
    (pt.Telecopieur LIKE '%'+@searchText+'%') OR
    (pt.Telephone2 LIKE '%'+@searchText+'%') OR
    (pt.Telephone2_Desc LIKE '%'+@searchText+'%') OR
    (pt.Telephone2_Poste LIKE '%'+@searchText+'%') OR
    (pt.Telephone3 LIKE '%'+@searchText+'%') OR
    (pt.Telephone3_Desc LIKE '%'+@searchText+'%') OR
    (pt.Telephone3_Poste LIKE '%'+@searchText+'%') OR
    (pt.No_membre LIKE '%'+@searchText+'%') OR
    (pt.Resident LIKE '%'+@searchText+'%') OR
    (pt.Email LIKE '%'+@searchText+'%') OR
    (pt.WWW LIKE '%'+@searchText+'%') OR
    (pt.Commentaires LIKE '%'+@searchText+'%') OR
    (pt.AfficherCommentaires LIKE '%'+@searchText+'%') OR
    (pt.DepotDirect LIKE '%'+@searchText+'%') OR
    (pt.InstitutionBanquaireID LIKE '%'+@searchText+'%') OR
    (pt.Banque_transit LIKE '%'+@searchText+'%') OR
    (pt.Banque_folio LIKE '%'+@searchText+'%') OR
    (pt.No_TPS LIKE '%'+@searchText+'%') OR
    (pt.No_TVQ LIKE '%'+@searchText+'%') OR
    (pt.PayerA LIKE '%'+@searchText+'%') OR
    (pt.PayerAID LIKE '%'+@searchText+'%') OR
    (pt.Statut LIKE '%'+@searchText+'%') OR
    (pt.Rep_Nom LIKE '%'+@searchText+'%') OR
    (pt.Rep_Telephone LIKE '%'+@searchText+'%') OR
    (pt.Rep_Telephone_Poste LIKE '%'+@searchText+'%') OR
    (pt.Rep_Email LIKE '%'+@searchText+'%') OR
    (pt.EnAnglais LIKE '%'+@searchText+'%') OR
    (pt.Actif LIKE '%'+@searchText+'%') OR
    (pt.PaiementManuel LIKE '%'+@searchText+'%') OR
    (pt.Journal LIKE '%'+@searchText+'%') OR
    (pt.RecoitTPS LIKE '%'+@searchText+'%') OR
    (pt.RecoitTVQ LIKE '%'+@searchText+'%') OR
    (pt.ModifierTrigger LIKE '%'+@searchText+'%') OR
    (pt.IsProducteur LIKE '%'+@searchText+'%') OR
    (pt.IsTransporteur LIKE '%'+@searchText+'%') OR
    (pt.IsChargeur LIKE '%'+@searchText+'%') OR
    (pt.IsAutre LIKE '%'+@searchText+'%') OR
    (pt.AfficherCommentairesSurPermit LIKE '%'+@searchText+'%') OR
    (pt.PasEmissionPermis LIKE '%'+@searchText+'%') OR
    (pt.Generique LIKE '%'+@searchText+'%') OR
    (pt.Membre_OGC LIKE '%'+@searchText+'%') OR
    (pt.InscritTPS LIKE '%'+@searchText+'%') OR
    (pt.InscritTVQ LIKE '%'+@searchText+'%') OR
    (pt.IsOGC LIKE '%'+@searchText+'%') OR
    (pt.Rep2_Nom LIKE '%'+@searchText+'%') OR
    (pt.Rep2_Telephone LIKE '%'+@searchText+'%') OR
    (pt.Rep2_Telephone_Poste LIKE '%'+@searchText+'%') OR
    (pt.Rep2_Email LIKE '%'+@searchText+'%') OR
    (pt.Rep2_Commentaires LIKE '%'+@searchText+'%')
) AND (
    ((@Nom IS NULL) OR (pt.Nom = @Nom))
)
ORDER BY
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'id' THEN pt.ID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'cleTri' THEN pt.CleTri END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'nom' THEN pt.Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'auSoinsDe' THEN pt.AuSoinsDe END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rue' THEN pt.Rue END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'ville' THEN pt.Ville END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'paysid_text' THEN lut1.Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'code_postal' THEN pt.Code_postal END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telephone' THEN pt.Telephone END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telephone_Poste' THEN pt.Telephone_Poste END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telecopieur' THEN pt.Telecopieur END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telephone2' THEN pt.Telephone2 END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telephone2_Desc' THEN pt.Telephone2_Desc END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telephone2_Poste' THEN pt.Telephone2_Poste END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telephone3' THEN pt.Telephone3 END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telephone3_Desc' THEN pt.Telephone3_Desc END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'telephone3_Poste' THEN pt.Telephone3_Poste END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'no_membre' THEN pt.No_membre END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'resident' THEN pt.Resident END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'email' THEN pt.Email END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'www' THEN pt.WWW END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'commentaires' THEN pt.Commentaires END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'afficherCommentaires' THEN pt.AfficherCommentaires END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'depotDirect' THEN pt.DepotDirect END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'institutionbanquaireid_text' THEN lut2.Description END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'banque_transit' THEN pt.Banque_transit END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'banque_folio' THEN pt.Banque_folio END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'no_TPS' THEN pt.No_TPS END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'no_TVQ' THEN pt.No_TVQ END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'payerA' THEN pt.PayerA END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'payerAID' THEN pt.PayerAID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'statut' THEN pt.Statut END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep_Nom' THEN pt.Rep_Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep_Telephone' THEN pt.Rep_Telephone END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep_Telephone_Poste' THEN pt.Rep_Telephone_Poste END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep_Email' THEN pt.Rep_Email END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'enAnglais' THEN pt.EnAnglais END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'actif' THEN pt.Actif END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN 0  WHEN @sortColumn = 'mRCProducteurID' THEN pt.MRCProducteurID END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'paiementManuel' THEN pt.PaiementManuel END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'journal' THEN pt.Journal END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'recoitTPS' THEN pt.RecoitTPS END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'recoitTVQ' THEN pt.RecoitTVQ END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'modifierTrigger' THEN pt.ModifierTrigger END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'isProducteur' THEN pt.IsProducteur END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'isTransporteur' THEN pt.IsTransporteur END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'isChargeur' THEN pt.IsChargeur END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'isAutre' THEN pt.IsAutre END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'afficherCommentairesSurPermit' THEN pt.AfficherCommentairesSurPermit END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'pasEmissionPermis' THEN pt.PasEmissionPermis END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'generique' THEN pt.Generique END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'membre_OGC' THEN pt.Membre_OGC END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'inscritTPS' THEN pt.InscritTPS END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'inscritTVQ' THEN pt.InscritTVQ END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'isOGC' THEN pt.IsOGC END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep2_Nom' THEN pt.Rep2_Nom END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep2_Telephone' THEN pt.Rep2_Telephone END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep2_Telephone_Poste' THEN pt.Rep2_Telephone_Poste END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep2_Email' THEN pt.Rep2_Email END ASC,
    CASE WHEN @sortDirection <> 'ASC' THEN '' WHEN @sortColumn = 'rep2_Commentaires' THEN pt.Rep2_Commentaires END ASC,
    --,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'id' THEN pt.ID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'cleTri' THEN pt.CleTri END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'nom' THEN pt.Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'auSoinsDe' THEN pt.AuSoinsDe END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rue' THEN pt.Rue END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'ville' THEN pt.Ville END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'paysid_text' THEN lut1.Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'code_postal' THEN pt.Code_postal END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telephone' THEN pt.Telephone END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telephone_Poste' THEN pt.Telephone_Poste END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telecopieur' THEN pt.Telecopieur END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telephone2' THEN pt.Telephone2 END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telephone2_Desc' THEN pt.Telephone2_Desc END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telephone2_Poste' THEN pt.Telephone2_Poste END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telephone3' THEN pt.Telephone3 END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telephone3_Desc' THEN pt.Telephone3_Desc END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'telephone3_Poste' THEN pt.Telephone3_Poste END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'no_membre' THEN pt.No_membre END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'resident' THEN pt.Resident END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'email' THEN pt.Email END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'www' THEN pt.WWW END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'commentaires' THEN pt.Commentaires END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'afficherCommentaires' THEN pt.AfficherCommentaires END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'depotDirect' THEN pt.DepotDirect END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'institutionbanquaireid_text' THEN lut2.Description END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'banque_transit' THEN pt.Banque_transit END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'banque_folio' THEN pt.Banque_folio END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'no_TPS' THEN pt.No_TPS END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'no_TVQ' THEN pt.No_TVQ END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'payerA' THEN pt.PayerA END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'payerAID' THEN pt.PayerAID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'statut' THEN pt.Statut END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep_Nom' THEN pt.Rep_Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep_Telephone' THEN pt.Rep_Telephone END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep_Telephone_Poste' THEN pt.Rep_Telephone_Poste END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep_Email' THEN pt.Rep_Email END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'enAnglais' THEN pt.EnAnglais END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'actif' THEN pt.Actif END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN 0  WHEN @sortColumn = 'mRCProducteurID' THEN pt.MRCProducteurID END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'paiementManuel' THEN pt.PaiementManuel END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'journal' THEN pt.Journal END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'recoitTPS' THEN pt.RecoitTPS END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'recoitTVQ' THEN pt.RecoitTVQ END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'modifierTrigger' THEN pt.ModifierTrigger END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'isProducteur' THEN pt.IsProducteur END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'isTransporteur' THEN pt.IsTransporteur END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'isChargeur' THEN pt.IsChargeur END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'isAutre' THEN pt.IsAutre END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'afficherCommentairesSurPermit' THEN pt.AfficherCommentairesSurPermit END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'pasEmissionPermis' THEN pt.PasEmissionPermis END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'generique' THEN pt.Generique END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'membre_OGC' THEN pt.Membre_OGC END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'inscritTPS' THEN pt.InscritTPS END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'inscritTVQ' THEN pt.InscritTVQ END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'isOGC' THEN pt.IsOGC END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep2_Nom' THEN pt.Rep2_Nom END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep2_Telephone' THEN pt.Rep2_Telephone END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep2_Telephone_Poste' THEN pt.Rep2_Telephone_Poste END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep2_Email' THEN pt.Rep2_Email END DESC,
    CASE WHEN @sortDirection <> 'DESC' THEN '' WHEN @sortColumn = 'rep2_Commentaires' THEN pt.Rep2_Commentaires END DESC
OFFSET @rowoffset ROWS
FETCH NEXT @pageSize ROWS ONLY
;

SELECT * FROM @returnTable;
END
