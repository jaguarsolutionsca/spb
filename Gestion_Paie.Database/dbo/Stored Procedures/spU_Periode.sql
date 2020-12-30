

Create Procedure [spU_Periode]

-- Update an existing record in [Periode] table

(
  @Annee [int] -- for [Periode].[Annee] column
, @SemaineNo [int] -- for [Periode].[SemaineNo] column
, @DateDebut [smalldatetime] = Null -- for [Periode].[DateDebut] column
, @ConsiderNull_DateDebut bit = 0
, @DateFin [smalldatetime] = Null -- for [Periode].[DateFin] column
, @ConsiderNull_DateFin bit = 0
, @PeriodeContingentement [int] = Null -- for [Periode].[PeriodeContingentement] column
, @ConsiderNull_PeriodeContingentement bit = 0
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @ConsiderNull_DateDebut Is Null
	Set @ConsiderNull_DateDebut = 0

If @ConsiderNull_DateFin Is Null
	Set @ConsiderNull_DateFin = 0

If @ConsiderNull_PeriodeContingentement Is Null
	Set @ConsiderNull_PeriodeContingentement = 0


Update [dbo].[Periode]

Set
	 [DateDebut] = Case @ConsiderNull_DateDebut When 0 Then IsNull(@DateDebut, [DateDebut]) When 1 Then @DateDebut End
	,[DateFin] = Case @ConsiderNull_DateFin When 0 Then IsNull(@DateFin, [DateFin]) When 1 Then @DateFin End
	,[PeriodeContingentement] = Case @ConsiderNull_PeriodeContingentement When 0 Then IsNull(@PeriodeContingentement, [PeriodeContingentement]) When 1 Then @PeriodeContingentement End

Where
	     ([Annee] = @Annee)
	And ([SemaineNo] = @SemaineNo)

Set NoCount Off

Return(0)


