using System;

namespace PlateTracker.ViewModels
{
    public class TankMeasurementNominalVM
    {
        public int TankMeasurementNominalId { get; set; }
        public int TankTypeId { get; set; }
        public string TankTypeName { get; set; }
        public int TankMeasurementTypeId { get; set; }
        public string TankMeasurementTypeName { get; set; }
        public int LowNominalValue { get; set; }
        public int IdealNominalValue { get; set; }
        public int HighNominalValue { get; set; }
        public int MinimumTestingFrequencyDays { get; set; }
        public int IdealTestingFrequencyDays { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DatetimeUpdated { get; set; }
        public string UOM { get; set; }
    }
}
