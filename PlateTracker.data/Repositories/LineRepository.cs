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
    }
}
