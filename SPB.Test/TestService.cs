using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseApp.Service;

namespace SPB.Test
{
    public partial interface ITestService : IDisposable
    {
    }

    public partial class TestService : ITestService
    {
        internal IAppService app { get; }

        public TestService(IAppConfigValues configValues)
        {
            app = new AppService();
            app.SetConfigValues(configValues);
        }

        #region IDisposable Support

        bool disposedValue = false; // To detect redundant Dispose() calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    app.Dispose();
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
