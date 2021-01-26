using System;
using System.Collections.Generic;

#nullable disable

namespace PlateTracker.data.Models
{
    public partial class TankMeasurementType
    {
        public TankMeasurementType()
        {
            TankMeasurementNominals = new HashSet<TankMeasurementNominal>();
            TankMeasurements = new HashSet<TankMeasurement>();
        }

        public int TankMeasurementTypeId { get; set; }
        public string TankMeasurementTypeName { get; set; }
        public string TankMeasurementTypeDescription { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Uom { get; set; }

        public virtual ICollection<TankMeasurementNominal> TankMeasurementNominals { get; set; }
        public virtual ICollection<TankMeasurement> TankMeasurements { get; set; }
    }
}
