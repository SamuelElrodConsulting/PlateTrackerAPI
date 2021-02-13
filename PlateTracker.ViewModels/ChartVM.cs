using System;
using System.Collections.Generic;
using System.Text;

namespace PlateTracker.ViewModels
{
    public class ChartVM
    {
        public DateTime ChartStartDate { get; set; }
        public DateTime ChartEndDate { get; set; }
        public Decimal HighValue { get; set; }
        public Decimal LowValue { get; set; }
        public Decimal IdealValue { get; set; }
    }
}
