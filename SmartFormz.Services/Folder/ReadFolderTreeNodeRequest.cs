using System.Collections.Generic;
using MediatR;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Data.Repositories;

namespace SmartFormz.Services.Folder
{
    public class ReadFolderTreeNodeRequest : IRequest<ICollection<Business.Models.Folder.Folder>>
    {
        public long? ParentId { get; set; }
    }

    public class ReadFolderTreeNodeRequestHandler :
        IRequestHandler<ReadFolderTreeNodeRequest, ICollection<Business.Models.Folder.Folder>>
    {
        private readonly IFolderRepository _repo;

        public ReadFolderTreeNodeRequestHandler(IFolderRepository repo)
        {
            _repo = repo;
        }


        public ICollection<Business.Models.Folder.Folder> Handle(ReadFolderTreeNodeRequest message)
        {
            return _repo.GetFolderTreeNode(message.ParentId);
        }
    }
}
