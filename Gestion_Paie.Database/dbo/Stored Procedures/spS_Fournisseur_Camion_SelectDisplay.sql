

Create Procedure [spS_Fournisseur_Camion_SelectDisplay]

-- Retrieve specific records from the [Fournisseur_Camion] table depending on the input parameters you supply.

(
 @FournisseurID [varchar](15) = Null -- for [Fournisseur_Camion].[FournisseurID] column
,@VR [varchar](10) = Null -- for [Fournisseur_Camion].[VR] column
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

		 [Fournisseur_Camion_Records].[FournisseurID]
		,[Fournisseur_Camion_Records].[FournisseurID_Display]
		,[Fournisseur_Camion_Records].[VR]
		,[Fournisseur_Camion_Records].[MasseLimite]
		,[Fournisseur_Camion_Records].[Actif]

		From [fnFournisseur_Camion_SelectDisplay](@FournisseurID, @VR) As [Fournisseur_Camion_Records]
	End

Else

	Begin
		Select

		 [Fournisseur_Camion_Records].[FournisseurID]
		,[Fournisseur_Camion_Records].[FournisseurID_Display]
		,[Fournisseur_Camion_Records].[VR]
		,[Fournisseur_Camion_Records].[MasseLimite]
		,[Fournisseur_Camion_Records].[Actif]

		From [fnFournisseur_Camion_SelectDisplay](@FournisseurID, @VR) As [Fournisseur_Camion_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


