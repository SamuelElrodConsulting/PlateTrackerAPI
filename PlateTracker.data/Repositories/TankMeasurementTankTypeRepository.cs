using PlateTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace PlateTracker.data.Repositories
{
    public class TankTypeRepository
    {
        TechnicalPlatingContext _context;
        ILogger<TankTypeRepository> _logger;
        public TankTypeRepository(TechnicalPlatingContext context, ILogger<TankTypeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<TankType> GetTankTypes()
        {
            return _context.TankTypes.ToList();
        }
    }
}
