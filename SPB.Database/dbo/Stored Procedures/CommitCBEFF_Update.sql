
CREATE PROCEDURE [dbo].[CommitCBEFF_Update]
(
	@_uid int,
    @ID int,
    @Year int,
    @RegionLUID int,
    @Details nvarchar(50) NULL,
    @MonthPaid nvarchar(25) NULL,
    @Paid bit,
    @Amount money,
    @Comment nvarchar(50) NULL,
    @Archive bit,
    @Updated datetime,
    @UpdatedBy int
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS(
    SELECT *
    FROM CommitCBEFF
    WHERE ID = @ID AND Updated > @Updated
)
    THROW 50000 , 'Concurrency Error', 1
;

    UPDATE CommitCBEFF
    SET
        Year = @Year,
        RegionLUID = @RegionLUID,
        Details = @Details,
        MonthPaid = @MonthPaid,
        Paid = @Paid,
        Amount = @Amount,
        Comment = @Comment,
        Archive = @Archive,
        Updated = GETDATE(),
        UpdatedBy = @UpdatedBy
    WHERE ID = @ID
    ;


END