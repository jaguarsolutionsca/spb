// File: Component/Fournisseur.cs

namespace BaseApp.Service
{
    public partial interface IAppService
    {
        object Fournisseur_Search(Dico pager);
        object Fournisseur_Select(string id);
        object Fournisseur_New();
        object Fournisseur_Insert(Dico uto);
        void Fournisseur_Update(Dico uto);
        void Fournisseur_Delete(Dico key);
    }

    public partial class AppService
    {
        public object Fournisseur_Search(Dico pager)
        {
            var parameters = KVList.Build(pager.TrimRowCount().Revive());
            var list = repo.queryDicoList(GP("Fournisseur_Search"), parameters, uid: true);
            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = (object)null
            };
        }

        public object Fournisseur_Select(string id)
        {
            return new
            {
                item = repo.queryDico(GP("Fournisseur_Select"), "@id", id, uid: true),
                xtra = repo.queryDico(GP("Fournisseur_Summary"), "@id", id, uid: true)
            };
        }

        public object Fournisseur_New()
        {
            return new
            {
                item = repo.queryDico(GP("Fournisseur_New"), uid: true),
                xtra = (object)null
            };
        }

        public object Fournisseur_Insert(Dico uto)
        {
            var parameters = KVList.Build(uto.Revive());
            var id = repo.queryScalar<string>(GP("Fournisseur_Insert"), parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Fournisseur_Update(Dico uto)
        {
            repo.queryNonQuery(GP("Fournisseur_Update"), KVList.Build(uto.Revive()), uid: true);
        }

        public void Fournisseur_Delete(Dico key)
        {
            repo.queryNonQuery(GP("Fournisseur_Delete"), KVList.Build(key.Revive()), uid: true);
        }
    }
}
