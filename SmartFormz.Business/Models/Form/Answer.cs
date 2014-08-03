using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartFormz.Business.Models.Base;

namespace SmartFormz.Business.Models.Form
{
    [Table("Answer")]
    public class Answer : BaseModel
    {
        [Key]
        public long AnswerId
        {
            get { return Id; }
            set { Id = value; }
        }

        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
