
namespace BaseApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using BaseApp.Common;
    using BaseApp.DAL;

    internal partial class Repo
    {
        public DTO.Profile_Select spProfile_Select(int id)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Profile_Select";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var entity = new DTO.Profile_Select();
                        var ix = -1;
                        ix++; entity.id = reader.GetInt32(ix);
                        ix++; entity.email = reader.GetString(ix);
                        ix++; entity.firstName = reader.GetString(ix);
                        ix++; entity.lastName = reader.GetString(ix);
                        ix++; entity.regionLUID = reader.GetInt32(ix);
                        ix++; entity.regionLUID_Text = reader.GetString(ix);
                        ix++; entity.districtLUID = reader.GetInt32(ix);
                        ix++; entity.districtLUID_Text = reader.GetString(ix);
                        ix++; entity.phone1 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.phone2 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.fax = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.currentYear = reader.GetInt32(ix);
                        ix++; entity.updatedUtc = reader.GetDateTime(ix);
                        return entity.Decrypt(crypto);
                    }
                    return null;
                }
            }
        }

        public void spProfile_Update(UTO.Profile_Select_Update uto, int id)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Profile_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@FirstName", crypto.Encrypt(uto.firstName));
                command.Parameters.AddWithValue("@LastName", crypto.Encrypt(uto.lastName));
                command.Parameters.AddWithValue("@RegionLUID", uto.regionLUID);
                command.Parameters.AddWithValue("@DistrictLUID", uto.districtLUID);
                command.Parameters.AddWithValue("@Phone1", string.IsNullOrEmpty(uto.phone1) ? DBNull.Value : (object)crypto.Encrypt(uto.phone1));
                command.Parameters.AddWithValue("@Phone2", string.IsNullOrEmpty(uto.phone2) ? DBNull.Value : (object)crypto.Encrypt(uto.phone2));
                command.Parameters.AddWithValue("@Fax", string.IsNullOrEmpty(uto.fax) ? DBNull.Value : (object)crypto.Encrypt(uto.fax));
                command.Parameters.AddWithValue("@CurrentYear", uto.currentYear);
                command.Parameters.AddWithValue("@Updated", uto.updatedUtc.ToLocalTime());
                command.ExecuteNonQuery();

            }
        }

    }
}

namespace BaseApp.DTO
{
    using BaseApp.Common;
    using System;

    public class Profile_Select : Account_Select_PK
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string fax { get; set; }
        public int currentYear { get; set; }
        public int regionLUID { get; set; }
        public string regionLUID_Text { get; set; }
        public int districtLUID { get; set; }
        public string districtLUID_Text { get; set; }
        public DateTime updatedUtc { get; set; }

        internal Profile_Select Decrypt(Crypto crypto)
        {
            email = crypto.Decrypt(email);
            firstName = crypto.Decrypt(firstName);
            lastName = crypto.Decrypt(lastName);
            phone1 = crypto.Decrypt(phone1);
            phone2 = crypto.Decrypt(phone2);
            fax = crypto.Decrypt(fax);
            return this;
        }
    }
}

namespace BaseApp.UTO
{
    using System;

    public class Profile_Select_Update
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string fax { get; set; }
        public int currentYear { get; set; }
        public int regionLUID { get; set; }
        public int districtLUID { get; set; }
        public DateTime updatedUtc { get; set; }
    }
}

namespace BaseApp.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using BaseApp.Common;
    using BaseApp.DTO;
    using BaseApp.Mapper;

    public partial interface IAppService
    {
        Profile_Select Get_Profile_Select(int id);
        void Profile_Update(UTO.Profile_Select_Update uto, int id);
    }

    public partial class AppService
    {
        public Profile_Select Get_Profile_Select(int id)
        {
            return repo.spProfile_Select(id);
        }

        public void Profile_Update(UTO.Profile_Select_Update uto, int id)
        {
            repo.spProfile_Update(uto, id);
        }
    }
}