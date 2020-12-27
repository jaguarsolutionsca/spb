using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseApp.Service
{
    using System.Runtime.Serialization.Json;

    public interface IAppConfigValues
    {
        string connString { get; }
        string cryptoKey { get; }
        string wwwroot { get; }
        string reportRoot { get; }
    }

    public class AppConfigValues : IAppConfigValues
    {
        public string connString { get; }
        public string cryptoKey { get; }
        public string wwwroot { get; }
        public string reportRoot { get; }

        public AppConfigValues()
        {
            var appsettings_json = File.ReadAllText("appsettings.json");
            var json = deserialize<Appsettings_Json>(appsettings_json);

            if (json.ConnectionStrings?.DefaultConnection != null)
                connString = json.ConnectionStrings.DefaultConnection;

            if (json.AppSettings?.cryptoKey != null)
                cryptoKey = json.AppSettings.cryptoKey;


            if (connString == null || cryptoKey == null)
            {
                appsettings_json = File.ReadAllText("appsettings.Development.json");
                json = deserialize<Appsettings_Json>(appsettings_json);

                connString = json.ConnectionStrings.DefaultConnection;
                cryptoKey = json.AppSettings.cryptoKey;
            }
        }

        internal T deserialize<T>(string json)
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
                var serializer = new DataContractJsonSerializer(typeof(T), settings);
                return (T)serializer.ReadObject(memoryStream);
            }
        }

        public class Appsettings_Json
        {
            public _ConnectionStrings ConnectionStrings { get; set; }
            public _AppSettings AppSettings { get; set; }
        }

        public class _ConnectionStrings
        {
            public string DefaultConnection { get; set; }
            public string GestionPaieConnection { get; set; }
        }

        public class _AppSettings
        {
            public string cryptoKey { get; set; }
        }
    }
}
