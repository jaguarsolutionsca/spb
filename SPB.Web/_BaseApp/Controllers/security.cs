using Belgrade.SqlClient;
using BaseApp.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace BaseApp.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize, ApiController]
    public class SecurityController : _CoreController
    {
        [HttpGet("{cie}")]
        public async Task GetMatrix(int cie)
        {
            await sqlPipe.Sql($"exec dbo.Perm_List @cie={cie}").Stream(Response.Body);
        }

        [HttpPut("{cie}")]
        public ActionResult Update(int cie, [FromBody] object uto)
        {
            sqlCommand.Proc("app.Perm_UpdateBatch")
                .Param("cie", cie)
                .Param("json", JsonSerializer.Serialize(uto))
                .Exec();
            return NoContent();
        }

        [HttpPost("{cie}")]
        public ActionResult InsertNew(int cie)
        {
            sqlCommand.Proc("app.Perm_CloneDefault")
                .Param("cie", cie)
                .Exec();
            return NoContent();
        }
    }
}
