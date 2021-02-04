using System;
using System.Collections.Generic;

#nullable disable

namespace PlateTracker.data.Models
{
    public partial class Line
    {
        public Line()
        {
            LineTankTypes = new HashSet<LineTankType>();
        }

        public int LineId { get; set; }
        public string LineName { get; set; }
        public string LineDescription { get; set; }
        public int LineTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DatetimeUpdated { get; set; }

        public virtual LineType LineType { get; set; }
        public virtual ICollection<LineTankType> LineTankTypes { get; set; }
    }
}
