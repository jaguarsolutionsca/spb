// File: Component/Lookup.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Lookup_Search(Dico pager);
        object Lookup_Select(int id);
        object Lookup_New();
        object Lookup_Insert(Dico uto);
        void Lookup_Update(Dico uto);
        void Lookup_Delete(Dico key);
    }

    public partial class AppService
    {
        public object Lookup_Search(Dico pager)
        {
            var parameters = KVList.Build(pager.TrimRowCount().ReviveUTO());
            var list = repo.queryDicoList("Lookup_Search", parameters, uid: true);
            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = (object)null
            };
        }

        public object Lookup_Select(int id)
        {
            return new
            {
                item = repo.queryDico("Lookup_Select", "@id", id, uid: true),
                xtra = repo.queryDico("Lookup_Summary", "@id", id, uid: true)
            };
        }

        public object Lookup_New()
        {
            return new
            {
                item = repo.queryDico("Lookup_New", uid: true),
                xtra = (object)null
            };
        }

        public object Lookup_Insert(Dico uto)
        {
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("Lookup_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Lookup_Update(Dico uto)
        {
            repo.queryNonQuery("Lookup_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Lookup_Delete(Dico key)
        {
            repo.queryNonQuery("Lookup_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }
    }
}
