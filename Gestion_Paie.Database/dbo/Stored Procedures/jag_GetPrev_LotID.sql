

CREATE PROCEDURE dbo.jag_GetPrev_LotID
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
WHERE (CONVERT(char(6), [CantonID])+CONVERT(char(6), [Rang])+CONVERT(char(6), [Lot])+CONVERT(char(10), [ID])) < (CONVERT(char(6), @CantonID)+CONVERT(char(6), @Rang)+CONVERT(char(6), @Lot)+CONVERT(char(10), @LotID))
order by (CONVERT(char(6), [CantonID])+CONVERT(char(6), [Rang])+CONVERT(char(6), [Lot])+CONVERT(char(10), [ID])) desc

RETURN




