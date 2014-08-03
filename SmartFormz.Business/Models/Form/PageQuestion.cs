using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFormz.Business.Models.Form
{
    [Table("PageQuestion")]
    public class PageQuestion
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Page")]
        public long PageId { get; set; }
        public Page Page { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Question")]
        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
