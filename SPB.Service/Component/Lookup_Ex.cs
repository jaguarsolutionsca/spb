using System;
using System.Collections.Generic;
using System.Text;

namespace BaseApp.DTO
{
    public class Lookup
    {
        public int id { get; set; }
        public int cie { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public int started { get; set; }
        public int? ended { get; set; }
        public int? sortOrder { get; set; }
        public bool? disabled { get; set; }
    }
}

namespace BaseApp.Service
{
    using BaseApp.Common;
    using BaseApp.DTO;
    using BaseApp.Mapper;

    public partial interface IAppService
    {
        List<Lookup> Lookup_LutGroup();
        List<Dico> Lookup_By(string groupe, int? year = null);
    }

    public partial class AppService
    {
        public List<Lookup> Lookup_LutGroup()
        {
            var list = new List<Lookup>
            {
                //new Lookup { Groupe = "yn", Description = "Yes, No" },
            };
            return list;
        }

        public List<Dico> Lookup_By(string groupe, int? year = null)
        {
            return repo.queryDicoList("app.Lookup_ListBy_Groupe", KVList.Build()
                .Add("@groupe", groupe)
                .Add("@year", year)
                );
        }

        //
        // All tables have a table_Lookup() method.
        // The controller should call that method instead of creating a shim here.
        //
    }
}
