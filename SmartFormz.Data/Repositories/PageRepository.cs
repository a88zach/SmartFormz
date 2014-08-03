using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.Models.Form;
using SmartFormz.Business.ResultModels;

namespace SmartFormz.Data.Repositories
{
    public class PageRepository : BaseRepository<Page, long>, IPageRepository
    {

    }
}
