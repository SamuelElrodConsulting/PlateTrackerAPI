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
        ILogger<TankMeasurementTypesRepository> _logger;
        public TankMeasurementTypesRepository(TechnicalPlatingContext context, ILogger<TankMeasurementTypesRepository> logger)
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
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(Utility.FlattException(ex));
                return null;
            }
        }

        public TankMeasurementType UpdateTankMeasurementType(TankMeasurementType tankMeasurementTypeToUpdate)
        {
            try
            {
                var currentValue = _context.TankMeasurementTypes.First(t => t.TankMeasurementTypeId == tankMeasurementTypeToUpdate.TankMeasurementTypeId);
                tankMeasurementTypeToUpdate.CreatedBy = currentValue.CreatedBy;
                tankMeasurementTypeToUpdate.DatetimeCreated = currentValue.DatetimeCreated;
                tankMeasurementTypeToUpdate.DatetimeUpdated = DateTime.Now;
                tankMeasurementTypeToUpdate.UpdatedBy = "SYSTEM";

                _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                _context.Entry(tankMeasurementTypeToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                var result = _context.TankMeasurementTypes.Update(tankMeasurementTypeToUpdate);
                _context.SaveChanges();
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
                    _context.SaveChanges();
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
