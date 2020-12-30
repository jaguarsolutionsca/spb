

CREATE FUNCTION dbo.jag_GetLotsForContingentID
	(
		 @ContingentID varchar(15) = Null
		,@DateContingent datetime = Null
	)

RETURNS TABLE 

AS

Return
(
	select
	L.[ID]
	from Lot L
	where 
	(((L.ContingentID = @ContingentID AND L.Contingent_Date >= CONVERT(datetime, CONVERT(CHAR(15), @DateContingent, 111)))
	OR
	(((L.ContingentID IS NULL)OR(L.ContingentID = L.ProprietaireID)) AND (L.ProprietaireID = @ContingentID)))
	OR
	((L.ProprietaireID = @ContingentID)AND(L.Contingent_Date < @DateContingent)))

)

















