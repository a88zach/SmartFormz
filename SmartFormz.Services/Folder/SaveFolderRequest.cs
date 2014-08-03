using System.Threading.Tasks;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.ResultModels;
using SmartFormz.Data.Repositories;

namespace SmartFormz.Services.Folder
{
    public class SaveFolderMessage : IMessage
    {
        public Business.Models.Folder.Folder Folder { get; set; }
    }

    public class SaveFolderRequest : IAsyncRequest<SaveFolderMessage, SaveResult<Business.Models.Folder.Folder>>
    {
        public SaveFolderMessage Message { get; set; }
        private IFolderRepository _repo;

        public SaveFolderRequest()
        {
            Message = new SaveFolderMessage();
            _repo = new FolderRepository();
        }

        public async Task<SaveResult<Business.Models.Folder.Folder>> Execute()
        {
            return await _repo.SaveAsync(Message.Folder);
        }


    }
}
