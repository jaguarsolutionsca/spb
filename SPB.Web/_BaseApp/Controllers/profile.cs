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
    [Authorize]
    public class ProfileController : _CoreController
    {
        [HttpGet]
        public Profile_Select Get()
        {
            var id = User.Get_UID();
            return app.Get_Profile_Select(id);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Profile_Select_Update uto)
        {
            var id = User.Get_UID();
            app.Profile_Update(uto, id);
            return NoContent();
        }
    }
}
