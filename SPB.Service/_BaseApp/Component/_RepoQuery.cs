using BaseApp.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace BaseApp.DAL
{
    internal partial class Repo
    {
        public T queryScalar<T>(string command_text, KVList parameters = null, bool uid = false)
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

                if (uid)
                    command.Parameters.AddWithValue("@_uid", user?.Get_UID());

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

        public T queryScalar<T>(string command_text, string parameter_name, object parameter_value, bool uid = false)
        {
            var parameters = new KVList().Add(parameter_name, parameter_value);
            return queryScalar<T>(command_text, parameters, uid);

        }


        public List<T> queryList<T>(string command_text, KVList parameters = null, bool uid = false)
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

                if (uid)
                    command.Parameters.AddWithValue("@_uid", user?.Get_UID());

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

        public List<T> queryList<T>(string command_text, string parameter_name, object parameter_value, bool uid = false)
        {
            var parameters = new KVList().Add(parameter_name, parameter_value);
            return queryList<T>(command_text, parameters, uid);
        }


        public T queryEntity<T>(string command_text, KVList parameters = null, bool uid = false)
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

                if (uid)
                    command.Parameters.AddWithValue("@_uid", user?.Get_UID());

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

        public T queryEntity<T>(string command_text, string parameter_name, object parameter_value, bool uid = false)
        {
            var parameters = new KVList().Add(parameter_name, parameter_value);
            return queryEntity<T>(command_text, parameters, uid);
        }


        public void queryNonQuery(string command_text, KVList parameters = null, bool uid = false)
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

                if (uid)
                    command.Parameters.AddWithValue("@_uid", user?.Get_UID());

                command.ExecuteNonQuery();
            }
        }

        public void queryNonQuery(string command_text, string parameter_name, object parameter_value, bool uid = false)
        {
            var parameters = new KVList().Add(parameter_name, parameter_value);
            queryNonQuery(command_text, parameters, uid);
        }


        public Dico queryDico(string command_text, KVList parameters = null, bool uid = false)
        {
            var entity = new Dico();
            using (var command = connex.CreateCommand())
            {
                command.CommandText = command_text;
                command.CommandType = (command_text.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                if (uid)
                    command.Parameters.AddWithValue("@_uid", user?.Get_UID());

                using (var reader = command.ExecuteReader())
                {
                    // Merge all resultsets
                    do
                    {
                        if (reader.Read())
                        {
                            for (var ix = 0; ix < reader.FieldCount; ix++)
                            {
                                var name = reader.GetName(ix).ToLower();
                                var value = reader[ix];

                                if (value == null || value == DBNull.Value)
                                {
                                    entity.Add(name, null);
                                }
                                else
                                {
                                    if (value.GetType().Equals(typeof(string)) && string.IsNullOrEmpty(value.ToString()))
                                        entity.Add(name, null);
                                    else
                                        entity.Add(name, value);
                                }
                            }
                        }
                    }
                    while (reader.NextResult());
                }
            }
            return entity;
        }

        public Dico queryDico(string command_text, string parameter_name, object parameter_value, bool uid = false)
        {
            var parameters = new KVList().Add(parameter_name, parameter_value);
            return queryDico(command_text, parameters, uid);
        }


        public List<Dico> queryDicoList(string command_text, KVList parameters = null, bool uid = false)
        {
            var list = new List<Dico>();
            using (var command = connex.CreateCommand())
            {
                command.CommandText = command_text;
                command.CommandType = (command_text.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure);

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                if (uid)
                    command.Parameters.AddWithValue("@_uid", user?.Get_UID());

                using (var reader = command.ExecuteReader())
                {
                    var columns = Enumerable.Range(0, reader.FieldCount).Select((one, ix) => { return reader.GetName(ix).ToLower(); }).ToList();

                    while (reader.Read())
                    {
                        var entity = new Dico();
                        for (var ix = 0; ix < reader.FieldCount; ix++)
                        {
                            var value = reader[ix];

                            if (value == null || value == DBNull.Value)
                            {
                                entity.Add(columns[ix], null);
                            }
                            else
                            {
                                if (value.GetType().Equals(typeof(string)) && string.IsNullOrEmpty(value.ToString()))
                                    entity.Add(columns[ix], null);
                                else
                                    entity.Add(columns[ix], value);
                            }
                        }
                        list.Add(entity);
                    }
                }
            }
            return list;
        }
    }
}