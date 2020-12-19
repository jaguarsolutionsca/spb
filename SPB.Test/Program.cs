using System;
using System.Collections.Generic;
using System.Data;

namespace SPB.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Something>();
            list.Add(new Something { Code = 1111, Nom = "VAL QUIRI", Montant = 9141.11M });
            list.Add(new Something { Code = 2222, Nom = "Cheval", Montant = 9142.22M });
            list.Add(new Something { Code = 3333, Nom = "Camion", Montant = 9143.33M });

            var ds = new DataSet("Bonjour");
            var dt = ExcelReport.ToDataTable<Something>(list);
            ds.Tables.Add(dt);

            ExcelReport.InsertDataSet(ds, "./templates/test.xlsx");
        }
    }

    public class Something
    {
        public int Code { get; set; }
        public string Nom { get; set; }
        public decimal Montant { get; set; }
    }
}
