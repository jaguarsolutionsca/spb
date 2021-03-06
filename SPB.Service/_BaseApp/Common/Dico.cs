﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseApp.Common
{
    public class Dico : Dictionary<string, object>
    {
        internal bool revived = false;

        private static Regex regex = new Regex(@"\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}");

        internal Dico Decrypt(Crypto crypto, string[] keys)
        {
            if (!revived)
                throw new Exception("Dico first needs to be revived before decrypting");

            foreach (var key in keys)
            {
                if (this.ContainsKey(key) && this[key] != null)
                {
                    this[key] = crypto.Decrypt(this[key].ToString());
                }
            }
            return this;
        }

        internal Dico Decrypt(Crypto crypto, string key)
        {
            if (!revived)
                throw new Exception("Dico first needs to be revived before decrypting");

            if (this.ContainsKey(key) && this[key] != null)
            {
                this[key] = crypto.Decrypt(this[key].ToString());
            }

            return this;
        }

        public Dico ReviveUTO(string[] whitelist = null, string[] blacklist = null, bool flatten = true)
        {
            var dico = new Dico();
            foreach (var key in this.Keys)
            {
                if (whitelist != null && !whitelist.Contains(key))
                    continue;

                if (blacklist != null && blacklist.Contains(key))
                    continue;

                var obj = (JsonElement?)this[key];
                if (!obj.HasValue)
                    dico.Add(key, null);
                else if (obj.Value.ValueKind == JsonValueKind.Number)
                    dico.Add(key, obj.Value.GetDouble());
                else if (obj.Value.ValueKind == JsonValueKind.True)
                    dico.Add(key, true);
                else if (obj.Value.ValueKind == JsonValueKind.False)
                    dico.Add(key, false);
                else if (obj.Value.ValueKind == JsonValueKind.String)
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
                else if (obj.Value.ValueKind == JsonValueKind.Object)
                {
                    var json = obj.Value.ToString();
                    var obj2 = JsonSerializer.Deserialize<Dico>(json).ReviveUTO(whitelist, blacklist);
                    if (flatten)
                    {
                        foreach (var key2 in obj2.Keys)
                        {
                            dico.Add(key2, obj2[key2]);
                        }
                    }
                    else
                    {
                        var dico2 = new Dico();
                        dico.Add(key, dico2);
                        foreach (var key2 in obj2.Keys)
                        {
                            dico2.Add(key2, obj2[key2]);
                        }
                    }
                }
                else
                {
                    dico.Add(key, this[key]);
                }
            }

            dico.revived = true;
            return dico;
        }

        public Dico ReviveDTO(string[] whitelist = null, string[] blacklist = null, string[] graylist = null)
        {
            var dico = new Dico();
            foreach (var key in this.Keys)
            {
                if (whitelist != null && !whitelist.Contains(key))
                    continue;

                if (blacklist != null && blacklist.Contains(key))
                    continue;

                if (graylist != null && graylist.Contains(key))
                {
                    dico.Add(key, this[key]);
                    continue;
                }

                var obj = this[key];
                if (obj == null)
                    dico.Add(key, null);
                else if (obj.GetType().Name == "String")
                {
                    var clean = obj.ToString().Trim();
                    object value = (!string.IsNullOrEmpty(clean) ? clean : null);

                    if (value != null)
                    {
                        var text = value.ToString();
                        var match = regex.Match(text);
                        if (match.Success)
                        {
                            dico.Add(key, DateTime.Parse(text));
                        }
                        else
                        {
                            if (bool.TryParse(clean, out bool boolValue))
                                value = boolValue;

                            if (double.TryParse(clean, out double doubleValue))
                                value = doubleValue;
                        }
                    }

                    dico.Add(key, value);
                }
                else
                {
                    dico.Add(key, obj);
                }
            }

            dico.revived = true;
            return dico;
        }

        public Dico TrimKeys(string[] keys)
        {
            foreach (var key in keys)
            {
                this.Remove(key);
            }
            return this;
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

            Add("rowCount", rowCount);
            return this;
        }

        internal static string Serialize(Dico dico)
        {
            return JsonSerializer.Serialize(dico);
        }

        internal static Dico Deserialize(string json)
        {
            Dico dico = null;
            if (json != null)
            {
                dico = new Dico();
                var items = JsonSerializer.Deserialize<Dico>(json);
                foreach (var one in items)
                {
                    object value = null;

                    if (one.Value == null)
                    {
                        value = (object)null;
                    }
                    else
                    {
                        var clean = one.Value.ToString().Trim();
                        value = (!string.IsNullOrEmpty(clean) ? clean : null);

                        if (bool.TryParse(clean, out bool boolValue))
                            value = boolValue;

                        if (double.TryParse(clean, out double doubleValue))
                            value = doubleValue;
                    }
                    dico.Add(one.Key, value);
                }
            }
            json = null;
            return dico;
        }

        internal T Parse<T>(string key)
        {
            T entity = default;

            if (!this.ContainsKey(key))
                return entity;

            var value = this[key];
            if (value == null)
                return entity;

            return (T)Convert.ChangeType(value, typeof(T));
        }

        internal DateTime? ParseDateTime(string key)
        {
            var entity = new DateTime?();

            if (!this.ContainsKey(key))
                return entity;

            var value = this[key];
            if (value == null)
                return entity;

            return (DateTime)value;
        }
    }
}
