using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartFormz.Business.Models.Form.Interfaces;

namespace SmartFormz.Business.Models.Base
{
    public abstract class BaseModel : IGenerateDates
    {
        [NotMapped]
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
