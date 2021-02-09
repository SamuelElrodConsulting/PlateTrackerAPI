using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.ViewModels
{
    public class LineTankTypeVM
    {
        public int LineTankTypeId { get; set; }
        public int LineId { get; set; }
        public int TankTypeId { get; set; }
        public int Sequence { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }

    }
}
