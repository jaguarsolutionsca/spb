CREATE PROCEDURE [dbo].[spU_Contingentement_Producteur]
@ContingentementID INT, @ProducteurID VARCHAR (15), @Superficie_Contingentee REAL=Null, @ConsiderNull_Superficie_Contingentee BIT=0, @Volume_Demande REAL=Null, @ConsiderNull_Volume_Demande BIT=0, @Volume_Facteur REAL=Null, @ConsiderNull_Volume_Facteur BIT=0, @Volume_Fixe REAL=Null, @ConsiderNull_Volume_Fixe BIT=0, @Volume_Supplementaire REAL=Null, @ConsiderNull_Volume_Supplementaire BIT=0, @Volume_Accorde REAL=Null, @ConsiderNull_Volume_Accorde BIT=0, @Date_Modification DATETIME=Null, @ConsiderNull_Date_Modification BIT=0, @Volume_Inventaire REAL=Null, @ConsiderNull_Volume_Inventaire BIT=0, @LastLivraison SMALLDATETIME=Null, @ConsiderNull_LastLivraison BIT=0, @VolumeMaximum REAL=Null, @ConsiderNull_VolumeMaximum BIT=0, @Imprime BIT, @ConsiderNull_Imprime BIT=0
AS
Set NoCount On

If @ConsiderNull_Superficie_Contingentee Is Null
	Set @ConsiderNull_Superficie_Contingentee = 0

If @ConsiderNull_Volume_Demande Is Null
	Set @ConsiderNull_Volume_Demande = 0

If @ConsiderNull_Volume_Facteur Is Null
	Set @ConsiderNull_Volume_Facteur = 0

If @ConsiderNull_Volume_Fixe Is Null
	Set @ConsiderNull_Volume_Fixe = 0

If @ConsiderNull_Volume_Supplementaire Is Null
	Set @ConsiderNull_Volume_Supplementaire = 0

If @ConsiderNull_Volume_Accorde Is Null
	Set @ConsiderNull_Volume_Accorde = 0

If @ConsiderNull_Date_Modification Is Null
	Set @ConsiderNull_Date_Modification = 0

If @ConsiderNull_Volume_Inventaire Is Null
	Set @ConsiderNull_Volume_Inventaire = 0

If @ConsiderNull_LastLivraison Is Null
	Set @ConsiderNull_LastLivraison = 0

If @ConsiderNull_VolumeMaximum Is Null
	Set @ConsiderNull_VolumeMaximum = 0

If @ConsiderNull_Imprime Is Null
	Set @ConsiderNull_Imprime = 0


Update [dbo].[Contingentement_Producteur]

Set
	 [Superficie_Contingentee] = Case @ConsiderNull_Superficie_Contingentee When 0 Then IsNull(@Superficie_Contingentee, [Superficie_Contingentee]) When 1 Then @Superficie_Contingentee End
	,[Volume_Demande] = Case @ConsiderNull_Volume_Demande When 0 Then IsNull(@Volume_Demande, [Volume_Demande]) When 1 Then @Volume_Demande End
	,[Volume_Facteur] = Case @ConsiderNull_Volume_Facteur When 0 Then IsNull(@Volume_Facteur, [Volume_Facteur]) When 1 Then @Volume_Facteur End
	,[Volume_Fixe] = Case @ConsiderNull_Volume_Fixe When 0 Then IsNull(@Volume_Fixe, [Volume_Fixe]) When 1 Then @Volume_Fixe End
	,[Volume_Supplementaire] = Case @ConsiderNull_Volume_Supplementaire When 0 Then IsNull(@Volume_Supplementaire, [Volume_Supplementaire]) When 1 Then @Volume_Supplementaire End
	,[Volume_Accorde] = Case @ConsiderNull_Volume_Accorde When 0 Then IsNull(@Volume_Accorde, [Volume_Accorde]) When 1 Then @Volume_Accorde End
	,[Date_Modification] = Case @ConsiderNull_Date_Modification When 0 Then IsNull(@Date_Modification, [Date_Modification]) When 1 Then @Date_Modification End
	,[Volume_Inventaire] = Case @ConsiderNull_Volume_Inventaire When 0 Then IsNull(@Volume_Inventaire, [Volume_Inventaire]) When 1 Then @Volume_Inventaire End
	,[LastLivraison] = Case @ConsiderNull_LastLivraison When 0 Then IsNull(@LastLivraison, [LastLivraison]) When 1 Then @LastLivraison End
	,[VolumeMaximum] = Case @ConsiderNull_VolumeMaximum When 0 Then IsNull(@VolumeMaximum, [VolumeMaximum]) When 1 Then @VolumeMaximum End
	,[Imprime] = Case @ConsiderNull_Imprime When 0 Then IsNull(@Imprime, [Imprime]) When 1 Then @Imprime End

Where
	     ([ContingentementID] = @ContingentementID)
	And ([ProducteurID] = @ProducteurID)

Set NoCount Off

Return(0)


