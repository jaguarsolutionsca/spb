CREATE PROCEDURE [app].[Lookup_Insert]
(
    @_uid int,
    @CIE int NULL,
    @Groupe nvarchar(12),
    @ParentGroupe nvarchar(12) NULL,
    @Code nvarchar(12) NULL,
    @Description nvarchar(50),
    @Value1 nvarchar(50) NULL,
    @Value2 nvarchar(50) NULL,
    @Value3 varchar(1024) NULL,
    @Started int,
    @Ended int NULL,
    @SortOrder int NULL
)
AS
BEGIN
SET NOCOUNT ON
;

INSERT INTO Lookup
(CIE,Groupe,ParentGroupe,Code,Description,Value1,Value2,Value3,Started,Ended,SortOrder,Created,Updated,UpdatedBy)
VALUES (
    @CIE,
    @Groupe,
    @ParentGroupe,
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
    @_uid
);
DECLARE @ID int = (SELECT CAST(SCOPE_IDENTITY() as int));
SELECT @ID;


END