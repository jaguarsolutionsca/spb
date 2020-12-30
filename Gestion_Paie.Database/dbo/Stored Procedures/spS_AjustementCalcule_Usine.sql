

Create Procedure [spS_AjustementCalcule_Usine]

-- Retrieve specific records from the [AjustementCalcule_Usine] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [AjustementCalcule_Usine].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Usine].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_Usine].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Usine].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_Usine].[LivraisonDetailID] column
,@UsineID [varchar](6) = Null -- for [AjustementCalcule_Usine].[UsineID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Usine].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_Usine].[Code] column
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

		 [AjustementCalcule_Usine_Records].[ID]
		,[AjustementCalcule_Usine_Records].[DateCalcul]
		,[AjustementCalcule_Usine_Records].[AjustementID]
		,[AjustementCalcule_Usine_Records].[EssenceID]
		,[AjustementCalcule_Usine_Records].[UniteID]
		,[AjustementCalcule_Usine_Records].[LivraisonDetailID]
		,[AjustementCalcule_Usine_Records].[UsineID]
		,[AjustementCalcule_Usine_Records].[Volume]
		,[AjustementCalcule_Usine_Records].[Taux]
		,[AjustementCalcule_Usine_Records].[Montant]
		,[AjustementCalcule_Usine_Records].[Facture]
		,[AjustementCalcule_Usine_Records].[FactureID]
		,[AjustementCalcule_Usine_Records].[ErreurCalcul]
		,[AjustementCalcule_Usine_Records].[ErreurDescription]
		,[AjustementCalcule_Usine_Records].[Code]

		From [fnAjustementCalcule_Usine](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @UsineID, @FactureID, @Code) As [AjustementCalcule_Usine_Records]
	End

Else

	Begin
		Select

		 [AjustementCalcule_Usine_Records].[ID]
		,[AjustementCalcule_Usine_Records].[DateCalcul]
		,[AjustementCalcule_Usine_Records].[AjustementID]
		,[AjustementCalcule_Usine_Records].[EssenceID]
		,[AjustementCalcule_Usine_Records].[UniteID]
		,[AjustementCalcule_Usine_Records].[LivraisonDetailID]
		,[AjustementCalcule_Usine_Records].[UsineID]
		,[AjustementCalcule_Usine_Records].[Volume]
		,[AjustementCalcule_Usine_Records].[Taux]
		,[AjustementCalcule_Usine_Records].[Montant]
		,[AjustementCalcule_Usine_Records].[Facture]
		,[AjustementCalcule_Usine_Records].[FactureID]
		,[AjustementCalcule_Usine_Records].[ErreurCalcul]
		,[AjustementCalcule_Usine_Records].[ErreurDescription]
		,[AjustementCalcule_Usine_Records].[Code]

		From [fnAjustementCalcule_Usine](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @UsineID, @FactureID, @Code) As [AjustementCalcule_Usine_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


