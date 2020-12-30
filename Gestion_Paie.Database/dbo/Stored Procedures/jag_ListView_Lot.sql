

CREATE Procedure jag_ListView_Lot
(
 @ID [int] = Null
,@CantonID [varchar](6) = Null -- for [Lot].[CantonID] column
,@Rang [varchar](25) = Null -- for [Lot].[Rang] column
,@Lot [varchar](6) = Null -- for [Lot].[Lot] column
,@MunicipaliteID [varchar](6) = Null -- for [Lot].[MunicipaliteID] column
,@ProprietaireID [varchar](15) = Null -- for [Lot].[ProprietaireID] column
,@ContingentID [varchar](15) = Null -- for [Lot].[ContingentID] column
,@Droit_coupeID [varchar](15) = Null -- for [Lot].[Droit_coupeID] column
,@Entente_paiementID [varchar](15) = Null -- for [Lot].[Entente_paiementID] column
,@ZoneID [varchar](2) = Null
,@Actif bit = null
)

-- Returns the number of records found

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 

		Select
		 L.[ID]
		,L.[CantonID]
		,L.[Rang]
		,Lot = 	L.[Lot] +
			case when L.[Sequence] is not null and L.[Sequence] <> '' then '-' + L.[Sequence] else '' end +
			case when L.[Partie] = 1 then '(P)' else '' end
		,Cadastre as [Désignation Cadastrale]
		,MunicipaliteID = L.[MunicipaliteID] + case when L.[ZoneID] is null or L.[ZoneID] = '0' then '' else ' (' + L.[ZoneID] + ')' end	
		,[Secteur] = case when L.[Secteur] <> 0 and L.[Secteur] is not null 
				then L.[Secteur]
				else '' end
		,(L.[ProprietaireID] + ' - ' + P.[Nom]) as [Proprietaire]
		,L.[Actif]
		
		From 
			Lot L
				left outer join Municipalite M on L.MunicipaliteID = M.[ID]
					left outer join Fournisseur P on L.ProprietaireID = P.[ID]

		where 
 				((@ID 			is null) or (@ID 			= L.[ID]))
			AND 	((@CantonID 		is null) or (@CantonID 			= L.[CantonID]))
			AND 	((@Rang 		is null) or (@Rang 			= L.[Rang]))
			AND 	((@Lot 			is null) or (@Lot 			= L.[Lot]))
			AND 	((@MunicipaliteID 	is null) or (@MunicipaliteID 		= L.[MunicipaliteID]))
			AND 	((@ProprietaireID 	is null) or (@ProprietaireID 		= L.[ProprietaireID]))
			AND 	((@ContingentID 	is null) or (@ContingentID 		= L.[ContingentID]))
			AND 	((@Droit_coupeID 	is null) or (@Droit_coupeID 		= L.[Droit_coupeID]))
			AND 	((@Entente_paiementID 	is null) or (@Entente_paiementID 	= L.[Entente_paiementID]))
			AND 	((@ZoneID 		is null) or (@ZoneID 			= L.[ZoneID]))
			AND	((@Actif 		is null) or (@Actif 			= L.[Actif]))

		ORDER BY CantonID, Rang, LEFT(('00000000'+Lot),6), L.[ID]


Return(@@RowCount)


