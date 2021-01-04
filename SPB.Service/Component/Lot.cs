// File: Component/Lot.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Lot_Search(Dico pager);
        object Lot_Select(int id);
        object Lot_New();
        object Lot_Insert(Dico uto);
        void Lot_Update(Dico uto);
        void Lot_Delete(Dico key);
    }

    public partial class AppService
    {
        public object Lot_Search(Dico pager)
        {
            var parameters = KVList.Build(pager.TrimRowCount().ReviveUTO());
            var list = repo.queryDicoList(GP("Lot_Search"), parameters, uid: true);
            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = (object)null
            };
        }

        public object Lot_Select(int id)
        {
            return new
            {
                item = repo.queryDico(GP("Lot_Select"), "@id", id, uid: true),
                xtra = repo.queryDico(GP("Lot_Summary"), "@id", id, uid: true)
            };
        }

        public object Lot_New()
        {
            return new
            {
                item = repo.queryDico(GP("Lot_New"), uid: true),
                xtra = (object)null
            };
        }

        public object Lot_Insert(Dico uto)
        {
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>(GP("Lot_Insert"), parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Lot_Update(Dico uto)
        {
            repo.queryNonQuery(GP("Lot_Update"), KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Lot_Delete(Dico key)
        {
            repo.queryNonQuery(GP("Lot_Delete"), KVList.Build(key.ReviveUTO()), uid: true);
        }
    }
}
