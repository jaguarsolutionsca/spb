// File: Component/PermMeta.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object PermMeta_Search(Dico pager, int? pid = null, string parent = null);
        object PermMeta_Select(int id, string parent = "PermMeta");
        object PermMeta_New(int? pid = null, string parent = null);
        object PermMeta_Insert(Dico uto);
        void PermMeta_Update(Dico uto);
        void PermMeta_Delete(Dico key);
        object PermMeta_Lookup_Groupe();
        object PermMeta_Lookup_Parent();
    }

    public partial class AppService
    {
        public object PermMeta_Search(Dico pager, int? pid = null, string parent = null)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("app.PermMeta_Search", parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = !pid.HasValue ? (object)null : repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
            };
        }

        public object PermMeta_Select(int id, string parent = "PermMeta")
        {
            return new
            {
                item = repo.queryDico("app.PermMeta_Select", "@id", id, uid: true),
                xtra = repo.queryDico($"app.{parent}_Summary", "@PermMetaid", id)
            };
        }

        public object PermMeta_New(int? pid = null, string parent = null)
        {
            if (!pid.HasValue)
                return new
                {
                    item = repo.queryDico("app.PermMeta_New", uid: true),
                    xtra = (object)null
                };
            else
                return new
                {
                    item = repo.queryDico("app.PermMeta_New", $"@{parent}id", pid, uid: true),
                    xtra = repo.queryDico($"app.{parent}_Summary", $"@{parent}id", pid)
                };
        }

        public object PermMeta_Insert(Dico uto)
        {
            uto.TrimKeys(new string[] { "groupe_text", "parentid_text", "created", "updatedby", "by" });
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("app.PermMeta_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void PermMeta_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "groupe_text", "parentid_text", "created", "updatedby", "by" });
            repo.queryNonQuery("app.PermMeta_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void PermMeta_Delete(Dico key)
        {
            repo.queryNonQuery("app.PermMeta_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }

        public object PermMeta_Lookup_Groupe()
        {
            return repo.queryDicoList("app.PermMeta_Lookup_Groupe");
        }

        public object PermMeta_Lookup_Parent()
        {
            return repo.queryDicoList("app.PermMeta_Lookup_Parent");
        }
    }
}
