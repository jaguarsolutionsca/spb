
namespace BaseApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    internal partial class Repo
    {
        public List<Lookup> Lookup_ListBy_Groupe(string groupe)
        {
            var list = new List<Lookup>();

            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Lookup]";
                var columns = "ID,Groupe,Code,Description,Value1,Value2,Value3,Started,Ended,SortOrder,Archive,Created,Updated,UpdatedBy";
                var where = "(Groupe=@p1) AND Archive=0";

                command.CommandText = $"SELECT {columns} FROM {table} WHERE {where} ORDER BY SortOrder, Description";
                command.Parameters.AddWithValue("@p1", groupe);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(getFromReader(reader));
                    }
                }
            }
            return list;
        }

        public List<Lookup> Lookup_ListBy_Groupe(string groupe, int year)
        {
            var list = new List<Lookup>();

            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Lookup]";
                var columns = "ID,Groupe,Code,Description,Value1,Value2,Value3,Started,Ended,SortOrder,Archive,Created,Updated,UpdatedBy";
                var where = "(Groupe=@p1) AND Archive=0 AND (Started <= @p2) AND (Ended IS NULL OR Ended >= @p2)";

                command.CommandText = $"SELECT {columns} FROM {table} WHERE {where} ORDER BY SortOrder, Description";
                command.Parameters.AddWithValue("@p1", groupe);
                command.Parameters.AddWithValue("@p2", year);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(getFromReader(reader));
                    }
                }
            }
            return list;
        }

        public Lookup Lookup_SingleBy_Code(string groupe, string code)
        {
            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Lookup]";
                var columns = "ID,Groupe,Code,Description,Value1,Value2,Value3,Started,Ended,SortOrder,Archive,Created,Updated,UpdatedBy";
                var where = "(Groupe=@p1) AND (Code=@p2) AND Archive=0";

                command.CommandText = $"SELECT {columns} FROM {table} WHERE {where} ORDER BY SortOrder, Description";
                command.Parameters.AddWithValue("@p1", groupe);
                command.Parameters.AddWithValue("@p2", code);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return getFromReader(reader);
                    }
                    return null;
                }
            }
        }

        public Lookup Lookup_Single(int id)
        {
            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Lookup]";
                var columns = "ID,Groupe,Code,Description,Value1,Value2,Value3,Started,Ended,SortOrder,Archive,Created,Updated,UpdatedBy";
                var where = "ID=@p1";

                command.CommandText = $"SELECT {columns} FROM {table} WHERE {where} ORDER BY SortOrder, Description";
                command.Parameters.AddWithValue("@p1", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return getFromReader(reader);
                    }
                    return null;
                }
            }
        }

        Lookup getFromReader(SqlDataReader reader)
        {
            var entity = new Lookup();
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
            return entity;
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
        public string code { get; set; }
        public string description { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public int started { get; set; }
        public int? ended { get; set; }
        public bool disabled { get; set; }
    }

    public class Lookup2
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    public class Lookup3
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public DateTime started { get; set; }
        public DateTime? ended { get; set; }
    }


    //public class Lookup_Summary : DTO_Summary
    //{
    //    public string groupe { get; set; }
    //}
}

namespace BaseApp.Mapper
{
    using System;
    using System.Collections.Generic;

    internal static partial class Mapper
    {
        public static DTO.Lookup ToDTO(this DAL.Lookup entity)
        {
            return new DTO.Lookup
            {
                id = entity.ID,
                code = entity.Code,
                description = entity.Description,
                value1 = entity.Value1,
                value2 = entity.Value2,
                value3 = entity.Value3,
                started = entity.Started,
                ended = entity.Ended,
            };
        }

        public static List<DTO.Lookup> ToDTO(this List<DAL.Lookup> entities)
        {
            var list = new List<DTO.Lookup>();
            foreach (var entity in entities)
            {
                list.Add(entity.ToDTO());
            }
            return list;
        }

        public static DTO.Lookup2 ToDTO2(this DAL.Lookup entity)
        {
            return new DTO.Lookup2
            {
                id = entity.Groupe,
                description = entity.Description,
            };
        }

        public static List<DTO.Lookup2> ToDTO2(this List<DAL.Lookup> entities)
        {
            var list = new List<DTO.Lookup2>();
            foreach (var entity in entities)
            {
                list.Add(entity.ToDTO2());
            }
            return list;
        }

        public static DTO.Lookup ToDTO_ByCode(this DAL.Lookup entity)
        {
            return new DTO.Lookup
            {
                id = int.Parse(entity.Code),
                code = entity.Code,
                description = entity.Description,
            };
        }

        public static List<DTO.Lookup> ToDTO_ByCode(this List<DAL.Lookup> entities)
        {
            var list = new List<DTO.Lookup>();
            foreach (var entity in entities)
            {
                list.Add(entity.ToDTO_ByCode());
            }
            return list;
        }
    }
}
