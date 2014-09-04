using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.Models.Security;

namespace SmartFormz.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SmartFormzUser> manager, SmartFormzUser user)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
