using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.ResultModels;
using SmartFormz.Data.Repositories;

namespace SmartFormz.Services.Form
{
    public class SaveFormMessage : IMessage
    {
        public Business.Models.Form.Form Form { get; set; }
    }
    public class SaveFormRequest : IAsyncRequest<SaveFormMessage, SaveResult<Business.Models.Form.Form>>
    {
        public SaveFormMessage Message { get; set; }
        private IFormRepository _repo;

        public SaveFormRequest()
        {
            Message = new SaveFormMessage();
            _repo = new FormRepository();
        }

        public async Task<SaveResult<Business.Models.Form.Form>> Execute()
        {
            return await _repo.SaveAsync(Message.Form);
        }



    }
}
