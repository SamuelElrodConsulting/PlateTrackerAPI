using PlateTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;
using PlateTracker.Utilities;

namespace PlateTracker.data.Repositories
{
    public class TankMeasurementTypesRepository
    {
        TechnicalPlatingContext _context;
        ILogger _logger;
        public TankMeasurementTypesRepository(TechnicalPlatingContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<TankMeasurementType> GetTankMeasurementTypes()
        {
            return _context.TankMeasurementTypes.ToList();
        }

        public TankMeasurementType AddTankMeasurementType(TankMeasurementType tankMeasurementType)
        {
            try
            {
                var result = _context.TankMeasurementTypes.Add(tankMeasurementType);
                return result.Entity;
            } catch (Exception ex)
            {
               _logger.LogError(Utility.FlattException(ex));
                return null;
            }
        }

        public TankMeasurementType UpdateTankMeasurementType(TankMeasurementType tankMeasurementType)
        {
            try
            {
                var result = _context.TankMeasurementTypes.Update(tankMeasurementType);
                return result.Entity;
            }
            catch (Exception ex)
            {
               _logger.LogError(Utility.FlattException(ex));
                return null;
            }
        }

        public bool DeleteTankMeasurementType(int tankMeasurementTypeID)
        {
            var entityToDelete = _context.TankMeasurementTypes.Find(tankMeasurementTypeID);

            try
            {
                if (entityToDelete != null)
                {
                    _context.TankMeasurementTypes.Remove(entityToDelete);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
               _logger.LogError(Utility.FlattException(ex));
                return false;
            }
        }
    }
}
