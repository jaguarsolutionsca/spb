

CREATE Procedure [dbo].[jag_ListView_ContingentementDemande]
(
	 @ID [int] = Null -- for [Contingentement_Demande].[ID] column
	,@ProducteurID [varchar](15) = Null -- for [Contingentement_Demande].[ProducteurID] column
	,@TransporteurID [varchar](15) = Null
)

As

	Select

	 [Contingentement_Demande_Records].[ID]
	,[Contingentement_Demande_Records].[Annee]
	,[Contingentement_Demande_Records].[ProducteurID] +' - '+ [Contingentement_Demande_Records].[ProducteurID_Nom] as Producteur
	,[Contingentement_Demande_Records].[TransporteurID]+ ' - '+ [Contingentement_Demande_Records].[TransporteurID_Nom] as Transporteur
	,[Contingentement_Demande_Records].[Superficie_Boisee]

	From [fnContingentement_Demande_Full](@ID, @ProducteurID, @TransporteurID) As [Contingentement_Demande_Records]
	



Return(@@RowCount)


