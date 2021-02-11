using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.data.Models;
using Microsoft.Extensions.Logging;
using PlateTracker.Utilities;

namespace PlateTracker.data.Repositories
{
    public class TankMeasurementNominalRepository
    {
        TechnicalPlatingContext _context;
        ILogger<TankMeasurementNominalRepository> _logger;
        public TankMeasurementNominalRepository(TechnicalPlatingContext context, ILogger<TankMeasurementNominalRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<TankMeasurementNominal> GetTankMeasurementNominals()
        {
            return _context.TankMeasurementNominals.ToList();
        }

        public TankMeasurementNominal GetTankMeasurementNominal(int tankTypeId, int tankMeasurementTypeId)
        {
            var value = _context.TankMeasurementNominals.FirstOrDefault(n =>
               n.TankMeasurementTypeId == tankMeasurementTypeId &&
               n.TankTypeId == tankTypeId);

            return value;
        }
        public TankMeasurementNominal AddTankMeasurementNominal(TankMeasurementNominal nominalToAdd)
        {
            var addResult = _context.TankMeasurementNominals.Add(nominalToAdd);
            _context.SaveChanges();
            return addResult.Entity;
        }
        public TankMeasurementNominal UpdateTankMeasurementNominal(TankMeasurementNominal nominalToUpdate)
        {
            var currentValue = _context.TankMeasurementNominals.First(n => n.TankMeasurementNominalId == nominalToUpdate.TankMeasurementNominalId);
            nominalToUpdate.CreatedBy = currentValue.CreatedBy;
            nominalToUpdate.DatetimeCreated = currentValue.DatetimeCreated;
            nominalToUpdate.DatetimeUpdated = DateTime.Now;
            nominalToUpdate.UpdatedBy = "SYSTEM";
            _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(nominalToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var updateResult = _context.TankMeasurementNominals.Update(nominalToUpdate);
            _context.SaveChanges();
            return updateResult.Entity;
        }

        public bool DeleteNominal(int nominalId)
        {
            var entityToDelete = _context.TankMeasurementNominals.Find(nominalId);

            try
            {
                if (entityToDelete != null)
                {
                    _context.TankMeasurementNominals.Remove(entityToDelete);
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
