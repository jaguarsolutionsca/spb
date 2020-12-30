
CREATE Procedure [spU_Contingentement]

-- Update an existing record in [Contingentement] table

(
  @ID [int] -- for [Contingentement].[ID] column
, @ContingentUsine [bit] = Null -- for [Contingentement].[ContingentUsine] column
, @ConsiderNull_ContingentUsine bit = 0
, @UsineID [varchar](6) = Null -- for [Contingentement].[UsineID] column
, @ConsiderNull_UsineID bit = 0
, @RegroupementID [int] = Null -- for [Contingentement].[RegroupementID] column
, @ConsiderNull_RegroupementID bit = 0
, @Annee [int] = Null -- for [Contingentement].[Annee] column
, @ConsiderNull_Annee bit = 0
, @PeriodeContingentement [int] = Null -- for [Contingentement].[PeriodeContingentement] column
, @ConsiderNull_PeriodeContingentement bit = 0
, @PeriodeDebut [int] = Null -- for [Contingentement].[PeriodeDebut] column
, @ConsiderNull_PeriodeDebut bit = 0
, @PeriodeFin [int] = Null -- for [Contingentement].[PeriodeFin] column
, @ConsiderNull_PeriodeFin bit = 0
, @EssenceID [varchar](6) = Null -- for [Contingentement].[EssenceID] column
, @ConsiderNull_EssenceID bit = 0
, @UniteMesureID [varchar](6) = Null -- for [Contingentement].[UniteMesureID] column
, @ConsiderNull_UniteMesureID bit = 0
, @Volume_Usine [real] = Null -- for [Contingentement].[Volume_Usine] column
, @ConsiderNull_Volume_Usine bit = 0
, @Facteur [real] = Null -- for [Contingentement].[Facteur] column
, @ConsiderNull_Facteur bit = 0
, @Volume_Fixe [real] = Null -- for [Contingentement].[Volume_Fixe] column
, @ConsiderNull_Volume_Fixe bit = 0
, @Date_Calcul [datetime] = Null -- for [Contingentement].[Date_Calcul] column
, @ConsiderNull_Date_Calcul bit = 0
, @CalculAccepte [bit] = Null -- for [Contingentement].[CalculAccepte] column
, @ConsiderNull_CalculAccepte bit = 0
, @Code [char](4) = Null -- for [Contingentement].[Code] column
, @ConsiderNull_Code bit = 0
, @Volume_Regroupement [real] = Null -- for [Contingentement].[Volume_Regroupement] column
, @ConsiderNull_Volume_Regroupement bit = 0
, @Volume_RegroupementPourcentage [real] = Null -- for [Contingentement].[Volume_RegroupementPourcentage] column
, @ConsiderNull_Volume_RegroupementPourcentage bit = 0
, @MaxVolumeFixe_Pourcentage [real] = Null -- for [Contingentement].[MaxVolumeFixe_Pourcentage] column
, @ConsiderNull_MaxVolumeFixe_Pourcentage bit = 0
, @MaxVolumeFixe_ContingentementID [int] = Null -- for [Contingentement].[MaxVolumeFixe_ContingentementID] column
, @ConsiderNull_MaxVolumeFixe_ContingentementID bit = 0
, @UseVolumeFixeUnique [bit] -- for [Contingentement].[UseVolumeFixeUnique] column
, @ConsiderNull_UseVolumeFixeUnique bit = 0
, @MasseContingentVoyageDefaut [real] = Null -- for [Contingentement].[MasseContingentVoyageDefaut] column
, @ConsiderNull_MasseContingentVoyageDefaut bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_ContingentUsine Is Null
	Set @ConsiderNull_ContingentUsine = 0

If @ConsiderNull_UsineID Is Null
	Set @ConsiderNull_UsineID = 0

If @ConsiderNull_RegroupementID Is Null
	Set @ConsiderNull_RegroupementID = 0

If @ConsiderNull_Annee Is Null
	Set @ConsiderNull_Annee = 0

If @ConsiderNull_PeriodeContingentement Is Null
	Set @ConsiderNull_PeriodeContingentement = 0

If @ConsiderNull_PeriodeDebut Is Null
	Set @ConsiderNull_PeriodeDebut = 0

If @ConsiderNull_PeriodeFin Is Null
	Set @ConsiderNull_PeriodeFin = 0

If @ConsiderNull_EssenceID Is Null
	Set @ConsiderNull_EssenceID = 0

If @ConsiderNull_UniteMesureID Is Null
	Set @ConsiderNull_UniteMesureID = 0

If @ConsiderNull_Volume_Usine Is Null
	Set @ConsiderNull_Volume_Usine = 0

If @ConsiderNull_Facteur Is Null
	Set @ConsiderNull_Facteur = 0

If @ConsiderNull_Volume_Fixe Is Null
	Set @ConsiderNull_Volume_Fixe = 0

If @ConsiderNull_Date_Calcul Is Null
	Set @ConsiderNull_Date_Calcul = 0

If @ConsiderNull_CalculAccepte Is Null
	Set @ConsiderNull_CalculAccepte = 0

If @ConsiderNull_Code Is Null
	Set @ConsiderNull_Code = 0

If @ConsiderNull_Volume_Regroupement Is Null
	Set @ConsiderNull_Volume_Regroupement = 0

If @ConsiderNull_Volume_RegroupementPourcentage Is Null
	Set @ConsiderNull_Volume_RegroupementPourcentage = 0

If @ConsiderNull_MaxVolumeFixe_Pourcentage Is Null
	Set @ConsiderNull_MaxVolumeFixe_Pourcentage = 0

If @ConsiderNull_MaxVolumeFixe_ContingentementID Is Null
	Set @ConsiderNull_MaxVolumeFixe_ContingentementID = 0

If @ConsiderNull_UseVolumeFixeUnique Is Null
	Set @ConsiderNull_UseVolumeFixeUnique = 0

If @ConsiderNull_MasseContingentVoyageDefaut Is Null
	Set @ConsiderNull_MasseContingentVoyageDefaut = 0


Update [dbo].[Contingentement]

Set
	 [ContingentUsine] = Case @ConsiderNull_ContingentUsine When 0 Then IsNull(@ContingentUsine, [ContingentUsine]) When 1 Then @ContingentUsine End
	,[UsineID] = Case @ConsiderNull_UsineID When 0 Then IsNull(@UsineID, [UsineID]) When 1 Then @UsineID End
	,[RegroupementID] = Case @ConsiderNull_RegroupementID When 0 Then IsNull(@RegroupementID, [RegroupementID]) When 1 Then @RegroupementID End
	,[Annee] = Case @ConsiderNull_Annee When 0 Then IsNull(@Annee, [Annee]) When 1 Then @Annee End
	,[PeriodeContingentement] = Case @ConsiderNull_PeriodeContingentement When 0 Then IsNull(@PeriodeContingentement, [PeriodeContingentement]) When 1 Then @PeriodeContingentement End
	,[PeriodeDebut] = Case @ConsiderNull_PeriodeDebut When 0 Then IsNull(@PeriodeDebut, [PeriodeDebut]) When 1 Then @PeriodeDebut End
	,[PeriodeFin] = Case @ConsiderNull_PeriodeFin When 0 Then IsNull(@PeriodeFin, [PeriodeFin]) When 1 Then @PeriodeFin End
	,[EssenceID] = Case @ConsiderNull_EssenceID When 0 Then IsNull(@EssenceID, [EssenceID]) When 1 Then @EssenceID End
	,[UniteMesureID] = Case @ConsiderNull_UniteMesureID When 0 Then IsNull(@UniteMesureID, [UniteMesureID]) When 1 Then @UniteMesureID End
	,[Volume_Usine] = Case @ConsiderNull_Volume_Usine When 0 Then IsNull(@Volume_Usine, [Volume_Usine]) When 1 Then @Volume_Usine End
	,[Facteur] = Case @ConsiderNull_Facteur When 0 Then IsNull(@Facteur, [Facteur]) When 1 Then @Facteur End
	,[Volume_Fixe] = Case @ConsiderNull_Volume_Fixe When 0 Then IsNull(@Volume_Fixe, [Volume_Fixe]) When 1 Then @Volume_Fixe End
	,[Date_Calcul] = Case @ConsiderNull_Date_Calcul When 0 Then IsNull(@Date_Calcul, [Date_Calcul]) When 1 Then @Date_Calcul End
	,[CalculAccepte] = Case @ConsiderNull_CalculAccepte When 0 Then IsNull(@CalculAccepte, [CalculAccepte]) When 1 Then @CalculAccepte End
	,[Code] = Case @ConsiderNull_Code When 0 Then IsNull(@Code, [Code]) When 1 Then @Code End
	,[Volume_Regroupement] = Case @ConsiderNull_Volume_Regroupement When 0 Then IsNull(@Volume_Regroupement, [Volume_Regroupement]) When 1 Then @Volume_Regroupement End
	,[Volume_RegroupementPourcentage] = Case @ConsiderNull_Volume_RegroupementPourcentage When 0 Then IsNull(@Volume_RegroupementPourcentage, [Volume_RegroupementPourcentage]) When 1 Then @Volume_RegroupementPourcentage End
	,[MaxVolumeFixe_Pourcentage] = Case @ConsiderNull_MaxVolumeFixe_Pourcentage When 0 Then IsNull(@MaxVolumeFixe_Pourcentage, [MaxVolumeFixe_Pourcentage]) When 1 Then @MaxVolumeFixe_Pourcentage End
	,[MaxVolumeFixe_ContingentementID] = Case @ConsiderNull_MaxVolumeFixe_ContingentementID When 0 Then IsNull(@MaxVolumeFixe_ContingentementID, [MaxVolumeFixe_ContingentementID]) When 1 Then @MaxVolumeFixe_ContingentementID End
	,[UseVolumeFixeUnique] = Case @ConsiderNull_UseVolumeFixeUnique When 0 Then IsNull(@UseVolumeFixeUnique, [UseVolumeFixeUnique]) When 1 Then @UseVolumeFixeUnique End
	,[MasseContingentVoyageDefaut] = Case @ConsiderNull_MasseContingentVoyageDefaut When 0 Then IsNull(@MasseContingentVoyageDefaut, [MasseContingentVoyageDefaut]) When 1 Then @MasseContingentVoyageDefaut End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)

