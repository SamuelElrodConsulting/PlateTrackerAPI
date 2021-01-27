using PlateTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PlateTracker.data.Repositories
{
    public class TankMeasurementTankTypeRepository
    {
        TechnicalPlatingContext _context;
        ILogger<TankMeasurementTankTypeRepository> _logger;
        public TankMeasurementTankTypeRepository(TechnicalPlatingContext context, ILogger<TankMeasurementTankTypeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<TankMeasurementTankType> GetTankMeasurementTankTypes()
        {
            return _context.TankMeasurementTankTypes.ToList();
        }
    }
}
