CREATE PROCEDURE [app].[Company_Summary]
(
    @Companyid int = NULL,
    @Accountid int = NULL,
    @Lookupid int = NULL,
    @Permid int = NULL
)
AS
BEGIN
SET NOCOUNT ON
;
IF (@Accountid IS NOT NULL)
    SELECT @Companyid = CIE FROM app.Account WHERE UID = @Accountid;

IF (@Lookupid IS NOT NULL)
    SELECT @Companyid = CIE FROM app.Lookup WHERE ID = @Lookupid;

IF (@Permid IS NOT NULL)
    SELECT @Companyid = CIE FROM app.Perm WHERE PermID = @Permid;

SELECT
    (SELECT Name FROM Company WHERE CIE = @Companyid) [title],
    (SELECT COUNT(*) FROM Account WHERE CIE = @Companyid) [AccountCount],
    (SELECT COUNT(*) FROM Lookup WHERE CIE = @Companyid) [LookupCount],
    (SELECT COUNT(*) FROM Perm WHERE CIE = @Companyid) [PermCount],
    --(SELECT COUNT(*) FROM dbo.DataFile WHERE TableName = 'company' AND TableID = @Companyid AND Archive = 0) [fileCount]
    CAST(0 as int) [fileCount]
;
END