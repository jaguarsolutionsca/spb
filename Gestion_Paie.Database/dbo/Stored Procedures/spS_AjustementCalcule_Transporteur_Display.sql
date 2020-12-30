

Create Procedure [spS_AjustementCalcule_Transporteur_Display]

(
 @ID [int] = Null -- for [AjustementCalcule_Transporteur].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Transporteur].[AjustementID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Transporteur].[UniteID] column
,@MunicipaliteID [varchar](6) = Null -- for [AjustementCalcule_Transporteur].[MunicipaliteID] column
,@LivraisonID [int] = Null -- for [AjustementCalcule_Transporteur].[LivraisonID] column
,@TransporteurID [varchar](15) = Null -- for [AjustementCalcule_Transporteur].[TransporteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Transporteur].[FactureID] column
,@ZoneID [varchar](2) = Null -- for [AjustementCalcule_Transporteur].[ZoneID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [AjustementCalcule_Transporteur_Records].[ID1]
,[AjustementCalcule_Transporteur_Records].[Display]

From [fnAjustementCalcule_Transporteur_Display](@ID, @AjustementID, @UniteID, @MunicipaliteID, @LivraisonID, @TransporteurID, @FactureID, @ZoneID) As [AjustementCalcule_Transporteur_Records]

Return(@@RowCount)


