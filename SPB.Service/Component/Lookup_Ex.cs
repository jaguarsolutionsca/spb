using System;
using System.Collections.Generic;
using System.Text;

namespace BaseApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    internal partial class Repo
    {
        public List<Lookup> Lookup_ListDistinct_Groupe()
        {
            var list = new List<Lookup> {
                new Lookup { Groupe = "attype", Description = "Air Attack Type (WFR)" },
                new Lookup { Groupe = "atbase", Description = "Air Tanker Base (WFR)" },
                new Lookup { Groupe = "airtyp", Description = "Aircraft Class" },
                new Lookup { Groupe = "alert", Description = "Alert Code (WFR)" },
                new Lookup { Groupe = "atbasealert", Description = "Attack Base Alert" },
                new Lookup { Groupe = "chargeback", Description = "Charge Back" },
                new Lookup { Groupe = "codingsupply", Description = "Coding Supply by Region" },
                new Lookup { Groupe = "codingsupreg", Description = "Coding Supply by District" },
                new Lookup { Groupe = "codingcbeff", Description = "Coding CB / EFF" },
                new Lookup { Groupe = "commitrole", Description = "Commitment Role" },
                new Lookup { Groupe = "committype", Description = "Commitment Type" },
                new Lookup { Groupe = "crewtype", Description = "Crew Type (WFR)" },
                new Lookup { Groupe = "detmet", Description = "Detection Method (WFR)" },
                new Lookup { Groupe = "direction", Description = "Direction" },
                new Lookup { Groupe = "district", Description = "District" },
                new Lookup { Groupe = "equipment", Description = "Equipment" },
                new Lookup { Groupe = "fbptyp", Description = "FBP Fuel Type" },
                new Lookup { Groupe = "fbptyppct", Description = "FBP Fuel Type Percent" },
                new Lookup { Groupe = "action", Description = "Fire Action" },
                new Lookup { Groupe = "fcause", Description = "Fire Cause (daily/historical Fire Entry)" },
                new Lookup { Groupe = "cause", Description = "Fire Cause (WFR)" },
                new Lookup { Groupe = "fstat", Description = "Fire Status (daily/hist Fire Entry)" },
                new Lookup { Groupe = "firtyp", Description = "Fire Type" },
                new Lookup { Groupe = "firwx", Description = "Fire Weather (daily/hist Fire Entry)" },
                new Lookup { Groupe = "genact", Description = "General Activity" },
                new Lookup { Groupe = "hire", Description = "Hire" },
                new Lookup { Groupe = "indian", Description = "Indian Reserves" },
                new Lookup { Groupe = "intensity", Description = "Intensity" },
                new Lookup { Groupe = "iabase", Description = "Initial Attack Base" },
                new Lookup { Groupe = "transp", Description = "Initial Attack Transport" },
                new Lookup { Groupe = "iatype", Description = "Initial Attack Type" },
                new Lookup { Groupe = "iazone", Description = "Initial Attack Zone" },
                new Lookup { Groupe = "ks", Description = "Known/Suspected (WFR)" },
                new Lookup { Groupe = "land", Description = "Land Status (WFR)" },
                new Lookup { Groupe = "locgov", Description = "Local Goverment (WFR)" },
                new Lookup { Groupe = "factor", Description = "Major Factor" },
                new Lookup { Groupe = "map", Description = "Map" },
                new Lookup { Groupe = "maplink", Description = "Map - Links" },
                new Lookup { Groupe = "othercharge", Description = "Other Charge" },
                new Lookup { Groupe = "outprovince", Description = "Out Of Province" },
                new Lookup { Groupe = "rurmun", Description = "Owner Municipal Land" },
                new Lookup { Groupe = "owner", Description = "Ownership (WFR)" },
                new Lookup { Groupe = "priozo", Description = "Priority Zone" },
                new Lookup { Groupe = "protzo", Description = "Protection Zone" },
                new Lookup { Groupe = "province", Description = "Province" },
                new Lookup { Groupe = "quickstrike", Description = "Quick Strike" },
                new Lookup { Groupe = "ros", Description = "Rate Of Spread" },
                new Lookup { Groupe = "ratetype", Description = "Rate Type" },
                new Lookup { Groupe = "reason", Description = "Reason (WFR)" },
                new Lookup { Groupe = "region", Description = "Regions (Exclude HQ)" },
                new Lookup { Groupe = "role", Description = "Role" },
                new Lookup { Groupe = "servprov", Description = "Service Provider" },
                new Lookup { Groupe = "speact", Description = "Specific Activity" },
                new Lookup { Groupe = "fuel", Description = "Surface Fuel" },
                new Lookup { Groupe = "tools", Description = "Tools - Links" },
                new Lookup { Groupe = "var", Description = "Value at Risk" },
                new Lookup { Groupe = "update", Description = "Weather Update (WFR)" },
                new Lookup { Groupe = "yn", Description = "Yes, No" },
            };

            return list;
        }

        public List<Lookup> Lookup_DistrictInRegion(int regionLUID)
        {
            var list = new List<Lookup>();

            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Lookup]";
                var columns = "ID,Code,Description";
                var where = "Groupe='District' AND Value2=@p1";

                command.CommandText = @"SELECT " + columns + " FROM " + table + " WHERE " + where;
                command.Parameters.AddWithValue("@p1", regionLUID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new Lookup();
                        var ix = -1;
                        ix++; entity.ID = reader.GetInt32(ix);
                        ix++; entity.Code = reader.GetString(ix);
                        ix++; entity.Description = reader.GetString(ix);
                        list.Add(entity);
                    }
                }
            }

            return list;
        }
    }
}

namespace BaseApp.Service
{
    using BaseApp.DTO;
    using BaseApp.Mapper;

    public partial interface IAppService
    {
        List<Lookup> Lookup_By(string groupe);
        List<Lookup> Lookup_By(string groupe, int year);
        Lookup Lookup_SingleBy_Code(string groupe, string code);
        Lookup Lookup_Single(int id);
        List<Lookup2> Lookup_LutGroup();
        List<Lookup> Lookup_Cat();
        List<Lookup> Lookup_Kind();
        List<Lookup> Lookup_Region();
        List<Lookup> Lookup_District();
        List<Lookup> Lookup_DistrictInRegion(int regionLUID);
        List<Lookup> Lookup_FCause();
        List<Lookup> Lookup_Action();
        List<Lookup> Lookup_Zone();
        List<Lookup> Lookup_Status();
    }

    public partial class AppService
    {
        public List<Lookup> Lookup_By(string groupe)
        {
            return repo.Lookup_ListBy_Groupe(groupe).ToDTO();
        }

        public List<Lookup> Lookup_By(string groupe, int year)
        {
            return repo.Lookup_ListBy_Groupe(groupe, year).ToDTO();
        }

        public Lookup Lookup_SingleBy_Code(string groupe, string code)
        {
            return repo.Lookup_SingleBy_Code(groupe, code).ToDTO();
        }

        public Lookup Lookup_Single(int id)
        {
            return repo.Lookup_Single(id).ToDTO();
        }

        public List<Lookup2> Lookup_LutGroup()
        {
            return repo.Lookup_ListDistinct_Groupe().ToDTO2();
        }

        public List<Lookup> Lookup_Cat()
        {
            return repo.Lookup_ListBy_Groupe("CAT").ToDTO();
        }

        public List<Lookup> Lookup_Kind()
        {
            return repo.Lookup_ListBy_Groupe("KIND").ToDTO();
        }

        public List<Lookup> Lookup_Region()
        {
            return repo.Lookup_ListBy_Groupe("REGION").ToDTO();
        }

        public List<Lookup> Lookup_District()
        {
            return repo.Lookup_ListBy_Groupe("DISTRICT").ToDTO();
        }

        public List<Lookup> Lookup_DistrictInRegion(int regionLUID)
        {
            return repo.Lookup_DistrictInRegion(regionLUID).ToDTO();
        }

        public List<Lookup> Lookup_FCause()
        {
            return repo.Lookup_ListBy_Groupe("FCAUSE").ToDTO();
        }

        public List<Lookup> Lookup_Action()
        {
            return repo.Lookup_ListBy_Groupe("ACTION").ToDTO();
        }

        public List<Lookup> Lookup_Zone()
        {
            return repo.Lookup_ListBy_Groupe("PRIOZO").ToDTO();
        }

        public List<Lookup> Lookup_Status()
        {
            return repo.Lookup_ListBy_Groupe("FSTAT").ToDTO();
        }

        //
        // All tables have a table_Lookup() method.
        // The controller should call that method instead of creating a shim here.
        //
    }
}
