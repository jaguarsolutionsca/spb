

Create Procedure [spS_Contingentement_Producteur_Display]

(
 @ContingentementID [int] = Null -- for [Contingentement_Producteur].[ContingentementID] column
,@ProducteurID [varchar](15) = Null -- for [Contingentement_Producteur].[ProducteurID] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Contingentement_Producteur_Records].[ID1]
,[Contingentement_Producteur_Records].[ID2]
,[Contingentement_Producteur_Records].[Display]

From [fnContingentement_Producteur_Display](@ContingentementID, @ProducteurID) As [Contingentement_Producteur_Records]

Return(@@RowCount)


