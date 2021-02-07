// File: Component/Office.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Office_Search(Dico pager, int? pid = null, string parent = null);
        object Office_Select(int id, string parent = "Office");
        object Office_New(int? pid = null, string parent = null);
        object Office_Insert(Dico uto);
        void Office_Update(Dico uto);
        void Office_Delete(Dico key);
        object Office_Lookup();
    }

    public partial class AppService
    {
        public object Office_Search(Dico pager, int? pid = null, string parent = null)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("Office_Search", parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = !pid.HasValue ? (object)null : repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
            };
        }

        public object Office_Select(int id, string parent = "Office")
        {
            return new
            {
                item = repo.queryDico("Office_Select", "@id", id, uid: true),
                xtra = repo.queryDico($"{parent}_Summary", "@Officeid", id)
            };
        }

        public object Office_New(int? pid = null, string parent = null)
        {
            if (!pid.HasValue)
                return new
                {
                    item = repo.queryDico("Office_New", uid: true),
                    xtra = (object)null
                };
            else
                return new
                {
                    item = repo.queryDico("Office_New", $"@{parent}id", pid, uid: true),
                    xtra = repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
                };
        }

        public object Office_Insert(Dico uto)
        {
            uto.TrimKeys(new string[] { "created", "updatedby", "by" });
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("Office_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Office_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "created", "updatedby", "by" });
            repo.queryNonQuery("Office_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Office_Delete(Dico key)
        {
            repo.queryNonQuery("Office_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }

        public object Office_Lookup()
        {
            return repo.queryDicoList("Office_Lookup");
        }
    }
}
