CREATE PROCEDURE [app].[Lookup_Insert]
(
    @_uid int,
    @ID int OUTPUT,
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
    @UpdatedBy int
)
AS
BEGIN
SET NOCOUNT ON
;

    INSERT INTO Lookup
    (CIE,Groupe,Code,Description,Value1,Value2,Value3,Started,Ended,SortOrder,Created,Updated,UpdatedBy)
    VALUES (
        @CIE,
        @Groupe,
        @Code,
        @Description,
        @Value1,
        @Value2,
        @Value3,
        @Started,
        @Ended,
        @SortOrder,
        GETDATE(),
        GETDATE(),
        @UpdatedBy
    )
    ;
    SET @ID = SCOPE_IDENTITY()
    ;


END