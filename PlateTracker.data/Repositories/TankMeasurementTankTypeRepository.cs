using PlateTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;
using PlateTracker.Utilities;

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

        public IEnumerable<TankType> GetTankTypesByLineId(int lineID)
        {
            var result = from ltt in _context.LineTankTypes
                         join tt in _context.TankTypes on ltt.TankTypeId equals tt.TankTypeId
                         where ltt.LineId == lineID
                         select tt;
            return result.ToList();
        }
        public IEnumerable<TankType> GetTankTypesByLineTypeId(int lineTypeID)
        {
            var result = from ltt in _context.LineTankTypes
                         join tt in _context.TankTypes on ltt.TankTypeId equals tt.TankTypeId
                         where tt.LineTypeId == lineTypeID
                         select tt;
            return result.ToList();
        }
        public TankType AddTankType(TankType TankType)
        {
            var addResult = _context.TankTypes.Add(TankType);
            _context.SaveChanges();
            return addResult.Entity;
        }
        public TankType UpdateTankType(TankType TankTypeToUpdate)
        {
            var currentValue = _context.TankTypes.First(n => n.TankTypeId == TankTypeToUpdate.TankTypeId);
            TankTypeToUpdate.CreatedBy = currentValue.CreatedBy;
            TankTypeToUpdate.DatetimeCreated = currentValue.DatetimeCreated;
            TankTypeToUpdate.DatetimeUpdated = DateTime.Now;
            TankTypeToUpdate.UpdatedBy = "SYSTEM";
            _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(TankTypeToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var updateResult = _context.TankTypes.Update(TankTypeToUpdate);
            _context.SaveChanges();
            return updateResult.Entity;
        }

        public bool DeleteTankType(int TankTypeId)
        {
            var entityToDelete = _context.TankTypes.Find(TankTypeId);

            try
            {
                if (entityToDelete != null)
                {
                    _context.TankTypes.Remove(entityToDelete);
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
