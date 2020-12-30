
CREATE Procedure [spU_Lot]

-- Update an existing record in [Lot] table

(
  @CantonID [varchar](6) = Null -- for [Lot].[CantonID] column
, @ConsiderNull_CantonID bit = 0
, @Rang [varchar](25) = Null -- for [Lot].[Rang] column
, @ConsiderNull_Rang bit = 0
, @Lot [varchar](6) = Null -- for [Lot].[Lot] column
, @ConsiderNull_Lot bit = 0
, @MunicipaliteID [varchar](6) = Null -- for [Lot].[MunicipaliteID] column
, @ConsiderNull_MunicipaliteID bit = 0
, @Superficie_total [real] = Null -- for [Lot].[Superficie_total] column
, @ConsiderNull_Superficie_total bit = 0
, @Superficie_boisee [real] = Null -- for [Lot].[Superficie_boisee] column
, @ConsiderNull_Superficie_boisee bit = 0
, @ProprietaireID [varchar](15) = Null -- for [Lot].[ProprietaireID] column
, @ConsiderNull_ProprietaireID bit = 0
, @ContingentID [varchar](15) = Null -- for [Lot].[ContingentID] column
, @ConsiderNull_ContingentID bit = 0
, @Contingent_Date [smalldatetime] = Null -- for [Lot].[Contingent_Date] column
, @ConsiderNull_Contingent_Date bit = 0
, @Droit_coupeID [varchar](15) = Null -- for [Lot].[Droit_coupeID] column
, @ConsiderNull_Droit_coupeID bit = 0
, @Droit_coupe_Date [smalldatetime] = Null -- for [Lot].[Droit_coupe_Date] column
, @ConsiderNull_Droit_coupe_Date bit = 0
, @Entente_paiementID [varchar](15) = Null -- for [Lot].[Entente_paiementID] column
, @ConsiderNull_Entente_paiementID bit = 0
, @Entente_paiement_Date [smalldatetime] = Null -- for [Lot].[Entente_paiement_Date] column
, @ConsiderNull_Entente_paiement_Date bit = 0
, @Actif [bit] = Null -- for [Lot].[Actif] column
, @ConsiderNull_Actif bit = 0
, @ID [int] -- for [Lot].[ID] column
, @Sequence [varchar](6) = Null -- for [Lot].[Sequence] column
, @ConsiderNull_Sequence bit = 0
, @Partie [bit] = Null -- for [Lot].[Partie] column
, @ConsiderNull_Partie bit = 0
, @Matricule [varchar](20) = Null -- for [Lot].[Matricule] column
, @ConsiderNull_Matricule bit = 0
, @ZoneID [varchar](2) = Null -- for [Lot].[ZoneID] column
, @ConsiderNull_ZoneID bit = 0
, @Secteur [varchar](2) = Null -- for [Lot].[Secteur] column
, @ConsiderNull_Secteur bit = 0
, @Cadastre [int] = Null -- for [Lot].[Cadastre] column
, @ConsiderNull_Cadastre bit = 0
, @Reforme [bit] = Null -- for [Lot].[Reforme] column
, @ConsiderNull_Reforme bit = 0
, @LotsComplementaires [varchar](255) = Null -- for [Lot].[LotsComplementaires] column
, @ConsiderNull_LotsComplementaires bit = 0
, @Certifie [bit] = Null -- for [Lot].[Certifie] column
, @ConsiderNull_Certifie bit = 0
, @NumeroCertification [varchar](50) = Null -- for [Lot].[NumeroCertification] column
, @ConsiderNull_NumeroCertification bit = 0
, @OGC [bit] = Null -- for [Lot].[OGC] column
, @ConsiderNull_OGC bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_CantonID Is Null
	Set @ConsiderNull_CantonID = 0

If @ConsiderNull_Rang Is Null
	Set @ConsiderNull_Rang = 0

If @ConsiderNull_Lot Is Null
	Set @ConsiderNull_Lot = 0

If @ConsiderNull_MunicipaliteID Is Null
	Set @ConsiderNull_MunicipaliteID = 0

If @ConsiderNull_Superficie_total Is Null
	Set @ConsiderNull_Superficie_total = 0

If @ConsiderNull_Superficie_boisee Is Null
	Set @ConsiderNull_Superficie_boisee = 0

If @ConsiderNull_ProprietaireID Is Null
	Set @ConsiderNull_ProprietaireID = 0

If @ConsiderNull_ContingentID Is Null
	Set @ConsiderNull_ContingentID = 0

If @ConsiderNull_Contingent_Date Is Null
	Set @ConsiderNull_Contingent_Date = 0

If @ConsiderNull_Droit_coupeID Is Null
	Set @ConsiderNull_Droit_coupeID = 0

If @ConsiderNull_Droit_coupe_Date Is Null
	Set @ConsiderNull_Droit_coupe_Date = 0

If @ConsiderNull_Entente_paiementID Is Null
	Set @ConsiderNull_Entente_paiementID = 0

If @ConsiderNull_Entente_paiement_Date Is Null
	Set @ConsiderNull_Entente_paiement_Date = 0

If @ConsiderNull_Actif Is Null
	Set @ConsiderNull_Actif = 0

If @ConsiderNull_Sequence Is Null
	Set @ConsiderNull_Sequence = 0

If @ConsiderNull_Partie Is Null
	Set @ConsiderNull_Partie = 0

If @ConsiderNull_Matricule Is Null
	Set @ConsiderNull_Matricule = 0

If @ConsiderNull_ZoneID Is Null
	Set @ConsiderNull_ZoneID = 0

If @ConsiderNull_Secteur Is Null
	Set @ConsiderNull_Secteur = 0

If @ConsiderNull_Cadastre Is Null
	Set @ConsiderNull_Cadastre = 0

If @ConsiderNull_Reforme Is Null
	Set @ConsiderNull_Reforme = 0

If @ConsiderNull_LotsComplementaires Is Null
	Set @ConsiderNull_LotsComplementaires = 0

If @ConsiderNull_Certifie Is Null
	Set @ConsiderNull_Certifie = 0

If @ConsiderNull_NumeroCertification Is Null
	Set @ConsiderNull_NumeroCertification = 0

If @ConsiderNull_OGC Is Null
	Set @ConsiderNull_OGC = 0


Update [dbo].[Lot]

Set
	 [CantonID] = Case @ConsiderNull_CantonID When 0 Then IsNull(@CantonID, [CantonID]) When 1 Then @CantonID End
	,[Rang] = Case @ConsiderNull_Rang When 0 Then IsNull(@Rang, [Rang]) When 1 Then @Rang End
	,[Lot] = Case @ConsiderNull_Lot When 0 Then IsNull(@Lot, [Lot]) When 1 Then @Lot End
	,[MunicipaliteID] = Case @ConsiderNull_MunicipaliteID When 0 Then IsNull(@MunicipaliteID, [MunicipaliteID]) When 1 Then @MunicipaliteID End
	,[Superficie_total] = Case @ConsiderNull_Superficie_total When 0 Then IsNull(@Superficie_total, [Superficie_total]) When 1 Then @Superficie_total End
	,[Superficie_boisee] = Case @ConsiderNull_Superficie_boisee When 0 Then IsNull(@Superficie_boisee, [Superficie_boisee]) When 1 Then @Superficie_boisee End
	,[ProprietaireID] = Case @ConsiderNull_ProprietaireID When 0 Then IsNull(@ProprietaireID, [ProprietaireID]) When 1 Then @ProprietaireID End
	,[ContingentID] = Case @ConsiderNull_ContingentID When 0 Then IsNull(@ContingentID, [ContingentID]) When 1 Then @ContingentID End
	,[Contingent_Date] = Case @ConsiderNull_Contingent_Date When 0 Then IsNull(@Contingent_Date, [Contingent_Date]) When 1 Then @Contingent_Date End
	,[Droit_coupeID] = Case @ConsiderNull_Droit_coupeID When 0 Then IsNull(@Droit_coupeID, [Droit_coupeID]) When 1 Then @Droit_coupeID End
	,[Droit_coupe_Date] = Case @ConsiderNull_Droit_coupe_Date When 0 Then IsNull(@Droit_coupe_Date, [Droit_coupe_Date]) When 1 Then @Droit_coupe_Date End
	,[Entente_paiementID] = Case @ConsiderNull_Entente_paiementID When 0 Then IsNull(@Entente_paiementID, [Entente_paiementID]) When 1 Then @Entente_paiementID End
	,[Entente_paiement_Date] = Case @ConsiderNull_Entente_paiement_Date When 0 Then IsNull(@Entente_paiement_Date, [Entente_paiement_Date]) When 1 Then @Entente_paiement_Date End
	,[Actif] = Case @ConsiderNull_Actif When 0 Then IsNull(@Actif, [Actif]) When 1 Then @Actif End
	,[Sequence] = Case @ConsiderNull_Sequence When 0 Then IsNull(@Sequence, [Sequence]) When 1 Then @Sequence End
	,[Partie] = Case @ConsiderNull_Partie When 0 Then IsNull(@Partie, [Partie]) When 1 Then @Partie End
	,[Matricule] = Case @ConsiderNull_Matricule When 0 Then IsNull(@Matricule, [Matricule]) When 1 Then @Matricule End
	,[ZoneID] = Case @ConsiderNull_ZoneID When 0 Then IsNull(@ZoneID, [ZoneID]) When 1 Then @ZoneID End
	,[Secteur] = Case @ConsiderNull_Secteur When 0 Then IsNull(@Secteur, [Secteur]) When 1 Then @Secteur End
	,[Cadastre] = Case @ConsiderNull_Cadastre When 0 Then IsNull(@Cadastre, [Cadastre]) When 1 Then @Cadastre End
	,[Reforme] = Case @ConsiderNull_Reforme When 0 Then IsNull(@Reforme, [Reforme]) When 1 Then @Reforme End
	,[LotsComplementaires] = Case @ConsiderNull_LotsComplementaires When 0 Then IsNull(@LotsComplementaires, [LotsComplementaires]) When 1 Then @LotsComplementaires End
	,[Certifie] = Case @ConsiderNull_Certifie When 0 Then IsNull(@Certifie, [Certifie]) When 1 Then @Certifie End
	,[NumeroCertification] = Case @ConsiderNull_NumeroCertification When 0 Then IsNull(@NumeroCertification, [NumeroCertification]) When 1 Then @NumeroCertification End
	,[OGC] = Case @ConsiderNull_OGC When 0 Then IsNull(@OGC, [OGC]) When 1 Then @OGC End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)

