// File: Component/Job.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Job_Search(Dico pager, int? pid = null, string parent = null);
        object Job_Select(int id, string parent = "Job");
        object Job_New(int? pid = null, string parent = null);
        object Job_Insert(Dico uto);
        void Job_Update(Dico uto);
        void Job_Delete(Dico key);
        object Job_Lookup();
    }

    public partial class AppService
    {
        public object Job_Search(Dico pager, int? pid = null, string parent = null)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("Job_Search", parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = !pid.HasValue ? (object)null : repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
            };
        }

        public object Job_Select(int id, string parent = "Job")
        {
            return new
            {
                item = repo.queryDico("Job_Select", "@id", id, uid: true),
                xtra = repo.queryDico($"{parent}_Summary", "@Jobid", id)
            };
        }

        public object Job_New(int? pid = null, string parent = null)
        {
            if (!pid.HasValue)
                return new
                {
                    item = repo.queryDico("Job_New", uid: true),
                    xtra = (object)null
                };
            else
                return new
                {
                    item = repo.queryDico("Job_New", $"@{parent}id", pid, uid: true),
                    xtra = repo.queryDico($"{parent}_Summary", $"@{parent}id", pid)
                };
        }

        public object Job_Insert(Dico uto)
        {
            uto.TrimKeys(new string[] { "kindluid_text", "created", "updatedby", "by" });
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("Job_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Job_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "kindluid_text", "created", "updatedby", "by" });
            repo.queryNonQuery("Job_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Job_Delete(Dico key)
        {
            repo.queryNonQuery("Job_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }

        public object Job_Lookup()
        {
            return repo.queryDicoList("Job_Lookup");
        }
    }
}
