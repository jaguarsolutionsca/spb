using BaseApp.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BaseApp.DAL
{
    internal partial class Repo : IDisposable
    {
        public T queryScalar<T>(string command_text, Service.KVList parameters = null)
        {
            T scalar = default(T);
            using (var command = connex.CreateCommand())
            {
                command.CommandText = command_text;
                command.CommandType = (command_text.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader[0] != DBNull.Value)
                            scalar = (T)reader[0];
                    }
                }
            }
            return scalar;
        }

        public T queryScalar<T>(string command_text, string parameter_name, object parameter_value)
        {
            var parameters = new Service.KVList().Add(parameter_name, parameter_value);
            return queryScalar<T>(command_text, parameters);

        }


        public List<T> queryList<T>(string command_text, Service.KVList parameters = null)
        {
            var properties = typeof(T).GetProperties(); //note: not dealing with Fields

            var list = new List<T>();
            using (var command = connex.CreateCommand())
            {
                command.CommandText = command_text;
                command.CommandType = (command_text.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    var columns = Enumerable.Range(0, reader.FieldCount).Select((one, ix) => { return reader.GetName(ix).ToLower(); }).ToList();

                    var map = new int?[properties.Length];
                    for (var ix = 0; ix < properties.Length; ix++)
                    {
                        var propName = properties[ix].Name.ToLower();
                        var iy = columns.IndexOf(propName);
                        if (iy != -1)
                            map[ix] = iy;
                    }

                    while (reader.Read())
                    {
                        var instance = Activator.CreateInstance<T>();
                        for (var ix = 0; ix < properties.Length; ix++)
                        {
                            if (map[ix].HasValue)
                            {
                                var value = reader[map[ix].Value];
                                if (value != null && value != DBNull.Value)
                                    properties[ix].SetValue(instance, value, null);
                            }
                        }
                        list.Add(instance);
                    }
                }
            }
            return list;
        }

        public List<T> queryList<T>(string command_text, string parameter_name, object parameter_value)
        {
            var parameters = new Service.KVList().Add(parameter_name, parameter_value);
            return queryList<T>(command_text, parameters);
        }


        public T queryEntity<T>(string command_text, Service.KVList parameters = null)
        {
            var properties = typeof(T).GetProperties(); //note: not dealing with Fields
            var instance = Activator.CreateInstance<T>();

            T entity = default;
            using (var command = connex.CreateCommand())
            {
                command.CommandText = command_text;
                command.CommandType = (command_text.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    var columns = Enumerable.Range(0, reader.FieldCount).Select((one, ix) => { return reader.GetName(ix).ToLower(); }).ToList();

                    var map = new int?[properties.Length];
                    for (var ix = 0; ix < properties.Length; ix++)
                    {
                        var propName = properties[ix].Name.ToLower();
                        var iy = columns.IndexOf(propName);
                        if (iy != -1)
                            map[ix] = iy;
                    }

                    if (reader.Read())
                    {
                        for (var ix = 0; ix < properties.Length; ix++)
                        {
                            if (map[ix].HasValue)
                            {
                                var value = reader[map[ix].Value];
                                if (value != null && value != DBNull.Value)
                                    properties[ix].SetValue(instance, value, null);
                            }
                        }
                        entity = instance;
                    }
                }
            }
            return entity;
        }

        public T queryEntity<T>(string command_text, string parameter_name, object parameter_value)
        {
            var parameters = new Service.KVList().Add(parameter_name, parameter_value);
            return queryEntity<T>(command_text, parameters);
        }


        public void queryNonQuery(string command_text, Service.KVList parameters = null)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = command_text;
                command.CommandType = (command_text.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                command.ExecuteNonQuery();
            }
        }

        public void queryNonQuery(string command_text, string parameter_name, object parameter_value)
        {
            var parameters = new Service.KVList().Add(parameter_name, parameter_value);
            queryNonQuery(command_text, parameters);
        }


        public Service.Dico queryDico(string command_text, Service.KVList parameters = null)
        {
            var entity = new Service.Dico();
            using (var command = connex.CreateCommand())
            {
                command.CommandText = command_text;
                command.CommandType = (command_text.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    var columns = Enumerable.Range(0, reader.FieldCount).Select((one, ix) => { return reader.GetName(ix).ToLower(); }).ToList();

                    if (reader.Read())
                    {
                        for (var ix = 0; ix < reader.FieldCount; ix++)
                        {
                            var value = reader[ix];
                            if (value != null && value != DBNull.Value)
                                entity.Add(columns[ix], value);
                            else
                                entity.Add(columns[ix], null);
                        }
                    }
                }
            }
            return entity;
        }

        public Service.Dico queryDico(string command_text, string parameter_name, object parameter_value)
        {
            var parameters = new Service.KVList().Add(parameter_name, parameter_value);
            return queryDico(command_text, parameters);
        }


        public List<Service.Dico> queryDicoList(string command_text, Service.KVList parameters = null)
        {
            var list = new List<Service.Dico>();
            using (var command = connex.CreateCommand())
            {
                command.CommandText = command_text;
                command.CommandType = (command_text.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    var columns = Enumerable.Range(0, reader.FieldCount).Select((one, ix) => { return reader.GetName(ix).ToLower(); }).ToList();

                    while (reader.Read())
                    {
                        var entity = new Service.Dico();
                        for (var ix = 0; ix < reader.FieldCount; ix++)
                        {
                            var value = reader[ix];
                            if (value != null && value != DBNull.Value)
                                entity.Add(columns[ix], value);
                            else
                                entity.Add(columns[ix], null);
                        }
                        list.Add(entity);
                    }
                }
            }
            return list;
        }
    }
}

namespace BaseApp.Service
{
    public class KVList : List<KeyValuePair<string, object>>
    {
        public KVList Add(string key, object value)
        {
            this.Add(new KeyValuePair<string, object>(key, value));
            return this;
        }

        public static KVList Build()
        {
            return new KVList();
        }

        public static KVList Build<T>(T entity)
        {
            var properties = typeof(T).GetProperties(); //note: not dealing with Fields
            var kvlist = Build();

            foreach (var property in properties)
            {
                var propName = property.Name.ToLower();
                kvlist.Add(propName, property.GetValue(entity) ?? DBNull.Value);
            }

            return kvlist;
        }

        public static KVList Build(Dico dico)
        {
            var kvlist = Build();
            foreach (var key in dico.Keys)
            {
                var obj = dico[key];
                if (obj == null)
                    kvlist.Add(key, DBNull.Value);
                else
                    kvlist.Add(key, dico[key]);
            }
            return kvlist;
        }
    }

    public class Dico : Dictionary<string, object>
    {
        private Regex regex = new Regex(@"\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}");

        public Dico Revive(string[] blacklist = null)
        {
            var dico = new Dico();
            foreach (var key in this.Keys)
            {
                if (blacklist != null && blacklist.Contains(key))
                    continue;

                var obj = (System.Text.Json.JsonElement?)this[key];
                if (!obj.HasValue)
                    dico.Add(key, null);
                else if (obj.Value.ValueKind == System.Text.Json.JsonValueKind.Number)
                    dico.Add(key, obj.Value.GetDouble());
                else if (obj.Value.ValueKind == System.Text.Json.JsonValueKind.True)
                    dico.Add(key, true);
                else if (obj.Value.ValueKind == System.Text.Json.JsonValueKind.False)
                    dico.Add(key, false);
                else if (obj.Value.ValueKind == System.Text.Json.JsonValueKind.String)
                {
                    var text = obj.Value.GetString();
                    var match = regex.Match(text);
                    if (match.Success)
                    {
                        dico.Add(key, DateTime.Parse(text).ToLocalTime());
                    }
                    else
                    {
                        dico.Add(key, text);
                    }
                }
                else if (obj.Value.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    var json = obj.Value.ToString();
                    var obj2 = System.Text.Json.JsonSerializer.Deserialize<Dico>(json).Revive(blacklist);
                    foreach (var key2 in obj2.Keys)
                    {
                        dico.Add(key2, obj2[key2]);
                    }
                }
                else
                {
                    dico.Add(key, this[key]);
                }
            }
            return dico;
        }

        public Dico TrimRowCount()
        {
            this.Remove("rowCount");
            return this;
        }

        internal Dico ReviveRowCount(List<Dico> list)
        {
            var rowCount = 0;
            if (list != null && list.Count > 0)
                rowCount = int.Parse(list[0]["totalcount"].ToString());

            this.Add("rowCount", rowCount);
            return this;
        }
    }

    public partial class AppService
    {
        public static Tdestin mapTo<Tsource, Tdestin>(Tsource source) where Tdestin : new()
        {
            var sourceType = typeof(Tsource);
            var destinType = typeof(Tdestin);
            var sourceProps = sourceType.GetProperties(); //note: not dealing with Fields
            var destinProps = destinType.GetProperties(); //note: not dealing with Fields

            Tdestin destin = new Tdestin();
            foreach (var sourceProp in sourceProps)
            {
                var destinProp = destinType.GetProperty(sourceProp.Name);
                if (destinProp != null)
                {
                    destinProp.SetValue(destin, sourceProp.GetValue(source));
                }
            }
            return destin;
        }
    }
}
