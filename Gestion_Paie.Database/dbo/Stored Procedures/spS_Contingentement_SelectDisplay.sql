
CREATE Procedure [spS_Contingentement_SelectDisplay]

-- Retrieve specific records from the [Contingentement] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [Contingentement].[ID] column
,@UsineID [varchar](6) = Null -- for [Contingentement].[UsineID] column
,@RegroupementID [int] = Null -- for [Contingentement].[RegroupementID] column
,@EssenceID [varchar](6) = Null -- for [Contingentement].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [Contingentement].[UniteMesureID] column
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

		 [Contingentement_Records].[ID]
		,[Contingentement_Records].[ContingentUsine]
		,[Contingentement_Records].[UsineID]
		,[Contingentement_Records].[UsineID_Display]
		,[Contingentement_Records].[RegroupementID]
		,[Contingentement_Records].[RegroupementID_Display]
		,[Contingentement_Records].[Annee]
		,[Contingentement_Records].[PeriodeContingentement]
		,[Contingentement_Records].[PeriodeDebut]
		,[Contingentement_Records].[PeriodeFin]
		,[Contingentement_Records].[EssenceID]
		,[Contingentement_Records].[EssenceID_Display]
		,[Contingentement_Records].[UniteMesureID]
		,[Contingentement_Records].[UniteMesureID_Display]
		,[Contingentement_Records].[Volume_Usine]
		,[Contingentement_Records].[Facteur]
		,[Contingentement_Records].[Volume_Fixe]
		,[Contingentement_Records].[Date_Calcul]
		,[Contingentement_Records].[CalculAccepte]
		,[Contingentement_Records].[Code]
		,[Contingentement_Records].[Volume_Regroupement]
		,[Contingentement_Records].[Volume_RegroupementPourcentage]
		,[Contingentement_Records].[MaxVolumeFixe_Pourcentage]
		,[Contingentement_Records].[MaxVolumeFixe_ContingentementID]
		,[Contingentement_Records].[UseVolumeFixeUnique]
		,[Contingentement_Records].[MasseContingentVoyageDefaut]

		From [fnContingentement_SelectDisplay](@ID, @UsineID, @RegroupementID, @EssenceID, @UniteMesureID) As [Contingentement_Records]
	End

Else

	Begin
		Select

		 [Contingentement_Records].[ID]
		,[Contingentement_Records].[ContingentUsine]
		,[Contingentement_Records].[UsineID]
		,[Contingentement_Records].[UsineID_Display]
		,[Contingentement_Records].[RegroupementID]
		,[Contingentement_Records].[RegroupementID_Display]
		,[Contingentement_Records].[Annee]
		,[Contingentement_Records].[PeriodeContingentement]
		,[Contingentement_Records].[PeriodeDebut]
		,[Contingentement_Records].[PeriodeFin]
		,[Contingentement_Records].[EssenceID]
		,[Contingentement_Records].[EssenceID_Display]
		,[Contingentement_Records].[UniteMesureID]
		,[Contingentement_Records].[UniteMesureID_Display]
		,[Contingentement_Records].[Volume_Usine]
		,[Contingentement_Records].[Facteur]
		,[Contingentement_Records].[Volume_Fixe]
		,[Contingentement_Records].[Date_Calcul]
		,[Contingentement_Records].[CalculAccepte]
		,[Contingentement_Records].[Code]
		,[Contingentement_Records].[Volume_Regroupement]
		,[Contingentement_Records].[Volume_RegroupementPourcentage]
		,[Contingentement_Records].[MaxVolumeFixe_Pourcentage]
		,[Contingentement_Records].[MaxVolumeFixe_ContingentementID]
		,[Contingentement_Records].[UseVolumeFixeUnique]
		,[Contingentement_Records].[MasseContingentVoyageDefaut]

		From [fnContingentement_SelectDisplay](@ID, @UsineID, @RegroupementID, @EssenceID, @UniteMesureID) As [Contingentement_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)

