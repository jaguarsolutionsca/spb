








CREATE Procedure jag_ListView_Municipalite
(
 @ID [varchar](6) = Null -- for [Municipalite].[ID] column
,@MrcID [varchar](6) = Null -- for [Municipalite].[MrcID] column
,@AgenceID [varchar](4) = Null -- for [Municipalite].[AgenceID] column
,@Actif bit = null
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 

		Select

		 [Municipalite_Records].[Description]
		,[Municipalite_Records].[ID]
		,([Municipalite_Records].[MrcID]+' - '+[Municipalite_Records].[MrcID_Description]) as [MRC]
		,([Municipalite_Records].[AgenceID]+' - '+[Municipalite_Records].[AgenceID_Description]) as [Agence]		
		,[Municipalite_Records].[Actif]
		
		From [fnMunicipalite_Full](@ID, @MrcID, @AgenceID) As [Municipalite_Records]
		
		where ((@Actif is null) or ([Municipalite_Records].[Actif] = @Actif))
		order by [Municipalite_Records].[Description]


Return(@@RowCount)



