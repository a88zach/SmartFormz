using System.Threading.Tasks;
using System.Web.Mvc;
using SmartFormz.Business.Models.Folder;
using SmartFormz.Business.Models.Form;
using SmartFormz.Services;
using SmartFormz.Services.Folder;
using SmartFormz.Services.Form;

namespace SmartFormz.Web.Admin.Controllers
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

        public async Task<ActionResult> Test()
        {
            var request = new SaveFormRequest
            {
                Message =
                {
                    Form = new Form()
                    {
                        Name = "Test",
                        Description = "Test Desc"
                    }
                }
            };

            var result = await request.Execute();

            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Test2()
        {
            var parent = new Folder
            {
                FolderId = 2,
                Name = "Test2"
            };

            var request = new SaveFolderRequest
            {
                Message =
                {
                    Folder = new Folder()
                    {
                        Name = "Test2",
                        Parent = parent

                    }
                }
            };

            var result = await request.Execute();

            return RedirectToAction("Index");

        }
    }
}