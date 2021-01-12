CREATE PROCEDURE [app].[Lookup_Update]
(
    @_uid int,
    @ID int,
    @CIE int NULL,
    @Groupe nvarchar(12),
    @Code nvarchar(12) NULL,
    @Description nvarchar(50),
    @Value1 nvarchar(50) NULL,
    @Value2 nvarchar(50) NULL,
    @Value3 varchar(1024) NULL,
    @Started int,
    @Ended int NULL,
    @SortOrder int NULL,
    @Updated datetime,
    @UpdatedBy int
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS(
    SELECT *
    FROM Lookup
    WHERE ID = @ID AND Updated > @Updated
)
    THROW 50000 , 'Concurrency Error', 1
;

    UPDATE Lookup
    SET
        CIE = @CIE,
        Groupe = @Groupe,
        Code = @Code,
        Description = @Description,
        Value1 = @Value1,
        Value2 = @Value2,
        Value3 = @Value3,
        Started = @Started,
        Ended = @Ended,
        SortOrder = @SortOrder,
        Updated = GETDATE(),
        UpdatedBy = @UpdatedBy
    WHERE ID = @ID
    ;


END