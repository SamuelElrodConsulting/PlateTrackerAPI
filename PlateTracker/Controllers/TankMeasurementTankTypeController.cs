using Microsoft.AspNetCore.Http;
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
    public class TankMeasurementTankTypeController : ControllerBase
    {
        private readonly ILogger<TankMeasurementTankTypeController> _logger;
        private TankMeasurementTankTypeService _tankMeasurementTankType;

        public TankMeasurementTankTypeController(ILogger<TankMeasurementTankTypeController> logger)
        {
            _logger = logger;
            _tankMeasurementTankType = new TankMeasurementTankTypeService(logger);
        }

        [HttpGet]
        public IEnumerable<TankMeasurementTankTypeVM> Get()
        {
            return _tankMeasurementTankType.GetTankMeasurementTankTypes();
        }
    }
}
