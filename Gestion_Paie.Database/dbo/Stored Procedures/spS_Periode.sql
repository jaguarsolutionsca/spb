

Create Procedure [spS_Periode]

-- Retrieve specific records from the [Periode] table depending on the input parameters you supply.

(
 @Annee [int] = Null -- for [Periode].[Annee] column
,@SemaineNo [int] = Null -- for [Periode].[SemaineNo] column
,@ReturnXML [bit] = 0 -- Indicates if we want to get back XML content instead of normal resultset (@ReturnXML = 1 to get XML back)
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Periode_Records].[Annee]
		,[Periode_Records].[SemaineNo]
		,[Periode_Records].[DateDebut]
		,[Periode_Records].[DateFin]
		,[Periode_Records].[PeriodeContingentement]

		From [fnPeriode](@Annee, @SemaineNo) As [Periode_Records]
	End

Else

	Begin
		Select

		 [Periode_Records].[Annee]
		,[Periode_Records].[SemaineNo]
		,[Periode_Records].[DateDebut]
		,[Periode_Records].[DateFin]
		,[Periode_Records].[PeriodeContingentement]

		From [fnPeriode](@Annee, @SemaineNo) As [Periode_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


