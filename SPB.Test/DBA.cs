using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPB.Test
{
    using BaseApp.Service;

    public class DBA
    {
        internal static void TestPrototype()
        {
            var configValues = new AppConfigValues();
            using (var test = new TestService(configValues))
            {
                testMap(test);
            }
        }

        static void testMap(TestService test)
        {
            test.app.Fournisseur_Select("T100");
        }
    }
}
