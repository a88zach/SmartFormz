using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Data.Repositories;

namespace SmartFormz.Services.Folder
{
    public class GetChildFildersMessage : IMessage
    {
        public long ParentId { get; set; }
    }
    public class GetChildFoldersRequest : IRequest<GetChildFildersMessage, ICollection<Business.Models.Folder.Folder>>
    {
        public GetChildFildersMessage Message { get; set; }
        private  IFolderRepository _repo { get; set; }

        public GetChildFoldersRequest()
        {
            Message = new GetChildFildersMessage();
            _repo = new FolderRepository();
        }

        public ICollection<Business.Models.Folder.Folder> Execute()
        {
            return _repo.GetChildFolders(Message.ParentId);
        }
    }
}
