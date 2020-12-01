using BaseApp.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace BaseApp.DAL
{
    internal partial class Repo : IDisposable
    {
        public T executeScalar<T>(string command_text, Service.KVList parameters = null)
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
        
        public T executeScalar<T>(string command_text, string parameter_name, object parameter_value)
        {
            var parameters = new Service.KVList().AddParam(parameter_name, parameter_value);
            return executeScalar<T>(command_text, parameters);

        }

        public List<T> executeQuery<T>(string command_text, Service.KVList parameters = null)
        {
            var properties = typeof(T).GetProperties();
            var instance = Activator.CreateInstance<T>();

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
                    while (reader.Read())
                    {
                        foreach (var propinfo in properties)
                            propinfo.SetValue(instance, reader[propinfo.Name], null);

                        list.Add(instance);
                    }
                }
            }
            return list;
        }

        public List<T> executeQuery<T>(string command_text, string parameter_name, object parameter_value)
        {
            var parameters = new Service.KVList().AddParam(parameter_name, parameter_value);
            return executeQuery<T>(command_text, parameters);
        }
    }
}

namespace BaseApp.Service
{
    public class KVList : List<KeyValuePair<string, object>>
    {
        public KVList AddParam(string key, object value)
        {
            this.Add(new KeyValuePair<string, object>(key, value));
            return this;
        }
    }
}
