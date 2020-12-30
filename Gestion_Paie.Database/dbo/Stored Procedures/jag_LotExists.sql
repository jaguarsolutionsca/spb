


CREATE  PROCEDURE dbo.jag_LotExists
	(
		@CantonID [varchar](6) = Null  -- for [Lot].[CantonID] column
		, @Rang [varchar](25) = Null  -- for [Lot].[Rang] column
		, @Lot [varchar](6) = Null  -- for [Lot].[Lot] column
		, @Sequence [varchar](6) = Null  -- for [Lot].[Sequence] column
		, @Partie [bit] = Null  -- for [Lot].[Partie] column
		, @Cadastre [int] = Null -- for [Lot].[Cadastre] column
		, @Matricule [varchar](20) = Null -- for [Lot].[Matricule] column
	)
AS

SELECT
L.ID AS [ID]
FROM Lot L

WHERE 
(
((@CantonID IS NULL) OR (L.CantonID = @CantonID))
AND ((@Rang IS NULL) OR (L.Rang = @Rang))
AND ((@Lot IS NULL) OR (L.Lot = @Lot))
AND ((@Sequence IS NULL) OR (L.Sequence = @Sequence))
AND ((@Partie IS NULL) OR (L.Partie = @Partie))
AND ((@Cadastre IS NULL) OR (L.Cadastre = @Cadastre))
)
or ((@Cadastre is not null) and (L.Cadastre = @Cadastre))     --doit etre unique
or ((@Matricule is not null) and (L.Matricule = @Matricule))  --doit etre unique




