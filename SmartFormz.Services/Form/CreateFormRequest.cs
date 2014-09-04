using System.Threading.Tasks;
using MediatR;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.ResultModels;

namespace SmartFormz.Services.Form
{
    public class CreateFormRequest : IAsyncRequest<SaveResult<Business.Models.Form.Form>>
    {
        public Business.Models.Form.Form Form { get; set; }
    }

    public class CreateFormRequestHandler : IAsyncRequestHandler<CreateFormRequest, SaveResult<Business.Models.Form.Form>>
    {
        private readonly IFormRepository _repo;

        public CreateFormRequestHandler(IFormRepository repo)
        {
            _repo = repo;
        }

        public async Task<SaveResult<Business.Models.Form.Form>> Handle(CreateFormRequest message)
        {
            return await _repo.SaveAsync(message.Form);
        }
    }

}
