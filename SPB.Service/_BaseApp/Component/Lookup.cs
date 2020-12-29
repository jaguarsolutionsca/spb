// File: Component/Lookup.cs

using System;
using System.Collections.Generic;

namespace BaseApp.DAL
{
    using System.Data;
    using System.Data.SqlClient;
    using BaseApp.Common;

    internal class Lookup_Search
    {
        public int TotalCount { get; set; }
        public int ID { get; set; }
        public string Groupe { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public int Started { get; set; }
        public int? Ended { get; set; }
        public int? SortOrder { get; set; }
        public bool Archive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
        public string By { get; set; }

        internal Lookup_Search Decrypt(Crypto crypto)
        {
            By = crypto.Decrypt(By);
            return this;
        }
    }

    internal class Lookup_Detail
    {
        public int ID { get; set; }
        public string Groupe { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public int Started { get; set; }
        public int? Ended { get; set; }
        public int? SortOrder { get; set; }
        public bool Archive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
        public string By { get; set; }

        internal Lookup_Detail Decrypt(Crypto crypto)
        {
            By = crypto.Decrypt(By);
            return this;
        }
    }

    internal partial class Repo
    {
        public PagedList<Lookup_Search, DTO.Lookup_Search_Filter> spLookup_Search(DTO.Pager<DTO.Lookup_Search_Filter> pagerData)
        {
            var list = new PagedList<Lookup_Search, DTO.Lookup_Search_Filter>(pagerData);

            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[Lookup_Search]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pageNo", pagerData.pageNo);
                command.Parameters.AddWithValue("@pageSize", pagerData.pageSize);
                command.Parameters.AddWithValue("@sortColumn", (object)pagerData.sortColumn ?? DBNull.Value);
                command.Parameters.AddWithValue("@sortDirection", (object)pagerData.sortDirection ?? DBNull.Value);
                command.Parameters.AddWithValue("@searchText", (object)pagerData.searchText ?? DBNull.Value);
                command.Parameters.AddWithValue("@groupe", (object)pagerData.filter.groupe ?? DBNull.Value);
                command.Parameters.AddWithValue("@year", (object)pagerData.filter.year ?? DBNull.Value);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new Lookup_Search();
                        var ix = -1;
                        ix++; entity.TotalCount = reader.GetInt32(ix);
                        ix++; entity.ID = reader.GetInt32(ix);
                        ix++; entity.Groupe = reader.GetString(ix);
                        ix++; entity.Code = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Description = reader.GetString(ix);
                        ix++; entity.Value1 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Value2 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Value3 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Started = reader.GetInt32(ix);
                        ix++; entity.Ended = reader.IsDBNull(ix) ? (int?)null : reader.GetInt32(ix);
                        ix++; entity.SortOrder = reader.IsDBNull(ix) ? (int?)null : reader.GetInt32(ix);
                        ix++; entity.Archive = reader.GetBoolean(ix);
                        ix++; entity.Created = reader.GetDateTime(ix);
                        ix++; entity.Updated = reader.GetDateTime(ix);
                        ix++; entity.UpdatedBy = reader.GetInt32(ix);
                        ix++; entity.By = reader.GetString(ix);
                        list.Add(entity.Decrypt(crypto));
                    }
                }
            }

            list.Paginator.RowCount = (list.Count > 0 ? list[0].TotalCount : 0);
            return list;
        }

        public Lookup_Detail spLookup_Detail(int id)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[Lookup_Detail]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var entity = new Lookup_Detail();
                        var ix = -1;
                        ix++; entity.ID = reader.GetInt32(ix);
                        ix++; entity.Groupe = reader.GetString(ix);
                        ix++; entity.Code = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Description = reader.GetString(ix);
                        ix++; entity.Value1 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Value2 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Value3 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.Started = reader.GetInt32(ix);
                        ix++; entity.Ended = reader.IsDBNull(ix) ? (int?)null : reader.GetInt32(ix);
                        ix++; entity.SortOrder = reader.IsDBNull(ix) ? (int?)null : reader.GetInt32(ix);
                        ix++; entity.Archive = reader.GetBoolean(ix);
                        ix++; entity.Created = reader.GetDateTime(ix);
                        ix++; entity.Updated = reader.GetDateTime(ix);
                        ix++; entity.UpdatedBy = reader.GetInt32(ix);
                        ix++; entity.By = reader.GetString(ix);
                        return entity.Decrypt(crypto);
                    }
                    return null;
                }
            }
        }

        public void spLookup_Create(DTO.Lookup_Model model)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[Lookup_Create]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Groupe", model.groupe);
                command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(model.code) ? DBNull.Value : (object)model.code);
                command.Parameters.AddWithValue("@Description", model.description);
                command.Parameters.AddWithValue("@Value1", string.IsNullOrEmpty(model.value1) ? DBNull.Value : (object)model.value1);
                command.Parameters.AddWithValue("@Value2", string.IsNullOrEmpty(model.value2) ? DBNull.Value : (object)model.value2);
                command.Parameters.AddWithValue("@Value3", string.IsNullOrEmpty(model.value3) ? DBNull.Value : (object)model.value3);
                command.Parameters.AddWithValue("@Started", model.started);
                command.Parameters.AddWithValue("@Ended", model.ended == null ? DBNull.Value : (object)model.ended);
                command.Parameters.AddWithValue("@SortOrder", model.sortOrder == null ? DBNull.Value : (object)model.sortOrder);
                command.Parameters.AddWithValue("@Archive", model.archive);
                command.Parameters.AddWithValue("@UpdatedBy", model.updatedBy);

                var id = new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(id);
                command.ExecuteNonQuery();

                model.id = (int)id.Value;
            }
        }

        public void spLookup_Update(DTO.Lookup_Model model)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[Lookup_Update]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", model.id);
                command.Parameters.AddWithValue("@Groupe", model.groupe);
                command.Parameters.AddWithValue("@Code", string.IsNullOrEmpty(model.code) ? DBNull.Value : (object)model.code);
                command.Parameters.AddWithValue("@Description", model.description);
                command.Parameters.AddWithValue("@Value1", string.IsNullOrEmpty(model.value1) ? DBNull.Value : (object)model.value1);
                command.Parameters.AddWithValue("@Value2", string.IsNullOrEmpty(model.value2) ? DBNull.Value : (object)model.value2);
                command.Parameters.AddWithValue("@Value3", string.IsNullOrEmpty(model.value3) ? DBNull.Value : (object)model.value3);
                command.Parameters.AddWithValue("@Started", model.started);
                command.Parameters.AddWithValue("@Ended", model.ended == null ? DBNull.Value : (object)model.ended);
                command.Parameters.AddWithValue("@SortOrder", model.sortOrder == null ? DBNull.Value : (object)model.sortOrder);
                command.Parameters.AddWithValue("@Archive", model.archive);
                command.Parameters.AddWithValue("@UpdatedBy", model.updatedBy);
                command.Parameters.AddWithValue("@concurrency", model.updatedUtc.ToLocalTime());
                command.ExecuteNonQuery();
            }
        }

        public void spLookup_Delete(int id, DateTime updatedUtc)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "[dbo].[Lookup_Delete]";
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
    public class Lookup_Search
    {
        public int totalCount { get; set; }
        public int id { get; set; }
        public string groupe { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public int started { get; set; }
        public int? ended { get; set; }
        public int? sortOrder { get; set; }
        public bool archive { get; set; }
        public DateTime createdUtc { get; set; }
        public DateTime updatedUtc { get; set; }
        public int updatedBy { get; set; }
        public string by { get; set; }

        internal Lookup_Search Decrypt(Common.Crypto crypto)
        {
            by = crypto.Decrypt(by);
            return this;
        }
    }

    public class Lookup_Search_Key
    {
    }

    public class Lookup_Search_Filter : Lookup_Search_Key
    {
        public string groupe { get; set; }
        public int? year { get; set; }
    }

    public class Lookup_Detail
    {
        public object xtra { get; set; }
        public int id { get; set; }
        public string groupe { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public int started { get; set; }
        public int? ended { get; set; }
        public int? sortOrder { get; set; }
        public bool archive { get; set; }
        public DateTime createdUtc { get; set; }
        public DateTime updatedUtc { get; set; }
        public int updatedBy { get; set; }
        public string by { get; set; }
    }

    public class Lookup_Detail_PK
    {
        public int id { get; set; }
        public DateTime updatedUtc { get; set; }
    }

    public class Lookup_Model
    {
        public int id { get; set; }
        public string groupe { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public int started { get; set; }
        public int? ended { get; set; }
        public int? sortOrder { get; set; }
        public bool archive { get; set; }
        public DateTime createdUtc { get; set; }
        public DateTime updatedUtc { get; set; }
        public int updatedBy { get; set; }
        public string by { get; set; }

        internal void Validate()
        {
            if (groupe.Length > 12)
                throw new Common.ValidationException("Groupe is too long (max length = 12)");

            if (code?.Length > 9)
                throw new Common.ValidationException("Code is too long (max length = 9)");

            if (description.Length > 50)
                throw new Common.ValidationException("Description is too long (max length = 50)");

            if (value1?.Length > 50)
                throw new Common.ValidationException("Value1 is too long (max length = 50)");

            if (value2?.Length > 50)
                throw new Common.ValidationException("Value2 is too long (max length = 50)");

            if (value3?.Length > 1024)
                throw new Common.ValidationException("Value3 is too long (max length = 1024)");

            if (ended.HasValue && ended < started)
                throw new Common.ValidationException("The end year must be greater than or equal to the start year");

        }
    }

    public class Lookup
    {
        public int id { get; set; }
        public int cie { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public int started { get; set; }
        public int? ended { get; set; }
        public int? sortOrder { get; set; }
        public bool? disabled { get; set; }
    }
}

namespace BaseApp.Mapper
{
    using BaseApp.Common;
    using System;
    using System.Collections.Generic;

    internal static partial class Mapper
    {
        public static DTO.Lookup_Search ToDTO(this DAL.Lookup_Search entity)
        {
            return new DTO.Lookup_Search
            {
                totalCount = entity.TotalCount,
                id = entity.ID,
                groupe = entity.Groupe,
                code = entity.Code,
                description = entity.Description,
                value1 = entity.Value1,
                value2 = entity.Value2,
                value3 = entity.Value3,
                started = entity.Started,
                ended = entity.Ended,
                sortOrder = entity.SortOrder,
                archive = entity.Archive,
                createdUtc = entity.Created,
                updatedUtc = entity.Updated,
                updatedBy = entity.UpdatedBy,
                by = entity.By,
            };
        }

        public static DTO.PagedList<DTO.Lookup_Search, DTO.Lookup_Search_Filter> ToDTO(this DAL.PagedList<DAL.Lookup_Search, DTO.Lookup_Search_Filter> entities, object xtra = null)
        {
            var list = new List<DTO.Lookup_Search>();
            foreach (var entity in entities)
            {
                list.Add(entity.ToDTO());
            }
            return new DTO.PagedList<DTO.Lookup_Search, DTO.Lookup_Search_Filter>
            {
                xtra = xtra,
                pager = entities.Paginator.ToDTO<DTO.Lookup_Search_Filter>(),
                list = list
            };
        }

        public static DTO.Lookup_Detail ToDTO(this DAL.Lookup_Detail entity, object xtra = null)
        {
            return new DTO.Lookup_Detail
            {
                xtra = xtra,
                id = entity.ID,
                groupe = entity.Groupe,
                code = entity.Code,
                description = entity.Description,
                value1 = entity.Value1,
                value2 = entity.Value2,
                value3 = entity.Value3,
                started = entity.Started,
                ended = entity.Ended,
                sortOrder = entity.SortOrder,
                archive = entity.Archive,
                createdUtc = entity.Created,
                updatedUtc = entity.Updated,
                updatedBy = entity.UpdatedBy,
                by = entity.By,
            };
        }

        public static DTO.Lookup_Model ToModel(this DAL.Lookup_Detail entity)
        {
            return new DTO.Lookup_Model
            {
                id = entity.ID,
                groupe = entity.Groupe,
                code = entity.Code,
                description = entity.Description,
                value1 = entity.Value1,
                value2 = entity.Value2,
                value3 = entity.Value3,
                started = entity.Started,
                ended = entity.Ended,
                sortOrder = entity.SortOrder,
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
    using System.Linq;
    using System.Threading;
    using BaseApp.Common;
    using BaseApp.DTO;
    using BaseApp.Mapper;

    public partial interface IAppService
    {
        /*
        PagedList<Lookup_Search, Lookup_Search_Filter> Search_AllLookup(Pager<Lookup_Search_Filter> pagerData);
        PagedList<Lookup_Search, Lookup_Search_Filter> Search_Lookup(Pager<Lookup_Search_Filter> pagerData);
        Lookup_Detail Get_Lookup(int id);
        Lookup_Detail GetNew_Lookup(string groupe);
        Lookup_Detail_PK Create_Lookup(Lookup_Model model);
        void Update_Lookup(Lookup_Model model);
        void Delete_Lookup(int id, DateTime concurrencyUtc);
        */
        List<Lookup> Lookup_By(string groupe, int? year = null);
    }

    public partial class AppService
    {
        /*
        public PagedList<Lookup_Search, Lookup_Search_Filter> Search_AllLookup(Pager<Lookup_Search_Filter> pagerData)
        {
            //RequirePermission(Perm.Admin_Account);

            return repo.spLookup_Search(pagerData).ToDTO();
        }

        public PagedList<Lookup_Search, Lookup_Search_Filter> Search_Lookup(Pager<Lookup_Search_Filter> pagerData)
        {
            //RequirePermission(Perm.Admin_Account);

            var list = repo.spLookup_Search(pagerData);
            var groupLUT = repo.Lookup_ListDistinct_Groupe().Single(one => string.Compare(one.Groupe, pagerData.filter.groupe, true) == 0);
            return list.ToDTO(new
            {
                title = groupLUT.Description
            });
        }

        public Lookup_Detail Get_Lookup(int id)
        {
            //RequirePermission(Perm.Admin_Account);

            var item = repo.spLookup_Detail(id);
            var groupLUT = repo.Lookup_ListDistinct_Groupe().Single(one => string.Compare(one.Groupe, item.Groupe, true) == 0);
            return item.ToDTO(new
            {
                title = $"{groupLUT.Description}: {item.Description}",
            });
        }

        public Lookup_Detail GetNew_Lookup(string groupe)
        {
            //RequirePermission(Perm.Admin_Account);

            var groupLUT = repo.Lookup_ListDistinct_Groupe().Single(one => string.Compare(one.Groupe, groupe, true) == 0);
            return new Lookup_Detail
            {
                xtra = new { title = groupLUT.Description },
                description = "",
                groupe = groupe,
                archive = false,
                started = DateTime.Now.Year,
                createdUtc = DateTime.Today,
                updatedUtc = DateTime.Today
            };
        }

        public Lookup_Detail_PK Create_Lookup(Lookup_Model model)
        {
            //RequirePermission(Perm.Admin_Account);

            model.Validate();
            model.updatedBy = user.Get_UID();
            repo.spLookup_Create(model);

            return new Lookup_Detail_PK { id = model.id };
        }

        public void Update_Lookup(Lookup_Model model)
        {
            //RequirePermission(Perm.Admin_Account);

            model.Validate();
            model.updatedBy = user.Get_UID();
            repo.spLookup_Update(model);
        }

        public void Delete_Lookup(int id, DateTime concurrencyUtc)
        {
            //RequirePermission(Perm.Admin_Account);

            repo.spLookup_Delete(id, concurrencyUtc);
        }
        */

        public List<Lookup> Lookup_By(string groupe, int? year = null)
        {
            return repo.queryList<Lookup>("app.Lookup_ListBy_Groupe", KVList.Build()
                .Add("@groupe", groupe)
                .Add("@year", year)
                );
        }
    }
}
