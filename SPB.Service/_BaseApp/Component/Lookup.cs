// File: Component/Lookup.cs

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
    using System.Collections.Generic;

    public partial interface IAppService
    {
        object Lookup_Search(Dico pager, int? pid = null, string parent = null);
        object Lookup_Select(int id, string parent = "Lookup");
        object Lookup_New(int? pid = null, string parent = null);
        object Lookup_Insert(Dico uto);
        void Lookup_Update(Dico uto);
        void Lookup_Delete(Dico key);
        //
        List<Dico> Lookup_By(string groupe, int? year = null);
    }

    public partial class AppService
    {
        public object Lookup_Search(Dico pager, int? pid = null, string parent = null)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("app.Lookup_Search", parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = !pid.HasValue ? (object)null : repo.queryDico($"app.{parent}_Summary", $"@{parent}id", pid)
            };
        }

        public object Lookup_Select(int id, string parent = "Lookup")
        {
            return new
            {
                item = repo.queryDico("app.Lookup_Select", "@id", id, uid: true),
                xtra = repo.queryDico($"app.{parent}_Summary", "@Lookupid", id)
            };
        }

        public object Lookup_New(int? pid = null, string parent = null)
        {
            if (!pid.HasValue)
                return new
                {
                    item = repo.queryDico("app.Lookup_New", uid: true),
                    xtra = (object)null
                };
            else
                return new
                {
                    item = repo.queryDico("app.Lookup_New", $"@{parent}id", pid, uid: true),
                    xtra = repo.queryDico($"app.{parent}_Summary", $"@{parent}id", pid)
                };
        }

        public object Lookup_Insert(Dico uto)
        {
            uto.TrimKeys(new string[] { "cie_text", "groupe_text", "created", "updatedby", "by" });
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("app.Lookup_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Lookup_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "cie_text", "groupe_text", "created", "updatedby", "by" });
            repo.queryNonQuery("app.Lookup_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Lookup_Delete(Dico key)
        {
            repo.queryNonQuery("app.Lookup_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }



        //
        //
        //

        public List<Dico> Lookup_By(string groupe, int? year = null)
        {
            return repo.queryDicoList("app.Lookup_ListBy_Groupe", KVList.Build()
                .Add("@groupe", groupe)
                .Add("@year", year),
            uid: true);
        }
    }
}
