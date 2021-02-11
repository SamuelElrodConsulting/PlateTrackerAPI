using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.ViewModels
{
    public class TankMeasurementVM
    {
        public long TankMeasurementId { get; set; }
        public int TankMeasurementTypeId { get; set; }
        public string TankeMeasurementTypeName { get; set; }
        public int LineTankTypeId { get; set; }
        public string LineName { get; set; }
        public int LineID { get; set; }
        public string TankTypeName { get; set; }
        public string EmployeeName { get; set; }

        public int TankTypeId { get; set; }
        public string TankMeasurementDescription { get; set; }
        public decimal Value { get; set; }
        public string Notes { get; set; }
        public int TankMeasurementEmployeeId { get; set; }
        public DateTime TankMeasurementDatetime { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string UOM { get; set; }
        public bool NominalExists { get; set; }
        public int LowNominalValue { get; set; }
        public int IdealNominalValue { get; set; }
        public int HighNominalValue { get; set; }
        public int MinimumTestingFrequencyDays { get; set; }
        public int IdealTestingFrequencyDays { get; set; }
        public bool OutsideNominal { get; set; }

    }
}
