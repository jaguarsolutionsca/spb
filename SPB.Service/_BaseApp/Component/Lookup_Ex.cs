
using System;
using System.Collections.Generic;

namespace BaseApp.DAL
{
    using System.Data;
    using System.Data.SqlClient;

    internal partial class Repo
    {
        public List<DTO.Lookup> Lookup_ListBy_Groupe(string groupe)
        {
            var where = "(Groupe=@p1) AND Archive=0";
            var query = $"SELECT * FROM app.Lookup WHERE {where} ORDER BY SortOrder, Description";
            return queryList<DTO.Lookup>(query, "@p1", groupe);
        }

        public List<DTO.Lookup> Lookup_ListBy_Groupe(string groupe, int year)
        {
            var where = "(Groupe=@p1) AND Archive=0 AND (Started <= @p2) AND (Ended IS NULL OR Ended >= @p2)";
            var query = $"SELECT * FROM app.Lookup WHERE {where} ORDER BY SortOrder, Description";
            return queryList<DTO.Lookup>(query, Service.KVList.Build()
                .Add("@p1", groupe)
                .Add("@p2", year)
                );
        }
    }
}

namespace BaseApp.DTO
{
    using System;
    using System.Collections.Generic;
    using BaseApp.Common;

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
