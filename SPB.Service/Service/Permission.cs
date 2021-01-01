using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseApp.DTO;
using System.Threading;
using BaseApp.Common;

namespace BaseApp.Service
{
    public enum Role
    {
        Admin = 1,
        Everyone = 2,
        AppManager = 4,
        HQPowerUser = 8,
        PowerUser = 16,
        RegularUser = 32,
        ReadOnly = 64
    }

    public enum Perm
    {
        Accounts_Edit = 100,
        Company_Edit = 100,
        Fournisseur_Edit = 100,
        //
        Aircraft_CanEditHired = 100201,
        Aircraft_CanUseDataEntry = 100200,
        Cost_CanUseDataEntry = 100900,
        Fire_CanEditDailySituation = 406,
        Fire_CanManageFireUpdate = 402,
        Fire_CanUseDataEntry = 400,
        Home_CanEditAllinDistrict = 207,
        Home_CanEditAllinProvince = 209,
        Home_CanEditAllinRegion = 208,
        Home_CanEditHistoricalData = 210,
        Home_CanViewAdminManagement = 201,
        Home_CanViewAdminModule = 200,
        Weather_CanUseDataEntry = 100800,
    }

    public partial interface IAppService
    {
        void RequireRole(Role role);
        void RequirePermission(int permission);
        void RequirePermission(Perm permission);
        void RequirePermissionAny(Perm[] permissions);
        void RequirePermission(bool allowed);
        void DenyPermission(Perm permission);
    }

    public partial class AppService
    {
        public void RequireRole(Role role)
        {
            if (!user.HasRole((int)role))
                throw new SecurityException();
        }

        public void RequirePermission(int permission)
        {
            if (!user.HasPermission(permission))
                throw new SecurityException();
        }

        public void RequirePermission(Perm permission)
        {
            if (!user.HasPermission((int)permission))
                throw new SecurityException();
        }

        public void RequirePermissionAny(Perm[] permissions)
        {
            foreach (var permission in permissions)
            {
                if (user.HasPermission((int)permission))
                    return;
            }
            throw new SecurityException();
        }

        public void RequirePermission(bool allowed)
        {
            if (!allowed)
                throw new SecurityException();
        }

        public void DenyPermission(Perm permission)
        {
            if (!user.DoesNotHavePermission((int)permission))
                throw new SecurityException();
        }
    }
}
