








CREATE PROCEDURE dbo.jag_GetFirst_ContingentementID
	(
		@ID int output
		,@ContingentUsine [bit] = Null
	)
AS

SET @ID = NULL

If @ContingentUsine Is Null
	Set @ContingentUsine = 0

If @ContingentUsine = 1
	Begin
		SELECT TOP 1
		@ID = [ID]
		FROM Contingentement
		WHERE ([ContingentUsine] = @ContingentUsine)	
		AND PeriodeContingentement = 1
		ORDER BY Annee ASC, UsineID ASC, EssenceID ASC, UniteMesureID ASC
	End
Else IF @ContingentUsine = 0
BEGIN
Begin
		SELECT TOP 1
		@ID = [ID]
		FROM Contingentement
		WHERE ([ContingentUsine] = @ContingentUsine)	
		AND PeriodeContingentement = 1
		ORDER BY Annee ASC, RegroupementID ASC, UniteMesureID ASC
	End
END








