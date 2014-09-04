using System.Threading.Tasks;
using MediatR;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.ResultModels;
using SmartFormz.Data.Repositories;

namespace SmartFormz.Services.Folder
{

    public class CreateFolderRequest : IAsyncRequest<SaveResult<Business.Models.Folder.Folder>>
    {
        public Business.Models.Folder.Folder Folder { get; set; }
    }

    public class CreateFolderRequestHandler :
        IAsyncRequestHandler<CreateFolderRequest, SaveResult<Business.Models.Folder.Folder>>
    {
        private readonly IFolderRepository _repo;

        public CreateFolderRequestHandler(IFolderRepository repo)
        {
            _repo = repo;
        }

        public async Task<SaveResult<Business.Models.Folder.Folder>> Handle(CreateFolderRequest message)
        {
            return await _repo.SaveAsync(message.Folder);
        }
    }
}
