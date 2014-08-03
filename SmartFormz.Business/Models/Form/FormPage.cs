using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFormz.Business.Models.Form
{
    [Table("FormPage")]
    public class FormPage
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Form")]
        public long FormId { get; set; }
        public Form Form { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Page")]
        public long PageId { get; set; }
        public Page Page { get; set; }
    }
}
