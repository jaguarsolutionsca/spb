using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Common
{
    public class Mapper
    {
        public static Tdestin mapTo<Tsource, Tdestin>(Tsource source) where Tdestin : new()
        {
            var sourceType = typeof(Tsource);
            var destinType = typeof(Tdestin);
            var sourceProps = sourceType.GetProperties(); //note: not dealing with Fields
            var destinProps = destinType.GetProperties(); //note: not dealing with Fields

            Tdestin destin = new Tdestin();
            foreach (var sourceProp in sourceProps)
            {
                var destinProp = destinType.GetProperty(sourceProp.Name);
                if (destinProp != null)
                {
                    destinProp.SetValue(destin, sourceProp.GetValue(source));
                }
            }
            return destin;
        }
    }
}
