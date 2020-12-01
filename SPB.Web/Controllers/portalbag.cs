
namespace LiveCore.Web.Controllers
{
    using BaseApp.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
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
