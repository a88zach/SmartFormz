using System.Collections.Generic;
using MediatR;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Data.Repositories;

namespace SmartFormz.Services.Folder
{
    public class GetFolderTreeNodeRequest : IRequest<ICollection<Business.Models.Folder.Folder>>
    {
        public long? ParentId { get; set; }
    }

    public class GetFolderTreeNodeRequestHandler :
        IRequestHandler<GetFolderTreeNodeRequest, ICollection<Business.Models.Folder.Folder>>
    {
        private readonly IFolderRepository _repo;

        public GetFolderTreeNodeRequestHandler(IFolderRepository repo)
        {
            _repo = repo;
        }


        public ICollection<Business.Models.Folder.Folder> Handle(GetFolderTreeNodeRequest message)
        {
            return _repo.GetFolderTreeNode(message.ParentId);
        }
    }
}
