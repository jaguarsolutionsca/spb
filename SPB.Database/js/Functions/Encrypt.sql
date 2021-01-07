CREATE FUNCTION [js].[Encrypt]
(@clearText NVARCHAR (MAX) NULL)
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [Jaguar].[UserDefinedFunctions].[Encrypt]

