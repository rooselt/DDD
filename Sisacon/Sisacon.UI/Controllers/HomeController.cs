using System.Web.Mvc;

namespace Sisacon.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LandingPage()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Account()
        {
            return View();
        }
    }
}