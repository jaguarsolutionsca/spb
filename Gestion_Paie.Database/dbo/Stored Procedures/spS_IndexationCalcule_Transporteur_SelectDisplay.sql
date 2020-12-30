

Create Procedure [spS_IndexationCalcule_Transporteur_SelectDisplay]

-- Retrieve specific records from the [IndexationCalcule_Transporteur] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [IndexationCalcule_Transporteur].[ID] column
,@TypeIndexation [char](1) = Null -- for [IndexationCalcule_Transporteur].[TypeIndexation] column
,@IndexationID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationID] column
,@IndexationDetailID [int] = Null -- for [IndexationCalcule_Transporteur].[IndexationDetailID] column
,@LivraisonID [int] = Null -- for [IndexationCalcule_Transporteur].[LivraisonID] column
,@TransporteurID [varchar](15) = Null -- for [IndexationCalcule_Transporteur].[TransporteurID] column
,@FactureID [int] = Null -- for [IndexationCalcule_Transporteur].[FactureID] column
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

		 [IndexationCalcule_Transporteur_Records].[ID]
		,[IndexationCalcule_Transporteur_Records].[DateCalcul]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation_Display]
		,[IndexationCalcule_Transporteur_Records].[IndexationID]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Display]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_Display]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Display]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Display]
		,[IndexationCalcule_Transporteur_Records].[MontantDejaPaye]
		,[IndexationCalcule_Transporteur_Records].[PourcentageDuMontant]
		,[IndexationCalcule_Transporteur_Records].[Montant]
		,[IndexationCalcule_Transporteur_Records].[Facture]
		,[IndexationCalcule_Transporteur_Records].[FactureID]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Display]
		,[IndexationCalcule_Transporteur_Records].[ErreurCalcul]
		,[IndexationCalcule_Transporteur_Records].[ErreurDescription]

		From [fnIndexationCalcule_Transporteur_SelectDisplay](@ID, @TypeIndexation, @IndexationID, @IndexationDetailID, @LivraisonID, @TransporteurID, @FactureID) As [IndexationCalcule_Transporteur_Records]
	End

Else

	Begin
		Select

		 [IndexationCalcule_Transporteur_Records].[ID]
		,[IndexationCalcule_Transporteur_Records].[DateCalcul]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation]
		,[IndexationCalcule_Transporteur_Records].[TypeIndexation_Display]
		,[IndexationCalcule_Transporteur_Records].[IndexationID]
		,[IndexationCalcule_Transporteur_Records].[IndexationID_Display]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID]
		,[IndexationCalcule_Transporteur_Records].[IndexationDetailID_Display]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID]
		,[IndexationCalcule_Transporteur_Records].[LivraisonID_Display]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID]
		,[IndexationCalcule_Transporteur_Records].[TransporteurID_Display]
		,[IndexationCalcule_Transporteur_Records].[MontantDejaPaye]
		,[IndexationCalcule_Transporteur_Records].[PourcentageDuMontant]
		,[IndexationCalcule_Transporteur_Records].[Montant]
		,[IndexationCalcule_Transporteur_Records].[Facture]
		,[IndexationCalcule_Transporteur_Records].[FactureID]
		,[IndexationCalcule_Transporteur_Records].[FactureID_Display]
		,[IndexationCalcule_Transporteur_Records].[ErreurCalcul]
		,[IndexationCalcule_Transporteur_Records].[ErreurDescription]

		From [fnIndexationCalcule_Transporteur_SelectDisplay](@ID, @TypeIndexation, @IndexationID, @IndexationDetailID, @LivraisonID, @TransporteurID, @FactureID) As [IndexationCalcule_Transporteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


