using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PS.PostalBeneficiario.UI.MVC.Controllers
{
    public class BaseController : Controller
    {
        public string UserId
        {
            get
            {
                return ControllerContext.HttpContext.User.Identity.IsAuthenticated ? ControllerContext.HttpContext.User.Identity.GetUserId() : "0";
            }
        }

        public const int PageSize = 5;
    }
}