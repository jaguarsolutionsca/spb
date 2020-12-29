using BaseApp.Common;
using BaseApp.DTO;
using BaseApp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public partial class LookupController : _CoreController
    {
        //[HttpGet("lutGroup")]
        //public List<Lookup2> Lookup_LutGroup()
        //{
        //    return app.Lookup_LutGroup();
        //}

        //
        // There is no need to create entries here for regular tables.
        // Their controller already have the appropriate [HttpGet("lookup")] method
        //
    }
}
