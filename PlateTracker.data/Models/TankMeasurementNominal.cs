using System;
using System.Collections.Generic;

#nullable disable

namespace PlateTracker.data.Models
{
    public partial class TankMeasurementNominal
    {
        public int TankMeasurementNominalId { get; set; }
        public int TankTypeId { get; set; }
        public int TankMeasurementTypeId { get; set; }
        public int LowNominalValue { get; set; }
        public int IdealNominalValue { get; set; }
        public int HighNominalValue { get; set; }
        public int MinimumTestingFrequencyDays { get; set; }
        public int IdealTestingFrequencyDays { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DatetimeUpdated { get; set; }

        public virtual TankMeasurementType TankMeasurementType { get; set; }
        public virtual TankType TankType { get; set; }
    }
}
