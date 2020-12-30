

Create Procedure [spU_Contrat_EssenceUnite]

-- Update an existing record in [Contrat_EssenceUnite] table

(
  @ContratID [varchar](10) -- for [Contrat_EssenceUnite].[ContratID] column
, @EssenceID [varchar](6) -- for [Contrat_EssenceUnite].[EssenceID] column
, @UniteID [varchar](6) -- for [Contrat_EssenceUnite].[UniteID] column
, @Code [char](4) -- for [Contrat_EssenceUnite].[Code] column
, @Quantite_prevue [float] = Null -- for [Contrat_EssenceUnite].[Quantite_prevue] column
, @ConsiderNull_Quantite_prevue bit = 0
, @Taux_usine [float] = Null -- for [Contrat_EssenceUnite].[Taux_usine] column
, @ConsiderNull_Taux_usine bit = 0
, @Taux_producteur [real] = Null -- for [Contrat_EssenceUnite].[Taux_producteur] column
, @ConsiderNull_Taux_producteur bit = 0
, @Actif [bit] = Null -- for [Contrat_EssenceUnite].[Actif] column
, @ConsiderNull_Actif bit = 0
, @Description [varchar](50) = Null -- for [Contrat_EssenceUnite].[Description] column
, @ConsiderNull_Description bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Quantite_prevue Is Null
	Set @ConsiderNull_Quantite_prevue = 0

If @ConsiderNull_Taux_usine Is Null
	Set @ConsiderNull_Taux_usine = 0

If @ConsiderNull_Taux_producteur Is Null
	Set @ConsiderNull_Taux_producteur = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0

If @ConsiderNull_Description Is Null
	Set @ConsiderNull_Description = 0


Update [dbo].[Contrat_EssenceUnite]

Set
	 [Quantite_prevue] = Case @ConsiderNull_Quantite_prevue When 0 Then IsNull(@Quantite_prevue, [Quantite_prevue]) When 1 Then @Quantite_prevue End
	,[Taux_usine] = Case @ConsiderNull_Taux_usine When 0 Then IsNull(@Taux_usine, [Taux_usine]) When 1 Then @Taux_usine End
	,[Taux_producteur] = Case @ConsiderNull_Taux_producteur When 0 Then IsNull(@Taux_producteur, [Taux_producteur]) When 1 Then @Taux_producteur End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End
	,[Description] = Case @ConsiderNull_Description When 0 Then IsNull(@Description, [Description]) When 1 Then @Description End

Where
	     ([ContratID] = @ContratID)
	And ([EssenceID] = @EssenceID)
	And ([UniteID] = @UniteID)
	And ([Code] = @Code)

Set NoCount Off

Return(0)


