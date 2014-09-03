using System.Threading.Tasks;
using System.Web.Mvc;
using SmartFormz.Business.Models.Folder;
using SmartFormz.Business.Models.Form;
using SmartFormz.Services.Folder;
using SmartFormz.Services.Form;

namespace SmartFormz.Web.Controllers
{
    public class HomeController : SmartFormzController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}