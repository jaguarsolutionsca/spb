

CREATE PROCEDURE dbo.jag_GetPrev_ContingentementID
	(
		@ID int = NULL output
		,@UsineID varchar(6) = NULL
		,@RegroupementID int = NULL
		,@Annee	int
		,@EssenceID varchar(6) = NULL
		,@Code char(4) = NULL
		,@UniteMesureID varchar(6)
		,@ContingentUsine [bit] = NULL	
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
		WHERE (Annee = @Annee)
		AND ((CONVERT(char(6), [UsineID])+CONVERT(char(6), [EssenceID])+[Code]+CONVERT(char(6), [UniteMesureID])) < (CONVERT(char(6), @UsineID)+CONVERT(char(6), @EssenceID)+@Code+CONVERT(char(6), @UniteMesureID)))
		AND ([ContingentUsine] = @ContingentUsine)
		ORDER BY UsineID, EssenceID, UniteMesureID, PeriodeContingentement ASC

		IF (@ID IS NULL)
		BEGIN
			SELECT TOP 1
			@ID = [ID]
			FROM Contingentement
			WHERE (Annee < @Annee)
			AND ([ContingentUsine] = @ContingentUsine)
			ORDER BY UsineID, EssenceID, UniteMesureID, PeriodeContingentement ASC
		END
	End
Else IF @ContingentUsine = 0
BEGIN
Begin
		SELECT TOP 1
		
		@ID = [ID]
		
		FROM Contingentement
		WHERE (Annee = @Annee)
		AND ((CONVERT(char(6), [RegroupementID])+CONVERT(char(6), [UniteMesureID])) < (CONVERT(char(6), @RegroupementID)+CONVERT(char(6), @UniteMesureID)))
		AND ([ContingentUsine] = @ContingentUsine)
		ORDER BY RegroupementID, UniteMesureID, PeriodeContingentement ASC

		IF (@ID IS NULL)
		BEGIN
			SELECT TOP 1
			@ID = [ID]
			FROM Contingentement
			WHERE (Annee < @Annee)
			AND ([ContingentUsine] = @ContingentUsine)
			ORDER BY RegroupementID, UniteMesureID, PeriodeContingentement ASC
		END
	End
END








