using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using SmartFormz.Business.Models.Folder;
using SmartFormz.Services.Folder;
using SmartFormz.Web.Models;
using SmartFormz.Web.Models.JsViewModels;

namespace SmartFormz.Web.Controllers
{
    public class FolderController : SmartFormzController
    {
        public JsonResult GetFormTree(string id)
        {
            ICollection<Folder> folders;
            if (id == "#")
            {
                folders = Mediator.Send(new GetFolderTreeNodeRequest
                {
                    ParentId = null
                });
            }
            else
            {
                folders = Mediator.Send(new GetFolderTreeNodeRequest
                {
                    ParentId = long.Parse(id)
                });
            }

            var folderList = folders.Select(f => new JsTreeResult
            {
                id = f.Id.ToString(CultureInfo.InvariantCulture), 
                text = f.Name, 
                type = "folder",
                children = true
            }).ToList();

            return Json(folderList, JsonRequestBehavior.AllowGet);
        }
    }
}