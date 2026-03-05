using Microsoft.AspNetCore.Mvc;

namespace eVote360.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
