

Create Procedure [spS_AjustementCalcule_Producteur]

-- Retrieve specific records from the [AjustementCalcule_Producteur] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [AjustementCalcule_Producteur].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Producteur].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_Producteur].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Producteur].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_Producteur].[LivraisonDetailID] column
,@ProducteurID [varchar](15) = Null -- for [AjustementCalcule_Producteur].[ProducteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Producteur].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_Producteur].[Code] column
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

		 [AjustementCalcule_Producteur_Records].[ID]
		,[AjustementCalcule_Producteur_Records].[DateCalcul]
		,[AjustementCalcule_Producteur_Records].[AjustementID]
		,[AjustementCalcule_Producteur_Records].[EssenceID]
		,[AjustementCalcule_Producteur_Records].[UniteID]
		,[AjustementCalcule_Producteur_Records].[LivraisonDetailID]
		,[AjustementCalcule_Producteur_Records].[ProducteurID]
		,[AjustementCalcule_Producteur_Records].[Volume]
		,[AjustementCalcule_Producteur_Records].[Taux]
		,[AjustementCalcule_Producteur_Records].[Montant]
		,[AjustementCalcule_Producteur_Records].[Facture]
		,[AjustementCalcule_Producteur_Records].[FactureID]
		,[AjustementCalcule_Producteur_Records].[ErreurCalcul]
		,[AjustementCalcule_Producteur_Records].[ErreurDescription]
		,[AjustementCalcule_Producteur_Records].[Code]

		From [fnAjustementCalcule_Producteur](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @ProducteurID, @FactureID, @Code) As [AjustementCalcule_Producteur_Records]
	End

Else

	Begin
		Select

		 [AjustementCalcule_Producteur_Records].[ID]
		,[AjustementCalcule_Producteur_Records].[DateCalcul]
		,[AjustementCalcule_Producteur_Records].[AjustementID]
		,[AjustementCalcule_Producteur_Records].[EssenceID]
		,[AjustementCalcule_Producteur_Records].[UniteID]
		,[AjustementCalcule_Producteur_Records].[LivraisonDetailID]
		,[AjustementCalcule_Producteur_Records].[ProducteurID]
		,[AjustementCalcule_Producteur_Records].[Volume]
		,[AjustementCalcule_Producteur_Records].[Taux]
		,[AjustementCalcule_Producteur_Records].[Montant]
		,[AjustementCalcule_Producteur_Records].[Facture]
		,[AjustementCalcule_Producteur_Records].[FactureID]
		,[AjustementCalcule_Producteur_Records].[ErreurCalcul]
		,[AjustementCalcule_Producteur_Records].[ErreurDescription]
		,[AjustementCalcule_Producteur_Records].[Code]

		From [fnAjustementCalcule_Producteur](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @ProducteurID, @FactureID, @Code) As [AjustementCalcule_Producteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


