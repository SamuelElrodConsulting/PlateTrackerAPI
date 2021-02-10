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
    public class LineTankTypeController
    {
        private readonly ILogger<LineTankTypeController> _logger;
        private LineTankTypeService _lineTypeService;

        public LineTankTypeController(
            LineTankTypeService lineTankTypeService,
            ILogger<LineTankTypeController> logger)
        {
            _logger = logger;
            _lineTypeService = lineTankTypeService;
        }

        [HttpGet]
        public IEnumerable<LineTankTypeVM> Get()
        {
            return _lineTypeService.GetLineTankTypes();
        }

        [HttpGet]
        [Route("{lineId}")]
        public IEnumerable<LineTankTypeVM> Get(int lineId)
        {
            return _lineTypeService.GetLineTankTypes().Where(l => l.LineId == lineId);

        }
        [HttpPost]
        public LineTankTypeVM Post(LineTankTypeVM newLine)
        {
            var result = _lineTypeService.AddLineTankType(newLine);
            return result;
        }
        [HttpPut]
        public LineTankTypeVM Put(LineTankTypeVM updateLine)
        {
            var result = _lineTypeService.UpdateLineTankType(updateLine);
            return result;
        }
    }
}
