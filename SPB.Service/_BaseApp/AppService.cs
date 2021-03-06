﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Service
{
    using BaseApp.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System.Security.Claims;
    using System.Security.Principal;

    public partial interface IAppService : IDisposable
    {
        IAppService SetConfigValues(IAppConfigValues configValues);
    }

    public partial class AppService : IAppService
    {
        internal DAL.Repo repo;
        internal ILogger log;
        internal IConfiguration config;
        internal ClaimsPrincipal user;
        internal Crypto crypto;

        public AppService(ILogger<object> logger, IConfiguration config, IPrincipal user)
        {
            this.log = logger;
            this.config = config;
            this.user = user as ClaimsPrincipal;
            this.crypto = new Crypto(CryptoKey);

            var connString = config.GetConnectionString("DefaultConnection");
            repo = new DAL.Repo(logger, connString, CryptoKey, user);
        }

        public AppService()
        {
        }

        public IAppService SetConfigValues(IAppConfigValues configValues)
        {
            repo = new DAL.Repo(null, configValues.connString, configValues.cryptoKey);

            return this;
        }

        public string GP(string sproc)
        {
            return $"Gestion_Paie.dbo.{sproc}";
        }

        #region IDisposable Support

        bool disposedValue = false; // To detect redundant Dispose() calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    repo.Dispose();
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
