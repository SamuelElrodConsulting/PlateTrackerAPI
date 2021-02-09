using Microsoft.Extensions.Logging;
using PlateTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlateTracker.data.Repositories
{
    public class LineTypeRepository
    {
        TechnicalPlatingContext _context;
        ILogger<LineTypeRepository> _logger;

        public LineTypeRepository(TechnicalPlatingContext context, ILogger<LineTypeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<LineType> GetLineTypes()
        {
            return _context.LineTypes.ToList();
        }

        public LineType AddLineType(LineType lineType)
        {
            var addResult = _context.LineTypes.Add(lineType);
            _context.SaveChanges();
            return addResult.Entity;
        }
        public LineType UpdateLineType(LineType lineTypeToUpdate)
        {
            var currentValue = _context.LineTypes.First(n => n.LineTypeId == lineTypeToUpdate.LineTypeId);
            lineTypeToUpdate.CreatedBy = currentValue.CreatedBy;
            lineTypeToUpdate.DatetimeCreated = currentValue.DatetimeCreated;
            lineTypeToUpdate.DatetimeUpdated = DateTime.Now;
            lineTypeToUpdate.UpdatedBy = "SYSTEM";
            _context.Entry(currentValue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(lineTypeToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var updateResult = _context.LineTypes.Update(lineTypeToUpdate);
            _context.SaveChanges();
            return updateResult.Entity;
        }
    }
}
