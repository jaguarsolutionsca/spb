CREATE PROCEDURE [dbo].[spI_FeuilletDomtar]
@Transaction VARCHAR (15), @TransactionType VARCHAR (3)=Null, @Fournisseur VARCHAR (15)=Null, @Contrat VARCHAR (25)=Null, @Produit VARCHAR (10)=Null, @DateLivraison SMALLDATETIME=Null, @Carte VARCHAR (15)=Null, @License VARCHAR (15)=Null, @Transporteur_Camion VARCHAR (15)=Null, @Producteur VARCHAR (15)=Null, @Municipalite VARCHAR (15)=Null, @Brut INT=Null, @Tare INT=Null, @Net INT=Null, @Rejets INT=Null, @KgVert_Paye INT=Null, @Pourcent_Sec FLOAT=Null, @KgSec_Paye INT=Null, @Validation VARCHAR (255)=Null, @Transfert BIT=Null, @EssenceID VARCHAR (6)=Null, @UniteID VARCHAR (6)=Null, @Code CHAR (4)=Null, @TransporteurID VARCHAR (15)=Null, @BonCommande VARCHAR (25)=Null
AS
Set NoCount On

Insert Into [dbo].[FeuilletDomtar]
(
	  [Transaction]
	, [TransactionType]
	, [Fournisseur]
	, [Contrat]
	, [Produit]
	, [DateLivraison]
	, [Carte]
	, [License]
	, [Transporteur_Camion]
	, [Producteur]
	, [Municipalite]
	, [Brut]
	, [Tare]
	, [Net]
	, [Rejets]
	, [KgVert_Paye]
	, [Pourcent_Sec]
	, [KgSec_Paye]
	, [Validation]
	, [Transfert]
	, [EssenceID]
	, [UniteID]
	, [Code]
	, [TransporteurID]
	, [BonCommande]
)

Values
(
	  @Transaction
	, @TransactionType
	, @Fournisseur
	, @Contrat
	, @Produit
	, @DateLivraison
	, @Carte
	, @License
	, @Transporteur_Camion
	, @Producteur
	, @Municipalite
	, @Brut
	, @Tare
	, @Net
	, @Rejets
	, @KgVert_Paye
	, @Pourcent_Sec
	, @KgSec_Paye
	, @Validation
	, @Transfert
	, @EssenceID
	, @UniteID
	, @Code
	, @TransporteurID
	, @BonCommande
)

Set NoCount Off

Return(0)


