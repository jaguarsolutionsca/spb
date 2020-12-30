CREATE PROCEDURE [dbo].[spU_Cert_Proprietaire]
@Agence VARCHAR (10), @NO_ACT VARCHAR (10), @Nom VARCHAR (50)=Null, @ConsiderNull_Nom BIT=0, @Representant VARCHAR (35)=Null, @ConsiderNull_Representant BIT=0, @ADRESSE VARCHAR (50)=Null, @ConsiderNull_ADRESSE BIT=0, @Ville VARCHAR (50)=Null, @ConsiderNull_Ville BIT=0, @CODE_POST VARCHAR (25)=Null, @ConsiderNull_CODE_POST BIT=0, @TEL_RES VARCHAR (25)=Null, @ConsiderNull_TEL_RES BIT=0, @TEL_BUR VARCHAR (25)=Null, @ConsiderNull_TEL_BUR BIT=0, @FournisseurID VARCHAR (15)=Null, @ConsiderNull_FournisseurID BIT=0, @FournisseurNom VARCHAR (40)=Null, @ConsiderNull_FournisseurNom BIT=0, @Traite BIT=Null, @ConsiderNull_Traite BIT=0, @Methode VARCHAR (25)=Null, @ConsiderNull_Methode BIT=0
AS
Set NoCount On

If @ConsiderNull_Nom Is Null
	Set @ConsiderNull_Nom = 0

If @ConsiderNull_Representant Is Null
	Set @ConsiderNull_Representant = 0

If @ConsiderNull_ADRESSE Is Null
	Set @ConsiderNull_ADRESSE = 0

If @ConsiderNull_Ville Is Null
	Set @ConsiderNull_Ville = 0

If @ConsiderNull_CODE_POST Is Null
	Set @ConsiderNull_CODE_POST = 0

If @ConsiderNull_TEL_RES Is Null
	Set @ConsiderNull_TEL_RES = 0

If @ConsiderNull_TEL_BUR Is Null
	Set @ConsiderNull_TEL_BUR = 0

If @ConsiderNull_FournisseurID Is Null
	Set @ConsiderNull_FournisseurID = 0

If @ConsiderNull_FournisseurNom Is Null
	Set @ConsiderNull_FournisseurNom = 0

If @ConsiderNull_Traite Is Null
	Set @ConsiderNull_Traite = 0

If @ConsiderNull_Methode Is Null
	Set @ConsiderNull_Methode = 0


Update [dbo].[Cert_Proprietaire]

Set
	 [Nom] = Case @ConsiderNull_Nom When 0 Then IsNull(@Nom, [Nom]) When 1 Then @Nom End
	,[Representant] = Case @ConsiderNull_Representant When 0 Then IsNull(@Representant, [Representant]) When 1 Then @Representant End
	,[ADRESSE] = Case @ConsiderNull_ADRESSE When 0 Then IsNull(@ADRESSE, [ADRESSE]) When 1 Then @ADRESSE End
	,[Ville] = Case @ConsiderNull_Ville When 0 Then IsNull(@Ville, [Ville]) When 1 Then @Ville End
	,[CODE_POST] = Case @ConsiderNull_CODE_POST When 0 Then IsNull(@CODE_POST, [CODE_POST]) When 1 Then @CODE_POST End
	,[TEL_RES] = Case @ConsiderNull_TEL_RES When 0 Then IsNull(@TEL_RES, [TEL_RES]) When 1 Then @TEL_RES End
	,[TEL_BUR] = Case @ConsiderNull_TEL_BUR When 0 Then IsNull(@TEL_BUR, [TEL_BUR]) When 1 Then @TEL_BUR End
	,[FournisseurID] = Case @ConsiderNull_FournisseurID When 0 Then IsNull(@FournisseurID, [FournisseurID]) When 1 Then @FournisseurID End
	,[FournisseurNom] = Case @ConsiderNull_FournisseurNom When 0 Then IsNull(@FournisseurNom, [FournisseurNom]) When 1 Then @FournisseurNom End
	,[Traite] = Case @ConsiderNull_Traite When 0 Then IsNull(@Traite, [Traite]) When 1 Then @Traite End
	,[Methode] = Case @ConsiderNull_Methode When 0 Then IsNull(@Methode, [Methode]) When 1 Then @Methode End

Where
	     ([Agence] = @Agence)
	And ([NO_ACT] = @NO_ACT)

Set NoCount Off

Return(0)


