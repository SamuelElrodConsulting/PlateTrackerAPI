using System;
using System.Collections.Generic;

#nullable disable

namespace PlateTracker.data.Models
{
    public partial class TankType
    {
        public TankType()
        {
            LineTankTypes = new HashSet<LineTankType>();
            TankMeasurementNominals = new HashSet<TankMeasurementNominal>();
        }

        public int TankTypeId { get; set; }
        public string TankTypeName { get; set; }
        public string TankTypeDescription { get; set; }
        public int LineTypeId { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual LineType LineType { get; set; }
        public virtual ICollection<LineTankType> LineTankTypes { get; set; }
        public virtual ICollection<TankMeasurementNominal> TankMeasurementNominals { get; set; }
    }
}
