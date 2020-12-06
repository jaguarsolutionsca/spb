using BaseApp.Common;
using BaseApp.DTO;
using BaseApp.Service;
using BaseApp.UTO;
using BaseApp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("search")]
        public PagedList<Account_Search, Account_Search_Filter> Search(bool? archive, bool? readyToArchive, int pn, int ps, string sc, string sd, string st)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            var pager = new Pager<Account_Search_Filter>(pn, ps, sc, sd, st);
            pager.filter.archive = archive;
            pager.filter.readyToArchive = readyToArchive;
            return app.Account_Search(pager);
        }

        [HttpGet("{uid}")]
        public Account_Full Select(int uid)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            return app.Account_Select(uid, buildUIRouterUrl("accept-invitation/{guid}"));
        }

        [HttpGet("new/{cie}")]
        public Account_Full New(int cie)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            return app.Account_New(cie);
        }

        [HttpPost]
        public Account_PK Insert([FromBody] Account_Update uto)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            return app.Account_Insert(uto, buildUIRouterUrl("accept-invitation/{guid}"));
        }

        [HttpPut]
        public ActionResult Update([FromBody] Account_Update uto)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            app.Account_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Account_UK key)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            app.Account_Delete(key.uid, key.updatedUtc);
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

        [HttpPost("auto-archive}")]
        public ActionResult AutoArchive(int cie)
        {
            app.RequirePermission(Perm.Accounts_Edit);
            app.Auto_Archive(cie);
            return NoContent();
        }
    }
}
