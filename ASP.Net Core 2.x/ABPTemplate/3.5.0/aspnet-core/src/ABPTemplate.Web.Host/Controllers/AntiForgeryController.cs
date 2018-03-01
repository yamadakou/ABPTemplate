using Microsoft.AspNetCore.Antiforgery;
using ABPTemplate.Controllers;

namespace ABPTemplate.Web.Host.Controllers
{
    public class AntiForgeryController : ABPTemplateControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
