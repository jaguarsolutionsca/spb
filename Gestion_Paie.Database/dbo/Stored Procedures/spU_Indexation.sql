

Create Procedure [spU_Indexation]

-- Update an existing record in [Indexation] table

(
  @ID [int] -- for [Indexation].[ID] column
, @DateIndexation [datetime] = Null -- for [Indexation].[DateIndexation] column
, @ConsiderNull_DateIndexation bit = 0
, @ContratID [varchar](10) = Null -- for [Indexation].[ContratID] column
, @ConsiderNull_ContratID bit = 0
, @Periode_Debut [int] = Null -- for [Indexation].[Periode_Debut] column
, @ConsiderNull_Periode_Debut bit = 0
, @Periode_Fin [int] = Null -- for [Indexation].[Periode_Fin] column
, @ConsiderNull_Periode_Fin bit = 0
, @TypeIndexation [char](1) = Null -- for [Indexation].[TypeIndexation] column
, @ConsiderNull_TypeIndexation bit = 0
, @PourcentageDuMontant [real] = Null -- for [Indexation].[PourcentageDuMontant] column
, @ConsiderNull_PourcentageDuMontant bit = 0
, @Facture [bit] = Null -- for [Indexation].[Facture] column
, @ConsiderNull_Facture bit = 0
, @IndexationTransporteur [bit] = Null -- for [Indexation].[IndexationTransporteur] column
, @ConsiderNull_IndexationTransporteur bit = 0
, @Date_Debut [smalldatetime] = Null -- for [Indexation].[Date_Debut] column
, @ConsiderNull_Date_Debut bit = 0
, @Date_Fin [smalldatetime] = Null -- for [Indexation].[Date_Fin] column
, @ConsiderNull_Date_Fin bit = 0
, @IndexationManuelle [bit] = Null -- for [Indexation].[IndexationManuelle] column
, @ConsiderNull_IndexationManuelle bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_DateIndexation Is Null
	Set @ConsiderNull_DateIndexation = 0

If @ConsiderNull_ContratID Is Null
	Set @ConsiderNull_ContratID = 0

If @ConsiderNull_Periode_Debut Is Null
	Set @ConsiderNull_Periode_Debut = 0

If @ConsiderNull_Periode_Fin Is Null
	Set @ConsiderNull_Periode_Fin = 0

If @ConsiderNull_TypeIndexation Is Null
	Set @ConsiderNull_TypeIndexation = 0

If @ConsiderNull_PourcentageDuMontant Is Null
	Set @ConsiderNull_PourcentageDuMontant = 0

If @ConsiderNull_Facture Is Null
	Set @ConsiderNull_Facture = 0

If @ConsiderNull_IndexationTransporteur Is Null
	Set @ConsiderNull_IndexationTransporteur = 0

If @ConsiderNull_Date_Debut Is Null
	Set @ConsiderNull_Date_Debut = 0

If @ConsiderNull_Date_Fin Is Null
	Set @ConsiderNull_Date_Fin = 0

If @ConsiderNull_IndexationManuelle Is Null
	Set @ConsiderNull_IndexationManuelle = 0


Update [dbo].[Indexation]

Set
	 [DateIndexation] = Case @ConsiderNull_DateIndexation When 0 Then IsNull(@DateIndexation, [DateIndexation]) When 1 Then @DateIndexation End
	,[ContratID] = Case @ConsiderNull_ContratID When 0 Then IsNull(@ContratID, [ContratID]) When 1 Then @ContratID End
	,[Periode_Debut] = Case @ConsiderNull_Periode_Debut When 0 Then IsNull(@Periode_Debut, [Periode_Debut]) When 1 Then @Periode_Debut End
	,[Periode_Fin] = Case @ConsiderNull_Periode_Fin When 0 Then IsNull(@Periode_Fin, [Periode_Fin]) When 1 Then @Periode_Fin End
	,[TypeIndexation] = Case @ConsiderNull_TypeIndexation When 0 Then IsNull(@TypeIndexation, [TypeIndexation]) When 1 Then @TypeIndexation End
	,[PourcentageDuMontant] = Case @ConsiderNull_PourcentageDuMontant When 0 Then IsNull(@PourcentageDuMontant, [PourcentageDuMontant]) When 1 Then @PourcentageDuMontant End
	,[Facture] = Case @ConsiderNull_Facture When 0 Then IsNull(@Facture, [Facture]) When 1 Then @Facture End
	,[IndexationTransporteur] = Case @ConsiderNull_IndexationTransporteur When 0 Then IsNull(@IndexationTransporteur, [IndexationTransporteur]) When 1 Then @IndexationTransporteur End
	,[Date_Debut] = Case @ConsiderNull_Date_Debut When 0 Then IsNull(@Date_Debut, [Date_Debut]) When 1 Then @Date_Debut End
	,[Date_Fin] = Case @ConsiderNull_Date_Fin When 0 Then IsNull(@Date_Fin, [Date_Fin]) When 1 Then @Date_Fin End
	,[IndexationManuelle] = Case @ConsiderNull_IndexationManuelle When 0 Then IsNull(@IndexationManuelle, [IndexationManuelle]) When 1 Then @IndexationManuelle End

Where
	     ([ID] = @ID)

Set NoCount Off

Return(0)


