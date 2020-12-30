

Create Procedure [spS_IndexationCalcule_Producteur_Display]

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
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [IndexationCalcule_Producteur_Records].[ID1]
,[IndexationCalcule_Producteur_Records].[Display]

From [fnIndexationCalcule_Producteur_Display](@ID, @TypeIndexation, @IndexationID, @IndexationDetailID, @LivraisonID, @LivraisonDetailID, @ProducteurID, @ContratID, @EssenceID, @Code, @UniteID, @FactureID) As [IndexationCalcule_Producteur_Records]

Return(@@RowCount)


