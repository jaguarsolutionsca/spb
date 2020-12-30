

CREATE PROCEDURE dbo.jag_Get_VolumeLivrePourContingentementParProducteur
	(
		@ContingentementID int,
		@ProducteurID varchar(15) = NULL,
		@Volume float OUTPUT
	)
AS

SELECT @Volume = dbo.jag_GetVolumeLivrePourContingentementParProducteur (@ContingentementID, @ProducteurID)




