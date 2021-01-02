CREATE PROCEDURE [app].[Company_Update]
(
    @_uid int,
    @CIE int,
    @Name nvarchar(64),
    @Features nvarchar(2048) NULL,
    @Archive bit,
    @Updated datetime,
    @UpdatedBy int,
	@ProfileJson nvarchar(MAX)
)
AS
BEGIN
SET NOCOUNT ON
;
IF EXISTS(
    SELECT *
    FROM app.Company
    WHERE CIE = @CIE AND Updated > @Updated
)
    THROW 50000 , 'Concurrency Error', 1
;

UPDATE app.Company
SET
    Name = @Name,
    Features = @Features,
    Archive = @Archive,
    Updated = GETDATE(),
    UpdatedBy = @UpdatedBy
WHERE CIE = @CIE
;

EXEC app.CompanyProfile_Update @_uid = @_uid, @cie = @cie, @json = @ProfileJson;

END