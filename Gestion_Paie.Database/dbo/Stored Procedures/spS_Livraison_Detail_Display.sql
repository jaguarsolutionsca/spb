

Create Procedure [spS_Livraison_Detail_Display]

(
 @ID [int] = Null -- for [Livraison_Detail].[ID] column
,@LivraisonID [int] = Null -- for [Livraison_Detail].[LivraisonID] column
,@ContratID [varchar](10) = Null -- for [Livraison_Detail].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Livraison_Detail].[EssenceID] column
,@UniteMesureID [varchar](6) = Null -- for [Livraison_Detail].[UniteMesureID] column
,@ProducteurID [varchar](15) = Null -- for [Livraison_Detail].[ProducteurID] column
,@ContingentementID [int] = Null -- for [Livraison_Detail].[ContingentementID] column
,@Code [char](4) = Null -- for [Livraison_Detail].[Code] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Livraison_Detail_Records].[ID1]
,[Livraison_Detail_Records].[Display]

From [fnLivraison_Detail_Display](@ID, @LivraisonID, @ContratID, @EssenceID, @UniteMesureID, @ProducteurID, @ContingentementID, @Code) As [Livraison_Detail_Records]

Return(@@RowCount)


