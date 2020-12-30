CREATE PROCEDURE [dbo].[spS_Contingentement_Producteur_SelectDisplay]
@ContingentementID INT=Null, @ProducteurID VARCHAR (15)=Null, @ReturnXML BIT=0
AS
If @ReturnXML Is Null
	Set @ReturnXML = 0

If @ReturnXML = 0
	Begin
		Select

		 [Contingentement_Producteur_Records].[ContingentementID]
		,[Contingentement_Producteur_Records].[ContingentementID_Display]
		,[Contingentement_Producteur_Records].[ProducteurID]
		,[Contingentement_Producteur_Records].[ProducteurID_Display]
		,[Contingentement_Producteur_Records].[Superficie_Contingentee]
		,[Contingentement_Producteur_Records].[Volume_Demande]
		,[Contingentement_Producteur_Records].[Volume_Facteur]
		,[Contingentement_Producteur_Records].[Volume_Fixe]
		,[Contingentement_Producteur_Records].[Volume_Supplementaire]
		,[Contingentement_Producteur_Records].[Volume_Accorde]
		,[Contingentement_Producteur_Records].[Date_Modification]
		,[Contingentement_Producteur_Records].[Volume_Inventaire]
		,[Contingentement_Producteur_Records].[LastLivraison]
		,[Contingentement_Producteur_Records].[VolumeMaximum]
		,[Contingentement_Producteur_Records].[Imprime]

		From [fnContingentement_Producteur_SelectDisplay](@ContingentementID, @ProducteurID) As [Contingentement_Producteur_Records]
	End

Else

	Begin
		Select

		 [Contingentement_Producteur_Records].[ContingentementID]
		,[Contingentement_Producteur_Records].[ContingentementID_Display]
		,[Contingentement_Producteur_Records].[ProducteurID]
		,[Contingentement_Producteur_Records].[ProducteurID_Display]
		,[Contingentement_Producteur_Records].[Superficie_Contingentee]
		,[Contingentement_Producteur_Records].[Volume_Demande]
		,[Contingentement_Producteur_Records].[Volume_Facteur]
		,[Contingentement_Producteur_Records].[Volume_Fixe]
		,[Contingentement_Producteur_Records].[Volume_Supplementaire]
		,[Contingentement_Producteur_Records].[Volume_Accorde]
		,[Contingentement_Producteur_Records].[Date_Modification]
		,[Contingentement_Producteur_Records].[Volume_Inventaire]
		,[Contingentement_Producteur_Records].[LastLivraison]
		,[Contingentement_Producteur_Records].[VolumeMaximum]
		,[Contingentement_Producteur_Records].[Imprime]

		From [fnContingentement_Producteur_SelectDisplay](@ContingentementID, @ProducteurID) As [Contingentement_Producteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


