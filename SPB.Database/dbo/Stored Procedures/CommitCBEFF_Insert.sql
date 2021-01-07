
CREATE PROCEDURE [dbo].[CommitCBEFF_Insert]
(
	@_uid int,
    @ID int OUTPUT,
    @Year int,
    @RegionLUID int,
    @Details nvarchar(50) NULL,
    @MonthPaid nvarchar(25) NULL,
    @Paid bit,
    @Amount money,
    @Comment nvarchar(50) NULL,
    @Archive bit,
    @UpdatedBy int
)
AS
BEGIN
SET NOCOUNT ON
;

    INSERT INTO CommitCBEFF
    (Year,RegionLUID,Details,MonthPaid,Paid,Amount,Comment,Archive,Created,Updated,UpdatedBy)
    VALUES (
        @Year,
        @RegionLUID,
        @Details,
        @MonthPaid,
        @Paid,
        @Amount,
        @Comment,
        @Archive,
        GETDATE(),
        GETDATE(),
        @UpdatedBy
    )
    ;
    SET @ID = SCOPE_IDENTITY()
    ;


END