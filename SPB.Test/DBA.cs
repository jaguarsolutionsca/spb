using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPB.Test
{
    using BaseApp.Service;
    using System.Data.SqlClient;

    public class DBA
    {
        internal static void TestPrototype()
        {
            var configValues = new AppConfigValues();
            using (var test = new TestService(configValues))
            {
                testQuery(test, configValues.gpConnString);
            }
        }

        static void testQuery(TestService test, string gpConnString)
        {
            var id = "T100";

            //var record = new Gestion_Paie.BusinessComponents.Fournisseur_Record(gpConnString, id);
            //record.Refresh();

            //var Param = new Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_Full();
            //Param.SetUpConnection(gpConnString);
            //Param.Param_ID = id;
            //var SP = new Gestion_Paie.DataClasses.StoredProcedures.spS_Fournisseur_Full(true);
            //SP.Execute(ref Param, out SqlDataReader reader);
            //reader.Close();

            var oFou = test.app.Fournisseur_Select(id);
        }
    }
}
