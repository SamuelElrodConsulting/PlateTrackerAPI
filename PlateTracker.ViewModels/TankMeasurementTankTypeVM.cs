using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.ViewModels
{
    public class TankTypeVM
    {
        public int TankTypeId { get; set; }
        public string TankTypeName { get; set; }
        public string TankTypeDescription { get; set; }
        public int LineTypeId { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
