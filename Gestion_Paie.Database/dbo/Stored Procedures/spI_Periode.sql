

Create Procedure [spI_Periode]

-- Inserts a new record in [Periode] table
(
  @Annee [int] -- for [Periode].[Annee] column
, @SemaineNo [int] -- for [Periode].[SemaineNo] column
, @DateDebut [smalldatetime] = Null  -- for [Periode].[DateDebut] column
, @DateFin [smalldatetime] = Null  -- for [Periode].[DateFin] column
, @PeriodeContingentement [int] = Null  -- for [Periode].[PeriodeContingentement] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[Periode]
(
	  [Annee]
	, [SemaineNo]
	, [DateDebut]
	, [DateFin]
	, [PeriodeContingentement]
)

Values
(
	  @Annee
	, @SemaineNo
	, @DateDebut
	, @DateFin
	, @PeriodeContingentement
)

Set NoCount Off

Return(0)


