using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.Models.Form;
using SmartFormz.Business.ResultModels;

namespace SmartFormz.Data.Repositories
{
    public class FormRepository : BaseRepository<Form, long>, IFormRepository
    {

    }
}
