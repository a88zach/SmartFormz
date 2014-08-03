using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using SmartFormz.Services;
using SmartFormz.Services.Startup;

namespace SmartFormz.Web.Admin
{
    public partial class Startup
    {
        public void InitDbContext()
        {
            new InitializeDatabaseRequest().Execute();
        }
    }
}