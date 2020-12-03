// File: Component/Company.cs

namespace BaseApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    internal partial class Repo
    {
        public DTO.PagedList<DTO.Company_Search, DTO.Company_Search_Filter> spCompany_Search(DTO.Pager<DTO.Company_Search_Filter> pagerData)
        {
            var pagedList = new DTO.PagedList<DTO.Company_Search, DTO.Company_Search_Filter>();
            pagedList.pager = pagerData;
            pagedList.list = new List<DTO.Company_Search>();
            var list = pagedList.list;

            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Company_Search";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pageNo", (object)pagerData.pageNo ?? DBNull.Value);
                command.Parameters.AddWithValue("@pageSize", (object)pagerData.pageSize ?? DBNull.Value);
                command.Parameters.AddWithValue("@sortColumn", string.IsNullOrEmpty(pagerData.sortColumn) ? DBNull.Value : (object)pagerData.sortColumn);
                command.Parameters.AddWithValue("@sortDirection", string.IsNullOrEmpty(pagerData.sortDirection) ? DBNull.Value : (object)pagerData.sortDirection);
                command.Parameters.AddWithValue("@searchText", string.IsNullOrEmpty(pagerData.searchText) ? DBNull.Value : (object)pagerData.searchText);
                command.Parameters.AddWithValue("@archive", pagerData.filter.archive);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new DTO.Company_Search();
                        var ix = -1;
                        ix++; entity.totalCount = reader.GetInt32(ix);
                        ix++; entity.nid = reader.GetInt32(ix);
                        ix++; entity.name = reader.GetString(ix);
                        ix++; entity.disabled = reader.GetBoolean(ix);
                        ix++; entity.stations = reader.GetInt32(ix);
                        ix++; entity.accounts = reader.GetInt32(ix);
                        ix++; entity.vods = reader.GetInt32(ix);
                        ix++; entity.imports = reader.GetInt32(ix);
                        list.Add(entity);
                    }
                }
            }

            pagedList.pager.rowCount = (list.Count > 0 ? list[0].totalCount : 0);
            return pagedList;
        }

        public DTO.Company_Record spCompany_Select(int nid)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Company_Select";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NID", nid);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var entity = new DTO.Company_Record();
                        var ix = -1;
                        ix++; entity.nid = reader.GetInt32(ix);
                        ix++; entity.name = reader.GetString(ix);
                        ix++; entity.archive = reader.GetBoolean(ix);
                        return entity;
                    }
                    return null;
                }
            }
        }

        public void spCompany_CreateFull(UTO.Company_Update uto)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Company_CreateFull";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", uto.name);

                var nid = new SqlParameter("@NID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(nid);
                command.ExecuteNonQuery();

                uto.nid = (int)nid.Value;
            }
        }

        public void spCompany_Update(UTO.Company_Update uto)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Company_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NID", uto.nid);
                command.Parameters.AddWithValue("@Name", uto.name);
                command.Parameters.AddWithValue("@Archive", uto.archive);
                command.ExecuteNonQuery();

            }
        }

        public void spCompany_Destroy(int nid)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Company_Destroy";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NID", nid);
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

    public class Company_Search
    {
        public int totalCount { get; set; }
        public int nid { get; set; }
        public string name { get; set; }
        public bool disabled { get; set; }
        public int stations { get; set; }
        public int accounts { get; set; }
        public int vods { get; set; }
        public int imports { get; set; }
    }

    public class Company_Search_FK
    {
    }

    public class Company_Search_Filter : Company_Search_FK
    {
        public bool? archive { get; set; }
    }

    public class Company_Record : Company_Record_PK
    {
        public object xtra { get; set; }
        public object perm { get; set; }
        public string name { get; set; }
        public bool archive { get; set; }
    }

    public class Company_Record_PK
    {
        public int nid { get; set; }
    }

    public class Company
    {
        public int nid { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }

        internal static List<Company> Clone(List<Company> list)
        {
            return new List<Company>(list);
        }
    }
}

namespace BaseApp.UTO
{
    using System;
    using System.Collections.Generic;
    using BaseApp.Common;

    public class Company_Record_UK : DTO.Company_Record_PK
    {
        public DateTime updatedUtc { get; set; }
    }

    public class Company_Update : Company_Record_UK
    {
        public string name { get; set; }
        public bool archive { get; set; }

        internal void Validate()
        {
            if (name.Length > 128)
                throw new ValidationException("Name is too long (max length = 128)");

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
    using System.Threading.Tasks;
    using System.Text.Json;

    public partial interface IAppService
    {
        PagedList<Company_Search, Company_Search_Filter> Company_Search(Pager<Company_Search_Filter> pagerData);
        Company_Record Company_Select(int id);
        Company_Record Company_NewRecord();
        Company_Record_PK Company_Insert(UTO.Company_Update uto);
        void Company_Update(UTO.Company_Update uto);
        void Company_Delete(int id, DateTime concurrencyUtc);
        int? Company_GetID(string company);
        object Company_GetFeature(int id);
    }

    public partial class AppService
    {
        public PagedList<Company_Search, Company_Search_Filter> Company_Search(Pager<Company_Search_Filter> pagerData)
        {
            var list = repo.spCompany_Search(pagerData);
            return list;
        }

        public Company_Record Company_Select(int nid)
        {
            var item = repo.spCompany_Select(nid);
            item.xtra = new
            {
                title = item.name,
            };
            return item;
        }

        public Company_Record Company_NewRecord()
        {
            var uid = user.Get_UID();
            var item = new Company_Record
            {
                archive = false,
            };
            return item;
        }

        public Company_Record_PK Company_Insert(UTO.Company_Update uto)
        {
            uto.Validate();
            repo.spCompany_CreateFull(uto);

            return new Company_Record_PK { nid = uto.nid };
        }

        public void Company_Update(UTO.Company_Update uto)
        {
            uto.Validate();
            repo.spCompany_Update(uto);
        }

        public void Company_Delete(int id, DateTime concurrencyUtc)
        {
            repo.spCompany_Destroy(id);
        }

        public int? Company_GetID(string company)
        {
            var query = "select id from app.Company where Name=@p1";
            return repo.queryScalar<int?>(query, "@p1", company);
        }

        public object Company_GetFeature(int id)
        {
            var query = "select Features from app.Company where ID=@cid";
            var scalar = repo.queryScalar<string>(query, "@cid", id);
            var json = scalar ?? "{}";

            var feature = JsonSerializer.Deserialize<object>(json);
            return feature;
        }
    }
}
