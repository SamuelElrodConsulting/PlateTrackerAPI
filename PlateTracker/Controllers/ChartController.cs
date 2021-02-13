using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlateTracker.Services;
using PlateTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChartController
    {
        private readonly ILogger<ChartController> _logger;
        private ChartService _chartService;

        public ChartController(
            ChartService chartService,
            ILogger<ChartController> logger)
        {
            _logger = logger;
            _chartService = chartService;
        }

        [HttpGet]
        [Route("{TankTypeId}/{tankMeasurementTypeId}")]

        public ChartVM Get(int tankTypeId, int tankMeasurementTypeId)
        {
            return _chartService.GetChartInfoByTankMeasurementType(tankTypeId, tankMeasurementTypeId);
        }
    }
}
