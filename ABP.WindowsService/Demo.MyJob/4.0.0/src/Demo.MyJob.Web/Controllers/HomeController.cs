using Microsoft.AspNetCore.Mvc;

namespace Demo.MyJob.Web.Controllers
{
    public class HomeController : MyJobControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}