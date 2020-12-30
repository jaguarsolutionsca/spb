
CREATE PROCEDURE [dbo].[DatabaseReIndex] 
(@Reindex as bit = 0)
AS
BEGIN
SET NOCOUNT ON;

	IF  EXISTS(SELECT * FROM tempdb.sys.objects WHERE name='Indexes') BEGIN--Delete Temp Table if exists, then create
	DROP TABLE TempDb.dbo.Indexes
	END
	CREATE TABLE TempDb.dbo.Indexes(IndexTempID INT IDENTITY(1,1),SchemaName NVARCHAR(128),TableName NVARCHAR(128),IndexName NVARCHAR(128),IndexFrag FLOAT)

	INSERT INTO TempDb.dbo.Indexes(SchemaName,TableName,IndexName,IndexFrag)
	select top 50 SchemaName, TableName, IndexName,avg_fragmentation_in_percent  from GetFragmentation() ORDER BY avg_fragmentation_in_percent DESC

	DECLARE @IndexTempID BIGINT=0,@SchemaName NVARCHAR(128),@TableName NVARCHAR(128),@IndexName NVARCHAR(128),@IndexFrag FLOAT
	SELECT * FROM TempDb.dbo.Indexes--View your results, comment out if not needed...
	-- Loop through the indexes
	WHILE @IndexTempID IS NOT NULL and @Reindex=1 BEGIN
    	SELECT @SchemaName=SchemaName,@TableName=TableName,@IndexName=IndexName,@IndexFrag=IndexFrag FROM TempDb.dbo.Indexes WHERE IndexTempID=@IndexTempID
    	IF @IndexName IS NOT NULL AND @SchemaName IS NOT NULL AND @TableName IS NOT NULL BEGIN
    	IF @IndexFrag<30. BEGIN--Low fragmentation can use re-organise, set at 30 as per most articles
    	PRINT 'ALTER INDEX ' + @IndexName + N' ON ' + @SchemaName + N'.' + @TableName + N' REORGANIZE'
    	EXEC('ALTER INDEX ' + @IndexName + N' ON ' + @SchemaName + N'.' + @TableName + N' REORGANIZE')
    	END
    	ELSE BEGIN--High fragmentation needs re-build
    	PRINT 'ALTER INDEX ' + @IndexName + N' ON ' + @SchemaName + N'.' + @TableName + N' REBUILD'
    	EXEC('ALTER INDEX ' + @IndexName + N' ON ' + @SchemaName + N'.' + @TableName + N' REBUILD')
    	END
    	END
    	SET @IndexTempID=(SELECT MIN(IndexTempID) FROM TempDb.dbo.Indexes WHERE IndexTempID>@IndexTempID)
	END
	
	DROP TABLE TempDb.dbo.Indexes
 
END