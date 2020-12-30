

CREATE PROCEDURE dbo.jag_Delete_Contingentement
	(
		@UsineID varchar(6) = NULL
		,@RegroupementID int = NULL
		,@Annee	int
		,@EssenceID varchar(6) = NULL
		,@Code char(4) = NULL
		,@UniteMesureID varchar(6)
		,@ContingentUsine [bit] = NULL	
	)
AS

SET NOCOUNT ON

If @ContingentUsine Is Null
	Set @ContingentUsine = 0

IF (@ContingentUsine = 1)
BEGIN
	DELETE Contingentement
	WHERE (ContingentUsine = @ContingentUsine)
	AND (UsineID = @UsineID)
	AND (Annee = @Annee)
	AND (EssenceID = @EssenceID)
	AND (Code = @Code)
	AND (UniteMesureID = @UniteMesureID)
END
ELSE
BEGIN
	DELETE Contingentement
	WHERE (ContingentUsine = @ContingentUsine)
	AND (RegroupementID = @RegroupementID)
	AND (Annee = @Annee)
	AND (UniteMesureID = @UniteMesureID)
END

RETURN 









