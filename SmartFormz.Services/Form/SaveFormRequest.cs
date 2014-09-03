using System.Threading.Tasks;
using MediatR;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.ResultModels;

namespace SmartFormz.Services.Form
{
    public class SaveFormRequest : IAsyncRequest<SaveResult<Business.Models.Form.Form>>
    {
        public Business.Models.Form.Form Form { get; set; }
    }

    public class SaveFormRequestHandler : IAsyncRequestHandler<SaveFormRequest, SaveResult<Business.Models.Form.Form>>
    {
        private readonly IFormRepository _repo;

        public SaveFormRequestHandler(IFormRepository repo)
        {
            _repo = repo;
        }

        public async Task<SaveResult<Business.Models.Form.Form>> Handle(SaveFormRequest message)
        {
            return await _repo.SaveAsync(message.Form);
        }
    }

}
