CREATE Procedure [dbo].[spS_AjustementCalcule_TransporteurEssence]

-- Retrieve specific records from the [AjustementCalcule_TransporteurEssence] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_TransporteurEssence].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_TransporteurEssence].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[LivraisonDetailID] column
,@TransporteurID [varchar](15) = Null -- for [AjustementCalcule_TransporteurEssence].[TransporteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_TransporteurEssence].[Code] column
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

		 [AjustementCalcule_TransporteurEssence_Records].[ID]
		,[AjustementCalcule_TransporteurEssence_Records].[DateCalcul]
		,[AjustementCalcule_TransporteurEssence_Records].[AjustementID]
		,[AjustementCalcule_TransporteurEssence_Records].[EssenceID]
		,[AjustementCalcule_TransporteurEssence_Records].[UniteID]
		,[AjustementCalcule_TransporteurEssence_Records].[LivraisonDetailID]
		,[AjustementCalcule_TransporteurEssence_Records].[TransporteurID]
		,[AjustementCalcule_TransporteurEssence_Records].[Volume]
		,[AjustementCalcule_TransporteurEssence_Records].[Taux]
		,[AjustementCalcule_TransporteurEssence_Records].[Montant]
		,[AjustementCalcule_TransporteurEssence_Records].[Facture]
		,[AjustementCalcule_TransporteurEssence_Records].[FactureID]
		,[AjustementCalcule_TransporteurEssence_Records].[ErreurCalcul]
		,[AjustementCalcule_TransporteurEssence_Records].[ErreurDescription]
		,[AjustementCalcule_TransporteurEssence_Records].[Code]

		From [fnAjustementCalcule_TransporteurEssence](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @TransporteurID, @FactureID, @Code) As [AjustementCalcule_TransporteurEssence_Records]
	End

Else

	Begin
		Select

		 [AjustementCalcule_TransporteurEssence_Records].[ID]
		,[AjustementCalcule_TransporteurEssence_Records].[DateCalcul]
		,[AjustementCalcule_TransporteurEssence_Records].[AjustementID]
		,[AjustementCalcule_TransporteurEssence_Records].[EssenceID]
		,[AjustementCalcule_TransporteurEssence_Records].[UniteID]
		,[AjustementCalcule_TransporteurEssence_Records].[LivraisonDetailID]
		,[AjustementCalcule_TransporteurEssence_Records].[TransporteurID]
		,[AjustementCalcule_TransporteurEssence_Records].[Volume]
		,[AjustementCalcule_TransporteurEssence_Records].[Taux]
		,[AjustementCalcule_TransporteurEssence_Records].[Montant]
		,[AjustementCalcule_TransporteurEssence_Records].[Facture]
		,[AjustementCalcule_TransporteurEssence_Records].[FactureID]
		,[AjustementCalcule_TransporteurEssence_Records].[ErreurCalcul]
		,[AjustementCalcule_TransporteurEssence_Records].[ErreurDescription]
		,[AjustementCalcule_TransporteurEssence_Records].[Code]

		From [fnAjustementCalcule_TransporteurEssence](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @TransporteurID, @FactureID, @Code) As [AjustementCalcule_TransporteurEssence_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)
