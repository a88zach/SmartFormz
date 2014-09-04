using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SmartFormz.Business.Models.Security;

namespace SmartFormz.Business.DataInterfaces
{
    public interface IUserRepository
    {
        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SmartFormzUser> manager, SmartFormzUser user);
    }
}
