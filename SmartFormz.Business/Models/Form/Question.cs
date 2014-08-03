using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartFormz.Business.Models.Base;

namespace SmartFormz.Business.Models.Form
{
    [Table("Question")]
    public class Question : BaseModel
    {
        [Key]
        public long QuestionId
        {
            get { return Id; }
            set { Id = value; }
        }

        public virtual ICollection<PageQuestion> PageQuestions { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
