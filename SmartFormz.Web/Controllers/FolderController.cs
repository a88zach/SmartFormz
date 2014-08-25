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
                var message = new GetFolderTreeNodeMessage
                {
                    ParentId = null
                };
                folders = new GetFolderTreeNodeRequest
                {
                    Message = message
                }.Execute();
            }
            else
            {
                var message = new GetFolderTreeNodeMessage
                {
                    ParentId = long.Parse(id)
                };
                folders = new GetFolderTreeNodeRequest
                {
                    Message = message
                }.Execute();
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