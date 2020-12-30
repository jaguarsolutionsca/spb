

Create Procedure [spS_Municipalite_Secteur_Display]

(
 @MunicipaliteID [varchar](6) = Null -- for [Municipalite_Secteur].[MunicipaliteID] column
,@Secteur [varchar](2) = Null -- for [Municipalite_Secteur].[Secteur] column
)

-- Returns the number of records found

As


--	You can make changes to this SQL code. It will NOT be lost if
--	the code is regenerated.


Select
 [Municipalite_Secteur_Records].[ID1]
,[Municipalite_Secteur_Records].[ID2]
,[Municipalite_Secteur_Records].[Display]

From [fnMunicipalite_Secteur_Display](@MunicipaliteID, @Secteur) As [Municipalite_Secteur_Records]

Return(@@RowCount)


