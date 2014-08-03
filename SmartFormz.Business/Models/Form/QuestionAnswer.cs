using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFormz.Business.Models.Form
{
    [Table("QuestionAnswer")]
    public class QuestionAnswer
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Question")]
        public long QuestionId { get; set; }
        public Question Question { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Answer")]
        public long AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
