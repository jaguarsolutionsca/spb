CREATE FUNCTION [js].[Decrypt]
(@cryptedText NVARCHAR (MAX) NULL)
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [Jaguar].[UserDefinedFunctions].[Decrypt]

