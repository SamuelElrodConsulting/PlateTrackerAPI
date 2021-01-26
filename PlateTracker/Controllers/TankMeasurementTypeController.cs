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
    public class TankMeasurementTypeController : ControllerBase
    {
        private readonly ILogger<TankMeasurementTypeController> _logger;
        private TankMeasurementTypeService _tankMeasurementNominalService;

        public TankMeasurementTypeController(ILogger<TankMeasurementTypeController> logger)
        {
            _logger = logger;
            _tankMeasurementNominalService = new TankMeasurementTypeService(logger);
        }

        [HttpGet]
        public IEnumerable<TankMeasurementTypeVM> Get()
        {
            return _tankMeasurementNominalService.GetTankMeasurementTypes();
        }
    }
}
