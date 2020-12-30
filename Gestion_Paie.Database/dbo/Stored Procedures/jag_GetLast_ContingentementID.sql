








CREATE PROCEDURE dbo.jag_GetLast_ContingentementID
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
		ORDER BY Annee DESC, UsineID DESC, EssenceID DESC, UniteMesureID DESC
	End
Else IF @ContingentUsine = 0
BEGIN
Begin
		SELECT TOP 1
		@ID = [ID]
		FROM Contingentement
		WHERE ([ContingentUsine] = @ContingentUsine)	
		AND PeriodeContingentement = 1
		ORDER BY Annee DESC, RegroupementID DESC, UniteMesureID DESC
	End
END








