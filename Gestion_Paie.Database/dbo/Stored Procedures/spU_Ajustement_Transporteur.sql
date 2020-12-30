

Create Procedure [spU_Ajustement_Transporteur]

-- Update an existing record in [Ajustement_Transporteur] table

(
  @AjustementID [int] -- for [Ajustement_Transporteur].[AjustementID] column
, @UniteID [varchar](6) -- for [Ajustement_Transporteur].[UniteID] column
, @MunicipaliteID [varchar](6) -- for [Ajustement_Transporteur].[MunicipaliteID] column
, @ContratID [varchar](10) -- for [Ajustement_Transporteur].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @Taux_transporteur [real] = Null -- for [Ajustement_Transporteur].[Taux_transporteur] column
, @ConsiderNull_Taux_transporteur bit = 0
, @Date_Modification [datetime] = Null -- for [Ajustement_Transporteur].[Date_Modification] column
, @ConsiderNull_Date_Modification bit = 0
, @ZoneID [varchar](2) -- for [Ajustement_Transporteur].[ZoneID] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_Taux_transporteur Is Null
	Set @ConsiderNull_Taux_transporteur = 0

If @ConsiderNull_Date_Modification Is Null
	Set @ConsiderNull_Date_Modification = 0


Update [dbo].[Ajustement_Transporteur]

Set
	 [ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[Taux_transporteur] = Case @ConsiderNull_Taux_transporteur When 0 Then IsNull(@Taux_transporteur, [Taux_transporteur]) When 1 Then @Taux_transporteur End
	,[Date_Modification] = Case @ConsiderNull_Date_Modification When 0 Then IsNull(@Date_Modification, [Date_Modification]) When 1 Then @Date_Modification End

Where
	     ([AjustementID] = @AjustementID)
	And ([UniteID] = @UniteID)
	And ([MunicipaliteID] = @MunicipaliteID)
	And ([ZoneID] = @ZoneID)

Set NoCount Off

Return(0)


