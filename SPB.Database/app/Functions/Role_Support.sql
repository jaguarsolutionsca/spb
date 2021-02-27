CREATE FUNCTION [app].[Role_Support] ()
RETURNS int
AS
BEGIN
RETURN (select ID from app.PermMeta where Groupe='ROLE-ITEM' AND [Key]='SUPPORT');
END