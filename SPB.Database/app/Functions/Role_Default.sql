CREATE FUNCTION [app].[Role_Default] ()
RETURNS int
AS
BEGIN
RETURN (select ID from app.PermMeta where Groupe='ROLE-ITEM' AND [Key]='DEFAULT');
END