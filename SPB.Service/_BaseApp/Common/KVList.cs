using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Common
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
}
