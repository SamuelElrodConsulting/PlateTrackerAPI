using System;
using System.Collections.Generic;

#nullable disable

namespace PlateTracker.data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            TankMeasurements = new HashSet<TankMeasurement>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string BuddyPunchId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DatetimeCreated { get; set; }

        public virtual ICollection<TankMeasurement> TankMeasurements { get; set; }
    }
}
