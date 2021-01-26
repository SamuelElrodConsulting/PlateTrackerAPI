using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.ViewModels
{
    public class TankMeasurementTypeVM
    {
        public int TankMeasurementTypeId { get; set; }
        public string TankMeasurementTypeName { get; set; }
        public string TankMeasurementTypeDescription { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Uom { get; set; }

    }
}
