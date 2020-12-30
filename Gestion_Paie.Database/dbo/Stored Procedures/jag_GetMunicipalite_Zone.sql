

CREATE Procedure [jag_GetMunicipalite_Zone]

-- Retrieve specific records from the [Municipalite_Zone] table depending on the input parameters you supply.

(
 @ID [varchar](2) = Null -- for [Municipalite_Zone].[ID] column
,@MunicipaliteID [varchar](6) = Null -- for [Municipalite_Zone].[MunicipaliteID] column
)

As
		Select

		 [MZ].[ID]
		,[MZ].[MunicipaliteID]
		,[MZ].[Description]
		,[M].[Description] as Municipalite
		,[MZ].[Actif]

		From 
			[Municipalite_Zone] MZ
			inner join Municipalite M on M.ID = MZ.MunicipaliteID

		where 
			((@ID is null) or (@ID = MZ.[ID]))
		and	((@MunicipaliteID is null) or (@MunicipaliteID = M.[ID]))

