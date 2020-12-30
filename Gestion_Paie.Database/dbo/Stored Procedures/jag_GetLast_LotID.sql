

CREATE PROCEDURE dbo.jag_GetLast_LotID
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
ORDER BY [CantonID] desc, [Rang] desc, [Lot] desc, [ID] desc
	
RETURN




