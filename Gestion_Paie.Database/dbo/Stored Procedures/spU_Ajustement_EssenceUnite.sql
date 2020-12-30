CREATE Procedure [dbo].[spU_Ajustement_EssenceUnite]

-- Update an existing record in [Ajustement_EssenceUnite] table

(
  @AjustementID [int] -- for [Ajustement_EssenceUnite].[AjustementID] column
, @EssenceID [varchar](6) -- for [Ajustement_EssenceUnite].[EssenceID] column
, @UniteID [varchar](6) -- for [Ajustement_EssenceUnite].[UniteID] column
, @ContratID [varchar](10) -- for [Ajustement_EssenceUnite].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @Taux_usine [real] = Null -- for [Ajustement_EssenceUnite].[Taux_usine] column
, @ConsiderNull_Taux_usine bit = 0
, @Taux_producteur [real] = Null -- for [Ajustement_EssenceUnite].[Taux_producteur] column
, @ConsiderNull_Taux_producteur bit = 0
, @Taux_transporteur [real] = Null -- for [Ajustement_EssenceUnite].[Taux_transporteur] column
, @ConsiderNull_Taux_transporteur bit = 0
, @Date_Modification [datetime] = Null -- for [Ajustement_EssenceUnite].[Date_Modification] column
, @ConsiderNull_Date_Modification bit = 0
, @Code [char](4) -- for [Ajustement_EssenceUnite].[Code] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_Taux_usine Is Null
	Set @ConsiderNull_Taux_usine = 0

If @ConsiderNull_Taux_producteur Is Null
	Set @ConsiderNull_Taux_producteur = 0

If @ConsiderNull_Taux_transporteur Is Null
	Set @ConsiderNull_Taux_transporteur = 0

If @ConsiderNull_Date_Modification Is Null
	Set @ConsiderNull_Date_Modification = 0


Update [dbo].[Ajustement_EssenceUnite]

Set
	 [ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[Taux_usine] = Case @ConsiderNull_Taux_usine When 0 Then IsNull(@Taux_usine, [Taux_usine]) When 1 Then @Taux_usine End
	,[Taux_producteur] = Case @ConsiderNull_Taux_producteur When 0 Then IsNull(@Taux_producteur, [Taux_producteur]) When 1 Then @Taux_producteur End
	,[Taux_transporteur] = Case @ConsiderNull_Taux_transporteur When 0 Then IsNull(@Taux_transporteur, [Taux_transporteur]) When 1 Then @Taux_transporteur End
	,[Date_Modification] = Case @ConsiderNull_Date_Modification When 0 Then IsNull(@Date_Modification, [Date_Modification]) When 1 Then @Date_Modification End

Where
	     ([AjustementID] = @AjustementID)
	And ([EssenceID] = @EssenceID)
	And ([UniteID] = @UniteID)
	And ([Code] = @Code)

Set NoCount Off

Return(0)
