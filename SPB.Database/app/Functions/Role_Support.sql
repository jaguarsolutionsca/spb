CREATE FUNCTION [app].[Role_Support] ()
RETURNS int
AS
BEGIN
RETURN (select ID from app.PermMeta where Groupe='ROLE2EX' AND Code=1);
END