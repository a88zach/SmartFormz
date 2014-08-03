using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.Models.Form;

namespace SmartFormz.Data.Repositories
{
    public class QuestionRepository : BaseRepository<Question, long>, IQuestionRepository
    {
    }
}
