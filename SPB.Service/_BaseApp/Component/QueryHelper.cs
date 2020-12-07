using BaseApp.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
                kvlist.Add($"@{propName}", property.GetValue(entity) ?? DBNull.Value);
            }

            return kvlist;
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
