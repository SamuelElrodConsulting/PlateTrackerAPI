using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.ViewModels
{
    public class LineVM
    {
        public int LineId { get; set; }
        public string LineName { get; set; }
        public string LineDescription { get; set; }
        public int LineTypeId { get; set; }
        public string LineTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DatetimeUpdated { get; set; }
    }
}
