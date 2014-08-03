using System.Data.Entity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartFormz.Web.Admin.Startup))]
namespace SmartFormz.Web.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitDbContext();
        }
    }
}
