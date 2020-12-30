
Create Procedure [spS_Contingentement_VolumeFixe_Full]

/*
Retrieve specific records from the [Contingentement_VolumeFixe] table, as well as all its foreign tables, depending on the input parameters you supply:
	[Contingentement] (via [ContingentementID])
*/

(
 @ContingentementID [int] = Null -- for [Contingentement_VolumeFixe].[ContingentementID] column
,@Superficie_Min [real] = Null -- for [Contingentement_VolumeFixe].[Superficie_Min] column
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

		 [Contingentement_VolumeFixe_Records].[ContingentementID]
		,[Contingentement_VolumeFixe_Records].[Superficie_Min]
		,[Contingentement_VolumeFixe_Records].[Volume_Fixe]
		,[Contingentement_VolumeFixe_Records].[NombreMois]
		,[Contingentement_VolumeFixe_Records].[UseNombreMois]

		From [fnContingentement_VolumeFixe_Full](@ContingentementID, @Superficie_Min) As [Contingentement_VolumeFixe_Records]
	End

Else

	Begin
		Select

		 [Contingentement_VolumeFixe_Records].[ContingentementID]
		,[Contingentement_VolumeFixe_Records].[Superficie_Min]
		,[Contingentement_VolumeFixe_Records].[Volume_Fixe]
		,[Contingentement_VolumeFixe_Records].[NombreMois]
		,[Contingentement_VolumeFixe_Records].[UseNombreMois]

		From [fnContingentement_VolumeFixe_Full](@ContingentementID, @Superficie_Min) As [Contingentement_VolumeFixe_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)

