using PlateTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.Utilities;
using Microsoft.Extensions.Logging;

namespace PlateTracker.data.Repositories
{
    public class TankMeasurementRepository
    {
        TechnicalPlatingContext _context;
        ILogger<TankMeasurementRepository> _logger;

        public TankMeasurementRepository(TechnicalPlatingContext context, ILogger<TankMeasurementRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<TankMeasurement> GetTankMeasurements()
        {
            return _context.TankMeasurements.ToList();
        }


        public TankMeasurement AddTankMeasurement(TankMeasurement tankMeasurement)
        {
            try
            {
                var result = _context.TankMeasurements.Add(tankMeasurement);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(Utility.FlattException(ex));
                return null;
            }
        }


        public TankMeasurement UpdateTankMeasurement(TankMeasurement tankMeasurement)
        {
            try
            {
                var currentValue = _context.TankMeasurements.First(n => n.TankMeasurementId == tankMeasurement.TankMeasurementId);
                tankMeasurement.CreatedBy = currentValue.CreatedBy;
                tankMeasurement.DatetimeCreated = currentValue.DatetimeCreated;
                tankMeasurement.DatetimeUpdated = DateTime.Now;
                tankMeasurement.UpdatedBy = "SYSTEM";
                tankMeasurement.TankMeasurementDatetime = currentValue.TankMeasurementDatetime;
                _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                _context.Entry(tankMeasurement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var updateResult = _context.TankMeasurements.Update(tankMeasurement);


                _context.SaveChanges();
                return updateResult.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(Utility.FlattException(ex));
                return null;
            }
        }

        public bool DeleteTankMeasurement(int tankMeasurementID)
        {
            var entityToDelete = _context.TankMeasurements.Find(Convert.ToInt64(tankMeasurementID));

            try
            {
                if (entityToDelete != null)
                {
                    _context.TankMeasurements.Remove(entityToDelete);
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
