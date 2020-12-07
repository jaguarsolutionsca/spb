CREATE FUNCTION [app].[Role_Default] ()
RETURNS int
AS
BEGIN
RETURN (select ID from app.PermMeta where Groupe='ROLE2EX' AND [Key]='DEFAULT');
END