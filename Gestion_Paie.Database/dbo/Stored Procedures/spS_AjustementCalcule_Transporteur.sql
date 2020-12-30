

Create Procedure [spS_AjustementCalcule_Transporteur]

-- Retrieve specific records from the [AjustementCalcule_Transporteur] table depending on the input parameters you supply.

(
 @ID [int] = Null -- for [AjustementCalcule_Transporteur].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Transporteur].[AjustementID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) = Null -- for [AjustementCalcule_Transporteur].[MunicipaliteID] column
,@LivraisonID [int] = Null -- for [AjustementCalcule_Transporteur].[LivraisonID] column
,@TransporteurID [varchar](15) = Null -- for [AjustementCalcule_Transporteur].[TransporteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Transporteur].[FactureID] column
,@ZoneID [varchar](2) = Null -- for [AjustementCalcule_Transporteur].[ZoneID] column
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

		 [AjustementCalcule_Transporteur_Records].[ID]
		,[AjustementCalcule_Transporteur_Records].[DateCalcul]
		,[AjustementCalcule_Transporteur_Records].[AjustementID]
		,[AjustementCalcule_Transporteur_Records].[UniteID]
		,[AjustementCalcule_Transporteur_Records].[MunicipaliteID]
		,[AjustementCalcule_Transporteur_Records].[LivraisonID]
		,[AjustementCalcule_Transporteur_Records].[TransporteurID]
		,[AjustementCalcule_Transporteur_Records].[Volume]
		,[AjustementCalcule_Transporteur_Records].[Taux]
		,[AjustementCalcule_Transporteur_Records].[Montant]
		,[AjustementCalcule_Transporteur_Records].[Facture]
		,[AjustementCalcule_Transporteur_Records].[FactureID]
		,[AjustementCalcule_Transporteur_Records].[ErreurCalcul]
		,[AjustementCalcule_Transporteur_Records].[ErreurDescription]
		,[AjustementCalcule_Transporteur_Records].[ZoneID]

		From [fnAjustementCalcule_Transporteur](@ID, @AjustementID, @UniteID, @MunicipaliteID, @LivraisonID, @TransporteurID, @FactureID, @ZoneID) As [AjustementCalcule_Transporteur_Records]
	End

Else

	Begin
		Select

		 [AjustementCalcule_Transporteur_Records].[ID]
		,[AjustementCalcule_Transporteur_Records].[DateCalcul]
		,[AjustementCalcule_Transporteur_Records].[AjustementID]
		,[AjustementCalcule_Transporteur_Records].[UniteID]
		,[AjustementCalcule_Transporteur_Records].[MunicipaliteID]
		,[AjustementCalcule_Transporteur_Records].[LivraisonID]
		,[AjustementCalcule_Transporteur_Records].[TransporteurID]
		,[AjustementCalcule_Transporteur_Records].[Volume]
		,[AjustementCalcule_Transporteur_Records].[Taux]
		,[AjustementCalcule_Transporteur_Records].[Montant]
		,[AjustementCalcule_Transporteur_Records].[Facture]
		,[AjustementCalcule_Transporteur_Records].[FactureID]
		,[AjustementCalcule_Transporteur_Records].[ErreurCalcul]
		,[AjustementCalcule_Transporteur_Records].[ErreurDescription]
		,[AjustementCalcule_Transporteur_Records].[ZoneID]

		From [fnAjustementCalcule_Transporteur](@ID, @AjustementID, @UniteID, @MunicipaliteID, @LivraisonID, @TransporteurID, @FactureID, @ZoneID) As [AjustementCalcule_Transporteur_Records]

		For XML Auto, Elements, XMLData, BINARY BASE64
	End

Return(@@RowCount)


