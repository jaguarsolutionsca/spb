// File: Component/Lot_Proprietaire.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Lot_Proprietaire_Search(Dico pager);
        object Lot_Proprietaire_Select(int id);
        object Lot_Proprietaire_New(string proprietaireid);
        object Lot_Proprietaire_Insert(Dico uto);
        void Lot_Proprietaire_Update(Dico uto);
        void Lot_Proprietaire_Delete(Dico key);
    }

    public partial class AppService
    {
        public object Lot_Proprietaire_Search(Dico pager)
        {
            var parameters = KVList.Build(pager.TrimRowCount().ReviveUTO());
            var list = repo.queryDicoList("Lot_Proprietaire_Search", parameters, uid: true);
            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = (object)null //repo.queryDico("Fournisseur_Summary", "@proprietaireid", proprietaireid)

            };
        }

        public object Lot_Proprietaire_Select(int id)
        {
            return new
            {
                item = repo.queryDico("Lot_Proprietaire_Select", "@id", id, uid: true),
                xtra = (object)null //repo.queryDico("Fournisseur_Summary", "@proprietaireid", proprietaireid, uid: true)
            };
        }

        public object Lot_Proprietaire_New(string proprietaireid)
        {
            return new
            {
                item = repo.queryDico("Lot_Proprietaire_New", uid: true),
                xtra = (object)null //repo.queryDico("Fournisseur_Summary", "@proprietaireid", proprietaireid, uid: true)

            };
        }

        public object Lot_Proprietaire_Insert(Dico uto)
        {
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("Lot_Proprietaire_Insert", parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Lot_Proprietaire_Update(Dico uto)
        {
            repo.queryNonQuery("Lot_Proprietaire_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Lot_Proprietaire_Delete(Dico key)
        {
            repo.queryNonQuery("Lot_Proprietaire_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }
    }
}