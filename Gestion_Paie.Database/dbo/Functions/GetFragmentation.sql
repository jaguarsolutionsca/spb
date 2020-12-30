create FUNCTION [dbo].[GetFragmentation]()
RETURNS TABLE 
AS
RETURN 
(
	SELECT OBJECT_NAME(ind.OBJECT_ID) as TableName,sch.name SchemaName, ind.name IndexName,indexstats.index_type_desc,
	avg_fragmentation_in_percent,avg_page_space_used_in_percent,page_count
	 
	FROM sys.dm_db_index_physical_stats(DB_ID(DB_NAME()), NULL, NULL, NULL , 'SAMPLED') as indexstats
	INNER JOIN sys.indexes AS ind ON indexstats.object_id = ind.object_id AND indexstats.index_id = ind.index_id 
	INNER JOIN sys.objects obj on obj.object_id=indexstats.object_id
	INNER JOIN sys.schemas as sch ON sch.schema_id = obj.schema_id 

	WHERE indexstats.avg_fragmentation_in_percent > 10 AND indexstats.index_type_desc<>'HEAP'
)

