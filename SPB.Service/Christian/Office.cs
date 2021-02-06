// File: Component/Office.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Office_Search(Dico pager);
        object Office_Select(int id);
        object Office_New();
        object Office_Insert(Dico uto);
        void Office_Update(Dico uto);
        void Office_Delete(Dico key);
    }

    public partial class AppService
    {
        public object Office_Search(Dico pager)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("Office_Search", parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = (object)null
            };
        }

        public object Office_Select(int id)
        {
            return new
            {
                item = repo.queryDico("Office_Select", "@id", id, uid: true),
                xtra = repo.queryDico("Office_Summary", "@id", id, uid: true)
            };
        }

        public object Office_New()
        {
            return new
            {
                item = repo.queryDico("Office_New", uid: true),
                xtra = (object)null
            };
        }

        public object Office_Insert(Dico uto)
        {
            uto.TrimKeys(new string[] { "created", "by" });
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("Office_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Office_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "created", "by" });
            repo.queryNonQuery("Office_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Office_Delete(Dico key)
        {
            repo.queryNonQuery("Office_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }
    }
}
