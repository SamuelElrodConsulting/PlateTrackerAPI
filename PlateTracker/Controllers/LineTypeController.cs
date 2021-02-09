using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PlateTracker.Services;
using Microsoft.AspNetCore.Mvc;
using PlateTracker.ViewModels;

namespace PlateTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LineTypeController
    {
        private readonly ILogger<LineTypeController> _logger;
        private LineTypeService _lineTypeService;

        public LineTypeController(
            LineTypeService lineTypeSErvice,
            ILogger<LineTypeController> logger)
        {
            _logger = logger;
            _lineTypeService = lineTypeSErvice;
        }

        [HttpGet]
        public IEnumerable<LineTypeVM> Get()
        {
            return _lineTypeService.GetLineTypes();
        }
        [HttpPost]
        public LineTypeVM Post(LineTypeVM newLine)
        {
            var result = _lineTypeService.AddLineType(newLine);
            return result;
        }
        [HttpPut]
        public LineTypeVM Put(LineTypeVM updateLine)
        {
            var result = _lineTypeService.UpdateLineType(updateLine);
            return result;
        }
    }
}
