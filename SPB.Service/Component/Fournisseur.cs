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
            var list = repo.queryDicoList(GP("Fournisseur_Search"), parameters);
            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list)
            };
        }

        public object Fournisseur_Select(string id)
        {
            return new
            {
                item = repo.queryDico(GP("Fournisseur_Select"), "@id", id),
                xtra = repo.queryDico(GP("Fournisseur_Summary"), "@id", id)
            };
        }

        public object Fournisseur_New()
        {
            return new
            {
                item = repo.queryDico(GP("spS_Fournisseur_Full"), "@id", "---"),
                xtra = repo.queryDico(GP("Fournisseur_Summary"))
            };
        }

        public object Fournisseur_Insert(Dico uto)
        {
            var parameters = KVList.Build(uto.Revive());
            var id = repo.queryScalar<string>(GP("spI_Fournisseur"), parameters);
            return new
            {
                id = id
            };
        }

        public void Fournisseur_Update(Dico uto)
        {
            repo.queryNonQuery(GP("spU_Fournisseur"), KVList.Build(uto.Revive()));
        }

        public void Fournisseur_Delete(Dico key)
        {
            repo.queryNonQuery(GP("spD_Fournisseur"), KVList.Build(key.Revive()));
            //.Add("@updated", concurrencyUtc.ToLocalTime())
        }
    }
}
