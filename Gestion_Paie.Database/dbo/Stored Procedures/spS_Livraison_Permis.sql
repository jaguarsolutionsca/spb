

Create Procedure [spS_Livraison_Permis]

-- Retrieve specific records from the [Livraison_Permis] table depending on the input parameters you supply.

(
 @LivraisonID [int] = Null -- for [Livraison_Permis].[LivraisonID] column
,@PermisID [int] = Null -- for [Livraison_Permis].[PermisID] column
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

		 [Livraison_Permis_Records].[LivraisonID]
		,[Livraison_Permis_Records].[PermisID]
		,[Livraison_Permis_Records].[NumeroFactureUsine]

		From [fnLivraison_Permis](@LivraisonID, @PermisID) As [Livraison_Permis_Records]
	End

Else

	Begin
		Select

		 [Livraison_Permis_Records].[LivraisonID]
		,[Livraison_Permis_Records].[PermisID]
		,[Livraison_Permis_Records].[NumeroFactureUsine]

		From [fnLivraison_Permis](@LivraisonID, @PermisID) As [Livraison_Permis_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


