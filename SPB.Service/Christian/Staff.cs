// File: Component/Staff.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Staff_Search(Dico pager, int? pid = null, string parent = null);
        object Staff_Select(int id, string parent = "Staff");
        object Staff_New(int? pid = null, string parent = null);
        object Staff_Insert(Dico uto);
        void Staff_Update(Dico uto);
        void Staff_Delete(Dico key);
        object Staff_Lookup();
    }

    public partial class AppService
    {
        public object Staff_Search(Dico pager, int? pid = null, string parent = null)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("Staff_Search", parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = !pid.HasValue ? (object)null : repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
            };
        }

        public object Staff_Select(int id, string parent = "Staff")
        {
            return new
            {
                item = repo.queryDico("Staff_Select", "@id", id, uid: true),
                xtra = repo.queryDico($"{parent}_Summary", "@Staffid", id)
            };
        }

        public object Staff_New(int? pid = null, string parent = null)
        {
            if (!pid.HasValue)
                return new
                {
                    item = repo.queryDico("Staff_New", uid: true),
                    xtra = (object)null
                };
            else
                return new
                {
                    item = repo.queryDico("Staff_New", $"@{parent}id", pid, uid: true),
                    xtra = repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
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
