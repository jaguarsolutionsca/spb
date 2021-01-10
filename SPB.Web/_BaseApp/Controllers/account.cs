using BaseApp.Common;
using BaseApp.DTO;
using BaseApp.Service;
using BaseApp.UTO;
using BaseApp.Web.Controllers;
using BaseApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApp.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize, ApiController]
    public class AccountController : _CoreController
    {
        [HttpPost("search")]
        public object Search([FromBody] Dico pager)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            return app.Account_Search(pager);
        }

        [HttpGet("{uid}")]
        public object Select(int uid)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            return app.Account_Select(uid);
        }

        [HttpGet("new")]
        public object New()
        {
            app.RequirePermission(Perm.Accounts_Edit);
            var cie = User.Get_CIE();
            return app.Account_New(cie);
        }

        [HttpPost]
        public object Insert([FromBody] Dico uto)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            return app.Account_Insert(uto, buildUIRouterUrl("accept-invitation/{guid}"));
        }

        [HttpPut]
        public ActionResult Update([FromBody] Dico uto)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            app.Account_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Dico key)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            app.Account_Delete(key);
            return NoContent();
        }

        [HttpPost("reset-password")]
        public ActionResult ResetPassword([FromBody] Account_PK model)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            app.Reset_PasswordBy_Admin(model.uid, buildUIRouterUrl("reset-password/{guid}"));
            return NoContent();
        }

        [HttpPost("create-invitation")]
        public ActionResult CreateInvitation([FromBody] Account_PK model)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            app.Create_Invitation(model.uid, buildUIRouterUrl("accept-invitation/{guid}"));
            return NoContent();
        }

        //[HttpPost("refresh")]
        //public AuthorizationData Refresh()
        //{
        //    var usercaps = app.RefreshAppLogin();
        //    return populateAuthorizationData(usercaps);
        //}

        [HttpGet("role")]
        public List<Lookup> Lookup_Role()
        {
            var uid = User.Get_UID();
            return app.Account_GetRoleLookup(uid);
        }

        [HttpPost("auto-archive")]
        public ActionResult AutoArchive()
        {
            var cie = User.Get_CIE();
            app.RequirePermission(Perm.Accounts_Edit);
            app.Auto_Archive(cie);
            return NoContent();
        }
    }
}
