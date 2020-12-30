CREATE PROCEDURE [dbo].[spU_FeuilletDomtar]
@Transaction VARCHAR (15), @TransactionType VARCHAR (3)=Null, @ConsiderNull_TransactionType BIT=0, @Fournisseur VARCHAR (15)=Null, @ConsiderNull_Fournisseur BIT=0, @Contrat VARCHAR (25)=Null, @ConsiderNull_Contrat BIT=0, @Produit VARCHAR (10)=Null, @ConsiderNull_Produit BIT=0, @DateLivraison SMALLDATETIME=Null, @ConsiderNull_DateLivraison BIT=0, @Carte VARCHAR (15)=Null, @ConsiderNull_Carte BIT=0, @License VARCHAR (15)=Null, @ConsiderNull_License BIT=0, @Transporteur_Camion VARCHAR (15)=Null, @ConsiderNull_Transporteur_Camion BIT=0, @Producteur VARCHAR (15)=Null, @ConsiderNull_Producteur BIT=0, @Municipalite VARCHAR (15)=Null, @ConsiderNull_Municipalite BIT=0, @Brut INT=Null, @ConsiderNull_Brut BIT=0, @Tare INT=Null, @ConsiderNull_Tare BIT=0, @Net INT=Null, @ConsiderNull_Net BIT=0, @Rejets INT=Null, @ConsiderNull_Rejets BIT=0, @KgVert_Paye INT=Null, @ConsiderNull_KgVert_Paye BIT=0, @Pourcent_Sec FLOAT=Null, @ConsiderNull_Pourcent_Sec BIT=0, @KgSec_Paye INT=Null, @ConsiderNull_KgSec_Paye BIT=0, @Validation VARCHAR (255)=Null, @ConsiderNull_Validation BIT=0, @Transfert BIT, @ConsiderNull_Transfert BIT=0, @EssenceID VARCHAR (6)=Null, @ConsiderNull_EssenceID BIT=0, @UniteID VARCHAR (6)=Null, @ConsiderNull_UniteID BIT=0, @Code CHAR (4)=Null, @ConsiderNull_Code BIT=0, @TransporteurID VARCHAR (15)=Null, @ConsiderNull_TransporteurID BIT=0, @BonCommande VARCHAR (25)=Null, @ConsiderNull_BonCommande BIT=0
AS
Set NoCount On

If @ConsiderNull_TransactionType Is Null
	Set @ConsiderNull_TransactionType = 0

If @ConsiderNull_Fournisseur Is Null
	Set @ConsiderNull_Fournisseur = 0

If @ConsiderNull_Contrat Is Null
	Set @ConsiderNull_Contrat = 0

If @ConsiderNull_Produit Is Null
	Set @ConsiderNull_Produit = 0

If @ConsiderNull_DateLivraison Is Null
	Set @ConsiderNull_DateLivraison = 0

If @ConsiderNull_Carte Is Null
	Set @ConsiderNull_Carte = 0

If @ConsiderNull_License Is Null
	Set @ConsiderNull_License = 0

If @ConsiderNull_Transporteur_Camion Is Null
	Set @ConsiderNull_Transporteur_Camion = 0

If @ConsiderNull_Producteur Is Null
	Set @ConsiderNull_Producteur = 0

If @ConsiderNull_Municipalite Is Null
	Set @ConsiderNull_Municipalite = 0

If @ConsiderNull_Brut Is Null
	Set @ConsiderNull_Brut = 0

If @ConsiderNull_Tare Is Null
	Set @ConsiderNull_Tare = 0

If @ConsiderNull_Net Is Null
	Set @ConsiderNull_Net = 0

If @ConsiderNull_Rejets Is Null
	Set @ConsiderNull_Rejets = 0

If @ConsiderNull_KgVert_Paye Is Null
	Set @ConsiderNull_KgVert_Paye = 0

If @ConsiderNull_Pourcent_Sec Is Null
	Set @ConsiderNull_Pourcent_Sec = 0

If @ConsiderNull_KgSec_Paye Is Null
	Set @ConsiderNull_KgSec_Paye = 0

If @ConsiderNull_Validation Is Null
	Set @ConsiderNull_Validation = 0

If @ConsiderNull_Transfert Is Null
	Set @ConsiderNull_Transfert = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_UniteID Is Null
	Set @ConsiderNull_UniteID = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0

If @ConsiderNull_TransporteurID Is Null
	Set @ConsiderNull_TransporteurID = 0

If @ConsiderNull_BonCommande Is Null
	Set @ConsiderNull_BonCommande = 0


Update [dbo].[FeuilletDomtar]

Set
	 [TransactionType] = Case @ConsiderNull_TransactionType When 0 Then IsNull(@TransactionType, [TransactionType]) When 1 Then @TransactionType End
	,[Fournisseur] = Case @ConsiderNull_Fournisseur When 0 Then IsNull(@Fournisseur, [Fournisseur]) When 1 Then @Fournisseur End
	,[Contrat] = Case @ConsiderNull_Contrat When 0 Then IsNull(@Contrat, [Contrat]) When 1 Then @Contrat End
	,[Produit] = Case @ConsiderNull_Produit When 0 Then IsNull(@Produit, [Produit]) When 1 Then @Produit End
	,[DateLivraison] = Case @ConsiderNull_DateLivraison When 0 Then IsNull(@DateLivraison, [DateLivraison]) When 1 Then @DateLivraison End
	,[Carte] = Case @ConsiderNull_Carte When 0 Then IsNull(@Carte, [Carte]) When 1 Then @Carte End
	,[License] = Case @ConsiderNull_License When 0 Then IsNull(@License, [License]) When 1 Then @License End
	,[Transporteur_Camion] = Case @ConsiderNull_Transporteur_Camion When 0 Then IsNull(@Transporteur_Camion, [Transporteur_Camion]) When 1 Then @Transporteur_Camion End
	,[Producteur] = Case @ConsiderNull_Producteur When 0 Then IsNull(@Producteur, [Producteur]) When 1 Then @Producteur End
	,[Municipalite] = Case @ConsiderNull_Municipalite When 0 Then IsNull(@Municipalite, [Municipalite]) When 1 Then @Municipalite End
	,[Brut] = Case @ConsiderNull_Brut When 0 Then IsNull(@Brut, [Brut]) When 1 Then @Brut End
	,[Tare] = Case @ConsiderNull_Tare When 0 Then IsNull(@Tare, [Tare]) When 1 Then @Tare End
	,[Net] = Case @ConsiderNull_Net When 0 Then IsNull(@Net, [Net]) When 1 Then @Net End
	,[Rejets] = Case @ConsiderNull_Rejets When 0 Then IsNull(@Rejets, [Rejets]) When 1 Then @Rejets End
	,[KgVert_Paye] = Case @ConsiderNull_KgVert_Paye When 0 Then IsNull(@KgVert_Paye, [KgVert_Paye]) When 1 Then @KgVert_Paye End
	,[Pourcent_Sec] = Case @ConsiderNull_Pourcent_Sec When 0 Then IsNull(@Pourcent_Sec, [Pourcent_Sec]) When 1 Then @Pourcent_Sec End
	,[KgSec_Paye] = Case @ConsiderNull_KgSec_Paye When 0 Then IsNull(@KgSec_Paye, [KgSec_Paye]) When 1 Then @KgSec_Paye End
	,[Validation] = Case @ConsiderNull_Validation When 0 Then IsNull(@Validation, [Validation]) When 1 Then @Validation End
	,[Transfert] = Case @ConsiderNull_Transfert When 0 Then IsNull(@Transfert, [Transfert]) When 1 Then @Transfert End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[UniteID] = Case @ConsiderNull_UniteID When 0 Then IsNull(@UniteID, [UniteID]) When 1 Then @UniteID End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End
	,[TransporteurID] = Case @ConsiderNull_TransporteurID When 0 Then IsNull(@TransporteurID, [TransporteurID]) When 1 Then @TransporteurID End
	,[BonCommande] = Case @ConsiderNull_BonCommande When 0 Then IsNull(@BonCommande, [BonCommande]) When 1 Then @BonCommande End

Where
	     ([Transaction] = @Transaction)

Set NoCount Off

Return(0)


