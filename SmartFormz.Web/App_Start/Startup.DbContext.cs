using SmartFormz.Services.Startup;

namespace SmartFormz.Web
{
    public partial class Startup
    {
        public void InitDbContext()
        {
            new InitializeDatabaseRequest().Execute();
        }
    }
}