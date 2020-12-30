

Create Procedure [spU_Contrat_Transporteur]

-- Update an existing record in [Contrat_Transporteur] table

(
  @ContratID [varchar](10) -- for [Contrat_Transporteur].[ContratID] column
, @UniteID [varchar](6) -- for [Contrat_Transporteur].[UniteID] column
, @MunicipaliteID [varchar](6) -- for [Contrat_Transporteur].[MunicipaliteID] column
, @Taux_transporteur [real] = Null -- for [Contrat_Transporteur].[Taux_transporteur] column
, @ConsiderNull_Taux_transporteur bit = 0
, @Taux_producteur [real] = Null -- for [Contrat_Transporteur].[Taux_producteur] column
, @ConsiderNull_Taux_producteur bit = 0
, @Actif [bit] = Null -- for [Contrat_Transporteur].[Actif] column
, @ConsiderNull_Actif bit = 0
, @ZoneID [varchar](2) -- for [Contrat_Transporteur].[ZoneID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_Taux_transporteur Is Null
	Set @ConsiderNull_Taux_transporteur = 0

If @ConsiderNull_Taux_producteur Is Null
	Set @ConsiderNull_Taux_producteur = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0


Update [dbo].[Contrat_Transporteur]

Set
	 [Taux_transporteur] = Case @ConsiderNull_Taux_transporteur When 0 Then IsNull(@Taux_transporteur, [Taux_transporteur]) When 1 Then @Taux_transporteur End
	,[Taux_producteur] = Case @ConsiderNull_Taux_producteur When 0 Then IsNull(@Taux_producteur, [Taux_producteur]) When 1 Then @Taux_producteur End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End

Where
	     ([ContratID] = @ContratID)
	And ([UniteID] = @UniteID)
	And ([MunicipaliteID] = @MunicipaliteID)
	And ([ZoneID] = @ZoneID)

Set NoCount Off

Return(0)


