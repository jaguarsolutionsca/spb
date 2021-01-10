// File: Component/DataFile.cs

namespace BaseApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    internal class DataFile
    {
        public int ID { get; set; }
        public string tableName { get; set; }
        public int tableID { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Mime { get; set; }
        public string Comment { get; set; }
        public bool Archive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
    }

    internal class DataFile_Search
    {
        public int TotalCount { get; set; }
        public int ID { get; set; }
        public string tableName { get; set; }
        public int tableID { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Mime { get; set; }
        public string Comment { get; set; }
        public bool Archive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
        public string By { get; set; }
    }

    internal class DataFile_Detail
    {
        public int ID { get; set; }
        public string tableName { get; set; }
        public int tableID { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Mime { get; set; }
        public string Comment { get; set; }
        public bool Archive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
        public string By { get; set; }
    }

    internal partial class Repo
    {
        public List<DataFile> DataFile_Where(string where = "WHERE 1=0")
        {
            var list = new List<DataFile>();

            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[DataFile]";
                var columns = "ID,tableName,tableID,Name,Size,Mime,Comment,Archive,Created,Updated,UpdatedBy";
                command.CommandText = $"SELECT {columns} FROM {table} {where}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new DataFile();
                        var ix = -1;
                        ix++; entity.ID = reader.GetInt32(ix);
                        ix++; entity.tableName = reader.GetString(ix);
                        ix++; entity.tableID = reader.GetInt32(ix);
                        ix++; entity.Name = reader.GetString(ix);
                        ix++; entity.Size = reader.GetInt64(ix);
                        ix++; entity.Mime = reader.GetString(ix);
                        ix++; entity.Comment = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Archive = reader.GetBoolean(ix);
                        ix++; entity.Created = reader.GetDateTime(ix);
                        ix++; entity.Updated = reader.GetDateTime(ix);
                        ix++; entity.UpdatedBy = reader.GetInt32(ix);
                        list.Add(entity);
                    }
                }
            }

            return list;
        }

        public PagedList<DataFile_Search, DTO.DataFile_Search_Filter> spDataFile_Search(DTO.Pager<DTO.DataFile_Search_Filter> pagerData)
        {
            var list = new PagedList<DataFile_Search, DTO.DataFile_Search_Filter>(pagerData);

            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[DataFile_Search]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pageNo", pagerData.pageNo);
                command.Parameters.AddWithValue("@pageSize", pagerData.pageSize);
                command.Parameters.AddWithValue("@sortColumn", (object)pagerData.sortColumn ?? DBNull.Value);
                command.Parameters.AddWithValue("@sortDirection", (object)pagerData.sortDirection ?? DBNull.Value);
                command.Parameters.AddWithValue("@searchText", (object)pagerData.searchText ?? DBNull.Value);
                command.Parameters.AddWithValue("@tableName", pagerData.filter.tableName);
                command.Parameters.AddWithValue("@tableID", pagerData.filter.tableID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new DataFile_Search();
                        var ix = -1;
                        ix++; entity.TotalCount = reader.GetInt32(ix);
                        ix++; entity.ID = reader.GetInt32(ix);
                        ix++; entity.tableName = reader.GetString(ix);
                        ix++; entity.tableID = reader.GetInt32(ix);
                        ix++; entity.Name = reader.GetString(ix);
                        ix++; entity.Size = reader.GetInt64(ix);
                        ix++; entity.Mime = reader.GetString(ix);
                        ix++; entity.Comment = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Archive = reader.GetBoolean(ix);
                        ix++; entity.Created = reader.GetDateTime(ix);
                        ix++; entity.Updated = reader.GetDateTime(ix);
                        ix++; entity.UpdatedBy = reader.GetInt32(ix);
                        ix++; entity.By = reader.GetString(ix);
                        list.Add(entity);
                    }
                }
            }

            list.Paginator.RowCount = (list.Count > 0 ? list[0].TotalCount : 0);
            return list;
        }

        public DataFile_Detail spDataFile_Detail(int id)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[DataFile_Select]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var entity = new DataFile_Detail();
                        var ix = -1;
                        ix++; entity.ID = reader.GetInt32(ix);
                        ix++; entity.tableName = reader.GetString(ix);
                        ix++; entity.tableID = reader.GetInt32(ix);
                        ix++; entity.Name = reader.GetString(ix);
                        ix++; entity.Size = reader.GetInt64(ix);
                        ix++; entity.Mime = reader.GetString(ix);
                        ix++; entity.Comment = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Archive = reader.GetBoolean(ix);
                        ix++; entity.Created = reader.GetDateTime(ix);
                        ix++; entity.Updated = reader.GetDateTime(ix);
                        ix++; entity.UpdatedBy = reader.GetInt32(ix);
                        ix++; entity.By = reader.GetString(ix);
                        return entity;
                    }
                    return null;
                }
            }
        }

        public void spDataFile_Create(DTO.DataFile_Model model)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[DataFile_Create]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tableName", model.tableName);
                command.Parameters.AddWithValue("@tableID", model.tableID);
                command.Parameters.AddWithValue("@Name", model.name);
                command.Parameters.AddWithValue("@Size", model.size);
                command.Parameters.AddWithValue("@Mime", model.mime);
                command.Parameters.AddWithValue("@Comment", string.IsNullOrEmpty(model.comment) ? DBNull.Value : (object)model.comment);
                command.Parameters.AddWithValue("@Archive", model.archive);
                command.Parameters.AddWithValue("@UpdatedBy", model.updatedBy);

                var id = new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(id);
                command.ExecuteNonQuery();

                model.id = (int)id.Value;
            }
        }

        public void spDataFile_Update(DTO.DataFile_Model model)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[DataFile_Update]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", model.id);
                command.Parameters.AddWithValue("@Name", model.name);
                command.Parameters.AddWithValue("@Comment", string.IsNullOrEmpty(model.comment) ? DBNull.Value : (object)model.comment);
                command.Parameters.AddWithValue("@Archive", model.archive);
                command.Parameters.AddWithValue("@UpdatedBy", model.updatedBy);
                command.Parameters.AddWithValue("@concurrency", model.updatedUtc.ToLocalTime());
                command.ExecuteNonQuery();
            }
        }

        public void spDataFile_Delete(int id, DateTime updatedUtc)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[DataFile_Delete]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@concurrency", updatedUtc.ToLocalTime());
                command.ExecuteNonQuery();
            }
        }
    }
}

namespace BaseApp.DTO
{
    using System;
    using System.Collections.Generic;
    using BaseApp.Common;

    public class DataFile_Search
    {
        public int totalCount { get; set; }
        public int id { get; set; }
        public string tableName { get; set; }
        public int tableID { get; set; }
        public string name { get; set; }
        public long size { get; set; }
        public string mime { get; set; }
        public string comment { get; set; }
        public bool archive { get; set; }
        public DateTime createdUtc { get; set; }
        public DateTime updatedUtc { get; set; }
        public int updatedBy { get; set; }
        public string by { get; set; }
    }

    public class DataFile_Search_Key
    {

    }

    public class DataFile_Search_Filter : DataFile_Search_Key
    {
        public string tableName { get; set; }
        public int tableID { get; set; }
    }

    public class DataFile_Detail
    {
        public object xtra { get; set; }
        public string tableName { get; set; }
        public int tableID { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public long size { get; set; }
        public string mime { get; set; }
        public string comment { get; set; }
        public bool archive { get; set; }
        public DateTime createdUtc { get; set; }
        public DateTime updatedUtc { get; set; }
        public int updatedBy { get; set; }
        public string by { get; set; }
    }

    public class DataFile_Detail_PK
    {
        public string tableName { get; set; }
        public int tableID { get; set; }
        public int fileID { get; set; }
        public DateTime updatedUtc { get; set; }
    }

    public class DataFile_Model
    {
        public string tableName { get; set; }
        public int tableID { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public long size { get; set; }
        public string mime { get; set; }
        public string comment { get; set; }
        public bool archive { get; set; }
        public DateTime createdUtc { get; set; }
        public DateTime updatedUtc { get; set; }
        public int updatedBy { get; set; }
        public string by { get; set; }

        internal void Validate()
        {
            if (string.IsNullOrEmpty(name))
                throw new ValidationException("No file was submitted");

            if (name.Length > 256)
                throw new ValidationException("Name is too long (max length = 256)");

            if (mime.Length > 100)
                throw new ValidationException("Mime is too long (max length = 100)");

            if (comment?.Length > 256)
                throw new ValidationException("Comment is too long (max length = 256)");

        }
    }
}

namespace BaseApp.Mapper
{
    using BaseApp.Common;
    using System;
    using System.Collections.Generic;

    internal static partial class Mapper
    {
        public static DTO.DataFile_Search ToDTO(this DAL.DataFile_Search entity)
        {
            return new DTO.DataFile_Search
            {
                totalCount = entity.TotalCount,
                id = entity.ID,
                name = entity.Name,
                size = entity.Size,
                mime = entity.Mime,
                comment = entity.Comment,
                archive = entity.Archive,
                createdUtc = entity.Created,
                updatedUtc = entity.Updated,
                updatedBy = entity.UpdatedBy,
                by = entity.By,
            };
        }

        public static DTO.PagedList<DTO.DataFile_Search, DTO.DataFile_Search_Filter> ToDTO(this DAL.PagedList<DAL.DataFile_Search, DTO.DataFile_Search_Filter> entities, object xtra = null)
        {
            var list = new List<DTO.DataFile_Search>();
            foreach (var entity in entities)
            {
                list.Add(entity.ToDTO());
            }
            return new DTO.PagedList<DTO.DataFile_Search, DTO.DataFile_Search_Filter>
            {
                xtra = xtra,
                pager = entities.Paginator.ToDTO<DTO.DataFile_Search_Filter>(),
                list = list
            };
        }

        public static DTO.DataFile_Detail ToDTO(this DAL.DataFile_Detail entity, object xtra = null)
        {
            return new DTO.DataFile_Detail
            {
                xtra = xtra,
                tableName = entity.tableName,
                tableID = entity.tableID,
                id = entity.ID,
                name = entity.Name,
                size = entity.Size,
                mime = entity.Mime,
                comment = entity.Comment,
                archive = entity.Archive,
                createdUtc = entity.Created,
                updatedUtc = entity.Updated,
                updatedBy = entity.UpdatedBy,
                by = entity.By,
            };
        }
    }
}

namespace BaseApp.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using BaseApp.Common;
    using BaseApp.DTO;
    using BaseApp.Mapper;

    public partial interface IAppService
    {
        PagedList<DataFile_Search, DataFile_Search_Filter> Search_DataFile(Pager<DataFile_Search_Filter> pagerData);
        DataFile_Detail Get_DataFile(string tableName, int tableID, int id);
        DataFile_Detail Get_DataFile(int id);
        DataFile_Detail GetNew_DataFile(string tableName, int tableID);
        DataFile_Detail_PK Create_DataFile(DataFile_Model model);
        void Update_DataFile(DataFile_Model model);
        void Delete_DataFile(int id, DateTime concurrencyUtc);
    }

    public partial class AppService
    {
        object getSummary(string tableName, int tableID)
        {
            object xtra = null;
            switch (tableName)
            {
                //case "account":
                //    xtra = repo.spAccount_Summary(tableID);
                //    break;
                default:
                    break;
            }
            return xtra;
        }

        public PagedList<DataFile_Search, DataFile_Search_Filter> Search_DataFile(Pager<DataFile_Search_Filter> pagerData)
        {
            //RequirePermission(Perm.TODO);

            var list = repo.spDataFile_Search(pagerData);
            return list.ToDTO(getSummary(pagerData.filter.tableName, pagerData.filter.tableID));
        }

        public DataFile_Detail Get_DataFile(string tableName, int tableID, int id)
        {
            //RequirePermission(Perm.TODO);

            var item = repo.spDataFile_Detail(id);
            return item.ToDTO(getSummary(tableName, tableID));
        }

        public DataFile_Detail Get_DataFile(int id)
        {
            //RequirePermission(Perm.TODO);

            var item = repo.spDataFile_Detail(id);
            return item.ToDTO();
        }

        public DataFile_Detail GetNew_DataFile(string tableName, int tableID)
        {
            //RequirePermission(Perm.TODO);

            return new DataFile_Detail
            {
                xtra = getSummary(tableName, tableID),
                tableName = tableName,
                tableID = tableID,
                archive = false,
                createdUtc = DateTime.Today,
                updatedUtc = DateTime.Today
            };
        }

        public DataFile_Detail_PK Create_DataFile(DataFile_Model model)
        {
            //RequirePermission(Perm.TODO);

            model.Validate();
            model.updatedBy = user.Get_UID();
            repo.spDataFile_Create(model);

            return new DataFile_Detail_PK
            {
                tableName = model.tableName,
                tableID = model.tableID,
                fileID = model.id
            };
        }

        public void Update_DataFile(DataFile_Model model)
        {
            //RequirePermission(Perm.TODO);

            model.Validate();
            model.updatedBy = user.Get_UID();
            repo.spDataFile_Update(model);
        }

        public void Delete_DataFile(int id, DateTime concurrencyUtc)
        {
            //RequirePermission(Perm.TODO);

            repo.spDataFile_Delete(id, concurrencyUtc);
        }
    }
}
