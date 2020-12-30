

Create Procedure [spS_IndexationCalcule_Producteur_SelectDisplay]

-- Retrieve specific records from the [IndexationCalcule_Producteur] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [IndexationCalcule_Producteur].[ID] column
,@TypeIndexation [char](1) = Null -- for [IndexationCalcule_Producteur].[TypeIndexation] column
,@IndexationID [int] = Null -- for [IndexationCalcule_Producteur].[IndexationID] column
,@IndexationDetailID [int] = Null -- for [IndexationCalcule_Producteur].[IndexationDetailID] column
,@LivraisonID [int] = Null -- for [IndexationCalcule_Producteur].[LivraisonID] column
,@LivraisonDetailID [int] = Null -- for [IndexationCalcule_Producteur].[LivraisonDetailID] column
,@ProducteurID [varchar](15) = Null -- for [IndexationCalcule_Producteur].[ProducteurID] column
,@ContratID [varchar](10) = Null -- for [IndexationCalcule_Producteur].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [IndexationCalcule_Producteur].[EssenceID] column
,@Code [char](4) = Null -- for [IndexationCalcule_Producteur].[Code] column
,@UniteID [varchar](6) = Null -- for [IndexationCalcule_Producteur].[UniteID] column
,@FactureID [int] = Null -- for [IndexationCalcule_Producteur].[FactureID] column
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

		 [IndexationCalcule_Producteur_Records].[ID]
		,[IndexationCalcule_Producteur_Records].[DateCalcul]
		,[IndexationCalcule_Producteur_Records].[TypeIndexation]
		,[IndexationCalcule_Producteur_Records].[TypeIndexation_Display]
		,[IndexationCalcule_Producteur_Records].[IndexationID]
		,[IndexationCalcule_Producteur_Records].[IndexationID_Display]
		,[IndexationCalcule_Producteur_Records].[IndexationDetailID]
		,[IndexationCalcule_Producteur_Records].[IndexationDetailID_Display]
		,[IndexationCalcule_Producteur_Records].[LivraisonID]
		,[IndexationCalcule_Producteur_Records].[LivraisonID_Display]
		,[IndexationCalcule_Producteur_Records].[LivraisonDetailID]
		,[IndexationCalcule_Producteur_Records].[LivraisonDetailID_Display]
		,[IndexationCalcule_Producteur_Records].[ProducteurID]
		,[IndexationCalcule_Producteur_Records].[ProducteurID_Display]
		,[IndexationCalcule_Producteur_Records].[ContratID]
		,[IndexationCalcule_Producteur_Records].[ContratID_Display]
		,[IndexationCalcule_Producteur_Records].[EssenceID]
		,[IndexationCalcule_Producteur_Records].[EssenceID_Display]
		,[IndexationCalcule_Producteur_Records].[Code]
		,[IndexationCalcule_Producteur_Records].[Code_Display]
		,[IndexationCalcule_Producteur_Records].[UniteID]
		,[IndexationCalcule_Producteur_Records].[UniteID_Display]
		,[IndexationCalcule_Producteur_Records].[Volume]
		,[IndexationCalcule_Producteur_Records].[MontantDejaPaye]
		,[IndexationCalcule_Producteur_Records].[PourcentageDuMontant]
		,[IndexationCalcule_Producteur_Records].[Taux]
		,[IndexationCalcule_Producteur_Records].[Montant]
		,[IndexationCalcule_Producteur_Records].[Facture]
		,[IndexationCalcule_Producteur_Records].[FactureID]
		,[IndexationCalcule_Producteur_Records].[FactureID_Display]
		,[IndexationCalcule_Producteur_Records].[ErreurCalcul]
		,[IndexationCalcule_Producteur_Records].[ErreurDescription]

		From [fnIndexationCalcule_Producteur_SelectDisplay](@ID, @TypeIndexation, @IndexationID, @IndexationDetailID, @LivraisonID, @LivraisonDetailID, @ProducteurID, @ContratID, @EssenceID, @Code, @UniteID, @FactureID) As [IndexationCalcule_Producteur_Records]
	End

Else

	Begin
		Select

		 [IndexationCalcule_Producteur_Records].[ID]
		,[IndexationCalcule_Producteur_Records].[DateCalcul]
		,[IndexationCalcule_Producteur_Records].[TypeIndexation]
		,[IndexationCalcule_Producteur_Records].[TypeIndexation_Display]
		,[IndexationCalcule_Producteur_Records].[IndexationID]
		,[IndexationCalcule_Producteur_Records].[IndexationID_Display]
		,[IndexationCalcule_Producteur_Records].[IndexationDetailID]
		,[IndexationCalcule_Producteur_Records].[IndexationDetailID_Display]
		,[IndexationCalcule_Producteur_Records].[LivraisonID]
		,[IndexationCalcule_Producteur_Records].[LivraisonID_Display]
		,[IndexationCalcule_Producteur_Records].[LivraisonDetailID]
		,[IndexationCalcule_Producteur_Records].[LivraisonDetailID_Display]
		,[IndexationCalcule_Producteur_Records].[ProducteurID]
		,[IndexationCalcule_Producteur_Records].[ProducteurID_Display]
		,[IndexationCalcule_Producteur_Records].[ContratID]
		,[IndexationCalcule_Producteur_Records].[ContratID_Display]
		,[IndexationCalcule_Producteur_Records].[EssenceID]
		,[IndexationCalcule_Producteur_Records].[EssenceID_Display]
		,[IndexationCalcule_Producteur_Records].[Code]
		,[IndexationCalcule_Producteur_Records].[Code_Display]
		,[IndexationCalcule_Producteur_Records].[UniteID]
		,[IndexationCalcule_Producteur_Records].[UniteID_Display]
		,[IndexationCalcule_Producteur_Records].[Volume]
		,[IndexationCalcule_Producteur_Records].[MontantDejaPaye]
		,[IndexationCalcule_Producteur_Records].[PourcentageDuMontant]
		,[IndexationCalcule_Producteur_Records].[Taux]
		,[IndexationCalcule_Producteur_Records].[Montant]
		,[IndexationCalcule_Producteur_Records].[Facture]
		,[IndexationCalcule_Producteur_Records].[FactureID]
		,[IndexationCalcule_Producteur_Records].[FactureID_Display]
		,[IndexationCalcule_Producteur_Records].[ErreurCalcul]
		,[IndexationCalcule_Producteur_Records].[ErreurDescription]

		From [fnIndexationCalcule_Producteur_SelectDisplay](@ID, @TypeIndexation, @IndexationID, @IndexationDetailID, @LivraisonID, @LivraisonDetailID, @ProducteurID, @ContratID, @EssenceID, @Code, @UniteID, @FactureID) As [IndexationCalcule_Producteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


