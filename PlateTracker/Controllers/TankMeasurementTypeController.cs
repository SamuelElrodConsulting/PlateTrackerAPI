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
        private TankMeasurementTypeService _tankMeasurementTypeService;

        public TankMeasurementTypeController(
            TankMeasurementTypeService tankMeasurementTypeService,
            ILogger<TankMeasurementTypeController> logger)
        {
            _logger = logger;
            _tankMeasurementTypeService = tankMeasurementTypeService;
        }

        [HttpGet]
        public IEnumerable<TankMeasurementTypeVM> Get()
        {
            return _tankMeasurementTypeService.GetTankMeasurementTypes();
        }

        [HttpPost]
        public TankMeasurementTypeVM Post (TankMeasurementTypeVM tankMeasurementToAdd)
        {
            return _tankMeasurementTypeService.AddTankMeasurementType(tankMeasurementToAdd);
        }

        [HttpPut]
        public TankMeasurementTypeVM Put(TankMeasurementTypeVM tankMeasurementToAdd)
        {
            return _tankMeasurementTypeService.UpdateTankMeasurementType(tankMeasurementToAdd);
        }

        [HttpDelete]
        [Route("{tankMeasurementTypeID}")]
        public bool Delete(int tankMeasurementTypeID)
        {
            return _tankMeasurementTypeService.DeleteTankMeasurementType(tankMeasurementTypeID);
        }
    }
}
