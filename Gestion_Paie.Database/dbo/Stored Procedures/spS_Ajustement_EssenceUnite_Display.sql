CREATE Procedure [dbo].[spS_Ajustement_EssenceUnite_Display]

(
 @AjustementID [int] = Null -- for [Ajustement_EssenceUnite].[AjustementID] column
,@EssenceID [varchar](6) = Null -- for [Ajustement_EssenceUnite].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [Ajustement_EssenceUnite].[UniteID] column
,@Code [char](4) = Null -- for [Ajustement_EssenceUnite].[Code] column
,@ContratID [varchar](10) = Null -- for [Ajustement_EssenceUnite].[ContratID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Ajustement_EssenceUnite_Records].[ID1]
,[Ajustement_EssenceUnite_Records].[ID2]
,[Ajustement_EssenceUnite_Records].[ID3]
,[Ajustement_EssenceUnite_Records].[ID4]
,[Ajustement_EssenceUnite_Records].[Display]

From [fnAjustement_EssenceUnite_Display](@AjustementID, @EssenceID, @UniteID, @Code, @ContratID) As [Ajustement_EssenceUnite_Records]

Return(@@RowCount)
