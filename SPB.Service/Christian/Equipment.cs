// File: Component/Equipment.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Equipment_Search(Dico pager, int? pid = null, string parent = null);
        object Equipment_Select(int id, string parent = "Equipment");
        object Equipment_New(int? pid = null, string parent = null);
        object Equipment_Insert(Dico uto);
        void Equipment_Update(Dico uto);
        void Equipment_Delete(Dico key);
        object Equipment_Lookup();
    }

    public partial class AppService
    {
        public object Equipment_Search(Dico pager, int? pid = null, string parent = null)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("Equipment_Search", parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = !pid.HasValue ? (object)null : repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
            };
        }

        public object Equipment_Select(int id, string parent = "Equipment")
        {
            return new
            {
                item = repo.queryDico("Equipment_Select", "@id", id, uid: true),
                xtra = repo.queryDico($"{parent}_Summary", "@Equipmentid", id)
            };
        }

        public object Equipment_New(int? pid = null, string parent = null)
        {
            if (!pid.HasValue)
                return new
                {
                    item = repo.queryDico("Equipment_New", uid: true),
                    xtra = (object)null
                };
            else
                return new
                {
                    item = repo.queryDico("Equipment_New", $"@{parent}id", pid, uid: true),
                    xtra = repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
                };
        }

        public object Equipment_Insert(Dico uto)
        {
            uto.TrimKeys(new string[] { "staffid_text", "catluid_text", "created", "updatedby", "by" });
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("Equipment_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Equipment_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "staffid_text", "catluid_text", "created", "updatedby", "by" });
            repo.queryNonQuery("Equipment_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Equipment_Delete(Dico key)
        {
            repo.queryNonQuery("Equipment_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }

        public object Equipment_Lookup()
        {
            return repo.queryDicoList("Equipment_Lookup");
        }
    }
}
