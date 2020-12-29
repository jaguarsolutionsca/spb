using System;
using System.Collections.Generic;
using System.Text;

namespace BaseApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    internal partial class Repo
    {
        public List<DTO.Lookup> Lookup_ListDistinct_Groupe()
        {
            var list = new List<DTO.Lookup> {
                //new Lookup { Groupe = "yn", Description = "Yes, No" },
            };
            return list;
        }
    }
}

namespace BaseApp.Service
{
    using BaseApp.DTO;
    using BaseApp.Mapper;

    public partial interface IAppService
    {
        List<Lookup> Lookup_LutGroup();
    }

    public partial class AppService
    {
        public List<Lookup> Lookup_LutGroup()
        {
            return repo.Lookup_ListDistinct_Groupe();
        }

        //
        // All tables have a table_Lookup() method.
        // The controller should call that method instead of creating a shim here.
        //
    }
}
