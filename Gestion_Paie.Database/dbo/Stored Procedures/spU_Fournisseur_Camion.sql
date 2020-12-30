

Create Procedure [spU_Fournisseur_Camion]

-- Update an existing record in [Fournisseur_Camion] table

(
  @FournisseurID [varchar](15) -- for [Fournisseur_Camion].[FournisseurID] column
, @VR [varchar](10) -- for [Fournisseur_Camion].[VR] column
, @MasseLimite [float] = Null -- for [Fournisseur_Camion].[MasseLimite] column
, @ConsiderNull_MasseLimite bit = 0
, @Actif [bit] = Null -- for [Fournisseur_Camion].[Actif] column
, @ConsiderNull_Actif bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_MasseLimite Is Null
	Set @ConsiderNull_MasseLimite = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[Fournisseur_Camion]

Set
	 [MasseLimite] = Case @ConsiderNull_MasseLimite When 0 Then IsNull(@MasseLimite, [MasseLimite]) When 1 Then @MasseLimite End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([FournisseurID] = @FournisseurID)
	And ([VR] = @VR)

Set NoCount Off

Return(0)


