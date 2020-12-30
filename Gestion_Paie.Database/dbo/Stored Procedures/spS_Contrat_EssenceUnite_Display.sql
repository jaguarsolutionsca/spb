

Create Procedure [spS_Contrat_EssenceUnite_Display]

(
 @ContratID [varchar](10) = Null -- for [Contrat_EssenceUnite].[ContratID] column
,@EssenceID [varchar](6) = Null -- for [Contrat_EssenceUnite].[EssenceID] column
,@UniteID [varchar](6) = Null -- for [Contrat_EssenceUnite].[UniteID] column
,@Code [char](4) = Null -- for [Contrat_EssenceUnite].[Code] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Contrat_EssenceUnite_Records].[ID1]
,[Contrat_EssenceUnite_Records].[ID2]
,[Contrat_EssenceUnite_Records].[ID3]
,[Contrat_EssenceUnite_Records].[ID4]
,[Contrat_EssenceUnite_Records].[Display]

From [fnContrat_EssenceUnite_Display](@ContratID, @EssenceID, @UniteID, @Code) As [Contrat_EssenceUnite_Records]

Return(@@RowCount)


