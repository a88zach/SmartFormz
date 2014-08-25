using System.Collections.Generic;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Data.Repositories;

namespace SmartFormz.Services.Folder
{
    public class GetFolderTreeNodeMessage : IMessage
    {
        public long? ParentId { get; set; }
    }
    public class GetFolderTreeNodeRequest : IRequest<GetFolderTreeNodeMessage, ICollection<Business.Models.Folder.Folder>>
    {
        public GetFolderTreeNodeMessage Message { get; set; }
        private  IFolderRepository Repo { get; set; }

        public GetFolderTreeNodeRequest()
        {
            Message = new GetFolderTreeNodeMessage();
            Repo = new FolderRepository();
        }

        public ICollection<Business.Models.Folder.Folder> Execute()
        {
            return Repo.GetFolderTreeNode(Message.ParentId);
        }
    }
}
