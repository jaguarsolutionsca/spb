
CREATE FUNCTION [app].[CsvOfString_to_Table] (@cvs nvarchar(max))
RETURNS @table TABLE (ID nvarchar(32))
AS
BEGIN

    DECLARE @id nvarchar(32);
	DECLARE @index int;
	DECLARE @len int;

    WHILE LEN(@cvs) > 0
    BEGIN
		SET @index = CHARINDEX(',', @cvs);
		SET @len = LEN(@cvs);
        SET @id = LTRIM(LEFT(@cvs, ISNULL(NULLIF(@index - 1, -1), @len)));
        SET @cvs = SUBSTRING(@cvs, ISNULL(NULLIF(@index, 0), @len) + 1, @len);

        INSERT INTO @table VALUES(@id);
    END

    RETURN
END