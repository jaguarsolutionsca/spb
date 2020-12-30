

Create Procedure [spS_AjustementCalcule_Producteur_Display]

(
 @ID [int] = Null -- for [AjustementCalcule_Producteur].[ID] column
,@AjustementID [int] = Null -- for [AjustementCalcule_Producteur].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [AjustementCalcule_Producteur].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [AjustementCalcule_Producteur].[UniteID] column
,@LivraisonDetailID [int] = Null -- for [AjustementCalcule_Producteur].[LivraisonDetailID] column
,@ProducteurID [varchar](15) = Null -- for [AjustementCalcule_Producteur].[ProducteurID] column
,@FactureID [int] = Null -- for [AjustementCalcule_Producteur].[FactureID] column
,@Code [char](4) = Null -- for [AjustementCalcule_Producteur].[Code] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [AjustementCalcule_Producteur_Records].[ID1]
,[AjustementCalcule_Producteur_Records].[Display]

From [fnAjustementCalcule_Producteur_Display](@ID, @AjustementID, @EssenceID, @UniteID, @LivraisonDetailID, @ProducteurID, @FactureID, @Code) As [AjustementCalcule_Producteur_Records]

Return(@@RowCount)


