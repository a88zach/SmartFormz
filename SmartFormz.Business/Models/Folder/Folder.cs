using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartFormz.Business.Models.Base;

namespace SmartFormz.Business.Models.Folder
{
    [Table("Folder")]
    public class Folder : BaseModel
    {
        [Key]
        public long FolderId
        {
            get { return Id; }
            set { Id = value; }
        }

        public long? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Folder Parent { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
