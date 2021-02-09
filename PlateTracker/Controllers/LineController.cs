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
    public class LineController : ControllerBase
    {
        private readonly ILogger<LineController> _logger;
        private LineService _lineService;

        public LineController(
            LineService lineService,
            ILogger<LineController> logger)
        {
            _logger = logger;
            _lineService = lineService;
        }

        [HttpGet]
        public IEnumerable<LineVM> Get()
        {
            return _lineService.GetLines();
        }
        [HttpPost]
        public LineVM Post(LineVM newLine)
        {
            var result = _lineService.AddLine(newLine);
            return result;
        }
        [HttpPut]
        public LineVM Put(LineVM updateLine)
        {
            var result = _lineService.UpdateLine(updateLine);
            return result;
        }

        [HttpDelete("{lineId}")]
        public bool Delete(int lineId)
        {
            var result = _lineService.DeleteLine(lineId);
            return result;
        }
    }
}
