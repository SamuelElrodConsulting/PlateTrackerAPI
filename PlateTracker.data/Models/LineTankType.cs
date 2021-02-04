using System;
using System.Collections.Generic;

#nullable disable

namespace PlateTracker.data.Models
{
    public partial class LineTankType
    {
        public LineTankType()
        {
            TankMeasurements = new HashSet<TankMeasurement>();
        }

        public int LineTankTypeId { get; set; }
        public int LineId { get; set; }
        public int TankTypeId { get; set; }
        public int Sequence { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeUpdated { get; set; }

        public virtual Line Line { get; set; }
        public virtual TankType TankType { get; set; }
        public virtual ICollection<TankMeasurement> TankMeasurements { get; set; }
    }
}
