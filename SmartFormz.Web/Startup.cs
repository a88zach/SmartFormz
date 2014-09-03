using Microsoft.Owin;
using Owin;
using SmartFormz.Web;

[assembly: OwinStartup(typeof(SmartFormz.Web.Startup))]
namespace SmartFormz.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
