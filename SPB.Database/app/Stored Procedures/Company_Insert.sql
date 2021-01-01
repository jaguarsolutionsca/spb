CREATE PROCEDURE [app].[Company_Insert]
(
    @_uid int,
    @Name nvarchar(64),
    @Features nvarchar(2048) NULL,
    @Archive bit,
    @UpdatedBy int,
	@Profile char(1) NULL, -- not used, but required!
	@ProfileJson nvarchar(MAX)
)
AS
BEGIN
SET NOCOUNT ON
;

INSERT INTO app.Company
(Name,Features,Archive,Created,Updated,UpdatedBy)
VALUES (
    @Name,
    @Features,
    @Archive,
    GETDATE(),
    GETDATE(),
    @UpdatedBy
)
;
DECLARE @cie int = (SELECT CAST(SCOPE_IDENTITY() as int));

--EXEC app.CompanyProfile_Insert @cie = @cie, @json = @Profile;

SELECT @cie;
END