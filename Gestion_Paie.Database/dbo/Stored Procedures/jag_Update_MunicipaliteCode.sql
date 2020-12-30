

CREATE PROCEDURE dbo.jag_Update_MunicipaliteCode
	(
		@OldID VARCHAR(6),
		@NewID VARCHAR(6)
	)
AS

SET NOCOUNT ON

UPDATE Municipalite SET [ID] = @NewID WHERE [ID] = @OldID

