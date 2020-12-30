CREATE PROCEDURE [dbo].[spI_Cert_Proprietaire]
@Agence VARCHAR (10), @NO_ACT VARCHAR (10), @Nom VARCHAR (50)=Null, @Representant VARCHAR (35)=Null, @ADRESSE VARCHAR (50)=Null, @Ville VARCHAR (50)=Null, @CODE_POST VARCHAR (25)=Null, @TEL_RES VARCHAR (25)=Null, @TEL_BUR VARCHAR (25)=Null, @FournisseurID VARCHAR (15)=Null, @FournisseurNom VARCHAR (40)=Null, @Traite BIT=Null, @Methode VARCHAR (25)=Null
AS
Set NoCount On

Insert Into [dbo].[Cert_Proprietaire]
(
	  [Agence]
	, [NO_ACT]
	, [Nom]
	, [Representant]
	, [ADRESSE]
	, [Ville]
	, [CODE_POST]
	, [TEL_RES]
	, [TEL_BUR]
	, [FournisseurID]
	, [FournisseurNom]
	, [Traite]
	, [Methode]
)

Values
(
	  @Agence
	, @NO_ACT
	, @Nom
	, @Representant
	, @ADRESSE
	, @Ville
	, @CODE_POST
	, @TEL_RES
	, @TEL_BUR
	, @FournisseurID
	, @FournisseurNom
	, @Traite
	, @Methode
)

Set NoCount Off

Return(0)


