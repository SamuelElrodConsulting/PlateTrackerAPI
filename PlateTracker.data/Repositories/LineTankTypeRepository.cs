using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.data.Models;
using Microsoft.Extensions.Logging;

namespace PlateTracker.data.Repositories
{
    public class LineTankTypeRepository
    {
        TechnicalPlatingContext _context;
        ILogger<LineTankTypeRepository> _logger;

        public LineTankTypeRepository(TechnicalPlatingContext context, ILogger<LineTankTypeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<LineTankType> GetLineTankTypes()
        {
            return _context.LineTankTypes.ToList();
        }

        public LineTankType GetLineTankType(int lineId, int tankTypeId)
        {
            return _context.LineTankTypes.FirstOrDefault(l =>
            
                l.LineId == lineId
                && l.TankTypeId == tankTypeId
            );
        }

        public LineTankType AddLineTankType(LineTankType lineTankType)
        {
            var addResult = _context.LineTankTypes.Add(lineTankType);
            _context.SaveChanges();
            return addResult.Entity;
        }
        public LineTankType UpdateLineTankType(LineTankType lineTankTypeToUpdate)
        {
            var currentValue = _context.LineTankTypes.First(n => n.LineTankTypeId == lineTankTypeToUpdate.LineTankTypeId);
            lineTankTypeToUpdate.CreatedBy = currentValue.CreatedBy;
            lineTankTypeToUpdate.DatetimeCreated = currentValue.DatetimeCreated;
            lineTankTypeToUpdate.DatetimeUpdated = DateTime.Now;
            lineTankTypeToUpdate.UpdatedBy = "SYSTEM";
            _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(lineTankTypeToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var updateResult = _context.LineTankTypes.Update(lineTankTypeToUpdate);
            _context.SaveChanges();
            return updateResult.Entity;
        }
    }
}
