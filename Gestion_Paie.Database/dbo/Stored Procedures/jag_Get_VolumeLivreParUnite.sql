

CREATE PROCEDURE dbo.jag_Get_VolumeLivreParUnite
	(
		@ContingentementID INT,
		@UniteID varchar(6),
		@Volume float OUTPUT
	)
AS
	
SELECT @Volume = dbo.jag_GetVolumeLivreParUnite (@ContingentementID, @UniteID)



