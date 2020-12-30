

CREATE PROCEDURE dbo.jag_GetFirst_LotID
	(
		@CantonID varchar(6) output,
		@Rang varchar(25) output,
		@Lot varchar(6) output,
		@LotID int output
	)
AS
	
SELECT TOP 1
@CantonID = CantonID, 
@Rang = Rang, 
@Lot = Lot,
@LotID = [ID]
FROM Lot
ORDER BY [CantonID], [Rang], [Lot], [ID] ASC
	
RETURN




