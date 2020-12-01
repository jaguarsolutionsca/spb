using BaseApp.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BaseApp.DAL
{
    internal partial class Repo : IDisposable
    {
        public readonly SqlConnection connex;
        ILogger log;
        public Crypto crypto;

        public Repo(ILogger<object> logger, string connString, string cryptoKey)
        {
            log = logger;
            connex = new SqlConnection(connString);
            connex.Open();
            crypto = new Crypto(cryptoKey);
        }

        public void ReOpen()
        {
            connex.Close();
            connex.Open();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant Dispose() calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (connex != null)
                        connex.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
