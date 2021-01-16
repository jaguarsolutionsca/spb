CREATE FUNCTION [app].[UserIs_Support] (@uid int)
RETURNS bit
AS
BEGIN
RETURN (CAST(CASE WHEN EXISTS(select * from app.Account where UID = @uid and RoleLUID = app.Role_Support()) THEN 1 ELSE 0 END AS bit));
END