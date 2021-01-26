using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.ViewModels
{
    public class TankMeasurementTankTypeVM
    {
        public int TankMeasurementTankTypeId { get; set; }
        public string TankMeasurementTankTypeName { get; set; }
        public string TankMeasurementTankTypeDescription { get; set; }
        public int LineTypeId { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
