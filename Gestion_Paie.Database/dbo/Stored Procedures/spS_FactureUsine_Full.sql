

Create Procedure [spS_FactureUsine_Full]

/*
Retrieve specific records from the [FactureUsine] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Periode] (via [Annee])
	[Periode] (via [Periode])
	[Contrat] (via [ContratID])
*/

(
 @ID [int] = Null -- for [FactureUsine].[ID] column
,@Annee [int] = Null -- for [FactureUsine].[Annee] column
,@Periode [int] = Null -- for [FactureUsine].[Periode] column
,@ContratID [varchar](10) = Null -- for [FactureUsine].[ContratID] column
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

		 [FactureUsine_Records].[ID]
		,[FactureUsine_Records].[DatePermis]
		,[FactureUsine_Records].[DateLivraison]
		,[FactureUsine_Records].[DatePaye]
		,[FactureUsine_Records].[Annee]
		,[FactureUsine_Records].[Periode]
		,[FactureUsine_Records].[ContratID]
		,[FactureUsine_Records].[Sciage]
		,[FactureUsine_Records].[EssenceSciage]
		,[FactureUsine_Records].[NumeroFactureUsine]
		,[FactureUsine_Records].[ProducteurID]
		,[FactureUsine_Records].[Livraison]
		,[FactureUsine_Records].[Annee_Annee]
		,[FactureUsine_Records].[Annee_SemaineNo]
		,[FactureUsine_Records].[Annee_DateDebut]
		,[FactureUsine_Records].[Annee_DateFin]
		,[FactureUsine_Records].[Annee_PeriodeContingentement]
		,[FactureUsine_Records].[Periode_Annee]
		,[FactureUsine_Records].[Periode_SemaineNo]
		,[FactureUsine_Records].[Periode_DateDebut]
		,[FactureUsine_Records].[Periode_DateFin]
		,[FactureUsine_Records].[Periode_PeriodeContingentement]
		,[FactureUsine_Records].[ContratID_ID]
		,[FactureUsine_Records].[ContratID_Description]
		,[FactureUsine_Records].[ContratID_UsineID]
		,[FactureUsine_Records].[ContratID_Annee]
		,[FactureUsine_Records].[ContratID_Date_debut]
		,[FactureUsine_Records].[ContratID_Date_fin]
		,[FactureUsine_Records].[ContratID_Actif]
		,[FactureUsine_Records].[ContratID_PaieTransporteur]
		,[FactureUsine_Records].[ContratID_Taux_Surcharge]
		,[FactureUsine_Records].[ContratID_SurchargeManuel]
		,[FactureUsine_Records].[ContratID_TxTransSameProd]

		From [fnFactureUsine_Full](@ID, @Annee, @Periode, @ContratID) As [FactureUsine_Records]
	End

Else

	Begin
		Select

		 [FactureUsine_Records].[ID]
		,[FactureUsine_Records].[DatePermis]
		,[FactureUsine_Records].[DateLivraison]
		,[FactureUsine_Records].[DatePaye]
		,[FactureUsine_Records].[Annee]
		,[FactureUsine_Records].[Periode]
		,[FactureUsine_Records].[ContratID]
		,[FactureUsine_Records].[Sciage]
		,[FactureUsine_Records].[EssenceSciage]
		,[FactureUsine_Records].[NumeroFactureUsine]
		,[FactureUsine_Records].[ProducteurID]
		,[FactureUsine_Records].[Livraison]
		,[FactureUsine_Records].[Annee_Annee]
		,[FactureUsine_Records].[Annee_SemaineNo]
		,[FactureUsine_Records].[Annee_DateDebut]
		,[FactureUsine_Records].[Annee_DateFin]
		,[FactureUsine_Records].[Annee_PeriodeContingentement]
		,[FactureUsine_Records].[Periode_Annee]
		,[FactureUsine_Records].[Periode_SemaineNo]
		,[FactureUsine_Records].[Periode_DateDebut]
		,[FactureUsine_Records].[Periode_DateFin]
		,[FactureUsine_Records].[Periode_PeriodeContingentement]
		,[FactureUsine_Records].[ContratID_ID]
		,[FactureUsine_Records].[ContratID_Description]
		,[FactureUsine_Records].[ContratID_UsineID]
		,[FactureUsine_Records].[ContratID_Annee]
		,[FactureUsine_Records].[ContratID_Date_debut]
		,[FactureUsine_Records].[ContratID_Date_fin]
		,[FactureUsine_Records].[ContratID_Actif]
		,[FactureUsine_Records].[ContratID_PaieTransporteur]
		,[FactureUsine_Records].[ContratID_Taux_Surcharge]
		,[FactureUsine_Records].[ContratID_SurchargeManuel]
		,[FactureUsine_Records].[ContratID_TxTransSameProd]

		From [fnFactureUsine_Full](@ID, @Annee, @Periode, @ContratID) As [FactureUsine_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


