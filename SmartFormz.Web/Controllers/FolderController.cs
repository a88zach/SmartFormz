using System.Collections.Generic;
using System.Web.Mvc;
using SmartFormz.Services.Folder;
using SmartFormz.Web.Models;

namespace SmartFormz.Web.Controllers
{
    public class FolderController : Controller
    {
        // GET: Folder
        public PartialViewResult RootFolders()
        {
            var model = new List<TreeViewModel>();
            var request = new GetChildFoldersRequest {Message = {ParentId = 1}};
            var data = request.Execute();

            foreach (var folder in data)
            {
                model.Add(new TreeViewModel()
                {
                    label = folder.Name,
                    id = folder.FolderId,
                    load_on_demand = true
                });
            }
            return PartialView("_Folders", model);
        }

        public JsonResult ChildFolders(long node)
        {
            var model = new List<TreeViewModel>();
            var request = new GetChildFoldersRequest { Message = { ParentId = node } };
            var data = request.Execute();

            foreach (var folder in data)
            {
                model.Add(new TreeViewModel()
                {
                    label = folder.Name,
                    id = folder.FolderId,
                    load_on_demand = true
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}