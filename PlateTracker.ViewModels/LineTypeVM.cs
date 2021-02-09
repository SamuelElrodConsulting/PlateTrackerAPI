using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.ViewModels
{
    public class LineTypeVM
    {
        public int LineTypeId { get; set; }
        public string LineTypeName { get; set; }
        public string LineTypeDescription { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
