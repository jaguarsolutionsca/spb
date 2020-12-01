using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseApp.Service
{
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
            using (var reader = new StreamReader("appsettings.json"))
            {
                var appsettings_json = reader.ReadToEnd();
                dynamic json = JsonSerializer.Deserialize<object>(appsettings_json);

                if (json.ConnectionStrings?.DefaultConnection != null)
                    connString = json.ConnectionStrings.DefaultConnection;

                if (json.AppSettings?.cryptoKey != null)
                    cryptoKey = json.AppSettings.cryptoKey;
            }

            if (connString == null || cryptoKey == null)
            {
                using (var reader = new StreamReader("appsettings.Development.json"))
                {
                    var appsettings_json = reader.ReadToEnd();
                    dynamic json = JsonSerializer.Deserialize<object>(appsettings_json);

                    connString = json.ConnectionStrings.DefaultConnection;
                    cryptoKey = json.AppSettings.cryptoKey;
                }
            }
        }
    }
}
