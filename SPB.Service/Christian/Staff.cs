// File: Component/Staff.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Staff_Search(Dico pager, int? pid, string parent);
        object Staff_Select(int id, string parent);
        object Staff_New(int? officeid, string parent);
        object Staff_Insert(Dico uto);
        void Staff_Update(Dico uto);
        void Staff_Delete(Dico key);
        object Staff_Lookup();
    }

    public partial class AppService
    {
        public object Staff_Search(Dico pager, int? pid, string parent)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("Staff_Search", parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = repo.queryDico($"{parent}_Summary", "@id", pid)
            };
        }

        public object Staff_Select(int id, string parent)
        {
            return new
            {
                item = repo.queryDico("Staff_Select", "@id", id, uid: true),
                xtra = repo.queryDico($"{parent}_Summary", "@staffid", id)
            };
        }

        public object Staff_New(int? pid, string parent)
        {
            return new
            {
                item = repo.queryDico("Staff_New", $"@{parent}id", pid, uid: true),
                xtra = repo.queryDico($"{parent}_Summary", "@id", pid)
            };
        }

        public object Staff_Insert(Dico uto)
        {
            uto.TrimKeys(new string[] { "officeid_text", "jobid_text", "created", "updatedby", "by" });
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("Staff_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Staff_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "officeid_text", "jobid_text", "created", "updatedby", "by" });
            repo.queryNonQuery("Staff_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Staff_Delete(Dico key)
        {
            repo.queryNonQuery("Staff_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }

        public object Staff_Lookup()
        {
            return repo.queryDicoList("Staff_Lookup");
        }
    }
}
