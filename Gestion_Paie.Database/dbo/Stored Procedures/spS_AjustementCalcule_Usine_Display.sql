

Create Procedure [spS_AjustementCalcule_Usine_Display]

(
 @ID [int] = Null -- for [AjustementCalcule_Usine].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Usine].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_Usine].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Usine].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_Usine].[LivraisonDetailID] column
,@UsineID [varchar](6) = Null -- for [AjustementCalcule_Usine].[UsineID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Usine].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_Usine].[Code] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [AjustementCalcule_Usine_Records].[ID1]
,[AjustementCalcule_Usine_Records].[Display]

From [fnAjustementCalcule_Usine_Display](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @UsineID, @FactureID, @Code) As [AjustementCalcule_Usine_Records]

Return(@@RowCount)


