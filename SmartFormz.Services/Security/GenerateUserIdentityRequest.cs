using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.Identity;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.Models.Security;

namespace SmartFormz.Services.Security
{
    public class GenerateUserIdentityRequest : IAsyncRequest<ClaimsIdentity>
    {
        public UserManager<SmartFormzUser> Manager { get; set; }
        public SmartFormzUser User { get; set; }
    }

    public class GenerateUserIdentityRequestHandler : IAsyncRequestHandler<GenerateUserIdentityRequest, ClaimsIdentity>
    {
        private readonly IUserRepository _repo;

        public GenerateUserIdentityRequestHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<ClaimsIdentity> Handle(GenerateUserIdentityRequest message)
        {
            return  _repo.GenerateUserIdentityAsync(message.Manager, message.User);
        }
    }
}
