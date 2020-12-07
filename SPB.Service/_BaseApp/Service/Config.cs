using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Service
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System.IO;
    using System.Reflection;

    public partial interface IAppService
    {
        int FormsAuthenticationTimeoutTotalMinutes { get; }
        byte[] IssuerSigningKey { get; }
        string Audience { get; }
        string Issuer { get; }
        string ValidateOrigin(string origin);
        string DataFileFolder { get; }
    }

    public partial class AppService
    {
        public int FormsAuthenticationTimeoutTotalMinutes
        {
            get { return config.GetValue<int>("AppSettings:FormsAuthentication.Timeout.TotalMinutes"); }
        }

        public byte[] IssuerSigningKey
        {
            get { return Encoding.UTF8.GetBytes(config.GetValue<string>("AppSettings:jwt:passPhrase")); }
        }

        public string Audience
        {
            get { return config.GetValue<string>("AppSettings:jwt:audience"); }
        }

        public string Issuer
        {
            get { return config.GetValue<string>("AppSettings:jwt:issuer"); }
        }

        internal string SuperPassword
        {
            get { return config.GetValue<string>("AppSettings:superPassword"); }
        }

        internal string CryptoKey
        {
            get { return config.GetValue<string>("AppSettings:cryptoKey"); }
        }

        static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().Location;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        internal static string fullPathOf(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            return Path.GetFullPath(Path.Combine(AssemblyDirectory, path));
        }

        public string LangPathFromCurrentUICulture
        {
            get
            {
                var lang = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

                var path = config.GetValue<string>($"AppSettings:lang:{lang}");
                if (string.IsNullOrEmpty(path))
                    path = config.GetValue<string>("AppSettings:lang");

                return Path.GetFullPath(Path.Combine(AssemblyDirectory, path));
            }
        }

        public string[] AllowedOrigins()
        {
            return config.GetValue<string>("AppSettings:AllowedOrigins").Split(',');
        }

        public string ValidateOrigin(string origin)
        {
            if (string.IsNullOrEmpty(origin))
                return null;

            var parts = AllowedOrigins();
            foreach (var allowed in parts)
            {
                if (string.Compare(origin, allowed, true) == 0)
                    return origin;
            }

            return null;
        }

        public string DataFileFolder
        {
            get { return fullPathOf(config.GetValue<string>("AppSettings:folders:datafiles")); }
        }

        public int SupportUID
        {
            get { return config.GetValue<int>("AppSettings:support.uid"); }
        }
    }
}
