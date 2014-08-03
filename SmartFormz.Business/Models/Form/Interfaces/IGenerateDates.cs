using System;

namespace SmartFormz.Business.Models.Form.Interfaces
{
    public interface IGenerateDates
    {
        DateTime CreatedDate { get; set; }
        DateTime LastUpdatedDate { get; set; }
    }
}
