using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartFormz.Business.Models.Base;

namespace SmartFormz.Business.Models.Form
{
    [Table("Page")]
    public class Page : BaseModel
    {
        [Key]
        public long PageId
        {
            get { return Id; }
            set { Id = value; }
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ICollection<FormPage> FormPages { get; set; }
        public virtual ICollection<PageQuestion> PageQuestions { get; set; }


    }
}
