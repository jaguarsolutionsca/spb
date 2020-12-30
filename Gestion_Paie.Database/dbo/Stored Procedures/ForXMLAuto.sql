

CREATE Procedure ForXMLAuto 

@IsFournisseur bit,
@ID varchar(15),
@Path varchar(8000) OUTPUT

AS


SET NOCOUNT ON
SET CONCAT_NULL_YIELDS_NULL OFF

Declare @XML varchar(8000)
select @XML = ''

if @IsFournisseur is null
BEGIN
	select @IsFournisseur = 1
END

if @IsFournisseur = 1
BEGIN
	-- Creation du XML pour Fournisseur
	DECLARE @newCleTri			VARCHAR(15)
	DECLARE @newNom				VARCHAR(40)
	DECLARE @newAuSoinsDe			VARCHAR(30)
	DECLARE @newRue				VARCHAR(30)
	DECLARE @newVille			VARCHAR(30)
	DECLARE @newPaysID			VARCHAR(2)
	DECLARE @newCode_postal			VARCHAR(7)
	DECLARE @newTelephone			VARCHAR(12)
	DECLARE @newTelephone_Poste		VARCHAR(4)
	DECLARE @newTelecopieur			VARCHAR(12)
	DECLARE @newTelephone2			VARCHAR(12)
	DECLARE @newTelephone2_Desc		VARCHAR(20)
	DECLARE @newTelephone2_Poste		VARCHAR(4)
	DECLARE @newTelephone3			VARCHAR(12)
	DECLARE @newTelephone3_Desc		VARCHAR(20)
	DECLARE @newTelephone3_Poste		VARCHAR(4)
	DECLARE @newNo_membre			VARCHAR(10)
	DECLARE @newResident			CHAR(1)
	DECLARE @newEmail			VARCHAR(80)
	DECLARE @newWWW				VARCHAR(80)
	DECLARE @newCommentaires		VARCHAR(255)
	DECLARE @newAfficherCommentaires	BIT
	DECLARE @newDepotDirect			BIT
	DECLARE @newInstitutionBanquaireID	VARCHAR(3)
	DECLARE @newBanque_transit		VARCHAR(5)
	DECLARE @newBanque_folio		VARCHAR(12)
	DECLARE @newRecoitTPS			BIT
	DECLARE @newRecoitTVQ			BIT
	DECLARE @newNo_TPS			VARCHAR(25)
	DECLARE @newNo_TVQ			VARCHAR(25)
	DECLARE @newPayerA			BIT
	DECLARE @newPayerAID			VARCHAR(15)
	DECLARE @newStatut			VARCHAR(50)
	DECLARE @newRep_Nom			VARCHAR(30)
	DECLARE @newRep_Telephone		VARCHAR(12)
	DECLARE @newRep_Telephone_Poste		VARCHAR(4)
	DECLARE @newRep_Email			VARCHAR(80)
	DECLARE @newEnAnglais			BIT
	DECLARE @newActif			BIT
	
	SELECT @newCleTri			= (select CleTri FROM Fournisseur where [ID] = @ID)
	SELECT @newNom				= (select Nom FROM Fournisseur where [ID] = @ID)
	SELECT @newAuSoinsDe			= (select AuSoinsDe FROM Fournisseur where [ID] = @ID)
	SELECT @newRue				= (select Rue FROM Fournisseur where [ID] = @ID)
	SELECT @newVille			= (select Ville FROM Fournisseur where [ID] = @ID)
	SELECT @newPaysID			= (select PaysID FROM Fournisseur where [ID] = @ID)
	SELECT @newCode_postal			= (select Code_postal FROM Fournisseur where [ID] = @ID)
	SELECT @newTelephone			= (select Telephone FROM Fournisseur where [ID] = @ID)
	SELECT @newTelephone_Poste		= (select Telephone_Poste FROM Fournisseur where [ID] = @ID)
	SELECT @newTelecopieur			= (select Telecopieur FROM Fournisseur where [ID] = @ID)
	SELECT @newTelephone2			= (select Telephone2 FROM Fournisseur where [ID] = @ID)
	SELECT @newTelephone2_Desc		= (select Telephone2_Desc FROM Fournisseur where [ID] = @ID)
	SELECT @newTelephone2_Poste		= (select Telephone2_Poste FROM Fournisseur where [ID] = @ID)
	SELECT @newTelephone3			= (select Telephone3 FROM Fournisseur where [ID] = @ID)
	SELECT @newTelephone3_Desc		= (select Telephone3_Desc FROM Fournisseur where [ID] = @ID)
	SELECT @newTelephone3_Poste		= (select Telephone3_Poste FROM Fournisseur where [ID] = @ID)
	SELECT @newNo_membre			= (select No_membre FROM Fournisseur where [ID] = @ID)
	SELECT @newResident			= (select Resident FROM Fournisseur where [ID] = @ID)
	SELECT @newEmail			= (select Email FROM Fournisseur where [ID] = @ID)
	SELECT @newWWW				= (select WWW FROM Fournisseur where [ID] = @ID)
	SELECT @newCommentaires			= (select Commentaires FROM Fournisseur where [ID] = @ID)
	SELECT @newAfficherCommentaires		= (select AfficherCommentaires FROM Fournisseur where [ID] = @ID)
	SELECT @newDepotDirect			= (select DepotDirect FROM Fournisseur where [ID] = @ID)
	SELECT @newInstitutionBanquaireID	= (select InstitutionBanquaireID FROM Fournisseur where [ID] = @ID)
	SELECT @newBanque_transit		= (select Banque_transit FROM Fournisseur where [ID] = @ID)
	SELECT @newBanque_folio			= (select Banque_folio FROM Fournisseur where [ID] = @ID)
	SELECT @newRecoitTPS			= (select RecoitTPS FROM Fournisseur where [ID] = @ID)
	SELECT @newRecoitTVQ			= (select RecoitTVQ FROM Fournisseur where [ID] = @ID)
	SELECT @newNo_TPS			= (select No_TPS FROM Fournisseur where [ID] = @ID)
	SELECT @newNo_TVQ			= (select No_TVQ FROM Fournisseur where [ID] = @ID)
	SELECT @newPayerA			= (select PayerA FROM Fournisseur where [ID] = @ID)
	SELECT @newPayerAID			= (select PayerAID FROM Fournisseur where [ID] = @ID)
	SELECT @newStatut			= (select Statut FROM Fournisseur where [ID] = @ID)
	SELECT @newRep_Nom			= (select Rep_Nom FROM Fournisseur where [ID] = @ID)
	SELECT @newRep_Telephone		= (select Rep_Telephone FROM Fournisseur where [ID] = @ID)
	SELECT @newRep_Telephone_Poste		= (select Rep_Telephone_Poste FROM Fournisseur where [ID] = @ID)
	SELECT @newRep_Email			= (select Rep_Email FROM Fournisseur where [ID] = @ID)
	SELECT @newEnAnglais			= (select EnAnglais FROM Fournisseur where [ID] = @ID)
	SELECT @newActif			= (select Actif FROM Fournisseur where [ID] = @ID)

	select @XML = '<Fournisseur>' +
	'<ID>' 				+ dbo.jag_HTMLEncode(@ID)			+ '</ID>' +
	'<CleTri>' 			+ dbo.jag_HTMLEncode(@newCleTri) 					+ '</CleTri>' +
	'<Nom>' 			+ dbo.jag_HTMLEncode(@newNom) 					+ '</Nom>' +
	'<AuSoinsDe>' 			+ dbo.jag_HTMLEncode(@newAuSoinsDe) 				+ '</AuSoinsDe>' +
	'<Rue>' 			+ dbo.jag_HTMLEncode(@newRue) 					+ '</Rue>' +
	'<Ville>' 			+ dbo.jag_HTMLEncode(@newVille) 					+ '</Ville>' +
	'<PaysID>' 			+ dbo.jag_HTMLEncode(@newPaysID) 					+ '</PaysID>' +
	'<Code_postal>' 		+ dbo.jag_HTMLEncode(@newCode_postal) 				+ '</Code_postal>' +
	'<Telephone>' 			+ dbo.jag_HTMLEncode(@newTelephone) 				+ '</Telephone>' +
	'<Telephone_Poste>' 		+ dbo.jag_HTMLEncode(@newTelephone_Poste) 				+ '</Telephone_Poste>' +
	'<Telecopieur>' 		+ dbo.jag_HTMLEncode(@newTelecopieur) 				+ '</Telecopieur>' +
	'<Telephone2>' 			+ dbo.jag_HTMLEncode(@newTelephone2) 				+ '</Telephone2>' +
	'<Telephone2_Desc>' 		+ dbo.jag_HTMLEncode(@newTelephone2_Desc) 				+ '</Telephone2_Desc>' +
	'<Telephone2_Poste>' 		+ dbo.jag_HTMLEncode(@newTelephone2_Poste)				+ '</Telephone2_Poste>' +
	'<Telephone3>' 			+ dbo.jag_HTMLEncode(@newTelephone3) 				+ '</Telephone3>' +
	'<Telephone3_Desc>' 		+ dbo.jag_HTMLEncode(@newTelephone3_Desc) 				+ '</Telephone3_Desc>' +
	'<Telephone3_Poste>' 		+ dbo.jag_HTMLEncode(@newTelephone3_Poste)				+ '</Telephone3_Poste>' +
	'<Email>'			+ dbo.jag_HTMLEncode(@newEmail) 					+ '</Email>' +
	'<WWW>' 			+ dbo.jag_HTMLEncode(@newWWW) 					+ '</WWW>' +
	'<Commentaires>' 		+ dbo.jag_HTMLEncode(@newCommentaires) 				+ '</Commentaires>' +
	'<AfficherCommentaires>' 	+ dbo.jag_HTMLEncode(convert(varchar(10), @newAfficherCommentaires))+ '</AfficherCommentaires>' +
	'<DepotDirect>' 		+ dbo.jag_HTMLEncode(convert(varchar(10), @newDepotDirect)) 	+ '</DepotDirect>' +
	'<InstitutionBanquaireID>' 	+ dbo.jag_HTMLEncode(@newInstitutionBanquaireID) 			+ '</InstitutionBanquaireID>' +
	'<Banque_transit>' 		+ dbo.jag_HTMLEncode(@newBanque_transit) 				+ '</Banque_transit>' +
	'<Banque_folio>' 		+ dbo.jag_HTMLEncode(@newBanque_folio) 				+ '</Banque_folio>' +
	'<No_TPS>' 			+ dbo.jag_HTMLEncode(convert(varchar(50), @newNo_TPS)) 		+ '</No_TPS>' +
	'<No_TVQ>' 			+ dbo.jag_HTMLEncode(convert(varchar(50), @newNo_TVQ)) 		+ '</No_TVQ>' +
	'<PayerA>' 			+ dbo.jag_HTMLEncode(convert(varchar(50), @newPayerA)) 		+ '</PayerA>' +
	'<PayerAID>' 			+ dbo.jag_HTMLEncode(convert(varchar(50), @newPayerAID))		+ '</PayerAID>' +
	'<Rep_Nom>' 			+ dbo.jag_HTMLEncode(@newRep_Nom) 					+ '</Rep_Nom>' +
	'<Rep_Telephone>' 		+ dbo.jag_HTMLEncode(@newRep_Telephone) 				+ '</Rep_Telephone>' +
	'<Rep_Telephone_Poste>' 	+ dbo.jag_HTMLEncode(@newRep_Telephone_Poste) 			+ '</Rep_Telephone_Poste>' +
	'<Rep_Email>' 			+ dbo.jag_HTMLEncode(@newRep_Email) 				+ '</Rep_Email>' +
	'<Actif>' 			+ dbo.jag_HTMLEncode(convert(varchar(10), @newActif)) 		+ '</Actif>' +
	'</Fournisseur>'
END

ELSE

BEGIN
	-- Creation du XML pour Usine
	DECLARE @newUsineActif		bit
	DECLARE @newUsineCleTri	varchar(20)
	DECLARE @newUsineDescription	varchar(50)
	DECLARE @newUsineSpecification	varchar(8000)

	DECLARE @newUsineAuSoinsDe		VARCHAR(30)
	DECLARE @newUsineRue			VARCHAR(30)
	DECLARE @newUsineVille			VARCHAR(30)
	DECLARE @newUsinePaysID			VARCHAR(2)
	DECLARE @newUsineCode_postal		VARCHAR(7)
	DECLARE @newUsineTelephone		VARCHAR(12)
	DECLARE @newUsineTelephone_Poste	VARCHAR(4)
	DECLARE @newUsineTelecopieur		VARCHAR(12)
	DECLARE @newUsineTelephone2		VARCHAR(12)
	DECLARE @newUsineTelephone2_Desc	VARCHAR(20)
	DECLARE @newUsineTelephone2_Poste	VARCHAR(4)
	DECLARE @newUsineTelephone3		VARCHAR(12)
	DECLARE @newUsineTelephone3_Desc	VARCHAR(20)
	DECLARE @newUsineTelephone3_Poste	VARCHAR(4)
	DECLARE @newUsineEmail			VARCHAR(80)

	IF ((SELECT [Value] FROM jag_SystemEx WHERE [Name]='CleTriClientNom')='true')
	BEGIN
		SELECT @newUsineCleTri	= (select LEFT([Description], 20) FROM Usine where [ID] = @ID)
	END
	ELSE
	BEGIN
		SELECT @newUsineCleTri	= (select LEFT([ID], 20) FROM Usine where [ID] = @ID)
	END

	SELECT @newUsineActif		= (select Actif 	FROM Usine where [ID] = @ID)
	SELECT @newUsineDescription	= (select [Description] FROM Usine where [ID] = @ID)
	SELECT @newUsineSpecification	= (select convert(varchar(8000), Specification) FROM Usine where [ID] = @ID)

	SELECT @newUsineAuSoinsDe		= (select AuSoinsDe FROM Usine where [ID] = @ID)
	SELECT @newUsineRue			= (select Rue FROM Usine where [ID] = @ID)
	SELECT @newUsineVille			= (select Ville FROM Usine where [ID] = @ID)
	SELECT @newUsinePaysID			= (select PaysID FROM Usine where [ID] = @ID)
	SELECT @newUsineCode_postal		= (select Code_postal FROM Usine where [ID] = @ID)
	SELECT @newUsineTelephone		= (select Telephone FROM Usine where [ID] = @ID)
	SELECT @newUsineTelephone_Poste		= (select Telephone_Poste FROM Usine where [ID] = @ID)
	SELECT @newUsineTelecopieur		= (select Telecopieur FROM Usine where [ID] = @ID)
	SELECT @newUsineTelephone2		= (select Telephone2 FROM Usine where [ID] = @ID)
	SELECT @newUsineTelephone2_Desc		= (select Telephone2_Desc FROM Usine where [ID] = @ID)
	SELECT @newUsineTelephone2_Poste	= (select Telephone2_Poste FROM Usine where [ID] = @ID)
	SELECT @newUsineTelephone3		= (select Telephone3 FROM Usine where [ID] = @ID)
	SELECT @newUsineTelephone3_Desc		= (select Telephone3_Desc FROM Usine where [ID] = @ID)
	SELECT @newUsineTelephone3_Poste	= (select Telephone3_Poste FROM Usine where [ID] = @ID)
	SELECT @newUsineEmail			= (select Email FROM Usine where [ID] = @ID)


	select @XML = '<Usine>' +
	'<ID>' 			+ dbo.jag_HTMLEncode(@ID) 					+ '</ID>' +
	'<CleTri>' 			+ dbo.jag_HTMLEncode(@newUsineCleTri) 					+ '</CleTri>' +
	'<Actif>' 		+ dbo.jag_HTMLEncode(convert(varchar(10), @newUsineActif)) 	+ '</Actif>' +
	'<Description>' 	+ dbo.jag_HTMLEncode(@newUsineDescription) 			+ '</Description>' +
	'<Specification>' 	+ dbo.jag_HTMLEncode(@newUsineSpecification)			+ '</Specification>' +
	'<AuSoinsDe>' 		+ dbo.jag_HTMLEncode(@newUsineAuSoinsDe) 			+ '</AuSoinsDe>' +
	'<Rue>' 		+ dbo.jag_HTMLEncode(@newUsineRue) 				+ '</Rue>' +
	'<Ville>' 		+ dbo.jag_HTMLEncode(@newUsineVille) 				+ '</Ville>' +
	'<PaysID>' 		+ dbo.jag_HTMLEncode(@newUsinePaysID) 				+ '</PaysID>' +
	'<Code_postal>' 	+ dbo.jag_HTMLEncode(@newUsineCode_postal) 			+ '</Code_postal>' +
	'<Telephone>' 		+ dbo.jag_HTMLEncode(@newUsineTelephone) 			+ '</Telephone>' +
	'<Telephone_Poste>' 	+ dbo.jag_HTMLEncode(@newUsineTelephone_Poste) 			+ '</Telephone_Poste>' +
	'<Telecopieur>' 	+ dbo.jag_HTMLEncode(@newUsineTelecopieur) 			+ '</Telecopieur>' +
	'<Telephone2>' 		+ dbo.jag_HTMLEncode(@newUsineTelephone2) 			+ '</Telephone2>' +
	'<Telephone2_Desc>' 	+ dbo.jag_HTMLEncode(@newUsineTelephone2_Desc) 			+ '</Telephone2_Desc>' +
	'<Telephone2_Poste>' 	+ dbo.jag_HTMLEncode(@newUsineTelephone2_Poste)			+ '</Telephone2_Poste>' +
	'<Telephone3>' 		+ dbo.jag_HTMLEncode(@newUsineTelephone3) 			+ '</Telephone3>' +
	'<Telephone3_Desc>' 	+ dbo.jag_HTMLEncode(@newUsineTelephone3_Desc) 			+ '</Telephone3_Desc>' +
	'<Telephone3_Poste>' 	+ dbo.jag_HTMLEncode(@newUsineTelephone3_Poste)			+ '</Telephone3_Poste>' +
	'<Email>'		+ dbo.jag_HTMLEncode(@newUsineEmail) 				+ '</Email>' +
	'</Usine>'
END

select @Path = [Value] + convert(varchar(1000), newid()) + '.txt' from jag_SystemEx where [Name] = 'AcombaSyncroPath'


DECLARE @FS int
declare @OLEResult int
Declare @FileID int

EXECUTE @OLEResult = sp_OACreate 'Scripting.FileSystemObject', @FS OUT
IF @OLEResult <> 0 PRINT 'Scripting.FileSystemObject'

--Open a file
execute @OLEResult = sp_OAMethod @FS, 'OpenTextFile', @FileID OUT, @Path, 8, 1
IF @OLEResult <> 0 PRINT 'OpenTextFile'

--Write Text1
execute @OLEResult = sp_OAMethod @FileID, 'WriteLine', Null, @XML
IF @OLEResult <> 0 PRINT 'WriteLine'

EXECUTE @OLEResult = sp_OADestroy @FileID
EXECUTE @OLEResult = sp_OADestroy @FS

