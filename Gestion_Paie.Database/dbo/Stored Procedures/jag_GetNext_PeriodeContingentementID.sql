

CREATE PROCEDURE dbo.jag_GetNext_PeriodeContingentementID
	(
		@ID int = NULL output
		,@UsineID varchar(6) = NULL
		,@RegroupementID int = NULL
		,@Annee	int
		,@EssenceID varchar(6) = NULL
		,@Code char(4) = NULL
		,@UniteMesureID varchar(6)
		,@PeriodeContingentement int
		,@ContingentUsine [bit] = NULL
	)
AS
	
If @ContingentUsine Is Null
	Set @ContingentUsine = 0
	
SET @ID = NULL

IF (@ContingentUsine = 1)
BEGIN
	SELECT TOP 1
	@ID = [ID]
	FROM Contingentement
	WHERE (ContingentUsine = @ContingentUsine)
	AND (UsineID = @UsineID)
	AND (Annee = @Annee)
	AND (EssenceID = @EssenceID)
	AND (Code = @Code)
	AND (UniteMesureID = @UniteMesureID)
	AND (PeriodeContingentement > @PeriodeContingentement)
	ORDER BY PeriodeContingentement
END
ELSE
BEGIN
	SELECT TOP 1
	@ID = [ID]
	FROM Contingentement
	WHERE (ContingentUsine = @ContingentUsine)
	AND (RegroupementID = @RegroupementID)
	AND (Annee = @Annee)
	AND (UniteMesureID = @UniteMesureID)
	AND (PeriodeContingentement > @PeriodeContingentement)
	ORDER BY PeriodeContingentement
END








