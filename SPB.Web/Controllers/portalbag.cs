
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalBagController : _CoreController
    {
        [HttpGet]
        public PortalBag GetPortalBag(string u)
        {
            var request = Encoding.ASCII.GetString(Convert.FromBase64String(u));
            var uri = new Uri(request);
            var bag = buildPortalBag(uri);
            return bag;
        }
    }
}
