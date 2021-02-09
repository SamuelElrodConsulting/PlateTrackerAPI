using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlateTracker.Utilities;

namespace PlateTracker.data.Repositories
{
    public class LineRepository
    {
        TechnicalPlatingContext _context;
        ILogger<LineRepository> _logger;
        public LineRepository(TechnicalPlatingContext context, ILogger<LineRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Line> GetLines()
        {
            return _context.Lines.ToList();
        }

        public Line AddLine(Line Line)
        {
            var addResult = _context.Lines.Add(Line);
            _context.SaveChanges();
            return addResult.Entity;
        }
        public Line UpdateLine(Line lineToUpdate)
        {
            var currentValue = _context.Lines.First(n => n.LineId == lineToUpdate.LineId);
            lineToUpdate.CreatedBy = currentValue.CreatedBy;
            lineToUpdate.DatetimeCreated = currentValue.DatetimeCreated;
            lineToUpdate.DatetimeUpdated = DateTime.Now;
            lineToUpdate.UpdatedBy = "SYSTEM";
            _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(lineToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var updateResult = _context.Lines.Update(lineToUpdate);
            _context.SaveChanges();
            return updateResult.Entity;
        }

        public bool DeleteLine(int lineId)
        {
            var entityToDelete = _context.Lines.Find(lineId);

            try
            {
                if (entityToDelete != null)
                {
                    _context.Lines.Remove(entityToDelete);
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
