using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Service
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;
    using System.Reflection;

    public partial interface IAppService
    {
        bool EmailEnabled { get; }
    }

    public partial class AppService
    {
        public bool EmailEnabled
        {
            get { return config.GetValue<bool>("Email:Enabled"); }
        }
    }
}
