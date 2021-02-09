using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public Line UpdateLine(Line LineToUpdate)
        {
            var currentValue = _context.Lines.First(n => n.LineId == LineToUpdate.LineId);
            LineToUpdate.CreatedBy = currentValue.CreatedBy;
            LineToUpdate.DatetimeCreated = currentValue.DatetimeCreated;
            LineToUpdate.DatetimeUpdated = DateTime.Now;
            LineToUpdate.UpdatedBy = "SYSTEM";
            _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(LineToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var updateResult = _context.Lines.Update(LineToUpdate);
            _context.SaveChanges();
            return updateResult.Entity;
        }
    }
}
