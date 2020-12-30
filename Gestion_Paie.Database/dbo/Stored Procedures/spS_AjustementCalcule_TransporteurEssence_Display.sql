Create Procedure [dbo].[spS_AjustementCalcule_TransporteurEssence_Display]

(
 @ID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_TransporteurEssence].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_TransporteurEssence].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[LivraisonDetailID] column
,@TransporteurID [varchar](15) = Null -- for [AjustementCalcule_TransporteurEssence].[TransporteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_TransporteurEssence].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_TransporteurEssence].[Code] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [AjustementCalcule_TransporteurEssence_Records].[ID1]
,[AjustementCalcule_TransporteurEssence_Records].[Display]

From [fnAjustementCalcule_TransporteurEssence_Display](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @TransporteurID, @FactureID, @Code) As [AjustementCalcule_TransporteurEssence_Records]

Return(@@RowCount)
