

CREATE PROCEDURE dbo.jag_GetNext_LotID
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
WHERE (CONVERT(char(6), [CantonID])+CONVERT(char(6), [Rang])+CONVERT(char(6), [Lot])+CONVERT(char(10), [ID])) > (CONVERT(char(6), @CantonID)+CONVERT(char(6), @Rang)+CONVERT(char(6), @Lot)+CONVERT(char(10), @LotID))
order by (CONVERT(char(6), [CantonID])+CONVERT(char(6), [Rang])+CONVERT(char(6), [Lot])+CONVERT(char(10), [ID])) ASC

IF (NOT EXISTS (SELECT * FROM Lot WHERE [CantonID] = @CantonID AND [Rang] = @Rang AND [Lot] = @Lot AND [ID] = @LotID))
BEGIN
	exec jag_GetLast_LotID @CantonID out, @Rang out, @Lot out, @LotID out
END

RETURN




